using System;
using System.Collections.Generic;

namespace Quantum2.Core.QASM.Instructions
{
    public class CMPFInstruction : Instr
    {
        private Dictionary<string, ID> _ids;
        private Dictionary<Point, Literal> _literals;

        private Flags _flags;

        public CMPFInstruction(Dictionary<string, ID> ids, Dictionary<Point, Literal> literals, Flags flags) : base()
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
                }, new int[2]
                {
                    (int)STTypes.real4,
                    (int)STTypes.real8
                }),
                new Arg(new int[2]
                {
                    (int)STToken.id,
                    (int)STToken.literal
                }, new int[10]
                {
                    (int)STTypes.type_byte,
                    (int)STTypes.word,
                    (int)STTypes.dword,
                    (int)STTypes.qword,
                    (int)STTypes.type_sbyte,
                    (int)STTypes.sword,
                    (int)STTypes.sdword,
                    (int)STTypes.sqword,
                    (int)STTypes.real4,
                    (int)STTypes.real8
                }
                )
            };
        }

        public override void ExecuteInstruction(List<ASTNode> args)
        {
            if (args.Count == 2)
            {
                double result = Convert.ToDouble(GetValue(args[0].Token, _ids, _literals)) - Convert.ToDouble(GetValue(args[1].Token, _ids, _literals));

                _flags.ZF = (result == 0);

                _flags.SF = (result < 0);
            }
            else
            {
                //error
            }
        }
    }
}
