using System;
using System.Collections.Generic;

namespace Quantum2.Core.QASM.Instructions
{
    public class SGRSInstruction : Instr
    {
        private Dictionary<string, ID> _ids;

        private Dictionary<Point, Literal> _literals;

        private Dictionary<string, QGate> _gates;

        public SGRSInstruction(Dictionary<string, ID> ids, Dictionary<Point, Literal> literals, Dictionary<string, QGate> gates) : base()
        {
            _ids = ids;
            _literals = literals;
            _gates = gates;

            _countArgs = 4;

            _validArgs = new Arg[4]
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
                }, new int[4]
                {
                    (int)STTypes.type_byte,
                    (int)STTypes.word,
                    (int)STTypes.dword,
                    (int)STTypes.qword
                }),
            };
        }

        public override void ExecuteInstruction(List<ASTNode> args)
        {
            if(args.Count == 4)
            {
                string nameGate = args[0].Token.NameID;

                uint indexRule = Convert.ToUInt32(GetValue(args[1].Token, _ids, _literals));
                uint indexRuleState = Convert.ToUInt32(GetValue(args[2].Token, _ids, _literals));
                uint indexGateState = Convert.ToUInt32(GetValue(args[3].Token, _ids, _literals));

                if (!IsNullValue(nameGate, _ids))
                {
                    if(_gates.ContainsKey(nameGate))
                    {
                        _gates[nameGate].SetGateRuleState(indexRule, indexRuleState, indexGateState);
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
            else
            {
                //error
            }
        }
    }
}
