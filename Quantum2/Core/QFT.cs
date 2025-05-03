using System;
using System.Numerics;

namespace Quantum2.Core
{
    public static class QFT
    {
        public static readonly double _oneOfTheSquareRootOfTwo = 1 / Math.Sqrt(2); 

        public static Qubit Rk(Qubit qubit, Complex arg0)
        {
            Complex alpha = Complex.Cos(arg0) * qubit.Alpha + Complex.Sin(arg0) * qubit.Beta;
            Complex beta = -Complex.Sin(arg0) * qubit.Alpha + Complex.Cos(arg0) * qubit.Beta;

            return new Qubit(alpha, beta);
        }

        public static Qubit IRk(Qubit qubit, Complex arg0)
        {
            return Rk(qubit, -arg0);
        }

        public static Qubit QFTq(Qubit qubit)
        {
            Complex alpha = _oneOfTheSquareRootOfTwo * (qubit.Alpha + qubit.Beta);
            Complex beta = _oneOfTheSquareRootOfTwo * (qubit.Alpha - qubit.Beta);

            return new Qubit(alpha, beta);
        }

        public static Qubit InQFTq(Qubit qubit)
        {
            Complex alpha = _oneOfTheSquareRootOfTwo * (qubit.Alpha + qubit.Beta);
            Complex beta = _oneOfTheSquareRootOfTwo * (qubit.Alpha - qubit.Beta);

            return new Qubit(alpha, beta);
        }

        public static Qubit[] QFTqs(Qubit[] qubits)
        {
            int n = qubits.Length;
            Qubit[] qubitsResult = new Qubit[n];
            double normCoef = 1 / Math.Sqrt(n);

            Complex Wn = Complex.Exp((-2 * Math.PI * Complex.ImaginaryOne) / n);

            for (int k = 0; k < n; k++)
            {
                Complex a = Complex.Zero;
                Complex b = Complex.Zero;

                for (int j = 0; j < n; j++)
                {
                    Complex WnPower = Complex.Pow(Wn, j * k);

                    a += qubits[j].Alpha * WnPower * normCoef;
                    b += qubits[j].Beta * WnPower * normCoef;
                }

                qubitsResult[k] = new Qubit(a, b);
            }

            return qubitsResult;
        }

        public static Qubit[] InQFTqs(Qubit[] qubits)
        {
            int n = qubits.Length;
            Qubit[] qubitsResult = new Qubit[n];
            double normCoef = 1 / Math.Sqrt(n);

            Complex Wn = Complex.Exp((-2 * Math.PI * Complex.ImaginaryOne) / n);
            //Complex Wn = (-2 * Math.PI * Complex.ImaginaryOne) / n;

            for (int k = 0; k < n; k++)
            {
                Complex a = Complex.Zero;
                Complex b = Complex.Zero;

                for (int j = 0; j < n; j++)
                {
                    Complex WnPower = Complex.Pow(Wn, j * k);

                    a += qubits[j].Alpha * WnPower * normCoef;
                    b += qubits[j].Beta * WnPower * normCoef;
                }

                qubitsResult[k] = new Qubit(a, b);
            }

            /// Reverse the order of the qubits to maintain proper output
            //Array.Reverse(qubitsResult);

            return qubitsResult;
        }

        public static Qubit[] Reverse(Qubit[] qubits)
        {
            Qubit[] qubitsResult = new Qubit[qubits.Length];

            qubitsResult[0] = qubits[0];
            int n = qubits.Length - 1;

            for(int i = n; i > 0; i--)
            {
                qubitsResult[n + 1 - i] = qubits[i];
            }

            //qubitsResult[0] = qubits[0];

            return qubitsResult;
        }
    }
}
