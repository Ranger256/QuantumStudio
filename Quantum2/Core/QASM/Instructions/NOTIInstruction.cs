using System;
using System.Collections.Generic;

namespace Quantum2.Core.QASM.Instructions
{
    public class NOTIInstruction : Instr
    {
        private Dictionary<string, ID> _ids;

        private Dictionary<Point, Literal> _literals;

        public NOTIInstruction(Dictionary<string, ID> ids, Dictionary<Point, Literal> literals)
        {
            _ids = ids;
            _literals = literals;

            _countArgs = 1;

            _validArgs = new Arg[1]
            {
                 new Arg(new int[1]
                 {
                     (int)STToken.id
                 }, new int[8]
                 {
                     (int)STTypes.type_byte,
                     (int)STTypes.word,
                     (int)STTypes.dword,
                     (int)STTypes.qword,

                     (int)STTypes.type_sbyte,
                     (int)STTypes.sword,
                     (int)STTypes.sdword,
                     (int)STTypes.sqword
                 })
            };
        }

        public override void ExecuteInstruction(List<ASTNode> args)
        {
            if (args.Count == 1)
            {
                int typeFirstOperand = GetType(args[0].Token, _ids, _literals);

                long op0 = Convert.ToInt64(GetValue(args[0].Token, _ids, _literals));

                object result = CIT(typeFirstOperand, ~op0);

                _ids[args[0].Token.NameID].Value = result;
            }
            else
            {
                //error
            }
        }
    }
}
