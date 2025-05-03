using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantum2.Core.QASM.Instructions
{
    public class SGRInstruction : Instr
    {
        private Dictionary<string, ID> _ids;
        private Dictionary<Point, Literal> _literals;
        private Dictionary<string, QGate> _gates;

        public SGRInstruction(Dictionary<string, ID> ids,Dictionary<Point, Literal> literals, Dictionary<string, QGate> gates) : base()
        {
            _ids = ids;
            _literals = literals;
            _gates = gates;

            _countArgs = 3;

            _validArgs = new Arg[3]
            {
                new Arg(new int[1]
                {
                    (int)STToken.id
                }, new int[1]
                {
                    (int)STTypes.gate
                }),
                new Arg(new int[2]
                {
                    (int)STToken.id,
                    (int)STToken.literal
                }, new int[4]
                {
                    (int)STTypes.type_byte,
                    (int)STTypes.word,
                    (int)STTypes.dword,
                    (int)STTypes.qword
                }),
                new Arg(new int[1]
                {
                    (int)STToken.id
                },new int[1]
                {
                    (int)STTypes.rule
                })
            };
        }

        public override void ExecuteInstruction(List<ASTNode> args)
        {
            Console.WriteLine(args.Count);
            if (args.Count == 3)
            {
               
                string nameGate = args[0].Token.NameID;

                uint numberRule = Convert.ToUInt32(GetValue(args[1].Token, _ids, _literals));

                Func<Rule> rule = (Func<Rule>)(_ids[args[2].Token.NameID].Value);

                _gates[nameGate].SetRule(rule(), numberRule);

                //if(_gates.ContainsKey())
            }
            else
            {
                //error
            }
        }
    }
}
