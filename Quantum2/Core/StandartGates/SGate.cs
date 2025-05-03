using System;
using System.Numerics;

namespace Quantum2.Core.StandartGates
{
    public class SGate : Gate, IGateFactory
    {
        public SGate() : base()
        {
            _matrix = new Matrix(new Complex[,]
            {
                {Complex.One, Complex.Zero },
                {Complex.Zero, Complex.ImaginaryOne }
            });

            _name = "S";

            _countStates = 1;

            SetDefaultRules();

        }

        public Gate CreateInstance()
        {
            return new SGate();
        }
    }
}
