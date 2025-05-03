using System;
using System.Numerics;

using Quantum2.Core.ImageProcessing;

namespace Quantum2.Core.Cryptography
{
    public static class QC
    {

        private static readonly int _rotationDegreeK1 = 300;
        private static readonly int _rotationDegreeK2 = 150;

        public static QImage EncryptQImageXOR(QImage image, QImage key)
        {
            return QXOR.XORqImage(image, key);
        }

        public static QImage EncryptQImage2QFT(QImage image, QImage keyImage)
        {
            if (image.Width != keyImage.Width || image.Height != keyImage.Height)
                throw new Exception("The sizes of quantum images must be equal to");

            QImage qImageCrypto = new QImage(image.Width, image.Height);

            for(int i = 0;i < image.Qubits.Length;i++)
            {
                Complex K1 = keyImage.Qubits[i].Alpha * _rotationDegreeK1;

                Qubit Dj = QFT.Rk(image.Qubits[i], K1);

                qImageCrypto.Qubits[i] = Dj;
            }

            qImageCrypto.Qubits = QFT.QFTqs(qImageCrypto.Qubits);
            
            for(int i = 0;i < image.Qubits.Length;i++)
            {
                Complex K2 = keyImage.Qubits[i].Beta * _rotationDegreeK2;

                Qubit K2QFTDj = QFT.Rk(qImageCrypto.Qubits[i], K2);

                qImageCrypto.Qubits[i] = K2QFTDj;
            }

            qImageCrypto.Qubits = QFT.InQFTqs(qImageCrypto.Qubits);

            return qImageCrypto;
        }

        public static QImage DecryptQImage2QFT(QImage image, QImage keyImage)
        {
            if (image.Width != keyImage.Width || image.Height != keyImage.Height)
                throw new Exception("The sizes of quantum images must be equal to");

            QImage qImage = new QImage(image.Width, image.Height);

            qImage.Qubits = QFT.Reverse(QFT.QFTqs(image.Qubits));

            for(int i = 0; i < qImage.Qubits.Length;i++)
            {
                Complex K2 = keyImage.Qubits[i].Beta * _rotationDegreeK2;

                Qubit K2QFTDj = QFT.IRk(qImage.Qubits[i], K2);

                qImage.Qubits[i] = K2QFTDj;
            }

            qImage.Qubits = QFT.Reverse(QFT.InQFTqs(qImage.Qubits));

            for(int i = 0; i < qImage.Qubits.Length;i++)
            {
                 Complex K1 = keyImage.Qubits[i].Alpha * _rotationDegreeK1;

                Qubit Dj = QFT.IRk(qImage.Qubits[i], K1);

                qImage.Qubits[i] = Dj;
            }

            return qImage;
        }

    }
}
