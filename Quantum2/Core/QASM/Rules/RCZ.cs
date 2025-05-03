using System;
using System.Numerics;

namespace Quantum2.Core.QASM.Rules
{
    public class RCZ : Rule
    {
        public RCZ() : base()
        {
            _matrixRule = new Matrix(new Complex[,]
            {
                {Complex.One, Complex.Zero, Complex.Zero, Complex.Zero },
                {Complex.Zero, Complex.One, Complex.Zero, Complex.Zero },
                {Complex.Zero, Complex.Zero, Complex.One, Complex.Zero },
                {Complex.Zero,Complex.Zero, Complex.Zero, -Complex.One }
            });

            _states = new QState[2];
        }

        public new static Rule Instance()
        {
            return new RCZ();
        }
    }
}
