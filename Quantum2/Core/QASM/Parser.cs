using System;
using System.Collections.Generic;

namespace Quantum2.Core.QASM
{
    public class Parser
    {
        private LA _lexer;

        private ErrorHandler _errorHandler;

        private Dictionary<string, int> _types;
        private Dictionary<string, int> _wildcards;

        private Dictionary<int, Instr> _instructions;

        private Dictionary<int, Operator> _operations;

        private int _pointer;

        private AST _resultAST;

        public LA Lexer
        {
            get
            {
                return _lexer;
            }
        }

        public ErrorHandler ErrorHandler
        {
            get
            {
                return _errorHandler;
            }
        }

        public Dictionary<int, Instr> Instructions
        {
            get
            {
                return _instructions;
            }
            set
            {
                _instructions = value;
            }
        }

        public int Pointer
        {
            get
            {
                return _pointer;
            }
        }

        public AST AST
        {
            get
            {
                return _resultAST;
            }
        }

        public Parser()
        {
            _lexer = new LA();

            _types = new Dictionary<string, int>();
            _wildcards = new Dictionary<string, int>();

            //_instructions = new Dictionary<int, Instr>();

            _operations = new Dictionary<int, Operator>();

            _pointer = 1;

            AddType("qreg");
            AddType("reg");

            AddType("qbit");
            AddType("bit");

            AddType("qstate");

            AddType("gate");

            AddType("rule");

            AddType("byte");
            AddType("word");
            AddType("dword");
            AddType("qword");

            AddType("sbyte");
            AddType("sword");
            AddType("sdword");
            AddType("sqword");

            AddType("real4");
            AddType("real8");

            AddType("complex");

            AddType("string");

            AddType("label");

            AddWildcard("["); // 2
            AddWildcard("]"); // 3

            AddWildcard(":"); // 4

            AddWildcard(","); // 5

            AddWildcard("+"); // 6

            AddWildcard("(");
            AddWildcard(")");

            AddWildcard("~");

            AddWildcard("^");

            AddWildcard("-"); // 7

            AddWildcard("*"); // 8
            AddWildcard("/"); // 9

            AddWildcard("="); // 10

            _lexer.Types = _types;
            _lexer.Wildcards = _wildcards;

            _operations.Add(_wildcards["("], new OperatorOpenRoundBracket());

            _operations.Add(_wildcards["+"], new OperatorPlus() );
            _operations.Add(_wildcards["-"], new OperatorMinus() );

            _operations.Add(_wildcards["*"], new OperatorMul());
            _operations.Add(_wildcards["/"], new OperatorDiv());

            _operations.Add(_wildcards["^"], new OperatorDegree());

            _operations.Add(_wildcards["~"], new OperatorUnaryMinus());
        }

        public void AddType(string c)
        {
            int n = _types.Count;

            _types.Add(c, n);
        }

        public void AddWildcard(string c)
        {
            int n = _lexer._idType + 1 + _wildcards.Count;

            _wildcards.Add(c, n);
        }

        public void Parse(string text)
        {
            _resultAST = new AST();

            _lexer.Analyze(text);

            _pointer = 0;

            Token token = Next();

            while(token != null)
            {
                ASTNode astNode = new ASTNode(token);

                if (IsInstruction(token.Type))
                {
                    ParseInstruction(_instructions[token.Type], ref astNode);
                }
                else if (isID(token.Type))
                {
                   ParseID(token);
                }

                _resultAST.AddNode(astNode);

                token = Next();

                _pointer++;
            }
        }

        public void Reset()
        {
            _lexer.Reset();

            _pointer = 1;
        }

        public void AnalyzeText(string text)
        {
            _lexer.Analyze(text);

            //Reset();
        }

        public ASTNode NextASTNode()
        {
            Token token = Next();

            ASTNode astNode = new ASTNode(token);

            if (token == null)
                return astNode;

            if (IsInstruction(token.Type))
            {
                ParseInstruction(_instructions[token.Type], ref astNode);
            }

            _pointer++;

            return astNode;
        }

        private Token Next()
        {
            Token token = _lexer.Next();

            return token;
        }

        private Token NextArgument()
        {
            Token token = Next();

            while (token != null)
            {
                if (IsEnd(token))
                {
                    break;
                }
                else if (token.Type == _wildcards["["])
                {
                    //парсинг адресса
                }
                else if (token.Type == _lexer._idType)
                {
                    Token tok = Next();

                    if (IsEnd(tok))
                    {
                        return token;
                    }
                    else
                    {
                        //error

                        return null;
                    }
                }
                else if(IsRealNumberToken(token) || _operations.ContainsKey(token.Type))
                {
                    return ParseNumber(token);
                }
                else if(token.Type == _lexer._literalType)
                {
                    Token tok = Next();

                    if (IsEnd(tok))
                    {
                        return token;
                    }
                    else
                    {
                        //error

                        return null;
                    }
                }

                token = Next();
            }

            return null;
        }

