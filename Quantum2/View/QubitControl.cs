using System;
using System.Windows.Forms;

namespace Quantum2.View
{
    public struct PairQubitD
    {
        public System.Numerics.Complex _alpha;
        public System.Numerics.Complex _beta;

        public PairQubitD(System.Numerics.Complex alpha, System.Numerics.Complex beta)
        {
            _alpha = alpha;
            _beta = beta;
        }
    }

    public partial class QubitControl : UserControl
    {
        private PairQubitD _pairQubit;

        public PairQubitD PairQubitD
        {
            get
            {
                return _pairQubit;
            }
        }

        public QubitControl()
        {
            InitializeComponent();

            AlphaTextBox.Text = "1 + 0i";
            BetaTextBox.Text = "0 + 0i";

            _pairQubit = new PairQubitD(System.Numerics.Complex.One, System.Numerics.Complex.Zero);
        }

        public void SetNumber(int number)
        {
            QubitLabel.Text += " " + number.ToString();
        }

        public void SetAlpha(System.Numerics.Complex alpha)
        {
            _pairQubit._alpha = alpha;

            AlphaTextBox.Text = ComplexExtension.TS(alpha);
        }

        public void SetBeta(System.Numerics.Complex beta)
        {
            _pairQubit._beta = beta;

            BetaTextBox.Text = ComplexExtension.TS(beta);
        }

        private void AlphaTextBox_EventEnter(object obj, KeyEventArgs keyEventArgs)
        {
            if(keyEventArgs.KeyCode == Keys.Enter)
            {
                ParseTextBox(AlphaTextBox, ref _pairQubit._alpha);
            }
        }
        
        private void AlphaTextBox_EventOnLostFocus(object obj, EventArgs eventArgs)
        {
            ParseTextBox(AlphaTextBox, ref _pairQubit._beta);
        }

        private void BetaTextBox_EventEnter(object obj, KeyEventArgs keyEventArgs)
        {
            if(keyEventArgs.KeyCode == Keys.Enter)
            {
                ParseTextBox(BetaTextBox, ref _pairQubit._beta);
            }
        }

        private void BetaTextBox_EventOnLostFocus(object obj, EventArgs eventArgs)
        {
            ParseTextBox(BetaTextBox, ref _pairQubit._beta);
        }

        private void ParseTextBox(TextBox textBox, ref System.Numerics.Complex complex)
        {
            try
            {
                complex = ComplexExtension.Parse(textBox.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ZeroButton_Click(object sender, EventArgs e)
        {
            AlphaTextBox.Text = "1 + 0i";
            BetaTextBox.Text = "0 + 0i";

            _pairQubit = new PairQubitD(System.Numerics.Complex.One, System.Numerics.Complex.Zero);
        }

        private void OneButton_Click(object sender, EventArgs e)
        {
            AlphaTextBox.Text = "0 + 0i";
            BetaTextBox.Text = "1 + 0i";

            _pairQubit = new PairQubitD(System.Numerics.Complex.Zero, System.Numerics.Complex.One);
        }
    }
}
