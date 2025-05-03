using System;
using System.Numerics;

using Quantum2.Core.ImageProcessing;

namespace Quantum2.Core.Cryptography
{
    public class QXOR
    {
        public static double XORd(double a, double b)
        {
            unsafe
            {
                long* aptr = (long*) & a;
                long* bptr = (long*) & b;
                long xor = *aptr ^ *bptr;
                double* xorptr = (double*) & xor;
                return *xorptr;
            }
        }

        public static Complex XORc(Complex c0, Complex c1)
        {
            return new Complex(XORd(c0.Real, c1.Real), XORd(c0.Imaginary, c1.Imaginary));
        }

        public static Qubit XORq(Qubit q0, Qubit q1)
        {
            return new Qubit(XORc(q0.Alpha, q1.Alpha), XORc(q0.Beta, q1.Beta));
        }

        public static Qubit[] XORqs(Qubit[] q0, Qubit[] q1)
        {
            if (q0.Length != q1.Length)
                throw new Exception("The length of the first array must be equal to the length of the second array");

            Qubit[] resultQubits = new Qubit[q0.Length];

            for(int i = 0;i < q0.Length;i++)
            {
                Qubit q2 = XORq(q0[i], q1[i]);

                resultQubits[i] = q2;
            }

            return resultQubits;
        }

        public static QImage XORqImage(QImage qImageArg, QImage key)
        {
            if (qImageArg.Width != key.Width || qImageArg.Height != key.Height)
                throw new Exception("The sizes of quantum images must be equal to");

            QImage qImage = new QImage(qImageArg.Width, qImageArg.Height);

            qImage.Qubits = XORqs(qImageArg.Qubits, key.Qubits);

            return qImage;
        }

        public static string DoubleToBinaryString(double val)
        {
            long v = BitConverter.DoubleToInt64Bits(val);
            string binary = Convert.ToString(v, 2);
            return binary.PadLeft(64, '0').Insert(12, ":").Insert(1, ":");
        }
    }
}