        private void ParseInstruction(Instr instr, ref ASTNode astNode)
        {
            //Console.WriteLine(instr.CountArgs);

            if(instr.CountArgs == 0)
            {
                Token token = Next();

                if(token == null || token.Type == _lexer._EOL)
                {
                    return;
                }
                else
                {
                    //error
                }
            }

            for(int i = 0; i < instr.CountArgs;i++)
            {
                Token tokenArgument = NextArgument();

                if (tokenArgument != null)
                {
                    if (SemanticParseArgument(tokenArgument, instr.ValidArgs[i]))
                    {
                        astNode.ASTNodes.Add(new ASTNode(tokenArgument));
                    }
                    else
                    {
                        //error
                    }
                }
                else
                {
                    //error
                }
            }
        }

        private Token ParseNumber(in Token inputToken)
        {
            Token tokenNext = inputToken;
            Token lastToken = inputToken;

            Stack<int> operatorStack = new Stack<int>();
            Stack<double> numberStack = new Stack<double>();

            List<int> operatorList = new List<int>();

            int counter = 0;

            int typeResult = 0;
            Point pointResult = null;

            while (tokenNext != null)
            {
                if(IsEnd(tokenNext))
                {
                    break;
                }
                if(IsRealNumberToken(tokenNext))
                {
                    pointResult = tokenNext.PointLiteral;
                    typeResult = _lexer.Literals[tokenNext.PointLiteral].Type;

                    double number = TokenNumberToDoubleNumber(tokenNext);

                    numberStack.Push(number);
                }
                else if(IsOpenRoundBracket(tokenNext))
                {
                    operatorStack.Push(tokenNext.Type);
                }
                else if(IsCloseRoundBracket(tokenNext))
                {
                    while (operatorStack.Count > 0 && operatorStack.Peek() != _wildcards["("])
                        operatorList.Add(operatorStack.Pop());

                    operatorStack.Pop();
                }
                else if(IsOperatorToken(tokenNext))
                {
                    int tokenType = tokenNext.Type;

                    if (tokenType == _wildcards["-"] && (counter == 0 || (counter > 0 && IsOperatorToken(lastToken))))
                    {
                        tokenType = _wildcards["~"];
                    }

                    while (operatorStack.Count > 0 && (GetOperatorPriority(operatorStack.Peek()) >= GetOperatorPriority(tokenType)))
                        operatorList.Add( operatorStack.Pop());

                    operatorStack.Push(tokenType);
                }
                else
                {
                    //error
                }

                counter++;

                lastToken = tokenNext;
                tokenNext = Next();
            }

            foreach(var item in operatorStack)
            {
                operatorList.Add(item);
            }

            for(int i = 0; i < operatorList.Count;i++)
            {
                double result = _operations[operatorList[i]].Execute(numberStack, _errorHandler);

                numberStack.Push(result);
            }

            if(numberStack.Count != 1)
            {
                //error
                return null;
            }

            Literal resultLiteral = CreateLiteralNumber(typeResult,numberStack.Pop());
            _lexer.Literals.Add(pointResult, resultLiteral);

            Token resultToken = new Token(_lexer._literalType,typeResult, pointResult);

            return resultToken;
        }

        private Literal CreateLiteralNumber(int type, double value)
        {
            /*if (type == _types["byte"])
            {
                if (value < 0)
                    return new Literal(type, (SByte)value);

                return new Literal(type, (Byte)(value));
            }
            else if (type == _types["sbyte"])
            {
                return new Literal(type, (SByte)(value));
            }
            else if (type == _types["word"])
            {
                if (value < 0)
                    return new Literal(type, (Int16)value);

                return new Literal(type, (UInt16)(value));
            }
            else if (type == _types["sword"])
            {
                return new Literal(type, (Int16)(value));
            }
            else if (type == _types["dword"])
            {
                if (value < 0)
                    return new Literal(type, (Int32)value);

                return new Literal(type, (UInt32)(value));
            }
            else if (type == _types["sdword"])
            {
                return new Literal(type, (Int32)(value));
            }
            else if (type == _types["qword"])
            {
                if (value < 0)
                    return new Literal(type, (Int64)value);

                return new Literal(type, (UInt64)(value));
            }
            else if (type == _types["sqword"])
            {
                return new Literal(type, (Int64)(value));
            }
            else if (type == _types["real4"])
            {
                return new Literal(type, (float)(value));
            }
            else if (type == _types["real8"])
            {
                return new Literal(type, (double)(value));
            }*/
            
            return new Literal(type, value);
        }

