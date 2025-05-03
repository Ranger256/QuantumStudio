using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Numerics;

using Quantum2.Core;
using Quantum2.View;

namespace Quantum2
{
    static class Controller
    {
        //model
        private static Circuit _circuit;
        private static CircuitLoader _circuitLoader;
        private static Quantum2.Core.QASM.Executor _qasmExecuter;
        //

        //view
        private static MainForm _mainForm;
        private static Timer _timer;
        //

        public static int InstructionNumber
        {
            get
            {
                return _circuit.CurrentNumberInstructionInGroup;
            }
        }

        public static int GroupNumber
        {
            get
            {
                return _circuit.CurrentNumberGroup;
            }
        }

        public static bool WorkExecuterQUASM
        {
            get
            {
                return _qasmExecuter.IsWork;
            }
        }

        [STAThread]
        private static void Main()
       {
            _circuit = new Circuit();
            _circuitLoader = new CircuitLoader();

            _qasmExecuter = new Quantum2.Core.QASM.Executor();

            // ExecuteQASM(System.IO.File.ReadAllText("QuantumProgram.qasm"));
            //_qasmExecuter.ExecuteCode(System.IO.File.ReadAllText("QuantumProgram.qasm"));

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            _mainForm = new MainForm();

            _timer = new Timer
            {
                Interval = 10
            };

            _timer.Start();

            Application.Run(_mainForm);
        }

        public static void SubUpdate(EventHandler eventHandler)
        {
            _timer.Tick += eventHandler;
        }

        public static void UnSubUpdate(EventHandler eventHandler)
        {
            _timer.Tick -= eventHandler;
        }

        public static void ExecuteQASM(string codeQASM)
        {
            _qasmExecuter.SetCode(codeQASM);

            _qasmExecuter.Start();
        }

        public static void StopExecuteQUASM()
        {
            _qasmExecuter.Stop();
        }

        public static void SwitchModeQUASM(string code)
        {
            if(_qasmExecuter.IsWork)
            {
                StopExecuteQUASM();
            }
            else
            {
                ExecuteQASM(code);
            }
        }

        public static string GetOutputQASMString()
        {
            return _qasmExecuter.OutputString;
        }

        public static void SubWorkActionExecuterQUASM(Action<bool> workAction)
        {
            _qasmExecuter.SubWorkAction(workAction);
        }

        public static void SubOutputStringActionExecuterQUASM(Action<string> outputAction)
        {
            _qasmExecuter.SubOutputString(outputAction);
        }

        public static void InvokeActionFromMainThread(Action action)
        {
            _mainForm.Invoke(action);
        }

        public static void SetRegisters(RegisterD[] registerDs)
        {
            QRegister[] qRegisters = new QRegister[registerDs.Length];

            for(int i = 0; i < registerDs.Length;i++)
            {
                qRegisters[i] = new QRegister(registerDs[i]._qubitDs.Length);

                for(int j = 0; j < registerDs[i]._qubitDs.Length;j++)
                {
                    qRegisters[i].Set(j, new Qubit(registerDs[i]._qubitDs[j]._alpha, registerDs[i]._qubitDs[j]._beta));
                }
            }

            _circuit.SetQREgisters(qRegisters);
        }
       
        public static void SetMeasuredQubits(int[] measurments)
        {
            _circuit.SetMeasuredQubits(measurments);
        }

        public static void CreateAndSetGE(int group, int reg, string name, int[] outputs, double[] args)
        {
            _mainForm.CreateAndSetGE(group, reg, name, outputs, args);
        }

        public static void SetInstructions(GE[,] gElements)
        {
            List<List<Instruction>> instructions = new List<List<Instruction>>();

            for(int i = 0; i < gElements.GetLength(0);i++)
            {
                instructions.Add(new List<Instruction>());

                for (int j = 0; j < gElements.GetLength(1); j++)
                {
                    if (gElements[i, j]._name != null && gElements[i, j]._name != "")
                    {
                        int[] numberQubits = new int[1 + gElements[i, j]._outputs.Length];
                        Gate gate = Gate.GetGate(gElements[i, j]._name);

                        numberQubits[numberQubits.Length - 1] = j;

                        for (int k = 0; k < numberQubits.Length - 1; k++)
                        {
                            numberQubits[k] = gElements[i, j]._outputs[k];
                        }

                        gate.Args = gElements[i, j]._args;

                        instructions[i].Add(new Instruction(numberQubits, gate));
                    }
                }
            }

            //блять это конечно жуткий говнокод, но работать должно

            List<Instruction[]> instrs = new List<Instruction[]>();

            for(int i = 0; i < instructions.Count; i++)
            {
                instrs.Add(instructions[i].ToArray());
            }

            _circuit.SetInstructions(instrs.ToArray());
        }

        public static Complex[] GetComplexResults()
        {
            return _circuit.States.GetCM(0);
        }

        public static Dictionary<int, byte> GetMeasuredQubits()
        {
            return _circuit.Measure.MBits;
        }

        public static void ExecuteCircuit()
        {
            _circuit.Execute();
        }

        public static void ExecuteNextInstruction()
        {
            _circuit.ExecuteNextInstruction();

            _circuit.SRFS();
        }

        public static void ProceedNextGroup()
        {
            _circuit.ProceedToTheNextGroup();

            _circuit.SRFS();
        }

        public static void RevertPreviousGroup()
        {
            _circuit.RevertPreviousGroup();

            _circuit.SRFS();
        }

        public static void RevertPreviousInstruction()
        {
            _circuit.RevertPreviousInstruction();

            _circuit.SRFS();
        }

        public static void SaveCircuit(string fileName)
        {
            CircuitSaver.SaveToXMLFile(fileName, _circuit);
        }

        public static void LoadCircuit(string fileName)
        {
            _circuitLoader.LoadFromXMLFile(fileName);

            _circuit.SetQREgisters(_circuitLoader.QRegisters);
            _mainForm.InitilizationCircuit.SetQRegistersUI(_circuitLoader.QRegisters);

            _mainForm.MeasurementsCircuit.SetCountQubits(_circuit.CountQubits);

            _circuit.SetMeasuredQubits(_circuitLoader.MeasurmentQubits);
            _mainForm.MeasurementsCircuit.SetQubitsUI(_circuitLoader.MeasurmentQubits);

            _circuitLoader.LoadInstructions();
        }
    }
}
