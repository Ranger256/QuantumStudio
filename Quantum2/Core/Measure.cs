using System;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;

namespace Quantum2.Core
{
    public class Measure
    {
        private Dictionary<int, byte> _mBits;

        private double[] _probabilities;

        private Random _random;

        public Dictionary<int, byte> MBits
        {
            get
            {
                return _mBits;
            }
        }

        public double[] Probilities
        {
            get
            {
                return _probabilities;
            }
        }

        public Measure()
        {
            _mBits =new Dictionary<int, byte>();

            _probabilities = new double[0];

            _random = new Random();
        }

        public void Take(Matrix state, int[] numbersOfmeasuredQRegisters)
        {
            if (Math.Pow(2, numbersOfmeasuredQRegisters.Length) > state.M)
                throw new Exception("The number of measured qubits should not be greater than the number of qubits in the state matrix");

            _probabilities = new double[state.M];

            for (int i = 0; i < state.M; i++)
            {
                _probabilities[i] = Math.Pow( state.Get(i, 0).Magnitude, 2);
            }

            NormalizeProbabilities(ref _probabilities);

            NBBToMRS(NumberToBinaryBytes(PlayNumbersOfTheProbabilities(_probabilities, _random)), numbersOfmeasuredQRegisters);
        }

        public void Take(Matrix state,Qubit[] qubits, int countQubits, Register register)
        {
            if (Math.Pow(2, countQubits) > state.M)
                throw new Exception("The number of measured qubits should not be greater than the number of qubits in the state matrix");

            _probabilities = new double[state.M];

            for (int i = 0; i < state.M; i++)
            {
                _probabilities[i] = Math.Pow(state.Get(i, 0).Magnitude, 2);
            }

            NormalizeProbabilities(ref _probabilities);

            int measureResult = PlayNumbersOfTheProbabilities(_probabilities, _random);

            byte[] bits = NumberToBinaryBytes(measureResult);

            SetResultRegister(register,measureResult,bits);

            CollapseQubitsAndState(qubits,state,measureResult, bits);
        }

        public static void CollapseQubitsAndState(Qubit[] qubits, Matrix state,int measureResult, byte[] bits)
        {
            for(int i = 0;i < qubits.Length;i++)
            {
                if (i >= bits.Length)
                {
                    qubits[i].Set(Complex.One, Complex.Zero);
                }
                else
                {
                    if(bits[i] == 0)
                    {
                        qubits[i].Set(Complex.One, Complex.Zero);
                    }
                    else
                    {
                        qubits[i].Set(Complex.Zero, Complex.One);
                    }
                }
            }

            for(int i = 0; i < state.M;i++)
            {
                state.Set(i, 0, 0);
            }

            state.Set(measureResult, 0, 1);
        }

        public static void SetResultRegister(Register register,int measureResult, byte[] bits)
        {
            register.Value = measureResult;

            for (uint i = 0; i < register.Bits.Length; i++)
            {
                if (i >= bits.Length)
                {
                    register.SetBit(i, false);
                }
                else
                {
                    bool bit = bits[i] != 0;

                    register.SetBit(i, bit);
                }
            }
        }

        public static byte[] NumberToBinaryBytes(int number)
        {
            byte[] result = new byte[Log2(number) + 1];

            for(int i = 0; i < result.Length;i++)
            {
                result[i] = (byte)(number % 2);
                number /= 2;
            }

            return result;
        }

        public static int Log2(int value)
        {
            int i;
            for (i = -1; value != 0; i++)
                value >>= 1;

            return (i == -1) ? 0 : (value < 1U << i) ? i : i + 1;
        }

        public static int PlayNumbersOfTheProbabilities(double[] probabilities, Random random)
        {
            double rndval = random.NextDouble();

            for (int i = 0; i < probabilities.Length; i++)
                if (probabilities[i] > rndval)
                    return i;
            return 0;
        }

        public static void NormalizeProbabilities(ref double[] vers)
        {
            double sum = vers.Sum();

            vers[0] /= sum;

            for (int i = 1; i < vers.Length; i++)
            {
                vers[i] = vers[i] / sum + vers[i - 1];
            }

            vers[vers.Length - 1] = 1.0;
        }

        private void NBBToMRS(byte[] nbbs, int[] numbersMQRs)
        {
            _mBits.Clear();

            for (int i = 0; i < numbersMQRs.Length; i++)
            {
                if (numbersMQRs[i] >= nbbs.Length)
                {
                    _mBits.Add(numbersMQRs[i], 0);
                }
                else
                {
                    _mBits.Add(numbersMQRs[i], nbbs[numbersMQRs[i]]);
                }
            }
        }
    }
}
