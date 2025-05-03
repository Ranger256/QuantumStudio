using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Quantum2.Core.QASM
{
    public class Literal
    {
        private int _type;
        private object _value;

        public int Type
        {
            get
            {
                return _type;
            }
        }

        public object Value
        {
            get
            {
                return _value;
            }
        }

        public Literal(int type, object value)
        {
            _type = type;
            _value = value;
        }
    }

    public class LA
    {
        private Preprocessor _preprocessor;

        private Dictionary<string, ID> _idTable;

        private Dictionary<Point, Literal> _literals;

        private Dictionary<string, int> _types;

        private Dictionary<string, int> _wildcards;
        private Dictionary<string, int> _instructions;

        private Stack<int> _stackAddrs;

        private ErrorHandler _errorHandler;

        private int _line;
        private int _part;

        public readonly int _undefinedType = -2;

        public readonly int _EOL = -1;

        public readonly int _literalType = 0;

        public readonly int _idType = 1;

        private bool _b;

        private string _jmpLabelName;
        private bool _jmpForward;

        //private 

        private int _pointer;

        public Dictionary<string, ID> IDTable
        {
            get
            {
                return _idTable;
            }
        }

        public Dictionary<Point, Literal> Literals
        {
            get
            {
                return _literals;
            }
        }

        public Dictionary<string, int> Types
        {
            get
            {
                return _types;
            }
            set
            {
                _types = value;
            }
        }

        public Dictionary<string, int> Wildcards
        {
            get
            {
                return _wildcards;
            }
            set
            {
                _wildcards = value;
            }
        }

        public Dictionary<string, int> Instructions
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

        public ErrorHandler ErrorHandler
        {
            get
            {
                return _errorHandler;
            }
        }

        public LA()
        {
            _preprocessor = new Preprocessor();

            _idTable = new Dictionary<string, ID>();
            _literals = new Dictionary<Point, Literal>();

            _instructions = new Dictionary<string, int>();

            _stackAddrs = new Stack<int>();

            _pointer = 0;

            _errorHandler = new ErrorHandler();

            _line = 0;
            _part = 0;

            _jmpForward = false;
        }

        public void AddInstruction(string c)
        {
            int n = _idType + 1 + _wildcards.Count + 1 + _instructions.Count;

            _instructions.Add(c, n);
        }

        public int GetInstructuon(string c)
        {
            return _instructions[c];
        }

        public void Reset()
        {
            _preprocessor.Reset();

            _idTable.Clear();
            _literals.Clear();

            _pointer = 0;

            _line = 0;
            _part = 0;

            _jmpForward = false;

            Console.WriteLine("RESET_LEXER");
        }

        public void Analyze(string text)
        {
            _preprocessor.Execute(text);

           // Reset();
        }

        //ПРЕДПОЛАГАЕТСЯ ЧТО МЕТКА ПОД ДАННЫМ ИМЕНЕМ ОБЯЗАТЕЛЬНО СУЩЕСТВУЕТ, Я ПОНИМАЮ ЧТО ЭТО ЕБАННЫЙ КОСТЫЛЬ, НО ПО ДРУГОМУ Я НИХУЯ НЕ МОГУ
        public void Jump(string nameLabel)
        {
            int val = (int)_idTable[nameLabel].Value;

            if(val == -1)
            {
                _jmpLabelName = nameLabel;
                _jmpForward = true;
            }
            else
            {
                _part = 0;
                _line = val;

                _b = false;
            }

            //Console.WriteLine(val + "LEX");
        }

        public void Call(string nameLabel)
        {
            _stackAddrs.Push(_line);

            Jump(nameLabel);
        }

        public void Ret()
        {
            if(_stackAddrs.Count == 0)
            {
                //error
            }

            _part = 0;
            _line = _stackAddrs.Pop();

            _b = false;
        }

        public Token Next()
        {

            if (_preprocessor.Parts.Count <= _line)
            {
                return null;
            }

            if (_preprocessor.Parts[_line].Count == 0)
            {
                _part++;

                if (_preprocessor.Parts[_line].Count <= _part)
                {
                    _line++;
                    _part = 0;
                }

                return Next();
            }
            //else if(_preprocessor.Parts[_line][_part] != "$" && _preprocessor.Parts[_line][_part] != "'" && _b)
            else if(_b)
            {
                _b = false;

                _pointer++;

                return new Token(_EOL);
            }

            if (_preprocessor.Parts[_line][_part] == "$")
            {
                if(_part != 0)
                {
                    //error
                }

                ParseLanguageDirective();

                _part = 0;
                _line++;
                //NextPointer();

                return Next();
            }

            if (!_jmpForward)
            {

                if (_preprocessor.Parts[_line][_part] == "'")
                {
                    Point pointToken = new Point(_line, _part);

                    string source = ParseString();

                    _literals.Add(pointToken, new Literal(_types["string"], source));

                    NextPointer();

                    return new Token(_literalType, _types["string"], pointToken);
                }

                string name = _preprocessor.Parts[_line][_part];

                int typeToken = DefineTypeToken(name);

                Token token = null;

                if (typeToken == _undefinedType)
                {
                    //error

                    token = new Token(typeToken);
                }
                else if (typeToken == _literalType)
                {
                    Point pointLiteral = new Point(_line, _part);

                    Literal literal = DefineLiteral(name);

                    _literals.Add(pointLiteral, literal);

                    token = new Token(typeToken, literal.Type, pointLiteral);
                }
                else if (typeToken == _idType)
                {
                    token = new Token(typeToken, _idTable[name].Type, name);
                }
                else
                {
                    token = new Token(typeToken);
                }

                NextPointer();

                return token;
            }
            else
            {
                _part = 0;
                _line++;

                return Next();
            }
        }

        private Literal DefineLiteral(string n)
        {
            if(IsIntegerNumeric(n))
            {
                //переделать под 1, 2, 4, 8 байтные числа
                int value = 0;

                if(!int.TryParse(n, out value))
                {
                    //error

                    return null;
                }

                return new Literal(_types["dword"], value);
            }
            else if(IsFloatNumeric(n))
            {
                double value = 0;

                n = n.Replace(".", ",");

                if(!double.TryParse(n, out value))
                {
                    //error
                    return null;
                }

                return new Literal(_types["real8"], value);
            }
            else if(IsComplexNumeric(n))
            {


                return new Literal(_types["complex"], n);
            }

            return null;
        }

        private int DefineTypeToken(string n)
        {
            if(IsInstruction(n))
            {
                return _instructions[n];
            }
            else if (IsWillcard(n))
            {
                return _wildcards[n];
            }
            else if(IsID(n))
            {
                return _idType;
            }
            else if (IsIntegerNumeric(n))
            {
                return _literalType;
            }
            else if (IsFloatNumeric(n))
            {
                return _literalType;
            }
            else if (IsComplexNumeric(n))
            {
                return _literalType;
            }        

            return _undefinedType;
        }

        private void NextPointer()
        {
            _part++;

            if (_preprocessor.Parts[_line].Count <= _part)
            {
                _line++;
                _part = 0;

                _b = true;
                //Console.WriteLine("GH");
            }
        }

        private void ParseLanguageDirective()
        {
            if(_preprocessor.Parts[_line].Count == 1)
            {
                //error
            }

            _part++;

            switch(_preprocessor.Parts[_line][_part])
            {
                case "defname":
                    {

                        if(_preprocessor.Parts[_line].Count != 5)
                        {
                            //error
                        }

                        _part++;

                        string nameName = _preprocessor.Parts[_line][_part];

                        int typeName = -1;

                        ID id = null;

                        if(IsWillcard(nameName))
                        {    
                            //error
                        }
                        else if(IsInstruction(nameName))
                        {
                            //error
                        }
                        else if(IsID(nameName))
                        {
                            //error
                        }
                        else if(IsIntegerNumeric(nameName))
                        {
                            
                            //error
                        }
                        else if(IsFloatNumeric(nameName))
                        {
                            //Console.WriteLine(c);
                            //errror
                        }
                        else if(IsComplexNumeric(nameName))
                        {
                            //error
                        }
                        else
                        {
                            
                        }

                        _part++;

                        if(_preprocessor.Parts[_line][_part] != ":")
                        {
                            //error
                        }

                        _part++;

                        if(IsType(_preprocessor.Parts[_line][_part]))
                        {
                            typeName = _types[_preprocessor.Parts[_line][_part]];
                        }
                        else
                        {
                            //error
                        }

                        id = new ID(typeName);

                        if(id.Type == (int)STTypes.type_byte || id.Type == (int)STTypes.word || id.Type == (int) STTypes.dword || id.Type == (int)STTypes.qword ||
                            id.Type == (int) STTypes.type_sbyte || id.Type == (int)STTypes.sword || id.Type == (int) STTypes.sdword || id.Type == (int)STTypes.sqword)
                        {
                            id.Value = 0;
                        }

                        if(id.Type == (int)STTypes.real4)
                        {
                            id.Value = (float)0.0;
                        }

                        if(id.Type == (int)STTypes.real8)
                        {
                            id.Value = (double)0.0;
                        }

                        if(id.Type == (int)STTypes.bit)
                        {
                            id.Value = false;
                        }

                        if(id.Type == (int)STTypes.complex)
                        {
                            id.Value = new System.Numerics.Complex(0, 0);
                        }

                        if(id.Type == (int)STTypes.label)
                        {
                            id.Value = -1;
                        }

                        if(!_idTable.ContainsKey(nameName))
                            _idTable.Add(nameName, id);

                        break;
                    }
                case "const":
                    {
                        if (_preprocessor.Parts[_line].Count != 3)
                        {
                            //error
                        }

                        _part++;

                        if(_idTable.ContainsKey(_preprocessor.Parts[_line][_part]))
                        {
                            if (!_idTable[_preprocessor.Parts[_line][_part]].IsCC)
                            {
                                _idTable[_preprocessor.Parts[_line][_part]].IsConst = true;
                            }
                            else
                            {

                            }
                        }
                        else
                        {
                            //error
                        }

                        break;
                    }
                case "unconst":
                    {
                        if (_preprocessor.Parts[_line].Count != 3)
                        {
                            //error
                        }

                        _part++;

                        if (_idTable.ContainsKey(_preprocessor.Parts[_line][_part]))
                        {
                            if (!_idTable[_preprocessor.Parts[_line][_part]].IsCC)
                            {
                                _idTable[_preprocessor.Parts[_line][_part]].IsConst = false;
                            }
                            else
                            {
                                
                            }
                        }
                        else
                        {
                            //error
                        }

                        break;
                    }
                case "label":
                    {
                        if(_preprocessor.Parts[_line].Count != 4)
                        {

                        }

                        _part++;

                        string nameLabel = _preprocessor.Parts[_line][_part];

                        _part++;

                        if(_preprocessor.Parts[_line][_part] != ":")
                        {
                            //error
                        }

                        if(_jmpForward)
                        {
                            if(_jmpLabelName == nameLabel)
                            {
                                _jmpForward = false;
                            }
                        }

                        if(_idTable.ContainsKey(nameLabel))
                        {
                            ID idLabel = _idTable[nameLabel];

                            if(idLabel.Type == (int)STTypes.label)
                            {
                                idLabel.Value = _line;
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

                        break;
                    }
                default:
                    //error
                    break;
            }
        }

        private string ParseString()
        {
            if ((_preprocessor.Parts[_line].Count - _part) < 2)
            {
                //error
            }

            string sourceString = "";

            _part++;

            while (_preprocessor.Parts[_line][_part] != "'")
            {

                sourceString += _preprocessor.Parts[_line][_part] + " ";

                _part++;

                if (_preprocessor.Parts[_line].Count == _part)
                {
                    //error не обнаружен конец строки

                    break;
                }
            }

            return sourceString;
        }

        private bool IsType(string c)
        {
            return _types.ContainsKey(c);
        }

        private bool IsWillcard(string c)
        {
            return _wildcards.ContainsKey(c);
        }

        private bool IsInstruction(string c)
        {
            return _instructions.ContainsKey(c);
        }

        private bool IsID(string c)
        {
            return _idTable.ContainsKey(c);
        }

        private bool IsIntegerNumeric(string c)
        {
            return Regex.IsMatch(c, @"^\d+$");
        }

        private bool IsFloatNumeric(string c)
        {
            return Regex.IsMatch(c, @"^[-+]?(\d+(\.\d*)?|\.\d+)([eE][-+]?\d+)?$");
        }

        private bool IsComplexNumeric(string c)
        {
            return Regex.IsMatch(c, @"^(\d+(?:\.\d+)?)i$");
        }

    }
}