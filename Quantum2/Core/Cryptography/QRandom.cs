using System;
using System.Numerics;

namespace Quantum2.Core.Cryptography
{
    public static class QRandom
    {
        private static Random _random;

        static QRandom()
        {
            _random = new Random();
        }

        public static Qubit GenerateRandomQubit(double normCoef = 1)
        {
            double magnitudeSquareAlpha = _random.NextDouble();
            // double magnitudeSquareAlpha = 1 / n;
            double magnitudeSquareBeta = 1 - magnitudeSquareAlpha;

            //double magnitudeSquareAlpha = 0.5;
            //double magnitudeSquareBeta = 0.5;

            return new Qubit(GenerateRandomComplex(Math.Sqrt(magnitudeSquareAlpha)) * normCoef, GenerateRandomComplex(Math.Sqrt(magnitudeSquareBeta)) * normCoef);
        }
        public static Complex GenerateRandomComplex(double a)
        {
            //double b = (_random.NextDouble() / 500) / ((_random.NextDouble()) + 0.000001 / 300);
            //double b =  0.2;
            double b = _random.NextDouble() / 800;

            double real = Math.Sqrt(Math.Abs(a * a - b * b));
            // double real = Math.Sqrt(Math.Abs(a * a));
            double imag = Math.Sqrt(Math.Abs(a * a - real * real));

            return new Complex(real, imag);
        }
    }
}
