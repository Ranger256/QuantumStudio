using System;
using System.Collections.Generic;

namespace Quantum2.Core.QASM.Instructions
{
    public class SGAInstruction : Instr
    {
        private Dictionary<string, ID> _ids;

        private Dictionary<Point, Literal> _literals;

        private Dictionary<string, QGate> _gates;

        private Dictionary<string, QState> _states;

        public SGAInstruction(Dictionary<string, ID> ids, Dictionary<Point, Literal> literals, Dictionary<string, QGate> gates, Dictionary<string, QState> states) : base()
        {
            _ids = ids;
            _literals = literals;
            _gates = gates;
            _states = states;

            _countArgs = 3;

            _validArgs = new Arg[3]
            {
                new Arg(new int[1]
                {
                    (int)STToken.id
                }, new int[1]
                {
                    (int)STTypes.gate
                }),
                new Arg(new int[2]
                {
                    (int)STToken.id,
                    (int)STToken.literal
                }, new int[4]
                {
                    (int)STTypes.type_byte,
                    (int)STTypes.word,
                    (int)STTypes.dword,
                    (int)STTypes.qword
                }),
                new Arg(new int[2]
                {
                    (int)STToken.id,
                    (int)STToken.literal
                }, new int[10]
                {
                    (int)STTypes.type_byte,
                    (int)STTypes.word,
                    (int)STTypes.dword,
                    (int)STTypes.qword,

                    (int)STTypes.type_sbyte,
                    (int)STTypes.sword,
                    (int)STTypes.sdword,
                    (int)STTypes.sqword,

                    (int)STTypes.real4,
                    (int)STTypes.real8
                })
            };
        }

        public override void ExecuteInstruction(List<ASTNode> args)
        {
            if (args.Count == 3)
            {
                string nameGate = args[0].Token.NameID;

                uint indexArg = Convert.ToUInt32(GetValue(args[1].Token, _ids, _literals));

                double arg = Convert.ToDouble(GetValue(args[2].Token, _ids, _literals));

                if (_gates.ContainsKey(nameGate))
                {
                    if(indexArg < _gates[nameGate].Args.Length)
                    {
                        _gates[nameGate].SetArg(arg, indexArg);
                    }
                    else
                    {

                    }
                }
                else
                {
                    //error
                }
            }
        }
    }
}
