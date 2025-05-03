using System;
using System.Collections.Generic;

namespace Quantum2.Core.QASM.Instructions
{
    public class SSQRInstruction : Instr
    {
        private Dictionary<string, QRegister> _qRegisters;

        private Dictionary<string, ID> _ids;

        private Dictionary<Point, Literal> _literals;

        public SSQRInstruction(Dictionary<string, QRegister> qRegisters, Dictionary<string, ID> ids, Dictionary<Point, Literal> literals) : base()
        {
            _qRegisters = qRegisters;
            _ids = ids;
            _literals = literals;

            _countArgs = 2;

            _validArgs = new Arg[2]
            {
                 new Arg(new int[1]
                {
                    (int)STToken.id
                },
                new int[1]
                {
                    (int)STTypes.qreg
                }),

                new Arg(new int[2]
                {
                    (int)STToken.id,
                    (int)STToken.literal
                },
                new int[4]
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
            if(args.Count == 2)
            {
                if(_qRegisters.ContainsKey(args[0].Token.NameID))
                {
                    if (!_ids[args[0].Token.NameID].IsConst)
                    {
                        int sizeQRegister = Convert.ToInt32(GetValue(args[1].Token, _ids, _literals));

                        if (sizeQRegister >= 0)
                        {
                            _qRegisters[args[0].Token.NameID].SetCount(sizeQRegister);
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
            else
            {
                //error
            }
        }
    }
}
