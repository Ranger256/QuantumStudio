using System;
using System.Numerics;

namespace Quantum2.Core.StandartGates
{
    public class CZGate : Gate, IGateFactory
    {
        public CZGate() : base()
        {
            _matrix = new Matrix(new Complex[,]
            {
                {Complex.One, Complex.Zero, Complex.Zero, Complex.Zero },
                {Complex.Zero, Complex.One, Complex.Zero, Complex.Zero },
                {Complex.Zero, Complex.Zero, Complex.One, Complex.Zero },
                {Complex.Zero,Complex.Zero, Complex.Zero, -Complex.One }
            });

            _name = "CZ";

            _countStates = 2;

            SetDefaultRules();
        }

        public Gate CreateInstance()
        {
            return new CZGate();
        }
    }
}
