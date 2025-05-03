
namespace Quantum2.View
{
    partial class QubitControl
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
            this.QubitLabel = new System.Windows.Forms.Label();
            this.AlphaLabel = new System.Windows.Forms.Label();
            this.BetaLabel = new System.Windows.Forms.Label();
            this.AlphaTextBox = new System.Windows.Forms.TextBox();
            this.BetaTextBox = new System.Windows.Forms.TextBox();
            this.ZeroButton = new System.Windows.Forms.Button();
            this.OneButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // QubitLabel
            // 
            this.QubitLabel.AutoSize = true;
            this.QubitLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.QubitLabel.Location = new System.Drawing.Point(50, 12);
            this.QubitLabel.Name = "QubitLabel";
            this.QubitLabel.Size = new System.Drawing.Size(59, 22);
            this.QubitLabel.TabIndex = 0;
            this.QubitLabel.Text = "Кубит";
            // 
            // AlphaLabel
            // 
            this.AlphaLabel.AutoSize = true;
            this.AlphaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AlphaLabel.Location = new System.Drawing.Point(3, 35);
            this.AlphaLabel.Name = "AlphaLabel";
            this.AlphaLabel.Size = new System.Drawing.Size(56, 22);
            this.AlphaLabel.TabIndex = 1;
            this.AlphaLabel.Text = "Alpha";
            // 
            // BetaLabel
            // 
            this.BetaLabel.AutoSize = true;
            this.BetaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BetaLabel.Location = new System.Drawing.Point(3, 66);
            this.BetaLabel.Name = "BetaLabel";
            this.BetaLabel.Size = new System.Drawing.Size(47, 22);
            this.BetaLabel.TabIndex = 2;
            this.BetaLabel.Text = "Beta";
            // 
            // AlphaTextBox
            // 
            this.AlphaTextBox.Location = new System.Drawing.Point(65, 37);
            this.AlphaTextBox.Name = "AlphaTextBox";
            this.AlphaTextBox.Size = new System.Drawing.Size(100, 20);
            this.AlphaTextBox.TabIndex = 3;
            this.AlphaTextBox.KeyDown += AlphaTextBox_EventEnter;
            this.AlphaTextBox.LostFocus += AlphaTextBox_EventOnLostFocus;
            // 
            // BetaTextBox
            // 
            this.BetaTextBox.Location = new System.Drawing.Point(65, 68);
            this.BetaTextBox.Name = "BetaTextBox";
            this.BetaTextBox.Size = new System.Drawing.Size(100, 20);
            this.BetaTextBox.TabIndex = 4;
            this.BetaTextBox.KeyDown += BetaTextBox_EventEnter;
            this.BetaTextBox.LostFocus += BetaTextBox_EventOnLostFocus;
            // 
            // ZeroButton
            // 
            this.ZeroButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ZeroButton.Location = new System.Drawing.Point(7, 94);
            this.ZeroButton.Name = "ZeroButton";
            this.ZeroButton.Size = new System.Drawing.Size(60, 60);
            this.ZeroButton.TabIndex = 5;
            this.ZeroButton.Text = "|0>";
            this.ZeroButton.UseVisualStyleBackColor = true;
            this.ZeroButton.Click += new System.EventHandler(this.ZeroButton_Click);
            // 
            // OneButton
            // 
            this.OneButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OneButton.Location = new System.Drawing.Point(105, 94);
            this.OneButton.Name = "OneButton";
            this.OneButton.Size = new System.Drawing.Size(60, 60);
            this.OneButton.TabIndex = 6;
            this.OneButton.Text = "|1>";
            this.OneButton.UseVisualStyleBackColor = true;
            this.OneButton.Click += new System.EventHandler(this.OneButton_Click);
            // 
            // QubitControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.Controls.Add(this.OneButton);
            this.Controls.Add(this.ZeroButton);
            this.Controls.Add(this.BetaTextBox);
            this.Controls.Add(this.AlphaTextBox);
            this.Controls.Add(this.BetaLabel);
            this.Controls.Add(this.AlphaLabel);
            this.Controls.Add(this.QubitLabel);
            this.Name = "QubitControl";
            this.Size = new System.Drawing.Size(170, 170);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label QubitLabel;
        private System.Windows.Forms.Label AlphaLabel;
        private System.Windows.Forms.Label BetaLabel;
        private System.Windows.Forms.TextBox AlphaTextBox;
        private System.Windows.Forms.TextBox BetaTextBox;
        private System.Windows.Forms.Button ZeroButton;
        private System.Windows.Forms.Button OneButton;
    }
}
