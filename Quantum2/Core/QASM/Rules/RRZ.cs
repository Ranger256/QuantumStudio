using System;
using System.Numerics;

namespace Quantum2.Core.QASM.Rules
{
    public class RRZ : Rule
    {
        public RRZ() : base()
        {
            _args = new double[] { 0 };

            Complex td2 = new Complex(0, _args[0] / 2);

            _matrixRule = new Matrix(new Complex[,]
            {
                {Complex.Exp(td2), 0 },
                {0, Complex.Exp(-td2) }
            });

            _states = new QState[1];
        }

        public override void Update()
        {
            Complex td2 = new Complex(0, _args[0] / 2);

            _matrixRule.Set(0, 0, Complex.Exp(td2));
            _matrixRule.Set(0, 1, 0);
            _matrixRule.Set(1, 0, 0);
            _matrixRule.Set(1, 1, Complex.Exp(-td2));
        }

        public new static Rule Instance()
        {
            return new RRZ();
        }
    }
}