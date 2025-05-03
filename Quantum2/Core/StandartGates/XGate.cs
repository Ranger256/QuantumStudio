using System.Numerics;

namespace Quantum2.Core.StandartGates
{
    public class XGate : Gate, IGateFactory
    {
        public static readonly XGate X = new XGate();

        public XGate() : base()
        {
            _matrix = new Matrix(new Complex[,] 
            {
                {Complex.Zero, Complex.One },
                {Complex.One, Complex.Zero }
            }
            );

            _name = "X";

            _countStates = 1;

            SetDefaultRules();
        }

        public Gate CreateInstance()
        {
            return new XGate();
        }
    }
}
