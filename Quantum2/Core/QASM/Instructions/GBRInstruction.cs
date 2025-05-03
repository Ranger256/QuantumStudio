using System;
using System.Collections.Generic;

namespace Quantum2.Core.QASM.Instructions
{
    public class GBRInstruction : Instr
    {
        private Dictionary<string, ID> _ids;

        private Dictionary<Point, Literal> _literals;

        private Dictionary<string, Register> _registers;

        public GBRInstruction(Dictionary<string, ID> ids, Dictionary<Point, Literal> literals, Dictionary<string, Register> registers) : base()
        {
            _ids = ids;
            _literals = literals;
            _registers = registers;

            _countArgs = 3;

            _validArgs = new Arg[3]
            {
                new Arg(new int[1]
                {
                    (int)STToken.id
                }, new int[1]
                {
                    (int)STTypes.bit
                }),new Arg(new int[1]
                {
                    (int)STToken.id
                }, new int[1]
                {
                    (int)STTypes.reg
                }), new Arg(new int[2]
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
         
            if(args.Count == 3)
            {
                string nameBit = args[0].Token.NameID;
                string nameRegister = args[1].Token.NameID;

                if(_registers.ContainsKey(nameRegister))
                {
                    Register register = _registers[nameRegister];

                    ulong indexBit = Convert.ToUInt64(GetValue(args[2].Token, _ids, _literals));

                    if(indexBit < (ulong)register.Bits.Length)
                    {
                        _ids[nameBit].Value = (bool)register.Bits[indexBit];
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
