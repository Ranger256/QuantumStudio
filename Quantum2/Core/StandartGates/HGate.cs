using System;
using System.Numerics;

namespace Quantum2.Core.StandartGates
{
    class HGate : Gate, IGateFactory
    {
        public HGate() : base()
        {
            Complex oneDivSqrt2 = new Complex(1 / Math.Sqrt(2), 0);

            _matrix = new Matrix(new Complex[,] {
                { oneDivSqrt2, oneDivSqrt2},
                {oneDivSqrt2, -1 * oneDivSqrt2 }
            });

            _name = "H";

            _countStates = 1;

            SetDefaultRules();
        }

        public Gate CreateInstance()
        {
            return new HGate();
        }
    }
}
