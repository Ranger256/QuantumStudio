
namespace Quantum2.View
{
    partial class ArgsGateForm
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
            this.ArgsGateLabel = new System.Windows.Forms.Label();
            this.ArgsGateScrollPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // ArgsGateLabel
            // 
            this.ArgsGateLabel.AutoSize = true;
            this.ArgsGateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ArgsGateLabel.Location = new System.Drawing.Point(12, 9);
            this.ArgsGateLabel.Name = "ArgsGateLabel";
            this.ArgsGateLabel.Size = new System.Drawing.Size(166, 24);
            this.ArgsGateLabel.TabIndex = 0;
            this.ArgsGateLabel.Text = "Аргументы гейта";
            // 
            // ArgsGateScrollPanel
            // 
            this.ArgsGateScrollPanel.AutoScroll = true;
            this.ArgsGateScrollPanel.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ArgsGateScrollPanel.Location = new System.Drawing.Point(12, 36);
            this.ArgsGateScrollPanel.Name = "ArgsGateScrollPanel";
            this.ArgsGateScrollPanel.Size = new System.Drawing.Size(191, 402);
            this.ArgsGateScrollPanel.TabIndex = 1;
            this.ArgsGateScrollPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.ArgsGateScrollPanel_Paint);
            // 
            // ArgsGateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(215, 450);
            this.Controls.Add(this.ArgsGateScrollPanel);
            this.Controls.Add(this.ArgsGateLabel);
            this.Name = "ArgsGateForm";
            this.Text = "ArgsGateForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ArgsGateLabel;
        private System.Windows.Forms.Panel ArgsGateScrollPanel;
    }
}