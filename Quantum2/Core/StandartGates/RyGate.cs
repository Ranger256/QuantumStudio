using System;
using System.Numerics;

namespace Quantum2.Core.StandartGates
{
    public class RyGate : Gate, IGateFactory
    {
        public RyGate() : base()
        {
            _args = new double[1] { 0};

            Complex d0 = new Complex(Math.Cos( _args[0] /2), 0);
            Complex d1 = new Complex(Math.Sin(_args[0] / 2), 0);

            _matrix = new Matrix(new Complex[,]{
                {d0,-d1 },
                {d1, d0 }
            });

            _name = "Ry";

            _countStates = 1;

            SetDefaultRules();
        }

        public Gate CreateInstance()
        {
            return new RyGate();
        }

        protected override void CSA()
        {
            Complex d0 = new Complex(Math.Cos(_args[0] / 2), 0);
            Complex d1 = new Complex(Math.Sin(_args[0] / 2), 0);

            _matrix.Set(0, 0, d0);
            _matrix.Set(0, 1, -d1);
            _matrix.Set(1, 0, d1);
            _matrix.Set(1, 1, d0);

           /* _matrix = new Matrix(new Complex[,]{
                {d0,-d1 },
                {d1, d0 }
            });*/
        }
    }
}
