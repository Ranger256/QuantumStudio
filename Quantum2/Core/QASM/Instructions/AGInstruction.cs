using System;
using System.Collections.Generic;

namespace Quantum2.Core.QASM.Instructions
{
    public class AGInstruction : Instr
    {
        private Dictionary<string, QGate> _gates;

        public AGInstruction(Dictionary<string, QGate> gates) : base()
        {
            _gates = gates;

            _countArgs = 1;

            _validArgs = new Arg[1]
            {
                new Arg(new int[1]
                {
                    (int)STToken.id
                }, new int[1]
                {
                    (int)STTypes.gate
                })
            };
        }

        public override void ExecuteInstruction(List<ASTNode> args)
        {
            if(args.Count == 1)
            {
                string nameGate = args[0].Token.NameID;

                if(_gates.ContainsKey(nameGate))
                {
                    _gates[nameGate].Apply();
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
