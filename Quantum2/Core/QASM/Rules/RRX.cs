using System;
using System.Numerics;

namespace Quantum2.Core.QASM.Rules
{
    public class RRX : Rule
    {
        public RRX() : base()
        {
            _args = new double[] { 0 };

            Complex d0 = new Complex(Math.Cos(_args[0] / 2), 0);
            Complex d1 = new Complex(0, -Math.Sin(_args[0] / 2));

            _matrixRule = new Matrix(new Complex[,] {
                {d0, d1 },
                {d1, d0 }
            });

            _states = new QState[1];
        }

        public override void Update()
        {
            Complex d0 = new Complex(Math.Cos(_args[0] / 2), 0);
            Complex d1 = new Complex(0, -Math.Sin(_args[0] / 2));

            _matrixRule.Set(0, 0, d0);
            _matrixRule.Set(0, 1, d1);
            _matrixRule.Set(1, 0, d1);
            _matrixRule.Set(1, 1, d0);
        }

        public new static Rule Instance()
        {
            return new RRX();
        }
    }
}
