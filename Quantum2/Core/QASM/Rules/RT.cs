using System;
using System.Numerics;

namespace Quantum2.Core.QASM.Rules
{
    public class RT : Rule
    {

        public RT() : base()
        {
            Complex ip8 = new Complex(0, Math.PI / 8);

            _matrixRule = new Matrix(new Complex[,]
            {
                {Complex.Exp(-ip8), 0 },
                {0, Complex.Exp(ip8)}
            });

            _states = new QState[1];
        }

        public static new Rule Instance()
        {
            return new RT();
        }
    }
}
