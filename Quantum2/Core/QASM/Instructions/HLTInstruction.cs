using System;
using System.Collections.Generic;

namespace Quantum2.Core.QASM.Instructions
{
    public class HLTInstruction : Instr
    {
        private Action _actionHALT;
        public HLTInstruction(Action actionHALT) : base()
        {
            _actionHALT = actionHALT;

            _countArgs = 0;

            _validArgs = new Arg[0];
        }

        public override void ExecuteInstruction(List<ASTNode> args)
        {
            _actionHALT?.Invoke();
        }
    }
}
