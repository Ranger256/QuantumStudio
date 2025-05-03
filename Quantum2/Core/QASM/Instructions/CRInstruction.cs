using System;
using System.Collections.Generic;

namespace Quantum2.Core.QASM.Instructions
{
    public class CRInstruction : Instr
    {
        private Dictionary<string, ID> _ids;
        private Dictionary<string, Register> _registers;
        public CRInstruction(Dictionary<string, Register> registers, Dictionary<string, ID> ids) : base()
        {
            _ids = ids;
            _registers = registers;

            //_typeReturnValue = (int)STTypes.reg;

            _countArgs = 1;

            _validArgs = new Arg[1]
            {
                 new Arg(new int[1]
                {
                    (int)STToken.id
                },
                new int[1]
                {
                    (int)STTypes.reg
                })
            };
        }

        public override void ExecuteInstruction(List<ASTNode> args)
        {
            if (args.Count == 1)
            {
                if (IsNullValue(args[0].Token.NameID, _ids))
                {

                    if (!_registers.ContainsKey(args[0].Token.NameID))
                    {
                        Register newRegister = new Register(1);

                        _registers.Add(args[0].Token.NameID, newRegister);

                        _ids[args[0].Token.NameID].Value = newRegister;
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
