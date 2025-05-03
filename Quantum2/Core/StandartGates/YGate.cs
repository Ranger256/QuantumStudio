using System;
using System.Numerics;

namespace Quantum2.Core.StandartGates
{
    public class YGate : Gate, IGateFactory
    {
        public YGate() : base()
        {
            _matrix = new Matrix(new Complex[,]{
                {Complex.Zero, -1 * Complex.ImaginaryOne },
                {Complex.ImaginaryOne, Complex.Zero }
            });

            _name = "Y";

            _countStates = 1;

            SetDefaultRules();
        }

        public Gate CreateInstance()
        {
            return new YGate();
        }
    }
}
