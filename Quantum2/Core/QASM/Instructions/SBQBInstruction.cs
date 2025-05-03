using System;
using System.Numerics;
using System.Collections.Generic;

namespace Quantum2.Core.QASM.Instructions
{
    public class SBQBInstruction : Instr
    {
        private Dictionary<string, ID> _ids;

        private Dictionary<Point, Literal> _literals;

        public SBQBInstruction(Dictionary<string, ID> ids, Dictionary<Point, Literal> literals) : base()
        {
            _ids = ids;
            _literals = literals;

            _countArgs = 3;

            _validArgs = new Arg[3]
            {
                new Arg(new int[1]
                {
                    (int)STToken.id
                }, new int[1]
                {
                    (int)STTypes.qbit
                }), new Arg(new int[2]
                {
                    (int)STToken.id,
                    (int)STToken.literal
                }, new int[1]
                {
                    (int)STTypes.complex
                }), new Arg(new int[2]
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
                })
            };
        }

        public override void ExecuteInstruction(List<ASTNode> args)
        {
            if (args.Count == 3)
            {
                Qubit qubit = (Qubit)_ids[args[0].Token.NameID].Value;

                Complex beta = (Complex)GetValue(args[1].Token, _ids, _literals);

                double realAlpha = Convert.ToDouble(GetValue(args[2].Token, _ids, _literals));

                qubit.SetARBC(realAlpha, beta);
            }
            else
            {
                //error
            }
        }
    }
}
