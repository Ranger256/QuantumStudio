
namespace Quantum2.View
{
    partial class QASMForm
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
            this.SaveFileButton = new System.Windows.Forms.Button();
            this.LoadFileButton = new System.Windows.Forms.Button();
            this.LabelConsoleIO = new System.Windows.Forms.Label();
            this.RichTextBoxConsoleIO = new System.Windows.Forms.RichTextBox();
            this.StartQASMButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.TextBoxQASMCode = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // SaveFileButton
            // 
            this.SaveFileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SaveFileButton.Location = new System.Drawing.Point(12, 7);
            this.SaveFileButton.Name = "SaveFileButton";
            this.SaveFileButton.Size = new System.Drawing.Size(126, 77);
            this.SaveFileButton.TabIndex = 0;
            this.SaveFileButton.Text = "Сохранить файл";
            this.SaveFileButton.UseVisualStyleBackColor = true;
            this.SaveFileButton.Click += new System.EventHandler(this.SaveFileButton_Click);
            // 
            // LoadFileButton
            // 
            this.LoadFileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LoadFileButton.Location = new System.Drawing.Point(144, 7);
            this.LoadFileButton.Name = "LoadFileButton";
            this.LoadFileButton.Size = new System.Drawing.Size(126, 77);
            this.LoadFileButton.TabIndex = 1;
            this.LoadFileButton.Text = "Загрузить файл";
            this.LoadFileButton.UseVisualStyleBackColor = true;
            this.LoadFileButton.Click += new System.EventHandler(this.LoadFileButton_Click);
            // 
            // LabelConsoleIO
            // 
            this.LabelConsoleIO.AutoSize = true;
            this.LabelConsoleIO.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelConsoleIO.Location = new System.Drawing.Point(12, 290);
            this.LabelConsoleIO.Name = "LabelConsoleIO";
            this.LabelConsoleIO.Size = new System.Drawing.Size(186, 20);
            this.LabelConsoleIO.TabIndex = 3;
            this.LabelConsoleIO.Text = "Консоль ввода/вывода";
            // 
            // RichTextBoxConsoleIO
            // 
            this.RichTextBoxConsoleIO.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.RichTextBoxConsoleIO.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RichTextBoxConsoleIO.Location = new System.Drawing.Point(16, 313);
            this.RichTextBoxConsoleIO.Name = "RichTextBoxConsoleIO";
            this.RichTextBoxConsoleIO.ReadOnly = true;
            this.RichTextBoxConsoleIO.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RichTextBoxConsoleIO.Size = new System.Drawing.Size(761, 202);
            this.RichTextBoxConsoleIO.TabIndex = 4;
            this.RichTextBoxConsoleIO.Text = "";
            // 
            // StartQASMButton
            // 
            this.StartQASMButton.BackgroundImage = global::Quantum2.Properties.Resources.Play;
            this.StartQASMButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StartQASMButton.Location = new System.Drawing.Point(276, 7);
            this.StartQASMButton.Name = "StartQASMButton";
            this.StartQASMButton.Size = new System.Drawing.Size(78, 77);
            this.StartQASMButton.TabIndex = 5;
            this.StartQASMButton.UseVisualStyleBackColor = true;
            this.StartQASMButton.Click += new System.EventHandler(this.StartQASMButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(16, 521);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(761, 26);
            this.textBox1.TabIndex = 6;
            // 
            // TextBoxQASMCode
            // 
            this.TextBoxQASMCode.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.TextBoxQASMCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TextBoxQASMCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TextBoxQASMCode.Location = new System.Drawing.Point(12, 90);
            this.TextBoxQASMCode.Multiline = true;
            this.TextBoxQASMCode.Name = "TextBoxQASMCode";
            this.TextBoxQASMCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TextBoxQASMCode.Size = new System.Drawing.Size(761, 197);
            this.TextBoxQASMCode.TabIndex = 7;
            // 
            // QASMForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(786, 557);
            this.Controls.Add(this.TextBoxQASMCode);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.StartQASMButton);
            this.Controls.Add(this.RichTextBoxConsoleIO);
            this.Controls.Add(this.LabelConsoleIO);
            this.Controls.Add(this.LoadFileButton);
            this.Controls.Add(this.SaveFileButton);
            this.Name = "QASMForm";
            this.Text = "QASMForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SaveFileButton;
        private System.Windows.Forms.Button LoadFileButton;
        private System.Windows.Forms.Label LabelConsoleIO;
        private System.Windows.Forms.RichTextBox RichTextBoxConsoleIO;
        private System.Windows.Forms.Button StartQASMButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox TextBoxQASMCode;
    }
}