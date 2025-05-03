using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Quantum2.View
{
    public partial class QASMForm : Form
    {
        public QASMForm()
        {
            InitializeComponent();

            FormClosing += delegate (object sender, System.Windows.Forms.FormClosingEventArgs args) {
                args.Cancel = true;
                Hide();
            };

            Controller.SubOutputStringActionExecuterQUASM(QUASMConsoleCallback);
            Controller.SubWorkActionExecuterQUASM(StartQUASMButton_UI_Action);
        }

        private void SaveFileButton_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "QASM files|*.qasm";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(saveFileDialog.FileName,TextBoxQASMCode.Text);
                }
            }
        }

        private void LoadFileButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "QASM|*.qasm";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                     TextBoxQASMCode.Text = File.ReadAllText(openFileDialog.FileName);
                }
            }
        }

        private void StartQASMButton_Click(object sender, EventArgs e)
        {
            Controller.SwitchModeQUASM(TextBoxQASMCode.Text);

            //Controller.ExecuteQASM(TextBoxQASMCode.Text);

           // RichTextBoxConsoleIO.Text = Controller.GetOutputQASMString();
        }

        private void QUASMConsoleCallback(string text)
        {
            Controller.InvokeActionFromMainThread( delegate { RichTextBoxConsoleIO.Text = text; });
        }

        private void StartQUASMButton_UI_Action(bool work)
        {
            if(work)
            {
                StartQASMButton.BackgroundImage = Properties.Resources.StopPlay;
            }
            else
            {
                StartQASMButton.BackgroundImage = Properties.Resources.Play;
            }
        }
    }
}
