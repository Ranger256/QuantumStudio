using System;
using System.Collections.Generic;

namespace Quantum2.Core.QASM.Instructions
{
    public class MOVSInstruction : Instr
    {
        private Dictionary<string, ID> _ids;

        private Dictionary<Point, Literal> _literals;

        public MOVSInstruction(Dictionary<string,ID> ids, Dictionary<Point,Literal> literals)
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
                    (int)STTypes.@string
                }), new Arg(new int[2]
                {
                    (int)STToken.id,
                    (int)STToken.literal
                }, new int[1]
                {
                    (int)STTypes.@string
                })
            };
        }

        public override void ExecuteInstruction(List<ASTNode> args)
        {
            if(args.Count == 2)
            {
                _ids[args[0].Token.NameID].Value = GetValue(args[1].Token, _ids, _literals);
            }else
            {
                //error
            }
        }
    }
}
