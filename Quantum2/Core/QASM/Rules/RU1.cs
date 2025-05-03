using System;
using System.Numerics;

namespace Quantum2.Core.QASM.Rules
{
    public class RU1 : Rule
    {
        public RU1() : base()
        {
            _args = new double[] { 0 };

            _matrixRule = new Matrix(new Complex[,]
            {
                {Complex.One , Complex.Zero},
                 {Complex.Zero, Complex.Exp( new Complex(0,_args[0]) ) }
            });

            _states = new QState[1];
        }

        public override void Update()
        {
            _matrixRule.Set(0, 0, Complex.One);
            _matrixRule.Set(0, 1, Complex.Zero);
            _matrixRule.Set(1, 0, Complex.Zero);
            _matrixRule.Set(1, 1, Complex.Exp(new Complex(0, _args[0])));
        }

        public new static Rule Instance()
        {
            return new RU1();
        }
    }
}
