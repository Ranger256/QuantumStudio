using System;
using System.Drawing;
using System.Windows.Forms;

namespace Quantum2.View
{
    public partial class ImageManipulationForm : Form
    {
        private ImageChoiseForm _imageChoiseForm;

        public ImageManipulationForm()
        {
            InitializeComponent();

            _imageChoiseForm = new ImageChoiseForm();
            _imageChoiseForm.AddAction(ChangeImageButton);
        }

        private void ChangeImageButton(string name)
        {
            ChoiseImageButton.BackgroundImage = ControllerImages.GetNormalImage(name);
        }

        private void UploadANormalImageButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "(*.png)|*.png|(*.bmp)|*.bmp|(*.jpg)|*.jpg";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        ControllerImages.LoadNormalImage(openFileDialog.FileName);

                        _imageChoiseForm.AddImageButton(openFileDialog.FileName, ControllerImages.GetNormalImage(openFileDialog.FileName));
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UploadAQuantumImage_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "(*.bqg)|*.bqg";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        ControllerImages.LoadQuantumImage(openFileDialog.FileName);

                        _imageChoiseForm.AddImageButton(openFileDialog.FileName, ControllerImages.GetNormalImage(openFileDialog.FileName));
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveANormalImage_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "(*.png)|*.png|(*.bmp)|*.bmp|(*.jpg)|*.jpg";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        ControllerImages.SaveNormalImage(saveFileDialog.FileName, _imageChoiseForm.ActiveImage);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveAQuantumImageButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "(*.bqg)|*.bqg";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        ControllerImages.SaveQuantumImage(saveFileDialog.FileName, _imageChoiseForm.ActiveImage);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ChoiseImageButton_Click(object sender, EventArgs e)
        {
            _imageChoiseForm.ShowDialog();
        }

        private void EncryptTheImageButton_Click(object sender, EventArgs e)
        {
            string keyImageName;
            string encryptedImageName;

            ControllerImages.EncryptImage(_imageChoiseForm.ActiveImage, out keyImageName, out encryptedImageName);

            _imageChoiseForm.AddImageButton(keyImageName, ControllerImages.GetNormalImage(keyImageName));
            _imageChoiseForm.AddImageButton(encryptedImageName, ControllerImages.GetNormalImage(encryptedImageName));
        }

        private void DecryptImageButton_Click(object sender, EventArgs e)
        {
            string decryptedImageName = null;
            string keyImageName = null;

            
            try
            {
                //ВОТ это блять ебанный говнокод исправь это долбаеб
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "(*.bqg)|*.bqg";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        keyImageName = openFileDialog.FileName;
                    }
                }
                //

                ControllerImages.DecryptImage(_imageChoiseForm.ActiveImage, keyImageName, out decryptedImageName);

                _imageChoiseForm.AddImageButton(decryptedImageName, ControllerImages.GetNormalImage(decryptedImageName));
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
