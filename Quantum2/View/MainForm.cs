using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Quantum2.View;

namespace Quantum2
{
    public partial class MainForm : Form
    {
        private InitilizationCircuitForm _initilizationCircuitForm;
        private MeasurementForm _measurementForm;
        private ImageManipulationForm _imageManipulationForm;
        private QASMForm _qasmForm;

        private List<List<Panel>> _panelDotsRW;

        private int _lengthRegWireInDots;
        private int _pointDistance;

        public InitilizationCircuitForm InitilizationCircuit
        {
            get
            {
                return _initilizationCircuitForm;
            }
        }

        public MeasurementForm MeasurementsCircuit
        {
            get
            {
                return _measurementForm;
            }
        }

        public MainForm()
        {
            InitializeComponent();

            LabelMeasurmentQubits.Text = "";

            _initilizationCircuitForm = new InitilizationCircuitForm();

            _initilizationCircuitForm.AddActionResizeCountRegister(delegate (int arg0) 
            {
                PaintRegWires(arg0);
                GateControl.SetFieldSizeOfQuantumCircuit(_lengthRegWireInDots, _initilizationCircuitForm.GetRegisterDs().Length);
            });

            _initilizationCircuitForm.AddActionClose(UpdateCR);

            _measurementForm = new MeasurementForm();
            _measurementForm.SetCountQubits(1);

            _imageManipulationForm = new ImageManipulationForm();

            _qasmForm = new QASMForm(); 

            _panelDotsRW = new List<List<Panel>>();

            _lengthRegWireInDots = 13;
            _pointDistance = 60;

            PaintRegWires(1);

            GateControl.SetFieldSizeOfQuantumCircuit(_lengthRegWireInDots, 1);

            Controller.SetRegisters(_initilizationCircuitForm.GetRegisterDs());

            PlayCircuitButton_Click(null, null);
        }

        public GateControl AddGate(string name,int countOutputs = 0, int countArgs = 0)
        {
            GateControl gate = new GateControl(_panelDotsRW, name,countOutputs, countArgs);

            gate.Location = PointToClient( MousePosition);

            Controls.Add(gate);

            gate.BringToFront();

            return gate;
        }

        public void CreateAndSetGE(int group, int reg, string name, int[] outputs, double[] args)
        {
            GateControl gateControl = AddGate(name, outputs.Length, args.Length);

            gateControl.Set(group, reg);
            gateControl.SetOutputs(outputs);
            gateControl.SetArgs(args);
        }

        private void UpdateCR()
        {
            _measurementForm.SetCountQubits(_initilizationCircuitForm.CountQubits);
            //GateControl.SetFieldSizeOfQuantumCircuit(_lengthRegWireInDots, _initilizationCircuitForm.GetRegisterDs().Length);
            Controller.SetRegisters(_initilizationCircuitForm.GetRegisterDs());

            PlayCircuitButton_Click(null, null);
        }

        private void PaintRegWires(int countRegWires)
        {
            ScrollPanelOfQuantumCircuit.Controls.Clear();
            _panelDotsRW.Clear();

            for(int i = 0; i < countRegWires; i++)
            {
                Panel panelRegWire = new Panel();
                Label labelRegWire = new Label();

                _panelDotsRW.Add(new List<Panel>());

                panelRegWire.BackColor = Color.Black;

                panelRegWire.Location = new Point(33, i * 50 + 10);
                panelRegWire.Size = new Size(_pointDistance * _lengthRegWireInDots, 10);

                labelRegWire.Location = new Point(10, i * 50 + 10);
                labelRegWire.Size = new Size(33, 15);

                labelRegWire.Text = "r" + i.ToString();

                ScrollPanelOfQuantumCircuit.Controls.Add(labelRegWire);
                ScrollPanelOfQuantumCircuit.Controls.Add(panelRegWire);

                for (int j = 0; j < _lengthRegWireInDots; j++)
                {
                    Panel panelDotRegWire = new Panel
                    {
                        BackColor = Color.Red,

                        Location = new Point(j * _pointDistance + 30, 0),
                        Size = new Size(10, 10)
                    };

                    panelRegWire.Controls.Add(panelDotRegWire);

                    _panelDotsRW[_panelDotsRW.Count - 1].Add(panelDotRegWire);
                }
            }
        }
        
