using System;
using System.Numerics;

namespace Quantum2.Core.StandartGates
{
    public class SWAPGate : Gate, IGateFactory
    {
        public SWAPGate() : base()
        {
            _matrix = new Matrix(new Complex[,] {
                { Complex.One, Complex.Zero, Complex.Zero, Complex.Zero},
                {Complex.Zero, Complex.Zero, Complex.One, Complex.Zero },
                {Complex.Zero, Complex.One, Complex.Zero, Complex.Zero },
                {Complex.Zero, Complex.Zero, Complex.Zero, Complex.One }
            });

            _name = "SWAP";

            _countStates = 2;

            SetDefaultRules();
        }

        public Gate CreateInstance()
        {
            return new SWAPGate();
        }
    }
}
