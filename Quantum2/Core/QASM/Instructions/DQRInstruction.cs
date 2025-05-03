using System;
using System.Collections.Generic;

namespace Quantum2.Core.QASM.Instructions
{
    public class DQRInstruction : Instr
    {
        private Dictionary<string, ID> _ids;
        private Dictionary<string, QRegister> _qRegisters;

        public DQRInstruction(Dictionary<string,QRegister> qRegisters, Dictionary<string, ID> ids) : base()
        {
            // _typeReturnValue = (int)STTypes.type_void;

            _ids = ids;
            _qRegisters = qRegisters;

            _countArgs = 1;

            _validArgs = new Arg[1]
             {
                 new Arg(new int[1]
                 {
                     (int)STToken.id
                 },
                 new int[1]
                 {
                     (int)STTypes.qreg
                 })
             };
        }

        public override void ExecuteInstruction(List<ASTNode> args)
        {
            if (args.Count == 1)
            {
                if (!IsNullValue(args[0].Token.NameID, _ids))
                {
                    if (_qRegisters.ContainsKey(args[0].Token.NameID))
                    {
                        _qRegisters.Remove(args[0].Token.NameID);
                        _ids[args[0].Token.NameID].Value = null;
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
