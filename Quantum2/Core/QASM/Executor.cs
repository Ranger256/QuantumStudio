using System;
using System.Numerics;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;

using Quantum2.Core.QASM.Instructions;

namespace Quantum2.Core.QASM
{
    public class Flags
    {
        private bool _WORK;

        private bool _CF;
        private bool _OF;
        private bool _SF;
        private bool _ZF;

        public bool WORK
        {
            get
            {
                return _WORK;
            }
            set
            {
                _WORK = value;
            }
        }

        public bool CF
        {
            get
            {
                return _CF;
            }
            set
            {
                _CF = value;
            }
        }

        public bool OF
        {
            get
            {
                return _OF;
            }
            set
            {
                _OF = value;
            }
        }

        public bool SF
        {
            get
            {
                return _SF;
            }
            set
            {
                _SF = value;
            }
        }

        public bool ZF
        {
            get
            {
                return _ZF;
            }
            set
            {
                _ZF = value;
            }
        }

        public Flags()
        {
            _WORK = false;

            _CF = false;
            _OF = false;
            _SF = false;
            _ZF = false;
        }

        public override string ToString()
        {
            string result = "Flags:" + Environment.NewLine;

            result += "WORK: " + _WORK + Environment.NewLine;

            result += "CF: " + _CF + Environment.NewLine;
            result += "OF: " + _OF + Environment.NewLine;
            result += "SF: " + _SF + Environment.NewLine;
            result += "ZF: " + _ZF;

            return result;
        }
    }

    public class Executor
    {
        private Parser _parser;

        private ErrorHandler _errorHandler;

        private Dictionary<int,Instr> _instructions;

        private Dictionary<string, QRegister> _qRegisters;
        private Dictionary<string, Register> _registers;

        private Dictionary<string, QState> _states;

        private Dictionary<string, QGate> _gates;

        private Flags _flags;

        private Measure _measure;

        private Dictionary<string, ID> _ids;
        private Dictionary<Point, Literal> _literals;

        private StringBuilder _outputStringBuilder;

        private ASTNode _mainASTNode;

        private Action<bool> _actionWork;
        private Action<string> _actionOutputString;

        public bool IsWork
        {
            get
            {
                return _flags.WORK;
            }
        }

        public string OutputString
        {
            get
            {
                return _outputStringBuilder.ToString();
            }
        }

