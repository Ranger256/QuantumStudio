using System;
using System.Numerics;

namespace Quantum2.Core
{
    [Serializable]
    public sealed class Qubit
    {
        private Complex _alpha;
        private Complex _beta;

        public Complex Alpha
        {
            get
            {
                return _alpha;
            }
        }

        public Complex Beta
        {
            get
            {
                return _beta;
            }
        }

        public static Qubit Zero
        {
            get
            {
                return new Qubit();
            }
        }

        public static Qubit One
        {
            get
            {
                return new Qubit(Complex.Zero, Complex.One);
            }
        }

        public Qubit()
        {
            _alpha = Complex.One;
            _beta = Complex.Zero;
        }

        public Qubit(Complex alpha, Complex beta)
        {
            _alpha = alpha;
            _beta = beta;
        }

        public void Normalization()
        {
            double norm = Math.Sqrt( Math.Pow(_alpha.Magnitude, 2) + Math.Pow(_beta.Magnitude, 2));

            _alpha = _alpha / norm;
            _beta = _beta / norm;
        }

        public void Set(Complex alpha, Complex beta)
        {
            _alpha = alpha;
            _beta = beta;
        }
        public void Set(Complex alpha, double realBeta)
        {
            double imag = Math.Sqrt(1 - (Math.Pow(alpha.Magnitude, 2)) - Math.Pow(realBeta, 2));

            _alpha = alpha;
            _beta = new Complex(realBeta, imag);
        }
        public void Set(double realAlpha, Complex beta)
        {
            double imag = Math.Sqrt(1 - Math.Pow(beta.Magnitude, 2) - Math.Pow(realAlpha, 2));

            _alpha = new Complex(realAlpha, imag);
            _beta = beta;
        }

        //set alpha complex beta real
        public void SetACBR(Complex alpha, double realBeta)
        {
            double imag = Math.Sqrt(1 - (Math.Pow(alpha.Magnitude, 2)) - Math.Pow(realBeta, 2));

            _alpha = alpha;
            _beta = new Complex(realBeta, imag);
        }

        //set alpha real beta complex
        public void SetARBC(double realAlpha, Complex beta)
        {
            double imag = Math.Sqrt( 1 - Math.Pow(beta.Magnitude, 2) - Math.Pow(realAlpha, 2));

            //Console.WriteLine( Math.Pow( new Complex(realAlpha, imag).Magnitude, 2) + Math.Pow(beta.Magnitude, 2) + "GHG");

            _alpha = new Complex(realAlpha, imag);
            _beta = beta;
        }

        public Matrix ToMatrix()
        {
            Matrix resultMatrix = new Matrix(2, 1);

            resultMatrix.Set(0, 0, _alpha);
            resultMatrix.Set(1, 0, _beta);

            return resultMatrix;
        }

        public static Matrix operator* (Qubit qubit0, Qubit qubit1)
        {
            Matrix matrix = new Matrix(4, 1);

            matrix.Set(0, 0, qubit0.Alpha * qubit1.Alpha);
            matrix.Set(1, 0, qubit0.Alpha * qubit1.Beta);
            matrix.Set(2, 0, qubit0.Beta * qubit1.Alpha);
            matrix.Set(3, 0, qubit0.Beta * qubit1.Beta);

            return matrix;
        }

        public static Matrix TensorProduct(Qubit[] qubits)
        {
            if (qubits == null || qubits.Length == 0)
            {
                throw new ArgumentException("Array of qubits cannot be null or empty.");
            }

            Matrix result = qubits[0].ToMatrix();

            for (int i = 1; i < qubits.Length; i++)
            {
                result = Matrix.TensorMul(result, qubits[i].ToMatrix());
            }

            return result;
        }

        public override string ToString()
        {
            string result = "Alpha: " + _alpha.ToString() + Environment.NewLine;

            result += "Beta" + _beta.ToString();

            return result;
        }
    }
}
