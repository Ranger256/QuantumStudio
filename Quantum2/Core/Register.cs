using System;

namespace Quantum2.Core
{
    public class Register
    {
        private int _N;

        private bool[] _bits;

        private long _value;

        public bool[] Bits
        {
            get
            {
                return _bits;
            }
        }

        public long Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }

        public Register(int N)
        {
            _bits = new bool[N];
        }

        public void SetCount(int N)
        {
            if (N <= 0)
            {
                throw new Exception("N must be greater than 0");
            }

            Array.Resize<bool>(ref _bits, N);

            if (_N > N)
            {
                for (int i = _N; i < N; i++)
                {
                    _bits[i] = false;
                }
            }

            _N = N;
        }

        public void SetBit(uint index, bool bit)
        {
            _bits[index] = bit;
        }

        public override string ToString()
        {
            string result = "Count Bits: " + _bits.Length + Environment.NewLine;

            for(int i = 0; i < _bits.Length;i++)
            {
                result += "Bit " + i + ": " + Convert.ToByte(_bits[i]) + Environment.NewLine;
            }

            return result;
        }
    }
}
