using System;
using System.Numerics;

namespace Quantum2.Core.QASM.Rules
{
    public class RU2 : Rule
    {
        public RU2() : base()
        {
            _args = new double[] { 0,0 };

            _matrixRule = new Matrix(new Complex[,]
            {
                { new Complex(1 / Math.Sqrt(2), 0 ), -Complex.Exp(new Complex(0, _args[1])) / Math.Sqrt(2) },
                { Complex.Exp(new Complex(0, _args[0])) / Math.Sqrt(2), Complex.Exp(new Complex(0, _args[0] + _args[1])) / Math.Sqrt(2) }
            });

            _states = new QState[1];
        }

        public override void Update()
        {
            _matrixRule.Set(0, 0, new Complex(1 / Math.Sqrt(2), 0));
            _matrixRule.Set(0, 1, -Complex.Exp(new Complex(0, _args[1])) / Math.Sqrt(2));
            _matrixRule.Set(1, 0, Complex.Exp(new Complex(0, _args[0])) / Math.Sqrt(2));
            _matrixRule.Set(1, 1, Complex.Exp(new Complex(0, _args[0] + _args[1])) / Math.Sqrt(2));
        }

        public new static Rule Instance()
        {
            return new RU2();
        }
    }
}