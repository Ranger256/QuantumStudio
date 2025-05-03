using System;
using System.Collections.Generic;

namespace Quantum2.Core.QASM.Instructions
{
    public class CQBInstruction : Instr
    {
        private Dictionary<string, ID> _ids;

        private Dictionary<Point, Literal> _literals;

        public CQBInstruction(Dictionary<string, ID> ids, Dictionary<Point, Literal> literals) : base()
        {
            _ids = ids;
            _literals = literals;

            _countArgs = 1;

            _validArgs = new Arg[1]
            {
                new Arg(new int[1]
                {
                    (int)STToken.id
                }, new int[1]
                {
                    (int)STTypes.qbit
                })
            };
        }

        public override void ExecuteInstruction(List<ASTNode> args)
        {
            if(args.Count == 1)
            {
                Qubit qbit = new Qubit();

                _ids[args[0].Token.NameID].Value = qbit;
            }
            else
            {
                //error
            }
        }
    }
}
