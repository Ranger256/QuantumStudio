using System;
using System.Numerics;

namespace Quantum2.Core.StandartGates
{
    public class ZGate : Gate, IGateFactory
    {
        public ZGate() : base()
        {
            _matrix = new Matrix(new Complex[,] {
                {Complex.One, Complex.Zero },
                {Complex.Zero, -1 * Complex.One}
            });

            _name = "Z";

            _countStates = 1;

            SetDefaultRules();
        }

        public Gate CreateInstance()
        {
            return new ZGate();
        }
    }
}
