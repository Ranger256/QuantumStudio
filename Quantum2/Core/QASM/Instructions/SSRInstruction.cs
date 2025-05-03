using System;
using System.Collections.Generic;

namespace Quantum2.Core.QASM.Instructions
{
    public class SSRInstruction : Instr
    {
        private Dictionary<string, Register> _registers;

        private Dictionary<string, ID> _ids;

        private Dictionary<Point, Literal> _literals;

        public SSRInstruction(Dictionary<string, Register> registers, Dictionary<string, ID> ids, Dictionary<Point, Literal> literals) : base()
        {
            _registers = registers;
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
                    (int)STTypes.reg
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
                    (int)(STTypes.qword)
                })
            };
        }

        public override void ExecuteInstruction(List<ASTNode> args)
        {
            if(args.Count == 2)
            {
                if(_registers.ContainsKey(args[0].Token.NameID))
                {
                    if (!_ids[args[0].Token.NameID].IsConst)
                    {
                        int sizeRegister = Convert.ToInt32(GetValue(args[1].Token, _ids, _literals));

                        if (sizeRegister >= 0)
                        {
                            _registers[args[0].Token.NameID].SetCount(sizeRegister);
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

                }
            }
            else
            {
                //error
            }
        }
    }
}
