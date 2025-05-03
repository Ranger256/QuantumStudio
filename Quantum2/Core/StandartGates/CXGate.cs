using System.Numerics;

namespace Quantum2.Core.StandartGates
{
    class CXGate : Gate, IGateFactory
    {
        public CXGate() : base()
        {
            _matrix = new Matrix(new Complex[,] 
            {
                { Complex.One, Complex.Zero, Complex.Zero, Complex.Zero },
                {Complex.Zero, Complex.One, Complex.Zero, Complex.Zero },
                {Complex.Zero, Complex.Zero, Complex.Zero, Complex.One },
                {Complex.Zero,Complex.Zero, Complex.One, Complex.Zero }
            });

            _name = "CX";

            _countStates = 2;

            SetDefaultRules();
        }

        public Gate CreateInstance()
        {
            return new CXGate();
        }

       /* public override void EqualizeDimension(int dimensionState)
        {
            //base.EqualizeDimension(dimensionState);

            System.Console.WriteLine("RR" + Matrix.TensorMul( Matrix.GetI(dimensionState / _matrix.N), _matrix));

            if (_matrix.N != dimensionState)
            {
                _matrix = new Matrix(new Complex[,]
                {
                { Complex.One, Complex.Zero, Complex.Zero, Complex.Zero, Complex.Zero, Complex.Zero, Complex.Zero, Complex.Zero },
                {Complex.Zero, Complex.Zero, Complex.One, Complex.Zero , Complex.Zero, Complex.Zero, Complex.Zero, Complex.Zero },
                {Complex.Zero, Complex.One, Complex.Zero, Complex.Zero, Complex.Zero, Complex.Zero, Complex.Zero, Complex.Zero },
                {Complex.Zero,Complex.Zero, Complex.Zero, Complex.One , Complex.Zero, Complex.One, Complex.Zero, Complex.Zero},
                {Complex.Zero, Complex.Zero, Complex.Zero, Complex.Zero , Complex.Zero, Complex.Zero, Complex.Zero, Complex.Zero},
                {Complex.Zero, Complex.Zero, Complex.Zero, Complex.Zero , Complex.Zero, Complex.Zero, Complex.Zero, Complex.Zero},
                {Complex.Zero, Complex.Zero, Complex.Zero, Complex.Zero , Complex.One, Complex.Zero, Complex.Zero, Complex.One},
                {Complex.Zero,Complex.Zero, Complex.Zero, Complex.Zero , Complex.Zero, Complex.Zero, Complex.One, Complex.Zero}
                });
            }
        }*/
    }
}
