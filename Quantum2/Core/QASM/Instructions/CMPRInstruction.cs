using System;
using System.Collections.Generic;

namespace Quantum2.Core.QASM.Instructions
{
    public class CMPRInstruction : Instr
    {
        private Dictionary<string, ID> _ids;

        private Dictionary<Point, Literal> _literals;

        private Dictionary<string, Register> _registers;

        private Flags _flags;

        public CMPRInstruction(Dictionary<string,ID> ids, Dictionary<Point, Literal> literals, Dictionary<string, Register> registers, Flags flags) : base()
        {
            _ids = ids;
            _literals = literals;
            _registers = registers;
            _flags = flags;

            _countArgs = 2;

            _validArgs = new Arg[2]
            {
                new Arg(new int[1]
                {
                    (int)STToken.id
                }, new int[1]
                {
                    (int)STTypes.reg
                }), 
                new Arg(new int[2]
                {
                    (int)STToken.id,
                    (int)STToken.literal
                }, new int[8]
                {
                    (int)STTypes.type_byte,
                    (int)STTypes.word,
                    (int)STTypes.dword,
                    (int)STTypes.qword,

                    (int)STTypes.type_sbyte,
                    (int)STTypes.sword,
                    (int)STTypes.sdword,
                    (int)STTypes.sqword
                })
            };
        }

        public override void ExecuteInstruction(List<ASTNode> args)
        {
            if (args.Count == 2)
            {
                if(_registers.ContainsKey(args[0].Token.NameID))
                {
                    long firstOperand = _registers[args[0].Token.NameID].Value;

                    int typeSecondOperand = GetType(args[1].Token, _ids, _literals);

                    long result = 0;

                    if (typeSecondOperand <= (int)STTypes.qword)
                    {
                        result = (long)( ((ulong)firstOperand) - Convert.ToUInt64(GetValue(args[1].Token, _ids, _literals)));
                    }
                    else
                    {
                        result = firstOperand - Convert.ToInt64(GetValue(args[1].Token, _ids, _literals));
                    }

                    _flags.ZF = (result == 0);

                    _flags.SF = (result < 0);
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
