using System;
using System.Collections.Generic;

namespace Quantum2.Core.QASM.Instructions
{
    public class DRInstruction : Instr
    {
        private Dictionary<string, ID> _ids;
        private Dictionary<string, Register> _registers;

        public DRInstruction(Dictionary<string, Register> registers, Dictionary<string, ID> ids) : base()
        {
            _ids = ids;
            _registers = registers;

            _countArgs = 1;

            _validArgs = new Arg[1]
            {
                new Arg(new int[1]
                {
                    (int)STToken.id
                },new int[1]
                {
                    (int)STTypes.reg
                })
            };
        }

        public override void ExecuteInstruction(List<ASTNode> args)
        {
            if(args.Count == 1)
            {
                if (!IsNullValue(args[0].Token.NameID, _ids))
                {
                    if (_registers.ContainsKey(args[0].Token.NameID))
                    {
                        _registers.Remove(args[0].Token.NameID);
                        _ids[args[0].Token.NameID].Value = null;
                    }
                    else
                    {

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
