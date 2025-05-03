using System;
using System.Collections.Generic;

namespace Quantum2.Core.QASM.Instructions
{
    public class DGInstruction : Instr
    {
        private Dictionary<string, ID> _ids;
        private Dictionary<string, QGate> _gates;

        public DGInstruction(Dictionary<string, ID> ids, Dictionary<string, QGate> gates) : base()
        {
            _ids = ids;
            _gates = gates;

            _countArgs = 1;

            _validArgs = new Arg[1]
            {
                new Arg(new int[1]
                {
                   (int) STToken.id
                }, new int[1]
                {
                    (int) STTypes.gate
                })
            };
        }

        public override void ExecuteInstruction(List<ASTNode> args)
        {
            if (args.Count != 1)
            {
                string nameGate = args[0].Token.NameID;

                if (!IsNullValue(nameGate, _ids))
                {
                    if (_gates.ContainsKey(nameGate))
                    {
                        _gates.Remove(nameGate);
                        _ids[nameGate].Value = null;
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
