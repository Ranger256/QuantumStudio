using System;
using System.Collections.Generic;

namespace Quantum2.Core.QASM.Instructions
{
    public class CMPBInstruction : Instr
    {
        private Dictionary<string, ID> _ids;

        private Dictionary<Point, Literal> _literals;

        private Flags _flags;

        public CMPBInstruction(Dictionary<string, ID> ids, Dictionary<Point, Literal> literals, Flags flags) : base()
        {
            _ids = ids;
            _literals = literals;
            _flags = flags;

            _countArgs = 2;

            _validArgs = new Arg[2]
            {
                new Arg(new int[1]
                {
                    (int)STToken.id
                }, new int[1]
                {
                    (int)STTypes.bit
                }), new Arg(new int[2]
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
            if(args.Count == 2)
            {
                bool bit = (bool)GetValue(args[0].Token, _ids, _literals);

                bool op1 = !(Convert.ToInt64(GetValue(args[1].Token, _ids, _literals)) == 0);

                _flags.ZF = (bit == op1);
            }
            else
            {
                //error
            }
        }
    }
}
