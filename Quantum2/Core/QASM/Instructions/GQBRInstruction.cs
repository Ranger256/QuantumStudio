using System;
using System.Collections.Generic;

namespace Quantum2.Core.QASM.Instructions
{
    public class GQBRInstruction : Instr
    {
        private Dictionary<string, ID> _ids;

        private Dictionary<Point, Literal> _literals;

        private Dictionary<string, QRegister> _qRegisters;

        public GQBRInstruction(Dictionary<string,ID> ids, Dictionary<Point, Literal> literals, Dictionary<string, QRegister> qRegisters) : base()
        {
            _ids = ids;
            _literals = literals;
            _qRegisters = qRegisters;

            _countArgs = 3;

            _validArgs = new Arg[3]
            {
                new Arg(new int[1]
                {
                    (int)STToken.id
                }, new int[1]
                {
                    (int)STTypes.qbit
                }),new Arg(new int[1]
                {
                    (int)STToken.id
                }, new int[1]
                {
                    (int)STTypes.qreg
                }), new Arg(new int[2]
                {
                    (int)STToken.id,
                    (int)STToken.literal
                }, new int[4]
                {
                    (int)STTypes.type_byte,
                    (int)STTypes.word,
                    (int)STTypes.dword,
                    (int)STTypes.qword
                })
            };
        }

        public override void ExecuteInstruction(List<ASTNode> args)
        {
            if (args.Count == 3)
            {
                string nameQRegister = args[1].Token.NameID;

                if(_qRegisters.ContainsKey(nameQRegister))
                {
                    QRegister qRegister = _qRegisters[nameQRegister];

                    ulong indexQBit = Convert.ToUInt64(GetValue(args[2].Token, _ids, _literals));

                    if(indexQBit < (ulong)qRegister.Qubits.Length)
                    {
                        Qubit qbit = qRegister.Get(indexQBit);

                        _ids[args[0].Token.NameID].Value = qbit;
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
            else
            {
                //error
            }
        }
    }
}
