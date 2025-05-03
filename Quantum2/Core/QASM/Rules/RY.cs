using System.Numerics;

namespace Quantum2.Core.QASM.Rules
{
    public class RY : Rule
    {

        public RY() : base()
        {
            _matrixRule = new Matrix(new Complex[,]{
                {Complex.Zero, -1 * Complex.ImaginaryOne },
                {Complex.ImaginaryOne, Complex.Zero }
            });

            _states = new QState[1];
        }

        public static new Rule Instance()
        {
            return new RY();
        }
    }
}
