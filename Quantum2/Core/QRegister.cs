using System;

namespace Quantum2.Core
{
    public class QRegister
    {
        private int _N;
        private Qubit[] _qubits;

        private Matrix _stateMatrix;

        public int N
        {
            get
            {
                return _N;
            }
        }

        public Qubit[] Qubits
        {
            get
            {
                return _qubits;
            }
        }

        public Matrix StateMatrix
        {
            get
            {
                return _stateMatrix;
            }
        }

        public QRegister(int N)
        {
            if(N <= 0)
            {
                throw new Exception("N must be greater than 0");
            }

            _N = N;
            _qubits = new Qubit[N];

            for(int i = 0; i < _qubits.Length; i++)
            {
                _qubits[i] = Qubit.Zero;
            }

            Update();
        }

        public QRegister(Qubit[] qubits)
        {
            if(qubits.Length <= 0)
            {
                throw new Exception("N must be greater than 0");
            }

            _N =  qubits.Length;
            _qubits = qubits;

            Update();
        }

        public void Set(int indexQubit, Qubit qubit)
        {
            _qubits[indexQubit] = qubit;
            Update();
        }

        public void SetCount(int N)
        {
            if (N <= 0)
            {
                throw new Exception("N must be greater than 0");
            }

            Array.Resize<Qubit>(ref _qubits, N);

            if(N > _N)
            {
                for(int i = _N; i < N; i++)
                {
                    _qubits[i] = Qubit.Zero;
                }
            }

            _N = N;

            Update();
        }

        public Qubit Get(int indexQubit)
        {
            return _qubits[indexQubit];
        }
        
        public Qubit Get(ulong indexQubit)
        {
            return _qubits[indexQubit];
        }

        private void Update()
        {
            _stateMatrix = Qubit.TensorProduct(_qubits);
        }

        public override string ToString()
        {
            string result = "Register:" + Environment.NewLine;

            for(int i = 0; i < _qubits.Length;i++)
            {
                result += "Qubit: " + Environment.NewLine + _qubits[i].ToString() + Environment.NewLine;
            }

            result += "End register";

            return result;
        }

    }
}
