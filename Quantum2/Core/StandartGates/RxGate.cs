using System;
using System.Numerics;

namespace Quantum2.Core.StandartGates
{
    class RxGate : Gate, IGateFactory
    {
        public RxGate() : base()
        {
            _args = new double[] { 0};

            Complex d0 = new Complex(Math.Cos(_args[0] / 2), 0);
            Complex d1 = new Complex(0, -Math.Sin(_args[0] / 2));

            _matrix = new Matrix(new Complex[,] {
                {d0, d1 },
                {d1, d0 }
            });

            _name = "Rx";

            _countStates = 1;

            SetDefaultRules();
        }

        public Gate CreateInstance()
        {
            return new RxGate();
        }

        protected override void CSA()
        {
            Complex d0 = new Complex(Math.Cos(_args[0] / 2), 0);
            Complex d1 = new Complex(0, -Math.Sin(_args[0] / 2));

            _matrix.Set(0, 0, d0);
            _matrix.Set(0, 1, d1);
            _matrix.Set(1, 0, d1);
            _matrix.Set(1, 1, d0);

            /*_matrix = new Matrix(new Complex[,] {
                {d0, d1 },
                {d1, d0 }
            });*/
        }
    }
}
