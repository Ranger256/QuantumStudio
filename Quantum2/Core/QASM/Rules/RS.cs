using System;
using System.Numerics;

namespace Quantum2.Core.QASM.Rules
{
    public class RS : Rule
    {

        public RS() : base()
        {
            Complex ip8 = new Complex(0, Math.PI / 8);

            _matrixRule = new Matrix(new Complex[,]
            {
                {Complex.One, Complex.Zero },
                {Complex.Zero, Complex.ImaginaryOne }
            });

            _states = new QState[1];
        }

        public static new Rule Instance()
        {
            return new RS();
        }
    }
}
