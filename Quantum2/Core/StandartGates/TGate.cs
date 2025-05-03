using System;
using System.Numerics;

namespace Quantum2.Core.StandartGates
{
    public class TGate : Gate, IGateFactory
    {
        public TGate() : base()
        {
            Complex ip8 = new Complex(0, Math.PI / 8);

            _matrix = new Matrix(new Complex[,]
            {
                {Complex.Exp(-ip8), 0 },
                {0, Complex.Exp(ip8)}
            });

            _name = "T";

            _countStates = 1;

            SetDefaultRules();
        }

        public Gate CreateInstance()
        {
            return new TGate();
        }
    }
}
