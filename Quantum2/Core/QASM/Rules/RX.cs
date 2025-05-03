using System.Numerics;

namespace Quantum2.Core.QASM.Rules
{
    public class RX : Rule
    {
        public RX() : base()
        {
            _matrixRule = new Matrix(new Complex[,]
            {
                {Complex.Zero, Complex.One },
                {Complex.One, Complex.Zero }
            }
            );

            _states = new QState[1];
        }

        public new static Rule Instance()
        {
            return new RX();
        }
    }
}