        public Executor()
        {
            _parser = new Parser();

            _errorHandler = new ErrorHandler();

            _instructions = new Dictionary<int, Instr>();

            _qRegisters = new Dictionary<string, QRegister>();
            _registers = new Dictionary<string, Register>();

            _states = new Dictionary<string, QState>();

            _gates = new Dictionary<string, QGate>();

            _flags = new Flags();

            _measure = new Measure();

            _ids = _parser.Lexer.IDTable;
            _literals = _parser.Lexer.Literals;

            _outputStringBuilder = new StringBuilder();

            //_actionOutputString += delegate { Console.WriteLine("PRINT"); };

           // _ids = new Dictionary<string, ID>();
            ///_literals = new Dictionary<Point, Literal>();

            AddInstruction("cqr", new CQRInstruction(_qRegisters, _ids));
            AddInstruction("cr", new CRInstruction(_registers, _ids));
            AddInstruction("cg", new CGInsruction(_ids, _gates));
            AddInstruction("cqb", new CQBInstruction(_ids, _literals));

            AddInstruction("dqr", new DQRInstruction(_qRegisters, _ids));
            AddInstruction("dr", new DRInstruction(_registers, _ids));
            AddInstruction("dg", new DGInstruction(_ids, _gates));

            AddInstruction("ssqr", new SSQRInstruction(_qRegisters, _ids, _literals));
            AddInstruction("ssr", new SSRInstruction(_registers, _ids, _literals));

            AddInstruction("scs", new SCMInstruction(_ids, _literals, _gates));
            AddInstruction("scr", new SCRInstruction(_ids, _literals, _gates));
            AddInstruction("sca", new SCAInstruction(_ids, _literals, _gates));

            AddInstruction("sgs", new SSGInstruction(_ids, _literals, _gates, _states));
            AddInstruction("sgr", new SGRInstruction(_ids, _literals, _gates));
            AddInstruction("sga", new SGAInstruction(_ids, _literals, _gates, _states));

            AddInstruction("sgrs", new SGRSInstruction(_ids, _literals, _gates));
            AddInstruction("sgra", new SGRAInstruction(_ids, _literals, _gates));

            AddInstruction("saqb", new SAQBInstruction(_ids, _literals));
            AddInstruction("sbqb", new SBQBInstruction(_ids, _literals));

            AddInstruction("gsqr", new GSQRInstruction(_ids, _qRegisters, _states));

            AddInstruction("gbr", new GBRInstruction(_ids, _literals, _registers));

            AddInstruction("gqbr", new GQBRInstruction(_ids, _literals, _qRegisters));

            AddInstruction("ag", new AGInstruction(_gates));

            AddInstruction("print", new PrintInstruction(_ids, _literals, _outputStringBuilder));

            AddInstruction("src", new SRCInstruction(_ids, _literals));
            AddInstruction("sic", new SICInstruction(_ids, _literals));

            AddInstruction("movi", new MOVIInstruction(_ids, _literals));
            AddInstruction("movf", new MOVFInstruction(_ids, _literals));
            AddInstruction("movs", new MOVSInstruction(_ids, _literals));

            AddInstruction("addi", new ADDIInstruction(_ids, _literals));
            AddInstruction("addf", new ADDFInstruction(_ids, _literals));

            AddInstruction("subi", new SUBIInstruction(_ids, _literals));
            AddInstruction("subf", new SUBFInstruction(_ids, _literals));

            AddInstruction("muli", new MULIInstruction(_ids, _literals));
            AddInstruction("mulf", new MULFInstruction(_ids, _literals));

            AddInstruction("divi", new DIVIInstruction(_ids, _literals));
            AddInstruction("divf", new DIVFInstruction(_ids, _literals));

            AddInstruction("shli", new SHLIInstruction(_ids, _literals));

            AddInstruction("shri", new SHRIInstruction(_ids, _literals));

            AddInstruction("andi", new ANDIInstruction(_ids, _literals));

            AddInstruction("ori", new ORIInstruction(_ids, _literals));

            AddInstruction("xori", new XORIInstruction(_ids, _literals));

            AddInstruction("noti", new NOTIInstruction(_ids, _literals));

            AddInstruction("negi", new NEGIInstruction(_ids, _literals));
            AddInstruction("negf", new NEGFInstruction(_ids, _literals));

            AddInstruction("cmpi", new CMPIInstruction(_ids, _literals, _flags));
            AddInstruction("cmpf", new CMPFInstruction(_ids, _literals, _flags));
            AddInstruction("cmpr", new CMPRInstruction(_ids, _literals, _registers, _flags));
            AddInstruction("cmpb", new CMPBInstruction(_ids, _literals, _flags));

            AddInstruction("jmp", new JMPInstruction(_parser.Lexer));

            AddInstruction("je", new JEInstruction(_flags, _parser.Lexer));
            AddInstruction("jne", new JNEInstruction(_flags, _parser.Lexer));
            AddInstruction("jg", new JGInstruction(_flags, _parser.Lexer));
            AddInstruction("Jge", new JGEInstruction(_flags, _parser.Lexer));
            AddInstruction("jl", new JLInstruction(_flags, _parser.Lexer));
            AddInstruction("jle", new JLEInstruction(_flags, _parser.Lexer));
            AddInstruction("ja", new JAInstruction(_flags, _parser.Lexer));
            AddInstruction("jb", new JBInstruction(_flags, _parser.Lexer));

            AddInstruction("hlt", new HLTInstruction(Stop));

            AddInstruction("mqsr", new MQSRInstruction(_ids, _literals, _registers, _measure));

            AddInstruction("call", new CALLInstruction(_parser.Lexer));
            AddInstruction("ret", new RETInstruction(_parser.Lexer));

            _parser.Instructions = _instructions;
        }

        public void SetCode(string code)
        {
            _parser.AnalyzeText(code);

            _mainASTNode = _parser.NextASTNode();
        }

