using System;
using System.Collections.Generic;

namespace Quantum2.Core.QASM.Instructions
{
    public class SSGInstruction : Instr
    {
        private Dictionary<string, ID> _ids;

        private Dictionary<Point, Literal> _literals;

        private Dictionary<string, QGate> _gates;

        private Dictionary<string, QState> _states;

        public SSGInstruction(Dictionary<string, ID> ids, Dictionary<Point, Literal> literals, Dictionary<string, QGate> gates, Dictionary<string, QState> states) : base()
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
                new Arg(new int[1]
                {
                    (int)STToken.id
                }, new int[1] 
                {
                    (int)STTypes.qstate
                })
            };
        }

        public override void ExecuteInstruction(List<ASTNode> args)
        {
            if(args.Count == 3)
            {
                string nameGate = args[0].Token.NameID;

                uint indexState = Convert.ToUInt32( GetValue(args[1].Token, _ids, _literals));

                string nameState = args[2].Token.NameID;

                if(_gates.ContainsKey(nameGate))
                {
                    if(_states.ContainsKey(nameState))
                    {
                        if(indexState < _gates[nameGate].QStates.Length)
                        {
                            _gates[nameGate].SetState(_states[nameState], indexState);
                        }
                        else
                        {
                            //error
                        }
                    }
                }
            }
            else
            {
                //error
            }
        }
    }
}
