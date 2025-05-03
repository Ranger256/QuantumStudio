
namespace Quantum2.View
{
    partial class RegisterControl
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
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.CountQubitsLabel = new System.Windows.Forms.Label();
            this.CountQubitsTextBox = new System.Windows.Forms.TextBox();
            this.ScrollPanelQubits = new System.Windows.Forms.Panel();
            this.RegisterLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CountQubitsLabel
            // 
            this.CountQubitsLabel.AutoSize = true;
            this.CountQubitsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CountQubitsLabel.Location = new System.Drawing.Point(9, 37);
            this.CountQubitsLabel.Name = "CountQubitsLabel";
            this.CountQubitsLabel.Size = new System.Drawing.Size(160, 22);
            this.CountQubitsLabel.TabIndex = 1;
            this.CountQubitsLabel.Text = "Количество кубит";
            // 
            // CountQubitsTextBox
            // 
            this.CountQubitsTextBox.Location = new System.Drawing.Point(13, 62);
            this.CountQubitsTextBox.Name = "CountQubitsTextBox";
            this.CountQubitsTextBox.Size = new System.Drawing.Size(208, 20);
            this.CountQubitsTextBox.TabIndex = 2;
            this.CountQubitsTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CountQubitsTextBox_EventKey);
            this.CountQubitsTextBox.LostFocus += new System.EventHandler(this.CountQubitsTextBox_EventOnLostFocus);
            // 
            // ScrollPanelQubits
            // 
            this.ScrollPanelQubits.AutoScroll = true;
            this.ScrollPanelQubits.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ScrollPanelQubits.Location = new System.Drawing.Point(13, 88);
            this.ScrollPanelQubits.Name = "ScrollPanelQubits";
            this.ScrollPanelQubits.Size = new System.Drawing.Size(215, 239);
            this.ScrollPanelQubits.TabIndex = 3;
            // 
            // RegisterLabel
            // 
            this.RegisterLabel.AutoSize = true;
            this.RegisterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RegisterLabel.Location = new System.Drawing.Point(67, 15);
            this.RegisterLabel.Name = "RegisterLabel";
            this.RegisterLabel.Size = new System.Drawing.Size(76, 22);
            this.RegisterLabel.TabIndex = 4;
            this.RegisterLabel.Text = "Регистр";
            // 
            // RegisterControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(this.RegisterLabel);
            this.Controls.Add(this.ScrollPanelQubits);
            this.Controls.Add(this.CountQubitsTextBox);
            this.Controls.Add(this.CountQubitsLabel);
            this.Name = "RegisterControl";
            this.Size = new System.Drawing.Size(240, 334);
            this.Load += new System.EventHandler(this.RegisterControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label CountQubitsLabel;
        private System.Windows.Forms.TextBox CountQubitsTextBox;
        private System.Windows.Forms.Panel ScrollPanelQubits;
        private System.Windows.Forms.Label RegisterLabel;
    }
}
