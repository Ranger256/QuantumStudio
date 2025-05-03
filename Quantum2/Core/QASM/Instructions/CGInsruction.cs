using System;
using System.Collections.Generic;

namespace Quantum2.Core.QASM.Instructions
{
    public class CGInsruction : Instr
    {
        private Dictionary<string, ID> _ids;
        private Dictionary<string, QGate> _gates;

        public CGInsruction(Dictionary<string, ID> ids, Dictionary<string, QGate> gates) : base()
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
            if(args.Count == 1)
            {
                string nameGate = args[0].Token.NameID;
                
                if (IsNullValue(nameGate, _ids))
                {
                    if(!_gates.ContainsKey(nameGate))
                    {
                        QGate gate = new QGate();

                        //gate.Rules = new Matrix[1];

                        _gates.Add(nameGate, gate);
                        _ids[nameGate].Value = gate;
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
