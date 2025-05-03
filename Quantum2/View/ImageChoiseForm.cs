using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Quantum2.View
{
    public partial class ImageChoiseForm : Form
    {
        private Dictionary<string, Button> _imageButtons;

        private Action<string> _actionClick;

        private string _activeImage;

        public string ActiveImage
        {
            get
            {
                return _activeImage;
            }
        }

        public ImageChoiseForm()
        {
            InitializeComponent();

            _imageButtons = new Dictionary<string, Button>();
            _activeImage = "";
        }

        public void AddAction(Action<string> action)
        {
            _actionClick += action;
        }

        public void RemoveAction(Action<string> action)
        {
            _actionClick -= action;
        }

        public void AddImageButton(string nameImage, Image imageButton)
        {
            if (_imageButtons.Count == 0)
            {
                _activeImage = nameImage;
                _actionClick?.Invoke(_activeImage);
            }

            Button buttonImage = new Button()
            {
                Text = "",
                BackgroundImage = imageButton,
                BackgroundImageLayout = ImageLayout.Zoom,
                Size = new Size(400, 400),
                Location = new Point(15, _imageButtons.Count * 410 + 20)
            };

            buttonImage.Click += delegate (object sender, EventArgs eventArgs)
            {
                _activeImage = nameImage;
                _actionClick?.Invoke(_activeImage);
            };

            ImageButtonsScrollPanel.Controls.Add(buttonImage);

            _imageButtons.Add(nameImage, buttonImage);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
