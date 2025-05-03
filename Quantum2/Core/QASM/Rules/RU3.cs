using System;
using System.Numerics;

namespace Quantum2.Core.QASM.Rules
{
    public class RU3 : Rule
    {
        public RU3() : base()
        {
            _args = new double[] { 0, 0,0 };

            _matrixRule = new Matrix(new Complex[,]
            {
                 {new Complex(_args[0] / 2, 0), -Complex.Exp(new Complex(0, _args[2])) * Math.Sin(_args[0] / 2) },
                {Complex.Exp(new Complex(0, _args[1])) * Math.Sin(_args[0]), Complex.Exp(new Complex(0, _args[1] +_args[2])) * Math.Cos(_args[0] / 2) }
            });

            _states = new QState[1];
        }

        public override void Update()
        {
            _matrixRule.Set(0, 0, _args[0] / 2);
            _matrixRule.Set(0, 1, -Complex.Exp(new Complex(0, _args[2])) * Math.Sin(_args[0] / 2));
            _matrixRule.Set(1, 0, Complex.Exp(new Complex(0, _args[1])) * Math.Sin(_args[0]));
            _matrixRule.Set(1, 1, Complex.Exp(new Complex(0, _args[1] + _args[2])) * Math.Cos(_args[0] / 2));
        }

        public new static Rule Instance()
        {
            return new RU3();
        }
    }
}
