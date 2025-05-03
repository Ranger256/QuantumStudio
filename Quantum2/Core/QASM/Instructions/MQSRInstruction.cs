using System;
using System.Collections.Generic;

namespace Quantum2.Core.QASM.Instructions
{
    public class MQSRInstruction : Instr
    {
        private Dictionary<string, ID> _ids;

        private Dictionary<Point, Literal> _literals;

        private Dictionary<string, Register> _registers;

        private Measure _measure;

        public MQSRInstruction(Dictionary<string,ID> ids, Dictionary<Point,Literal> literals, Dictionary<string, Register> registers, Measure measure) : base()
        {
            _ids = ids;
            _literals = literals;
            _registers = registers;

            _measure = measure;

            _countArgs = 2;

            _validArgs = new Arg[2]
            {
                new Arg(new int[1]
                {
                    (int)STToken.id
                }, new int[1]
                {
                    (int)STTypes.reg
                }), new Arg(new int[1]
                {
                    (int)STToken.id
                }, new int[1]
                {
                    (int)STTypes.qstate
                })
            };
        }

        public override void ExecuteInstruction(List<ASTNode> args)
        {
            if(args.Count == 2)
            {
                string nameRegister = args[0].Token.NameID;

                if(_registers.ContainsKey(nameRegister))
                {
                    Register register = _registers[nameRegister];
                    QState qstate = (QState)GetValue(args[1].Token, _ids, _literals);

                    _measure.Take(qstate.State,qstate.Qubits, qstate.CountQubits, register);
                }
                else
                {
                    //error
                }
            }
            else
            {
                //error
            }
        }
    }
}
