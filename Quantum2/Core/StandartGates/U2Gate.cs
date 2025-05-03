using System;
using System.Numerics;

namespace Quantum2.Core.StandartGates
{
    public class U2Gate : Gate, IGateFactory
    {
        public U2Gate() : base()
        {
            _args = new double[2] { 0,0 };

            _matrix = new Matrix(new Complex[,] {
                { new Complex(1 / Math.Sqrt(2), 0 ), -Complex.Exp(new Complex(0, _args[1])) / Math.Sqrt(2) },
                { Complex.Exp(new Complex(0, _args[0])) / Math.Sqrt(2), Complex.Exp(new Complex(0, _args[0] + _args[1])) / Math.Sqrt(2) }
            });

            _name = "U2";

            _countStates = 1;

            SetDefaultRules();
        }

        public Gate CreateInstance()
        {
            return new U2Gate();
        }

        protected override void CSA()
        {
            _matrix.Set(0, 0, new Complex(1 / Math.Sqrt(2), 0));
            _matrix.Set(0, 1, -Complex.Exp(new Complex(0, _args[1])) / Math.Sqrt(2));
            _matrix.Set(1, 0, Complex.Exp(new Complex(0, _args[0])) / Math.Sqrt(2));
            _matrix.Set(1, 1, Complex.Exp(new Complex(0, _args[0] + _args[1])) / Math.Sqrt(2));

            /*_matrix = new Matrix(new Complex[,] {
                { new Complex(1 / Math.Sqrt(2), 0 ), -Complex.Exp(new Complex(0, _args[1])) / Math.Sqrt(2) },
                { Complex.Exp(new Complex(0, _args[0])) / Math.Sqrt(2), Complex.Exp(new Complex(0, _args[0] + _args[1])) / Math.Sqrt(2) }
            });*/
        }
    }
}
