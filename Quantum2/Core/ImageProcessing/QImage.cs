using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Quantum2.Core.ImageProcessing
{
    public class QImage
    {
        private QImageData _data;

        public int Width
        {
            get
            {
                return _data._width;
            }
        }

        public int Height
        {
            get
            {
                return _data._height;
            }
        }

        public Qubit[] Qubits
        {
            get
            {
                return _data._qubits;
            }
            set
            {
                if (value.Length != _data._qubits.Length)
                    throw new Exception("The length of the first array must be equal to the length of the second array");

                _data._qubits = value;
            }
        }

        public static void SaveToFile(QImage qImage, string fileName)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, qImage._data);
            }
        }

        public static QImage LoadFromFile(string fileName)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                return new QImage( (QImageData)formatter.Deserialize(fs));
            }
        }

        private QImage(QImageData data)
        {
            _data = data;
        }

        public QImage(int width, int height)
        {
            _data = new QImageData();

            SetSize(width, height);
        }

        public void SetSize(int width, int height)
        {
            _data._width = width;
            _data._height = height;

            _data._qubits = new Qubit[_data._width * _data._height];

            _data._normCoef = 1 / Math.Sqrt(_data._width * _data._height);

        }

        public void SetQPixel(Qubit qPixel, int x, int y)
        {
            // Qubit resultQubit = new Qubit(qPixel.Alpha * x * _normCoef, qPixel.Beta * y * _normCoef);
            Qubit resultQubit = new Qubit(qPixel.Alpha * _data._normCoef, qPixel.Beta * _data._normCoef);

            _data._qubits[GetPixelIndex(x, y)] = resultQubit;
        }

        public Qubit GetQubit(int x, int y)
        {
            return _data._qubits[GetPixelIndex(x, y)];
        }

        public Qubit GetQPixel(int x, int y)
        {
            Qubit qi = _data._qubits[GetPixelIndex(x, y)];

            return new Qubit(qi.Alpha / _data._normCoef, qi.Beta / _data._normCoef);
            //return new Qubit(qi.Alpha / _normCoef / x, qi.Beta / _normCoef / y);
        }

        public int GetPixelIndex(int x, int y)
        {
            if (x >= _data._width || x < 0)
                throw new Exception("x must be greater than zero, and less than width");

            if (y >= _data._height || y < 0)
                throw new Exception("y must be greater than zero, and less than height");

            return y * _data._width + x;
        }
    }
}
