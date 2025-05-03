
namespace Quantum2.View
{
    partial class MeasurementForm
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
            this.MeasurmentQubitsList = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // MeasurmentQubitsList
            // 
            this.MeasurmentQubitsList.FormattingEnabled = true;
            this.MeasurmentQubitsList.Location = new System.Drawing.Point(12, 12);
            this.MeasurmentQubitsList.Name = "MeasurmentQubitsList";
            this.MeasurmentQubitsList.Size = new System.Drawing.Size(305, 424);
            this.MeasurmentQubitsList.TabIndex = 0;
            this.MeasurmentQubitsList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.MeasurmentQubitsList_ChangeElement);
            // 
            // MeasurementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 451);
            this.Controls.Add(this.MeasurmentQubitsList);
            this.Name = "MeasurementForm";
            this.Text = "MeasurementForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox MeasurmentQubitsList;
    }
}