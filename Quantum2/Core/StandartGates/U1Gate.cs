using System;
using System.Numerics;

namespace Quantum2.Core.StandartGates
{
    public class U1Gate : Gate, IGateFactory
    {
        public U1Gate() : base()
        {
            _args = new double[1] { 0 };

            _matrix = new Matrix(new Complex[,]
            {
                 {Complex.One , Complex.Zero},
                 {Complex.Zero, Complex.Exp( new Complex(0,_args[0]) ) }
            });

            _name = "U1";

            _countStates = 1;

            SetDefaultRules();
        }

        public Gate CreateInstance()
        {
            return new U1Gate();
        }

        protected override void CSA()
        {
            _matrix.Set(0, 0, Complex.One);
            _matrix.Set(0, 1, Complex.Zero);
            _matrix.Set(1, 0, Complex.Zero);
            _matrix.Set(1, 1, Complex.Exp(new Complex(0, _args[0])));

            /*_matrix = new Matrix(new Complex[,]
            {
                 {Complex.One , Complex.Zero},
                 {Complex.Zero, Complex.Exp( new Complex(0,_args[0]) ) }
            });*/
        }
    }
}
