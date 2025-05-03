using System;
using System.Linq;

namespace Quantum2.Core.QASM
{
    public class Rule
    {
        protected Matrix _matrixRule;

        protected QState[] _states;

        protected double[] _args;

        public Rule()
        {

        }

        public void Apply()
        {
            Update();

            Matrix generalState = _states[0].State;

            Qubit[] qubits = _states[0].Qubits;

            int countQubits = _states[0].CountQubits;

            int countQubitsV = _states[_states.Length - 1].CountQubits;

            for(int i = 1; i < _states.Length;i++)
            {
                // countQubits += _states[i].CountQubits;
                qubits = qubits.Concat(_states[i].Qubits).ToArray();

                generalState = Matrix.TensorMul(generalState, _states[i].State);
            }

            Matrix matrixRule = Gate.EqDimRegs( _matrixRule, countQubitsV);

            matrixRule = Gate.EqDim(matrixRule, generalState.M);

            generalState = matrixRule * generalState;

            for (int i = 0; i < _states.Length;i++)
            {
                _states[i].CountQubits = countQubits;
                _states[i].Qubits = qubits;
                _states[i].State = generalState;
            }
        }

        public void SetState(QState matrix, uint indexState)
        {
            if (matrix == null)
                Console.WriteLine("NULL MATRIX");

            if (_states == null)
                Console.WriteLine("NULL STATES");

            _states[indexState] = matrix;
        }

        public void SetArg(double arg, uint indexArg)
        {
            _args[indexArg] = arg;
        }

        public virtual void Update()
        {

        }

        public static Rule Instance()
        {
            return new Rule();
        }
    }
}