        public void SubWorkAction(Action<bool> workAction)
        {
            _actionWork += workAction;
        }

        public void SubOutputString(Action<string> outputAction)
        {
            _actionOutputString += outputAction;
        }

        public async void Start()
        {
            if (_mainASTNode == null)
                return;      

            _flags.WORK = true;
            _actionWork?.Invoke(_flags.WORK);

            AddRules();

            await Task.Run(() => 
            {
                while(true)
                {

                    if (!_flags.WORK || _mainASTNode == null || _mainASTNode.Token == null)
                    {
                        Stop();

                        break;
                    }
                    else if (_parser.IsInstruction(_mainASTNode.Token.Type))
                    {
                        ExecuteInstructionProvidedASTNode(_mainASTNode);
                    }
                    else
                    {
                        Console.WriteLine(_mainASTNode.Token.Type);
                        //error
                    }

                    _actionOutputString(_outputStringBuilder.ToString());

                    _mainASTNode = _parser.NextASTNode();
                }

                end:    ;
            });
        }

        public void Stop()
        {
            Reset();

            _actionWork?.Invoke(_flags.WORK);
        }

        public void ExecuteCode(string code)
        {
            _flags.WORK = true;

            _parser.AnalyzeText(code);

            AddRules();

            ASTNode astNode = _parser.NextASTNode();

            Console.WriteLine("EXECUTE");

            while(true)
            {
                if(!_flags.WORK || astNode == null || astNode.Token == null)
                {
                    Stop();

                    break;
                }

                if (_parser.IsInstruction(astNode.Token.Type))
                {
                    ExecuteInstructionProvidedASTNode(astNode);
                }
                else
                {
                    Console.WriteLine(astNode.Token.Type);
                    //error
                }

                astNode = _parser.NextASTNode();
            }

            _flags.WORK = false;
        }

        private void ExecuteInstructionProvidedASTNode(ASTNode astNode)
        {
            _instructions[astNode.Token.Type].ExecuteInstruction(astNode.ASTNodes);
        }

        private void AddInstruction(string c, Instr instr)
        {
            _parser.Lexer.AddInstruction(c);

            instr.TypeToken = _parser.Lexer.GetInstructuon(c);

            _instructions.Add(instr.TypeToken, instr);
        }

        private void AddRule(string name,Func<Rule> rule)
        {
            ID idRule = new ID((int)STTypes.rule, true);

            idRule.Value = rule;

            _ids.Add(name, idRule);
        }

        private void AddRules()
        {
            AddRule("rlh", delegate { return Rules.RH.Instance(); });

            AddRule("rlx", delegate { return Rules.RX.Instance(); });
            AddRule("rly", delegate { return Rules.RY.Instance(); });
            AddRule("rlz", delegate { return Rules.RZ.Instance(); });

            AddRule("rlt", delegate { return Rules.RT.Instance(); });
            AddRule("rls", delegate { return Rules.RS.Instance(); });

            AddRule("rlrx", delegate { return Rules.RRX.Instance(); });
            AddRule("rlry", delegate { return Rules.RRY.Instance(); });
            AddRule("rlrz", delegate { return Rules.RRY.Instance(); });

            AddRule("rlu1", delegate { return Rules.RU1.Instance(); });
            AddRule("rlu2", delegate { return Rules.RU2.Instance(); });
            AddRule("rlu3", delegate { return Rules.RU3.Instance(); });

            AddRule("rlswap", delegate { return Rules.RSWAP.Instance(); });

            AddRule("rlcx", delegate { return Rules.RCX.Instance(); });
            AddRule("rlcy", delegate { return Rules.RCY.Instance(); });
            AddRule("rlcz", delegate { return Rules.RCZ.Instance(); });
        }

        private void Reset()
        {
            _parser.Reset();

            _qRegisters.Clear();
            _registers.Clear();
            _states.Clear();
            _gates.Clear();
            _ids.Clear();
            _literals.Clear();

            _flags.WORK = false;

            _flags.CF = false;
            _flags.OF = false;
            _flags.ZF = false;
            _flags.SF = false;  
        }
    }
}
