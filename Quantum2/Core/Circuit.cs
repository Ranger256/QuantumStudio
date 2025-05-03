using System;
using System.Collections.Generic;

namespace Quantum2.Core
{
    public class Instruction
    {
        public int[] _numbers;
        public Gate _gate;

        public Instruction(int[] numbers, Gate gate)
        {
            _numbers = numbers;
            _gate = gate;
        }
    }

    public class Circuit
    {
        private QRegister[] _qRegisters;

        private Instruction[][] _instructions;

        private int[] _measuredQubits;
        private Measure _measure;

        private Matrix[] _stateMatrices;
        private Matrix _states;

        private int _currentNumberGroup;
        private int _currentNumberInstructionInGroup;

        private int _CNGR;
        private int _CNIIGR;

        private int _countQubits;
        private int _sizeSystem;

        public QRegister[] QRegisters
        {
            get
            {
                return _qRegisters;
            }
        }

        public Instruction[][] Instructions
        {
            get
            {
                return _instructions;
            }
        }

        public int[] MeasuredQubits
        {
            get
            {
                return _measuredQubits;
            }
        }

        public Measure Measure
        {
            get
            {
                return _measure;
            }
        }

        public Matrix States
        {
            get
            {
                return _states;
            }
        }

        public int CurrentNumberGroup
        {
            get
            {
                return _currentNumberGroup;
            }
        }

        public int CurrentNumberInstructionInGroup
        {
            get
            {
                return _currentNumberInstructionInGroup;
            }
        }

        public int CountQubits
        {
            get
            {
                return _countQubits;
            }
        }

        public int SizeSystem
        {
            get
            {
                return _sizeSystem;
            }
        }

        public Circuit()
        {
            _qRegisters = new QRegister[0];
            _instructions = new Instruction[0][];

            _measuredQubits = new int[0];
            _measure = new Measure();

            _states = new Matrix(0, 0);

            _currentNumberGroup = 0;
            _currentNumberInstructionInGroup = 0;
        }

        public void SetQREgisters(QRegister[] qRegisters)
        {
            _qRegisters = qRegisters;

            _stateMatrices = new Matrix[_qRegisters.Length];

            for (int i = 0; i < _qRegisters.Length; i++)
            {
                _stateMatrices[i] = _qRegisters[i].StateMatrix;
            }

            _countQubits = DefineCountQubits();
            _sizeSystem = DefineSizeSystem();
        }

        public void SetInstructions(Instruction[][] instructions)
        {
            _instructions = instructions;
        }

        public void SetInstructions(Instruction[] instructions, int i)
        {
            _instructions[i] = instructions;
        }

        public void SetMeasuredQubits(int[] measuredQubits)
        {
            if (_measuredQubits.Length > _countQubits)
                throw new Exception("The number of qubits to be measured must not exceed the number of qubits");

            _measuredQubits = measuredQubits;
        }

        public void ProceedToTheNextGroup()
        {
            if (_currentNumberGroup == _instructions.Length)
                throw new Exception("We're out of groups");

            while (_currentNumberInstructionInGroup < _instructions[_currentNumberGroup].Length)
            {
                ExecuteNextInstructionInGroup();
            }

            _currentNumberInstructionInGroup = 0;
            _currentNumberGroup++;
        }

        public void ExecuteNextInstructionInGroup()
        {
            if (_currentNumberGroup >= _instructions.Length)
                throw new Exception("We're out of groups");

            if (_currentNumberInstructionInGroup >= _instructions[_currentNumberGroup].Length)
                throw new Exception("We're out of group instruction");

            Gate gate = _instructions[_currentNumberGroup][_currentNumberInstructionInGroup]._gate;

            Matrix[] matrices = GetMatrices(_instructions[_currentNumberGroup][_currentNumberInstructionInGroup]._numbers);

            int lastNumber = _instructions[_currentNumberGroup][_currentNumberInstructionInGroup]._numbers[_instructions[_currentNumberGroup][_currentNumberInstructionInGroup]._numbers.Length - 1];

            gate.EqualizeDimensionRegisters( _qRegisters[lastNumber].Qubits.Length);

            Matrix[] matrixResults = gate.Apply(matrices, _sizeSystem);

            SetResultsInstruction(_instructions[_currentNumberGroup][_currentNumberInstructionInGroup]._numbers, matrixResults);

            _currentNumberInstructionInGroup++;
        }

        public void ExecuteNextInstruction()
        {
            while(_currentNumberInstructionInGroup >= _instructions[_currentNumberGroup].Length)
            {
                _currentNumberGroup++;
                _currentNumberInstructionInGroup = 0;

                if(_currentNumberGroup == _instructions.Length)
                {
                    _currentNumberGroup = 0;
                    _currentNumberInstructionInGroup = 0;

                    ZeroizeStateMatrices();
                    return;
                }
            }

            if (_currentNumberGroup >= _instructions.Length)
                throw new Exception("We're out of groups");

            Matrix[] matrixResults = _instructions[_currentNumberGroup][_currentNumberInstructionInGroup]._gate.Apply(GetMatrices(_instructions[_currentNumberGroup][_currentNumberInstructionInGroup]._numbers), _sizeSystem);

            SetResultsInstruction(_instructions[_currentNumberGroup][_currentNumberInstructionInGroup]._numbers, matrixResults);

            _currentNumberInstructionInGroup++;
        }

