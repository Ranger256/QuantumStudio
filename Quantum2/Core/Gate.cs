using System;
using System.Collections.Generic;
using Quantum2.Core.StandartGates;

namespace Quantum2.Core
{
    public interface IGateFactory
    {
        Gate CreateInstance();
    }

    public class Gate
    {
        private static Dictionary<string, IGateFactory> _factoryGates;

        protected string _name;

        protected int _countStates;

        protected double[] _args;

        protected Matrix _matrix;

        protected Matrix[] _rules;

        public Matrix Matrix
        {
            get
            {
                return _matrix;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public int CountStates
        {
            get
            {
                return _countStates;
            }
            set
            {
                _countStates = value;
            }
        }

        public double[] Args
        {
            get
            {
                return _args;
            }
            set
            {
                _args = value;

                CSA();
            }
        }

        public Matrix[] Rules
        {
            get
            {
                return _rules;
            }
            set
            {
                _rules = value;
            }
        }

        static Gate()
        {
            _factoryGates = new Dictionary<string, IGateFactory>
            {
                { "CX", new CXGate() },
                { "CY", new CYGate() },
                { "CZ", new CXGate() },

                { "H", new HGate() },
                { "S", new SGate() },
                { "T", new TGate() },

                { "Rk", new RkGate() },
                { "Rx", new RxGate() },
                { "Ry", new RyGate() },
                { "Rz", new RzGate() },

                { "SWAP", new SWAPGate() },

                { "U1", new U1Gate() },
                { "U2", new U2Gate() },
                { "U3", new U3Gate() },

                { "X", new XGate() },
                { "Y", new YGate() },
                { "Z", new ZGate() }
            };
        }

        public Gate(Matrix matrix, string name, int countQubits, Matrix[] rules)
        {
            _matrix = matrix;
            _name = name;
            _countStates = countQubits;
            _args = null;
            _rules = rules;
        }

        public Gate(string name, int countQubits, Matrix[] rules)
        {
            _name = name;
            _countStates = countQubits;
            _rules = rules;
        }

        public Gate(string name)
        {
            _name = name;
        }

        protected Gate()
        {
            _matrix = null;
            _name = null;
            _countStates = 0;
            _args = null;
            _rules = new Matrix[0];
        }

        protected void SetDefaultRules()
        {
            _rules = new Matrix[1]
            {
                _matrix
            };
        }

        protected virtual void CSA()
        {

        }

        public static void AddGate(string name, IGateFactory gateFactory)
        {
            _factoryGates.Add(name, gateFactory);
        }

        public static Gate GetGate(string name)
        {
            return _factoryGates[name].CreateInstance();
        }
        public Matrix[] Apply(Matrix[] matrix, int s)
        {
            Matrix[] results = new Matrix[matrix.Length];

            for(int i =0; i < _rules.Length;i++)
            {
                MatrixApply(_rules[i],_countStates, ref results, matrix, s);
            }

            return results;
        }

        protected static void MatrixApply(Matrix matrixGate,int countStates, ref Matrix[] resultMatrices,Matrix[] matrices, int s)
        {
            if (countStates != matrices.Length)
                throw new Exception("The number of inputs of the gate, should correspond to the number of incoming matrices");

            if (matrixGate != null)
            {
                Matrix generalState = matrices[0];          

                for (int i = 1; i < matrices.Length; i++)
                {
                    if (generalState.M == s)
                        break;

                    generalState = Matrix.TensorMul(generalState, matrices[i]);
                }

                EqualizeDimension(ref matrixGate,generalState.M);

                Matrix matrixResult = matrixGate *  generalState ;

                for (int i = 0; i < resultMatrices.Length; i++)
                {
                    resultMatrices[i] = matrixResult;
                }
            }

        }

        public void EqualizeDimensionRegisters(int dmr)
        {
            dmr--;

            for (int j = 0; j < _rules.Length; j++)
            {
                Matrix m = new Matrix(_rules[j]);

                for (int i = 0; i < dmr; i++)
                {
                    _rules[j] = Matrix.TensorMul(_rules[j], m);
                }
            }
        }

        public static Matrix EqDimRegs(Matrix matrix, int dmr)
        {
            int size = (int)Math.Pow(2, dmr);

            Matrix result = matrix;

           //for(int i = 0; i < dmr;i++)
            //{
             //   result = Matrix.TensorMul(result, matrix);
            //}

            while( result.M < size)
            {
                result = Matrix.TensorMul(result, matrix);
            }

            return result;
        }

        protected static void EqualizeDimension(ref Matrix matrix,int dimensionState)
        {
            if (matrix.N != dimensionState)
            {
                matrix = Matrix.TensorMul(Matrix.GetI(dimensionState / matrix.N), matrix);
            }
        }

        public static Matrix EqDim(Matrix matrix, int dimensionState)
        {
            return Matrix.TensorMul(Matrix.GetI(dimensionState / matrix.N), matrix);
        }

    }
}
