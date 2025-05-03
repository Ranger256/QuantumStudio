
namespace Quantum2.View
{
    partial class InitilizationCircuitForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CountRegistersTextBox = new System.Windows.Forms.TextBox();
            this.CountRegistersLabel = new System.Windows.Forms.Label();
            this.ScrollPanelRegisters = new System.Windows.Forms.Panel();
            this.SuspendLayout();

            this.FormClosed += this.InitilizationCircuitForm_EventClose;

            // 
            // CountRegistersTextBox
            // 
            this.CountRegistersTextBox.Location = new System.Drawing.Point(12, 34);
            this.CountRegistersTextBox.Name = "CountRegistersTextBox";
            this.CountRegistersTextBox.Size = new System.Drawing.Size(309, 20);
            this.CountRegistersTextBox.TabIndex = 0;
            this.CountRegistersTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CountRegistersTextBox_EventKey);
            this.CountRegistersTextBox.LostFocus += new System.EventHandler(this.CountRegistersTextBox_EventOnLostFocus);
            // 
            // CountRegistersLabel
            // 
            this.CountRegistersLabel.AutoSize = true;
            this.CountRegistersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CountRegistersLabel.Location = new System.Drawing.Point(60, 9);
            this.CountRegistersLabel.Name = "CountRegistersLabel";
            this.CountRegistersLabel.Size = new System.Drawing.Size(198, 22);
            this.CountRegistersLabel.TabIndex = 1;
            this.CountRegistersLabel.Text = "Количество регистров";
            // 
            // ScrollPanelRegisters
            // 
            this.ScrollPanelRegisters.AutoScroll = true;
            this.ScrollPanelRegisters.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ScrollPanelRegisters.Location = new System.Drawing.Point(12, 60);
            this.ScrollPanelRegisters.Name = "ScrollPanelRegisters";
            this.ScrollPanelRegisters.Size = new System.Drawing.Size(309, 378);
            this.ScrollPanelRegisters.TabIndex = 2;
            // 
            // InitilizationCircuitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 451);
            this.Controls.Add(this.ScrollPanelRegisters);
            this.Controls.Add(this.CountRegistersLabel);
            this.Controls.Add(this.CountRegistersTextBox);
            this.Name = "InitilizationCircuitForm";
            this.Text = "Инициализация квантовой схемы";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox CountRegistersTextBox;
        private System.Windows.Forms.Label CountRegistersLabel;
        private System.Windows.Forms.Panel ScrollPanelRegisters;
    }
}