using System;

namespace Quantum2.Core.ImageProcessing
{
    [Serializable]
    class QImageData
    {
        public int _width;
        public int _height;

        public Qubit[] _qubits;

        public double _normCoef;
    }
}
