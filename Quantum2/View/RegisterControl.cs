using System;
using System.Drawing;
using System.Windows.Forms;

namespace Quantum2.View
{
    public struct RegisterD
    {
        public PairQubitD[] _qubitDs;

        public RegisterD(PairQubitD[] qubitDs)
        {
            _qubitDs = qubitDs;
        }
    }

    public partial class RegisterControl : UserControl
    {
        private int _countQubits;

        private Action<int> _actionCountQubits;

        public int CountQubits
        {
            get
            {
                return _countQubits;
            }
        }

        public RegisterControl()
        {
            InitializeComponent();

            CountQubitsTextBox.Text = "1";

            ResizeCountQubits(1);
        }

        public void Clear()
        {
            CountQubitsTextBox.Text = "1";

            ResizeCountQubits(1);

            QubitControl qubitControl = (QubitControl)ScrollPanelQubits.Controls[0];

            qubitControl.SetAlpha(System.Numerics.Complex.One);
            qubitControl.SetBeta(System.Numerics.Complex.Zero);
        }

        public RegisterD GenerateRegisterD()
        {
            PairQubitD[] qubitDs = new PairQubitD[ScrollPanelQubits.Controls.Count];

            for(int i = 0; i < qubitDs.Length;i++)
            {
                QubitControl qubitControl = (QubitControl)ScrollPanelQubits.Controls[i];

                qubitDs[i] = qubitControl.PairQubitD;
            }

            return new RegisterD( qubitDs);
        }

        public void AddActionCountQubits(Action<int> action)
        {
            _actionCountQubits += action;
        }

        public void SetNumber(int n)
        {
            RegisterLabel.Text += " " + n.ToString();
        }

        public void SetRegisterUI(Core.QRegister register)
        {
            CountQubitsTextBox.Text = register.Qubits.Length.ToString();

            ResizeCountQubits(register.Qubits.Length);

            for(int i = 0; i < register.Qubits.Length;i++)
            {
                QubitControl qubitControl = (QubitControl)ScrollPanelQubits.Controls[i];

                qubitControl.SetAlpha(register.Qubits[i].Alpha);
                qubitControl.SetBeta(register.Qubits[i].Beta);
            }
        }

        public void ResizeCountQubits(int n)
        {
            if (n < 0)
                throw new ArgumentOutOfRangeException();

            if (n > ScrollPanelQubits.Controls.Count)
            {
                int s = ScrollPanelQubits.Controls.Count;

                for (int i = 0; i < n - s; i++)
                {
                    QubitControl qubitControl = new QubitControl();
                    qubitControl.SetNumber(s + i);

                    Point locationQubitControl = new Point(20, (qubitControl.Size.Height + 10) * (s + i) + 10);

                    qubitControl.Location = locationQubitControl;

                    ScrollPanelQubits.Controls.Add(qubitControl);
                  
                }
            }
            else if (n < ScrollPanelQubits.Controls.Count)
            {
                int s = ScrollPanelQubits.Controls.Count;

                for (int i = s - 1; i > n - 1; i--)
                {
                    ScrollPanelQubits.Controls.RemoveAt(i);
                }
            }

            if (_actionCountQubits != null)
                _actionCountQubits(n - _countQubits);

            _countQubits = n;
        }

        private void RegisterControl_Load(object sender, EventArgs e)
        {

        }

        private int CountQubitsTextBox_Get()
        {
            return int.Parse(CountQubitsTextBox.Text);
        }

        private void ParseTextBox()
        {
            try
            {
                ResizeCountQubits(CountQubitsTextBox_Get());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CountQubitsTextBox_EventKey(object obj, KeyEventArgs keyEvent)
        {
            if (keyEvent.KeyCode == Keys.Enter)
            {
                ParseTextBox();
            }
        }

        private void CountQubitsTextBox_EventOnLostFocus(object obj, EventArgs eventArgs)
        {
            ParseTextBox();
        }
    }
}
