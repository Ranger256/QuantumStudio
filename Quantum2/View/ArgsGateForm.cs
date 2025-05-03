using System;
using System.Drawing;
using System.Windows.Forms;

namespace Quantum2.View
{
    public partial class ArgsGateForm : Form
    {
        private double[] _args;

        private TextBox[] _argTextBoxs;

        public double[] Args
        {
            get
            {
                return _args;
            }
        }

        public ArgsGateForm(int countArgs)
        {
            InitializeComponent();

            SetCountArgs(countArgs);
        }

        public void SetArgs(double[] args)
        {
          //  SetCountArgs(args.Length);

            for(int i =0; i < args.Length;i++)
            {
                _argTextBoxs[i].Text = args[i].ToString();
                _args[i] = args[i];
            }
        }

        private void SetCountArgs(int countArgs)
        {
            _args = new double[countArgs];
            _argTextBoxs = new TextBox[countArgs];

            for(int i = 0; i < countArgs;i++)
            {
                Label argLabel = new Label();
                TextBox argValueTextBox = new TextBox();

                argLabel.AutoSize = true;
                argLabel.Location = new Point(5, i * 50 + 10);
                argLabel.Text = "Аргумент: " + i.ToString();

                argValueTextBox.Size = new Size(100, 7);
                argValueTextBox.Location = new Point(5, argLabel.Location.Y + argLabel.Size.Height);
                argValueTextBox.Text = "0";

                int k = i;

                argValueTextBox.KeyDown += delegate (object sender, KeyEventArgs eventArgs) {
                    if (eventArgs.KeyCode == Keys.Enter)
                    {
                        SetVA(k);
                    }
                };

                argValueTextBox.LostFocus += delegate (object sender, EventArgs eventArgs)
                {
                    SetVA(k);
                };

                _argTextBoxs[i] = argValueTextBox;

                ArgsGateScrollPanel.Controls.Add(argLabel);
                ArgsGateScrollPanel.Controls.Add(argValueTextBox);
            }
        }

        public void Clear()
        {
            _args = new double[0];

            ArgsGateScrollPanel.Controls.Clear();
        }

        private void SetVA(int i)
        {
            string numberStr = _argTextBoxs[i].Text;

            try
            {
                _args[i] = double.Parse(numberStr);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ArgsGateScrollPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
