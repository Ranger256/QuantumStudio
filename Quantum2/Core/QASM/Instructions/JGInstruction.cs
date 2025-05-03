using System;
using System.Collections.Generic;

namespace Quantum2.Core.QASM.Instructions
{
    public class JGInstruction : Instr
    {
        private Flags _flags;

        private LA _lexer;

        public JGInstruction(Flags flags, LA lexer) : base()
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
                if((!_flags.SF) )
                {
                    _lexer.Jump(args[0].Token.NameID);
                }
            }
            else
            {
                //eror
            }
        }
    }
}
