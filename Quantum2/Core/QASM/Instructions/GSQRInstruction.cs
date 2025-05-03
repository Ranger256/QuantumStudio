using System;
using System.Collections.Generic;

namespace Quantum2.Core.QASM.Instructions
{
    public class GSQRInstruction : Instr
    {
        private Dictionary<string, ID> _ids;
        private Dictionary<string, QRegister> _qRegisters;
        private Dictionary<string, QState> _states;

        public GSQRInstruction(Dictionary<string, ID> ids, Dictionary<string, QRegister> qRegisters, Dictionary<string, QState> qStates) : base()
        {
            _ids = ids;
            _qRegisters = qRegisters;
            _states = qStates;

            _countArgs = 2;

            _validArgs = new Arg[2]
             {
                 new Arg(new int[1]
                 {
                     (int)STToken.id
                 }, new int[1]
                 {
                     (int)STTypes.qstate
                 }),
                 new Arg(new int[1]
                 {
                     (int)STToken.id
                 }, new int[1]
                 {
                     (int)STTypes.qreg
                 })
             };
        }

        public override void ExecuteInstruction(List<ASTNode> args)
        {
            if(args.Count == 2)
            {
                string nameState = args[0].Token.NameID;
                string nameQRegister = args[1].Token.NameID;

                if(IsNullValue(nameState, _ids))
                {
                    if (!_states.ContainsKey(nameState))
                    {
                        if (_qRegisters.ContainsKey(nameQRegister))
                        {
                            QState state = new QState();

                            state.SetStateByQRegister(_qRegisters[nameQRegister]);

                            _states.Add(nameState,state);

                            _ids[nameState].Value = state;
                        }
                        else
                        {
                            //error
                        }
                    }
                    else
                    {

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
