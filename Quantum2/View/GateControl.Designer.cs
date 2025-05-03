
namespace Quantum2.View
{
    partial class GateControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);

            _argsGateForm.Dispose();

            if (_graphOutputs == null)
                return;
            
            for(int i = 0;i < _graphOutputs.Length;i++)
            {
                if(_graphOutputs[i] != null)
                    _graphOutputs[i].Clear();
            }
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.GateButton = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // 
            // GateButton
            // 
            this.GateButton.Location = new System.Drawing.Point(0, 0);
            this.GateButton.Name = "GateButton";
            this.GateButton.Size = new System.Drawing.Size(30, 30);
            this.GateButton.TabIndex = 0;
            this.GateButton.Text = "button1";
            this.GateButton.UseVisualStyleBackColor = true;
            this.GateButton.MouseDown += GateButton_Click;
            this.GateButton.KeyDown += delegate (object obj, System.Windows.Forms.KeyEventArgs e) {
                if(e.KeyCode == System.Windows.Forms.Keys.Delete && _active)
                {
                    SwitchActive();
                    Dispose(true);
                }
            };
            // 
            // GateControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Red;
            this.Controls.Add(this.GateButton);
            this.Name = "GateControl";
            this.Size = new System.Drawing.Size(30, 30);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button GateButton;
    }
}
