using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Quantum2.View
{
    public partial class MeasurementForm : Form
    {
        private List<int> _measurementQubits;

        public int[] MeasurmentQubits
        {
            get
            {
                _measurementQubits.Sort();
                return _measurementQubits.ToArray();
            }
        }

        public MeasurementForm()
        {
            InitializeComponent();

            _measurementQubits = new List<int>();
        }

        public void SetCountQubits(int n)
        {
            SetCountQubitsUI(n);

            if (n < _measurementQubits.Count)
                Controller.SetMeasuredQubits(MeasurmentQubits);
        }

        public void SetCountQubitsUI(int n)
        {
            int s = MeasurmentQubitsList.Items.Count;

            if (n > MeasurmentQubitsList.Items.Count)
            {

                for (int i = 0; i < n - s; i++)
                {
                    MeasurmentQubitsList.Items.Add((i + s).ToString());
                }
            }
            else if (n < MeasurmentQubitsList.Items.Count)
            {

                for (int i = s - 1; i > n - 1; i--)
                {
                    MeasurmentQubitsList.Items.RemoveAt(i);
                }
            }

            if (n < _measurementQubits.Count)
            {
                for (int i = _measurementQubits.Count - 1; i > n - 1; i--)
                {
                    _measurementQubits.RemoveAt(i);
                }
            }
        }

        public void SetQubitsUI(int[] qubits)
        {
            if (qubits.Length > MeasurmentQubitsList.Items.Count)
            {
                SetCountQubitsUI(qubits.Length);
            }

            for(int i =0; i < qubits.Length;i++)
            {
                MeasurmentQubitsList.SetItemChecked(qubits[i], true);

                _measurementQubits.Add(qubits[i]);
            }
        }

        private void MeasurmentQubitsList_ChangeElement(object sender, ItemCheckEventArgs e)
        {

            if(e.NewValue == CheckState.Checked)
            {
                if(!_measurementQubits.Contains(e.Index))
                {
                    _measurementQubits.Add(e.Index);
                }
            }
            else if(e.NewValue == CheckState.Unchecked)
            {
                if(_measurementQubits.Contains(e.Index))
                {
                    _measurementQubits.Remove(e.Index);
                }
            }

            Controller.SetMeasuredQubits(MeasurmentQubits);
        }
    }
}
