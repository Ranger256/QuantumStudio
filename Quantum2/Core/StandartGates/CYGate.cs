using System;
using System.Numerics;

namespace Quantum2.Core.StandartGates
{
    public class CYGate : Gate, IGateFactory
    {
        public CYGate() : base()
        {
            _matrix = new Matrix(new Complex[,]
            {
                {Complex.One, Complex.Zero, Complex.Zero, Complex.Zero },
                {Complex.Zero, Complex.One, Complex.Zero, Complex.Zero },
                {Complex.Zero, Complex.Zero, Complex.Zero, -Complex.ImaginaryOne },
                {Complex.Zero, Complex.Zero, Complex.ImaginaryOne, Complex.Zero }
            });

            _name = "CY";

            _countStates = 2;

            SetDefaultRules();
        }

        public Gate CreateInstance()
        {
            return new CYGate();
        }
    }
}
