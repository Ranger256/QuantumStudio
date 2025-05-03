using System;
using System.Numerics;

namespace Quantum2.Core.QASM.Rules
{
    public class RH : Rule
    {
        public RH() : base()
        {
            Complex oneDivSqrt2 = new Complex(1 / Math.Sqrt(2), 0);

            _matrixRule = new Matrix(new Complex[,] {
                { oneDivSqrt2, oneDivSqrt2},
                {oneDivSqrt2, -1 * oneDivSqrt2 }
            });

            _states = new QState[1];
        }

        public static new Rule Instance()
        {
            return new RH();
        }
    }
}
