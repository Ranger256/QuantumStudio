using System;
using System.Drawing;
using System.Windows.Forms;

namespace Quantum2.View
{
    public partial class InitilizationCircuitForm : Form
    {
        private int _countQubits;

        private Action<int> _actionResizeCountRegisters;
        private Action _actionClose;

        public int CountQubits
        {
            get
            {
                return _countQubits;
            }
        }

        public InitilizationCircuitForm()
        {
            InitializeComponent();

            CountRegistersTextBox.Text = "1";
            ResizeCountRegisters(1);
        }

        public RegisterD[] GetRegisterDs()
        {
            RegisterD[] registerDs = new RegisterD[ScrollPanelRegisters.Controls.Count];

            for (int i = 0; i < registerDs.Length; i++)
            {
                RegisterControl registerControl = (RegisterControl)ScrollPanelRegisters.Controls[i];

                registerDs[i] = registerControl.GenerateRegisterD();
            }

            return registerDs;
        }

        public void AddActionResizeCountRegister(Action<int> action)
        {
            _actionResizeCountRegisters += action;
        }

        public void AddActionClose(Action action)
        {
            _actionClose += action;
        }

        public void Clear()
        {
            CountRegistersTextBox.Text = "1";

            ResizeCountRegisters(1);

            RegisterControl registerControl = (RegisterControl)ScrollPanelRegisters.Controls[0];

            registerControl.Clear();

            _actionClose?.Invoke();
        }

        public void SetQRegistersUI(Core.QRegister[] qRegisters)
        {
            CountRegistersTextBox.Text = qRegisters.Length.ToString();

            ResizeCountRegisters(qRegisters.Length);

            for(int i = 0; i < qRegisters.Length;i++)
            {
                RegisterControl registerControl = (RegisterControl)ScrollPanelRegisters.Controls[i];

                registerControl.SetRegisterUI(qRegisters[i]);
            }
        }

        public void ResizeCountRegisters(int n)
        {
            if (n < 0)
                throw new ArgumentOutOfRangeException();

            if(n > ScrollPanelRegisters.Controls.Count)
            {
                int s = ScrollPanelRegisters.Controls.Count;

                for (int i =0; i < n - s; i++)
                {
                    RegisterControl registerControl = new RegisterControl();
                    registerControl.AddActionCountQubits(ActionSizeCountQubits);
                    registerControl.SetNumber(s + i);

                    _countQubits++;

                    Point locationRegisterControl = new Point(20, (registerControl.Size.Height + 10) * (s + i) + 10) ;

                    registerControl.Location = locationRegisterControl;

                    ScrollPanelRegisters.Controls.Add(registerControl) ;
                }
            }
            else if(n < ScrollPanelRegisters.Controls.Count)
            {
                int s = ScrollPanelRegisters.Controls.Count;

                for (int i = s - 1; i > n - 1; i--)
                {
                    RegisterControl registerControl = (RegisterControl)ScrollPanelRegisters.Controls[i];
                    _countQubits -= registerControl.CountQubits;

                    ScrollPanelRegisters.Controls.RemoveAt(i);
                }
            }

            // = GetCountQubits();

            _actionResizeCountRegisters?.Invoke(ScrollPanelRegisters.Controls.Count);
        }

        private void ActionSizeCountQubits(int cc)
        {
            _countQubits += cc ;
        }

        private int CountRegistersTextBox_Get()
        {
            return int.Parse(CountRegistersTextBox.Text);
        }

        private void InitilizationCircuitForm_EventClose(object obj, EventArgs eventArgs)
        {
            _actionClose?.Invoke();
        }

        private void CountRegistersTextBox_EventKey(object obj, KeyEventArgs keyEvent)
        {
            if(keyEvent.KeyCode == Keys.Enter)
            {
                try
                {
                    ResizeCountRegisters(CountRegistersTextBox_Get());
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void CountRegistersTextBox_EventOnLostFocus(object obj, EventArgs eventArgs)
        {
            try
            {
                ResizeCountRegisters(CountRegistersTextBox_Get());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
