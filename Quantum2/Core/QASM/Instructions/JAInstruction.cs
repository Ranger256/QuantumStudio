using System;
using System.Collections.Generic;

namespace Quantum2.Core.QASM.Instructions
{
    public class JAInstruction : Instr
    {
        private Flags _flags;

        private LA _lexer;

        public JAInstruction(Flags flags, LA lexer) : base()
        {
            _flags = flags;
            _lexer = lexer;

            _countArgs = 1;

            _validArgs = new Arg[1]
            {
                new Arg(new int[1]
                {
                    (int)STToken.id
                }, new int[1]
                {
                    (int)STTypes.label
                })
            };
        }

        public override void ExecuteInstruction(List<ASTNode> args)
        {
            if(args.Count == 1)
            {
                if((!_flags.SF) || (!_flags.ZF))
                {
                    _lexer.Jump(args[0].Token.NameID);
                }
            }
            else
            {
                //error
            }
        }
    }
}
