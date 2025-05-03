using System;
using System.Numerics;
using System.Drawing;
using System.Windows.Forms;

namespace Quantum2.View
{
    public partial class BarChartAmplitudeStates : UserControl
    {
        private const int _countVerticalNumericsDesignations = 12;
        private const int _amplitudeSpacing = 100;
        private const int _additiveValueOfGraphicAmplitudes = 5;
        private const int _amplitudeSizeX = 20;

        private Complex[] _data;

        private Panel _panelBarChart;
        //private HScrollBar _hScrollBar;

        public BarChartAmplitudeStates()
        {
            InitializeComponent();

            _data = new Complex[0];

            _panelBarChart = new Panel
            {
                Size = new Size(460, 280),
                Location = new Point(5, 5),
                AutoScroll = true,
                BackColor = Color.Gray
            };

            /*_hScrollBar = new HScrollBar
            {
                Minimum = 0,
                Maximum = (2 * _amplitudeSizeX + _amplitudeSpacing) * _data.Length,
                Location = new Point(10, _panelBarChart.Bottom + 10),
                Width = _panelBarChart.Width
            };*/

            _hScrollBar.Maximum = (_amplitudeSizeX + _amplitudeSpacing) * _data.Length;
            
            _panelBarChart.Paint += PanelBarChartPaint;
            _hScrollBar.Scroll += HScrollBar_Scroll;

            //_panelBarChart.Controls.Add(_hScrollBar);
            
            Controls.Add(_panelBarChart);

            //Controls.Add(_hScrollBar);
        }

        public void SetData(Complex[] data)
        {
            _data = data;

            _hScrollBar.Maximum = (_amplitudeSizeX + _amplitudeSpacing) * _data.Length - _panelBarChart.Width ;

            _panelBarChart.Invalidate();
        }

        private void PanelBarChartPaint(object sender,PaintEventArgs e)
        {
            Panel panel = sender as Panel;

            int offsetX0 = -100;
            int offsetY0Real =  -140 - 20;

            int offsetY0Phase = -140 - 20;

            int offsetY0Imag = -140 - 20;

            for(int i = 0; i < _data.Length;i++)
            {
                Complex absD = new Complex(Math.Abs(_data[i].Real), Math.Abs(_data[i].Phase) );

                int sizeRealX = _amplitudeSizeX;
                int sizeRealY = (int)(absD.Real * 100) + _additiveValueOfGraphicAmplitudes;

                if (_data[i].Real < 0)
                {
                    offsetY0Real = sizeRealY - 140 - 20;
                }
                else
                {
                    offsetY0Real = -140 - 20;
                }

                int positionRealX = i * _amplitudeSpacing - _hScrollBar.Value + offsetX0;
                int positionRealY = panel.Height - sizeRealY + offsetY0Real;

                int sizeImagX = _amplitudeSizeX;
                int sizeImagY = (int)(Math.Abs(_data[i].Imaginary) * 100) + _additiveValueOfGraphicAmplitudes;

                if (_data[i].Imaginary < 0)
                {
                    offsetY0Imag = sizeImagY - 140 - 20;
                }
                else
                {
                    offsetY0Imag = -140 - 20;
                }

                int positionImagX = positionRealX + sizeRealX;
                int positionImagY = panel.Height - sizeImagY + offsetY0Imag;

                int sizePhaseX = _amplitudeSizeX;
                int sizePhaseY = (int)((absD.Imaginary / (2 * Math.PI)) * 100) + _additiveValueOfGraphicAmplitudes;

                if (_data[i].Phase < 0)
                {
                    offsetY0Phase = -140 - 20 + sizePhaseY;
                }
                else
                {
                    offsetY0Phase = -140 - 20;
                }

                int positionPhaseX = positionImagX + sizeImagX;
                int positionPhaseY = panel.Height - sizePhaseY + offsetY0Phase;

                e.Graphics.FillRectangle(Brushes.Red, positionRealX, positionRealY, sizeRealX, sizeRealY);
                e.Graphics.FillRectangle(Brushes.Blue, positionImagX, positionImagY, sizeImagX, sizeImagY);
                e.Graphics.FillRectangle(Brushes.Green, positionPhaseX, positionPhaseY, sizePhaseX, sizePhaseY);
                //e.Graphics

                e.Graphics.DrawString(i.ToString(), this.Font, Brushes.Black, positionRealX, panel.Height - 40);
            }

            for(int i = -_countVerticalNumericsDesignations / 2 + 1; i < _countVerticalNumericsDesignations / 2;i++)
            {
                int positionLineY = panel.Height - i * ( (100 + _additiveValueOfGraphicAmplitudes) / ( (_countVerticalNumericsDesignations / 2) - 1) ) + (-140 - 20 - _additiveValueOfGraphicAmplitudes) + 4;

                e.Graphics.DrawLine(Pens.Black, 50, positionLineY, (_data.Length - 1) * _amplitudeSpacing - _hScrollBar.Value + offsetX0 + _amplitudeSizeX * 2 + 800, positionLineY);

                double number = i / (double)(_countVerticalNumericsDesignations / 2 - 1);

                e.Graphics.DrawString(number.ToString(), Font, Brushes.Black, 10, positionLineY - 5);
            }
        }

        private void HScrollBar_Scroll(object obj, ScrollEventArgs e)
        {
            _panelBarChart.Invalidate();
        }

        private void BarChartAmplitudeStates_Load(object sender, EventArgs e)
        {

        }

        private void _hScrollBar_Scroll(object sender, ScrollEventArgs e)
        {

        }
    }
}
