using System;
using System.Collections.Generic;

namespace Quantum2.Core.QASM.Instructions
{
    public class SCRInstruction : Instr
    {
        private Dictionary<string, ID> _ids;
        private Dictionary<Point, Literal> _literals;
        private Dictionary<string, QGate> _gates;

        public SCRInstruction(Dictionary<string, ID> ids, Dictionary<Point, Literal> literals, Dictionary<string, QGate> gates) : base()
        {
            _ids = ids;
            _literals = literals;
            _gates = gates;

            _countArgs = 2;

            _validArgs = new Arg[2]
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
                })
            };
        }

        public override void ExecuteInstruction(List<ASTNode> args)
        {
            if (args.Count == 2)
            {
                string nameGate = args[0].Token.NameID;

                if (_gates.ContainsKey(nameGate))
                {
                    if (!_ids[nameGate].IsConst)
                    {
                        uint countRules = Convert.ToUInt32(GetValue(args[1].Token, _ids, _literals));

                        if (countRules >= 0)
                        {
                            _gates[nameGate].SetCountRules(countRules);
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
    }
}
