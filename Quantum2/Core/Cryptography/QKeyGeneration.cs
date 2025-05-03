using System;
using System.Numerics;

using Quantum2.Core.ImageProcessing;

namespace Quantum2.Core.Cryptography
{
    public static class QKeyGeneration
    {
        public static Qubit[] CubitKeyGeneration(int N)
        {
            Qubit[] qubits = new Qubit[N];

            double normCoef = 1 / Math.Sqrt(N);

            for (int i = 0; i < N; i++)
            {
                qubits[i] = QRandom.GenerateRandomQubit();
            }

            return qubits;
        }

        public static QImage QImageKeyGeneration(int width, int height)
        {
            QImage qImage = new QImage(width, height);

            qImage.Qubits = CubitKeyGeneration(width * height);

            return qImage;
        }
    }
}