        public void ExecuteNextGroup()
        {
            if (_currentNumberGroup >= _instructions.Length)
                throw new Exception("We're out of groups");

            _currentNumberInstructionInGroup = 0;

            while(_currentNumberInstructionInGroup < _instructions[_currentNumberGroup].Length)
            {
                ExecuteNextInstructionInGroup();
            }

            _currentNumberGroup++;
        }

        public void RevertPreviousInstruction()
        {
            if(_currentNumberInstructionInGroup > 0)
            {
                _currentNumberInstructionInGroup--;

                Matrix[] matrixResults = _instructions[_currentNumberGroup][_currentNumberInstructionInGroup ]._gate.Apply(GetMatrices(_instructions[_currentNumberGroup][_currentNumberInstructionInGroup]._numbers), _sizeSystem);

                SetResultsInstruction(_instructions[_currentNumberGroup][_currentNumberInstructionInGroup ]._numbers, matrixResults);
            }
            else
            {
                if (_currentNumberGroup == 0)
                    throw new Exception("There's nowhere to go back.");

                _currentNumberGroup--;

                while (_instructions[_currentNumberGroup].Length == 0)
                {
                    _currentNumberGroup--;

                    if (_currentNumberGroup == 0)
                    {
                        _currentNumberInstructionInGroup = 0;

                        ZeroizeStateMatrices();

                        SRFS();

                        return;
                    }
                }

                _currentNumberInstructionInGroup = _instructions[_currentNumberGroup].Length - 1;

                Matrix[] matrixResults = _instructions[_currentNumberGroup][_currentNumberInstructionInGroup]._gate.Apply(GetMatrices(_instructions[_currentNumberGroup][_currentNumberInstructionInGroup]._numbers), _sizeSystem);

                SetResultsInstruction(_instructions[_currentNumberGroup][_currentNumberInstructionInGroup]._numbers, matrixResults);
            }
           
        }

        public void RevertPreviousGroup()
        {
            if (_currentNumberGroup == 0)
                throw new Exception("There's nowhere to go back");

            while (_currentNumberInstructionInGroup > 0)
            {
                _currentNumberInstructionInGroup--;

                Matrix[] matrixResults = _instructions[_currentNumberGroup][_currentNumberInstructionInGroup]._gate.Apply(GetMatrices(_instructions[_currentNumberGroup][_currentNumberInstructionInGroup]._numbers), _sizeSystem);

                SetResultsInstruction(_instructions[_currentNumberGroup][_currentNumberInstructionInGroup]._numbers, matrixResults);
            }

            while (_instructions[_currentNumberGroup].Length == 0)
            {
                _currentNumberGroup--;

                if (_currentNumberGroup == 0)
                {
                    _currentNumberInstructionInGroup = 0;

                    ZeroizeStateMatrices();
                    return;
                }
            }
        }

        public void Execute()
        {
            if (_qRegisters.Length <= 0)
                return;

            _CNGR = _currentNumberGroup;
            _CNIIGR = _currentNumberInstructionInGroup;

            _currentNumberGroup = 0;
            _currentNumberInstructionInGroup = 0;

            while (_currentNumberGroup < _instructions.Length)
            {
                ExecuteNextGroup();
            }

            Final();
        }

        public void Final()
        {
            _currentNumberGroup = _CNGR;
            _currentNumberInstructionInGroup = _CNIIGR;

            SetResultsFinalState();
            ZeroizeStateMatrices();
        }

        public void SRFS()
        {
            SetResultsFinalState();
        }

        private void ZeroizeStateMatrices()
        {
            Array.Resize<Matrix>(ref _stateMatrices, _qRegisters.Length);

            for (int i = 0; i < _qRegisters.Length; i++)
            {
                _stateMatrices[i] = _qRegisters[i].StateMatrix;
            }
        }

        private void SetResultsInstruction(int[] numbers, Matrix[] resultMatrices)
        {
            for (int j = 0; j < numbers.Length; j++)
            {
                Matrix wire = _stateMatrices[numbers[j]];

                for (int k = 0; k < _stateMatrices.Length; k++)
                {
                    if (wire == _stateMatrices[k])
                    {
                        _stateMatrices[k] = resultMatrices[j];
                    }
                }
            }
        }

        private void SetResultsFinalState()
        {
            HashSet<Matrix> smc = new HashSet<Matrix>(_stateMatrices);

            Matrix[] stateMatrices = new Matrix[smc.Count];
            smc.CopyTo(stateMatrices);

            _states = stateMatrices[0];

            for (int i = 1; i < stateMatrices.Length; i++)
            {
                _states = Matrix.TensorMul(stateMatrices[i], _states);
            }

            _measure.Take(_states, _measuredQubits);
        }

        private int DefineCountQubits()
        {
            int countQubits = 0;

            for (int i = 0; i < _qRegisters.Length; i++)
            {
                countQubits += _qRegisters[i].Qubits.Length;
            }

            return countQubits;
        }

        private int DefineSizeSystem()
        {
            return (int)Math.Pow(DefineCountQubits(), 2);
        }

        private Matrix[] GetMatrices(int[] numbers)
        {
            Matrix[] matrices = new Matrix[numbers.Length];

            for(int i = 0;i < numbers.Length;i++)
            {
                matrices[i] = _stateMatrices[numbers[i]];
            }

            return matrices;
        }

        #region PublicStaticFuncs

        public static Matrix ApplyGate(Gate gate, Matrix[] states)
        {
            if (gate.CountStates != states.Length)
                throw new Exception("The number of states must be equal to the number of states of the gate");

            return null;
        }
        #endregion
    }
}
