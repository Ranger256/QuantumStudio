
namespace Quantum2.View
{
    partial class ImageChoiseForm
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
            this.ImageButtonsScrollPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // ImageButtonsScrollPanel
            // 
            this.ImageButtonsScrollPanel.AutoScroll = true;
            this.ImageButtonsScrollPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ImageButtonsScrollPanel.Location = new System.Drawing.Point(12, 12);
            this.ImageButtonsScrollPanel.Name = "ImageButtonsScrollPanel";
            this.ImageButtonsScrollPanel.Size = new System.Drawing.Size(430, 430);
            this.ImageButtonsScrollPanel.TabIndex = 0;
            this.ImageButtonsScrollPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // ImageChoiseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 450);
            this.Controls.Add(this.ImageButtonsScrollPanel);
            this.Name = "ImageChoiseForm";
            this.Text = "ImageChoiseForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ImageButtonsScrollPanel;
    }
}