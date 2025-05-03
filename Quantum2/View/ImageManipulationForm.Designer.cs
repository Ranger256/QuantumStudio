
namespace Quantum2.View
{
    partial class ImageManipulationForm
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
            this.UploadANormalImageButton = new System.Windows.Forms.Button();
            this.UploadAQuantumImage = new System.Windows.Forms.Button();
            this.SaveAQuantumImageButton = new System.Windows.Forms.Button();
            this.SaveANormalImage = new System.Windows.Forms.Button();
            this.ChoiseImageButton = new System.Windows.Forms.Button();
            this.EncryptTheImageButton = new System.Windows.Forms.Button();
            this.DecryptImageButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UploadANormalImageButton
            // 
            this.UploadANormalImageButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UploadANormalImageButton.Location = new System.Drawing.Point(12, 12);
            this.UploadANormalImageButton.Name = "UploadANormalImageButton";
            this.UploadANormalImageButton.Size = new System.Drawing.Size(256, 51);
            this.UploadANormalImageButton.TabIndex = 0;
            this.UploadANormalImageButton.Text = "Загрузить обычное изображение";
            this.UploadANormalImageButton.UseVisualStyleBackColor = true;
            this.UploadANormalImageButton.Click += new System.EventHandler(this.UploadANormalImageButton_Click);
            // 
            // UploadAQuantumImage
            // 
            this.UploadAQuantumImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UploadAQuantumImage.Location = new System.Drawing.Point(12, 69);
            this.UploadAQuantumImage.Name = "UploadAQuantumImage";
            this.UploadAQuantumImage.Size = new System.Drawing.Size(256, 51);
            this.UploadAQuantumImage.TabIndex = 1;
            this.UploadAQuantumImage.Text = "Загрузить квантовое изображение";
            this.UploadAQuantumImage.UseVisualStyleBackColor = true;
            this.UploadAQuantumImage.Click += new System.EventHandler(this.UploadAQuantumImage_Click);
            // 
            // SaveAQuantumImageButton
            // 
            this.SaveAQuantumImageButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SaveAQuantumImageButton.Location = new System.Drawing.Point(12, 183);
            this.SaveAQuantumImageButton.Name = "SaveAQuantumImageButton";
            this.SaveAQuantumImageButton.Size = new System.Drawing.Size(256, 51);
            this.SaveAQuantumImageButton.TabIndex = 4;
            this.SaveAQuantumImageButton.Text = "Сохранить квантовое изображение";
            this.SaveAQuantumImageButton.UseVisualStyleBackColor = true;
            this.SaveAQuantumImageButton.Click += new System.EventHandler(this.SaveAQuantumImageButton_Click);
            // 
            // SaveANormalImage
            // 
            this.SaveANormalImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SaveANormalImage.Location = new System.Drawing.Point(12, 126);
            this.SaveANormalImage.Name = "SaveANormalImage";
            this.SaveANormalImage.Size = new System.Drawing.Size(256, 51);
            this.SaveANormalImage.TabIndex = 3;
            this.SaveANormalImage.Text = "Сохранить обычное изображение";
            this.SaveANormalImage.UseVisualStyleBackColor = true;
            this.SaveANormalImage.Click += new System.EventHandler(this.SaveANormalImage_Click);
            // 
            // ChoiseImageButton
            // 
            this.ChoiseImageButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ChoiseImageButton.Location = new System.Drawing.Point(278, 12);
            this.ChoiseImageButton.Name = "ChoiseImageButton";
            this.ChoiseImageButton.Size = new System.Drawing.Size(400, 400);
            this.ChoiseImageButton.TabIndex = 5;
            this.ChoiseImageButton.UseVisualStyleBackColor = true;
            this.ChoiseImageButton.Click += new System.EventHandler(this.ChoiseImageButton_Click);
            // 
            // EncryptTheImageButton
            // 
            this.EncryptTheImageButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EncryptTheImageButton.Location = new System.Drawing.Point(12, 240);
            this.EncryptTheImageButton.Name = "EncryptTheImageButton";
            this.EncryptTheImageButton.Size = new System.Drawing.Size(256, 51);
            this.EncryptTheImageButton.TabIndex = 6;
            this.EncryptTheImageButton.Text = "Зашифровать изображение";
            this.EncryptTheImageButton.UseVisualStyleBackColor = true;
            this.EncryptTheImageButton.Click += new System.EventHandler(this.EncryptTheImageButton_Click);
            // 
            // DecryptImageButton
            // 
            this.DecryptImageButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DecryptImageButton.Location = new System.Drawing.Point(12, 297);
            this.DecryptImageButton.Name = "DecryptImageButton";
            this.DecryptImageButton.Size = new System.Drawing.Size(256, 51);
            this.DecryptImageButton.TabIndex = 7;
            this.DecryptImageButton.Text = "Расшифровать изображение";
            this.DecryptImageButton.UseVisualStyleBackColor = true;
            this.DecryptImageButton.Click += new System.EventHandler(this.DecryptImageButton_Click);
            // 
            // ImageManipulationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 420);
            this.Controls.Add(this.DecryptImageButton);
            this.Controls.Add(this.EncryptTheImageButton);
            this.Controls.Add(this.ChoiseImageButton);
            this.Controls.Add(this.SaveAQuantumImageButton);
            this.Controls.Add(this.SaveANormalImage);
            this.Controls.Add(this.UploadAQuantumImage);
            this.Controls.Add(this.UploadANormalImageButton);
            this.Name = "ImageManipulationForm";
            this.Text = "ImageManipulation";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button UploadANormalImageButton;
        private System.Windows.Forms.Button UploadAQuantumImage;
        private System.Windows.Forms.Button SaveAQuantumImageButton;
        private System.Windows.Forms.Button SaveANormalImage;
        private System.Windows.Forms.Button ChoiseImageButton;
        private System.Windows.Forms.Button EncryptTheImageButton;
        private System.Windows.Forms.Button DecryptImageButton;
    }
}