        private void OutputResults()
        {
            barChartAmplitudeStates1.SetData(Controller.GetComplexResults());

            Dictionary<int, byte> dictMQ = Controller.GetMeasuredQubits();

            int i = MeasurmentsQubitsScrollPanel.Controls.Count;

            if(dictMQ.Count > 0)
            {
                LabelMeasurmentQubits.Text += "Cubit measurements:" +Environment.NewLine;
                /*Label labelHeaderMQs = new Label
                {
                    Location = new Point(0, i * 25),
                    AutoSize = true,
                    Font = new Font(DefaultFont.Name, 11),
                    Text = "Cubit measurements:"
                };

                MeasurmentsQubitsScrollPanel.Controls.Add(labelHeaderMQs);

                i++;*/
            }

            foreach (var item in dictMQ)
            {
                LabelMeasurmentQubits.Text += "Number qubit: " + item.Key + "; Value: " + item.Value + Environment.NewLine;
                /*Label labelMQ = new Label();

                int positionY = i * 25;

                labelMQ.Location = new Point(0, positionY);
                labelMQ.AutoSize = true;
                labelMQ.Font = new Font(DefaultFont.Name, 11);
                labelMQ.Text = "Number qubit: " + item.Key  + "; Value: " + item.Value;

                MeasurmentsQubitsScrollPanel.Controls.Add(labelMQ);

                i++;*/
            }

            if (dictMQ.Count > 0)
            {
                LabelMeasurmentQubits.Text += "End of measured qubits" + Environment.NewLine + Environment.NewLine;
                /*Label labelEndMQs = new Label
                {
                    Location = new Point(0, i * 25),
                    AutoSize = true,
                    Font = new Font(DefaultFont.Name, 11),
                    Text = "End of measured qubits"
                };

                MeasurmentsQubitsScrollPanel.Controls.Add(labelEndMQs);*/
            }
        }

        private void ClearCircuit()
        {
            GateControl.Clear();

            _initilizationCircuitForm.Clear();
            GateControl.SetFieldSizeOfQuantumCircuit(_lengthRegWireInDots, _initilizationCircuitForm.GetRegisterDs().Length);

            PlayCircuitButton_Click(null, null);
        }

        private void InitializationQuantumCircuitButton_Click(object sender, EventArgs e)
        {
            _initilizationCircuitForm.StartPosition = FormStartPosition.Manual;
            _initilizationCircuitForm.Location = new Point(Location.X + Size.Width -370, Location.Y + Size.Height / 4) ;

            _initilizationCircuitForm.ShowDialog();

            
        }

        private void MeasurmentsButton_Click(object sender, EventArgs e)
        {
            _measurementForm.StartPosition = FormStartPosition.Manual;

            _measurementForm.Location = new Point(Location.X + Size.Width - 400, Location.Y + Size.Height / 4);

            _measurementForm.ShowDialog();
        }

        private void PlayCircuitButton_Click(object sender, EventArgs e)
        {
            Controller.SetInstructions(GateControl.GElements);

            Controller.ExecuteCircuit();

            OutputResults();

            ValueInstructionLabel.Text = Controller.InstructionNumber.ToString();
            ValueGroupLabel.Text = Controller.GroupNumber.ToString();
        }

