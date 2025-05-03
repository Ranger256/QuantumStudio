using System;
using System.Numerics;

namespace Quantum2.Core.StandartGates
{
    class RkGate : Gate, IGateFactory
    {
        public RkGate() : base()
        {
            _args = new double[] { 0 };

            //Complex alpha = Complex.Cos(arg0) * qubit.Alpha + Complex.Sin(arg0) * qubit.Beta;
            //Complex beta = -Complex.Sin(arg0) * qubit.Alpha + Complex.Cos(arg0) * qubit.Beta;

            _matrix = new Matrix(new Complex[,] {
                { Math.Cos(_args[0]), Math.Sin(_args[0]) },
                { -Math.Sin(_args[0]), Math.Cos(_args[0]) }
            });

            _name = "Rk";

            _countStates = 1;

            SetDefaultRules();
        }

        public Gate CreateInstance()
        {
            return new RkGate();
        }
    }
}
