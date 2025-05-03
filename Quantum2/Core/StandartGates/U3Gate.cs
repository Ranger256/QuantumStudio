using System;
using System.Numerics;

namespace Quantum2.Core.StandartGates
{
    public class U3Gate : Gate, IGateFactory
    {
        public U3Gate() : base()
        {
            _args = new double[3] { 0,0,0 };

            _matrix = new Matrix(new Complex[,]
            {
                {new Complex(_args[0] / 2, 0), -Complex.Exp(new Complex(0, _args[2])) * Math.Sin(_args[0] / 2) },
                {Complex.Exp(new Complex(0, _args[1])) * Math.Sin(_args[0]), Complex.Exp(new Complex(0, _args[1] +_args[2])) * Math.Cos(_args[0] / 2) }
            });

            _name = "U3";

            _countStates = 1;

            SetDefaultRules();
        }

        public Gate CreateInstance()
        {
            return new U3Gate();
        }

        protected override void CSA()
        {
            _matrix.Set(0, 0,_args[0] / 2);
            _matrix.Set(0, 1, -Complex.Exp(new Complex(0, _args[2])) * Math.Sin(_args[0] / 2));
            _matrix.Set(1, 0, Complex.Exp(new Complex(0, _args[1])) * Math.Sin(_args[0]));
            _matrix.Set(1, 1, Complex.Exp(new Complex(0, _args[1] + _args[2])) * Math.Cos(_args[0] / 2));

           /* _matrix = new Matrix(new Complex[,]
           {
                {new Complex(_args[0] / 2, 0), -Complex.Exp(new Complex(0, _args[2])) * Math.Sin(_args[0] / 2) },
                {Complex.Exp(new Complex(0, _args[1])) * Math.Sin(_args[0]), Complex.Exp(new Complex(0, _args[1] +_args[2])) * Math.Cos(_args[0] / 2) }
           });*/
        }
    }
}