        private void NextInstructionButton_Click(object sender, EventArgs e)
        {
            Controller.SetInstructions(GateControl.GElements);

            try
            {
                Controller.ExecuteNextInstruction();

                OutputResults();

                ValueInstructionLabel.Text = Controller.InstructionNumber.ToString();
                ValueGroupLabel.Text = Controller.GroupNumber.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void NextGroupButton_Click(object sender, EventArgs e)
        {
            Controller.SetInstructions(GateControl.GElements);

            try
            {
                Controller.ProceedNextGroup();

                OutputResults();

                ValueInstructionLabel.Text = Controller.InstructionNumber.ToString();
                ValueGroupLabel.Text = Controller.GroupNumber.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PreviousInstructionButton_Click(object sender, EventArgs e)
        {
            Controller.SetInstructions(GateControl.GElements);

            try
            {
                Controller.RevertPreviousInstruction();

                OutputResults();

                ValueInstructionLabel.Text = Controller.InstructionNumber.ToString();
                ValueGroupLabel.Text = Controller.GroupNumber.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PreviousGroupButton_Click(object sender, EventArgs e)
        {
            Controller.SetInstructions(GateControl.GElements);

            try
            {
                Controller.RevertPreviousGroup();

                OutputResults();

                ValueInstructionLabel.Text = Controller.InstructionNumber.ToString();
                ValueGroupLabel.Text = Controller.GroupNumber.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void barChartAmplitudeStates1_Load(object sender, EventArgs e)
        {

        }

        private void ClearMeasurmentQubitsButton_Click(object sender, EventArgs e)
        {
            LabelMeasurmentQubits.Text = "";
        }

        private void PaulXButton_Click(object sender, EventArgs e)
        {
            AddGate("X");
        }

        private void HGateButton_Click(object sender, EventArgs e)
        {
            AddGate("H");
        }

        private void RxButton_Click(object sender, EventArgs e)
        {
            AddGate("Rx",countArgs: 1);
        }

        private void CNOTButton_Click(object sender, EventArgs e)
        {
            AddGate("CX", countOutputs: 1);
        }

        private void PaulYButton_Click(object sender, EventArgs e)
        {
            AddGate("Y");
        }

        private void PaulZButton_Click(object sender, EventArgs e)
        {
            AddGate("Z");
        }

        private void SButton_Click(object sender, EventArgs e)
        {
            AddGate("S");
        }

        private void TButton_Click(object sender, EventArgs e)
        {
            AddGate("T");
        }

        private void RkGateButton_Click(object sender, EventArgs e)
        {
            AddGate("Rk", countArgs: 1);
        }

        private void RyButton_Click(object sender, EventArgs e)
        {
            AddGate("Ry", countArgs: 1);
        }

        private void RzButton_Click(object sender, EventArgs e)
        {
            AddGate("Rz", countArgs: 1);
        }

        private void U1Button_Click(object sender, EventArgs e)
        {
            AddGate("U1", countArgs: 1);
        }

        private void U2Button_Click(object sender, EventArgs e)
        {
            AddGate("U2", countArgs: 2);
        }

        private void U3Button_Click(object sender, EventArgs e)
        {
            AddGate("U3", countArgs: 3);
        }

        private void CYButton_Click(object sender, EventArgs e)
        {
            AddGate("CY", countOutputs: 1);
        }

        private void CZButton_Click(object sender, EventArgs e)
        {
            AddGate("CZ", countOutputs: 1);
        }

        private void barChartAmplitudeStates1_Load_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void SaveSchemeButton_Click(object sender, EventArgs e)
        {
            using(SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "XML circuit files|*.xml";

                if(saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Controller.SaveCircuit(saveFileDialog.FileName);
                }
            }
        }

        private void LoadSchemeButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "XML circuit files|*.xml";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ClearCircuit();

                    Controller.LoadCircuit(openFileDialog.FileName);

                    PlayCircuitButton_Click(null, null);
                }
            }
        }

        private void ClearCircuitButton_Click(object sender, EventArgs e)
        {
            ClearCircuit();
        }

        private void DeleteLastGateButton_Click(object sender, EventArgs e)
        {
            GateControl.ClearLastGate();
        }

        private void LegendStateSystemGreenLabe_Click(object sender, EventArgs e)
        {

        }

        private void ImageManipulationButton_Click(object sender, EventArgs e)
        {
            _imageManipulationForm.ShowDialog();
        }

        private void QASMButton_Click(object sender, EventArgs e)
        {
            _qasmForm.StartPosition = FormStartPosition.Manual;

            _qasmForm.Location = new Point(Location.X + 150, Location.Y + 50); 

            _qasmForm.Show();
        }
    }
}
