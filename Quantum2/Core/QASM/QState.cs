using System.Collections.Generic;

namespace Quantum2.Core.QASM
{
    public class QState
    {
        private Matrix _state;
        private Qubit[] _qubits;
        private int _countQubits;

        public Matrix State
        {
            get
            {
                return _state;
            }
            set
            {
                _state = value;
            }
        }

        public Qubit[] Qubits
        {
            get
            {
                return _qubits;
            }
            set
            {
                _qubits = value;
            }
        }

        public int CountQubits
        {
            get
            {
                return _countQubits;
            }
            set
            {
                _countQubits = value;
            }
        }

        public QState()
        {
        }

        public void SetStateByQRegister(QRegister qRegister)
        {
            _state = qRegister.StateMatrix;
            _qubits = qRegister.Qubits;
            _countQubits = qRegister.N;
        }

        public override string ToString()
        {
            string result = "CountQubits: " + _countQubits.ToString();

            result += System.Environment.NewLine + "Matrix:" + System.Environment.NewLine + _state.ToString();

            return result;
        }
    }
}
