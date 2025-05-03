using System;
using System.Collections.Generic;

namespace Quantum2.Core.QASM.Instructions
{
    public class NEGFInstruction : Instr
    {
        private Dictionary<string, ID> _ids;
        private Dictionary<Point, Literal> _literals;

        public NEGFInstruction(Dictionary<string, ID> ids, Dictionary<Point, Literal> literals) : base()
        {
            _ids = ids;
            _literals = literals;

            _countArgs = 1;

            _validArgs = new Arg[1]
            {
                new Arg(new int[1]
                {
                    (int)STToken.id
                }, new int[2]
                {
                    (int)STTypes.real4,
                    (int)STTypes.real8
                }) 
            };
        }

        public override void ExecuteInstruction(List<ASTNode> args)
        {
            if (args.Count == 1)
            {
                int typeFirstOperand = GetType(args[0].Token, _ids, _literals);

                double arg0 = Convert.ToDouble(GetValue(args[0].Token, _ids, _literals));

                _ids[args[0].Token.NameID].Value = CFT(typeFirstOperand, arg0 * -1);
            }
            else
            {
                //error
            }
        }
    }
}
