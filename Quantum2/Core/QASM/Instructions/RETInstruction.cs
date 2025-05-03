using System;
using System.Collections.Generic;

namespace Quantum2.Core.QASM.Instructions
{
    public class RETInstruction : Instr
    {
        private LA _lexer;

        public RETInstruction(LA lexer) : base()
        {
            _lexer = lexer;

            _countArgs = 0;

            _validArgs = new Arg[0];
        }

        public override void ExecuteInstruction(List<ASTNode> args)
        {
            _lexer.Ret();
        }
    }
}
