using System.Numerics;

namespace Quantum2.Core.QASM.Rules
{
    public class RZ : Rule
    {
        public RZ() : base()
        {
            _matrixRule = new Matrix(new Complex[,]{
                {Complex.One, Complex.Zero },
                {Complex.Zero, -1 * Complex.One}
            });

            _states = new QState[1];
        }

        public static new Rule Instance()
        {
            return new RZ();
        }
    }
}
