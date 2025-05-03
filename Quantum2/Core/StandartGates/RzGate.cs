using System;
using System.Numerics;

namespace Quantum2.Core.StandartGates
{
    public class RzGate : Gate, IGateFactory
    {
        public RzGate() : base()
        {
            _args = new double[1] { 0 };

            Complex td2 = new Complex(0, _args[0] / 2);

            _matrix = new Matrix(new Complex[,]
            {
                {Complex.Exp(td2), 0 },
                {0, Complex.Exp(-td2) }
            });

            _name = "Rz";

            _countStates = 1;

            SetDefaultRules();
        }

        public Gate CreateInstance()
        {
            return new RzGate();
        }

        protected override void CSA()
        {
            Complex td2 = new Complex(0, _args[0] / 2);

            _matrix.Set(0, 0, Complex.Exp(td2));
            _matrix.Set(0, 1, 0);
            _matrix.Set(1, 0, 0);
            _matrix.Set(1, 1, Complex.Exp(-td2));

            /*_matrix = new Matrix(new Complex[,]
            {
                {Complex.Exp(td2), 0 },
                {0, Complex.Exp(-td2) }
            });*/
        }
    }
}