        private double TokenNumberToDoubleNumber(in Token token)
        {
            double value = Convert.ToDouble(_lexer.Literals[token.PointLiteral].Value );

            _lexer.Literals.Remove(token.PointLiteral);

            return value;
        }

        private void ParseID(Token token)
        {
            Token tokenNext = Next();

            if(token == null)
            {
                //error

                return;
            }

            if(tokenNext.Type == _wildcards[":"])
            {
                //ParseLabel(token);
            }
        }

        private bool SemanticParseArgument(Token token, Arg arg)
        {
            for (int i = 0; i < arg.TypeTokens.Length; i++)
            {
                if (token.Type == arg.TypeTokens[i])
                {
                    for (int j = 0; j < arg.TypeArguments.Length; j++)
                    {
                        if (token.TypeValue == arg.TypeArguments[j])
                        {
                            return true;
                        }
                    }

                    return false;
                }
            }

            return false;
        }

        public int GetOperatorPriority(int @operator)
        {
            return _operations[@operator].Priority;
        }

        public bool IsEnd(Token token)
        {
            return token == null || token.Type == _wildcards[","] || token.Type == _lexer._EOL;
        }

        public bool IsOpenRoundBracket(Token token)
        {
            return _wildcards["("] == token.Type;
        }

        public bool IsCloseRoundBracket(Token token)
        {
            return _wildcards[")"] == token.Type;
        }

        public bool IsOperatorToken(Token token)
        {
            return _operations.ContainsKey(token.Type);
        }

        public bool IsRealNumberToken(Token token)
        {
            if(token.Type == _lexer._literalType)
            {
                int typeByte = _types["byte"];
                int typeReal8 = _types["real8"];

                if (_lexer.Literals[token.PointLiteral].Type >= typeByte && _lexer.Literals[token.PointLiteral].Type <= typeReal8)
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsInstruction(int typeToken)
        {
            return typeToken > _wildcards["="];
        }

        public bool isID(int typeToken)
        {
            return typeToken == _lexer._idType;
        }
    }

    public abstract class Operator
    {
        protected int _priority;

        public int Priority
        {
            get
            {
                return _priority;
            }
        }

        protected Operator()
        {
        }

        public virtual double Execute(Stack<double> numbers, ErrorHandler errorHandler)
        {
            return 0;
        }
    }

    public class OperatorOpenRoundBracket : Operator
    {
        public OperatorOpenRoundBracket() : base()
        {
            _priority = 0;
        }
    }

    public class OperatorPlus : Operator
    {
        public OperatorPlus() : base()
        {
            _priority = 1;
        }

        public override double Execute(Stack<double> numbers, ErrorHandler errorHandler)
        {
            if(numbers.Count < 2)
            {
                //error
                return 0;
            }

            double second = numbers.Pop();
            double first = numbers.Pop();

            return first + second;
        }
    }

    public class OperatorMinus : Operator
    {
        public OperatorMinus() : base()
        {
            _priority = 1;
        }

        public override double Execute(Stack<double> numbers, ErrorHandler errorHandler)
        {
            if(numbers.Count < 2)
            {
                //error

                return 0;
            }

            double second = numbers.Pop();
            double first = numbers.Pop();

            return first - second;
        }
    }

    public class OperatorMul : Operator
    {
        public OperatorMul() : base()
        {
            _priority = 2;
        }

        public override double Execute(Stack<double> numbers, ErrorHandler errorHandler)
        {
            if(numbers.Count < 2)
            {
                //error

                return 0;
            }

            double second = numbers.Pop();
            double first = numbers.Pop();

            return first * second;
        }
    }

    public class OperatorDiv : Operator
    { 
        public OperatorDiv() : base()
        {
            _priority = 2;
        }

        public override double Execute(Stack<double> numbers, ErrorHandler errorHandler)
        {
            if (numbers.Count < 2)
            {
                //error

                return 0;
            }

            double second = numbers.Pop();
            double first = numbers.Pop();

            return first / second;
        }
    }

    public class OperatorDegree : Operator
    { 
        public OperatorDegree() : base()
        {
            _priority = 3;
        }
        public override double Execute(Stack<double> numbers, ErrorHandler errorHandler)
        {
            if (numbers.Count < 2)
            {
                //error

                return 0;
            }

            double second = numbers.Pop();
            double first = numbers.Pop();

            return Math.Pow(first, second);
        }
    }

    public class OperatorUnaryMinus : Operator
    {
        public OperatorUnaryMinus() : base() 
        {
            _priority = 4; 
        }
        public override double Execute(Stack<double> numbers, ErrorHandler errorHandler)
        {
            if (numbers.Count < 1)
            {
                return 0;
            }

            double first = numbers.Pop();

            return first * -1;
        }

    }

}
