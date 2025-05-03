using System;
using System.Numerics;
using System.Collections.Generic;

namespace Quantum2.Core.QASM.Instructions
{
    public class SRCInstruction : Instr
    {
        private Dictionary<string, ID> _ids;

        private Dictionary<Point, Literal> _literals;

        public SRCInstruction(Dictionary<string,ID> ids, Dictionary<Point, Literal> literals) : base()
        {
            _ids = ids;
            _literals = literals;

            _countArgs = 2;

            _validArgs = new Arg[2]
            {
                new Arg(new int[1]
                {
                    (int)STToken.id
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
            if(args.Count == 2)
            {
                Complex complex = (Complex)(_ids[args[0].Token.NameID].Value);

                double real = Convert.ToDouble(GetValue(args[1].Token, _ids, _literals));

                _ids[args[0].Token.NameID].Value = new Complex(real, complex.Imaginary);
            }
            else
            {
                //error
            }
        }
    }
}
