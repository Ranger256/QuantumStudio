using System;
using System.Drawing;
using System.Collections.Generic;

using Quantum2.Core.ImageProcessing;
using Quantum2.Core.Cryptography;

namespace Quantum2
{
    public struct EI
    {
        public QImage _keyImage;
        public QImage _encryptImage;

        public EI(QImage keyImage, QImage encryptImage)
        {
            _keyImage = keyImage;
            _encryptImage = encryptImage;
        }
    }

    public static class ControllerImages
    {
        private static Dictionary<string,Bitmap> _normalImages;
        private static Dictionary<string,QImage> _quantumImages;

        static ControllerImages()
        {
            _normalImages = new Dictionary<string, Bitmap>();
            _quantumImages = new Dictionary<string, QImage>();
        }

        public static Bitmap GetNormalImage(string name)
        {
            return _normalImages[name];
        }

        public static QImage GetQImage(string name)
        {
            return _quantumImages[name];
        }

        public static void EncryptImage(string imageName, out string keyImageName, out string encryptedImageName)
        {
            QImage image = _quantumImages[imageName];

            keyImageName = "key" + imageName;
            encryptedImageName = "encrypted" + imageName;

            QImage keyImage = QKeyGeneration.QImageKeyGeneration(image.Width, image.Height);
            QImage encryptedImage = QC.EncryptQImage2QFT(image, keyImage);

            Bitmap keyImageBitmap = ConvertImage.ToImage(keyImage);
            Bitmap encryptedImageBitmap = ConvertImage.ToImage(encryptedImage);

            _quantumImages.Add(keyImageName,keyImage);
            _quantumImages.Add(encryptedImageName, encryptedImage);

            _normalImages.Add(keyImageName, keyImageBitmap);
            _normalImages.Add(encryptedImageName, encryptedImageBitmap);
        }

        public static void DecryptImage(string imageName, string keyImageName, out string decryptedImageName)
        {
            QImage encryptedImage = _quantumImages[imageName];
            QImage keyImage = _quantumImages[keyImageName];

            decryptedImageName = "decrypted" + imageName;

            QImage decryptedImage = QC.DecryptQImage2QFT(encryptedImage,keyImage);

            _quantumImages.Add(decryptedImageName, decryptedImage);
            _normalImages.Add(decryptedImageName, ConvertImage.ToImage(decryptedImage));
        }

        public static void LoadNormalImage(string name)
        {
            if (_normalImages.ContainsKey(name))
                throw new Exception("This image already exists");

            Bitmap normalImage = (Bitmap)Image.FromFile(name);
            QImage quantumImage = ConvertImage.ToQImage(normalImage);

            _normalImages.Add(name,normalImage);
            _quantumImages.Add(name,quantumImage);
        }

        public static void LoadQuantumImage(string name)
        {
            if(_quantumImages.ContainsKey(name))
                throw new Exception("This image already exists");

            QImage quantumImage = QImage.LoadFromFile(name);
            Bitmap normalImage = ConvertImage.ToImage(quantumImage);

            _quantumImages.Add(name, quantumImage);
            _normalImages.Add(name, normalImage);
        }

        public static void SaveNormalImage(string fileName, string nameImage)
        {
            _normalImages[nameImage].Save(fileName);
        }

        public static void SaveQuantumImage(string fileName, string nameImage)
        {
            QImage.SaveToFile(_quantumImages[nameImage], fileName);
        }
    }
}
