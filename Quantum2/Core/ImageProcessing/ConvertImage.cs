using System;
using System.Numerics;
using System.Drawing;

namespace Quantum2.Core.ImageProcessing
{
    public static class ConvertImage
    {
        public static QImage ToQImage(Bitmap image)
        {
            QImage qImage = new QImage(image.Width, image.Height);

            for(int x = 0; x < image.Width;x++)
            {
                for(int y = 0; y < image.Height; y++)
                {
                    qImage.SetQPixel(PixelToQubit(image.GetPixel(x,y)), x, y);
                }
            }

            return qImage;
        }

        public static Bitmap ToImage(QImage qImage)
        {
            Bitmap bitmap = new Bitmap(qImage.Width, qImage.Height);

            for(int x = 0; x < qImage.Width;x++)
            {
                for(int y = 0; y < qImage.Height;y++)
                {
                    bitmap.SetPixel( x, y, QubitToPixel( qImage.GetQPixel(x,y) ) );
                }
            }

            return bitmap;
        }

        public static Qubit PixelToQubit(double r, double g, double b)
        {
            if (r > 1 || r < 0 || g > 1 || g < 0 || b > 1 || b < 0)
                throw new Exception("Color components must be greater than zero and less than 1");

            double r1 = Math.Sqrt( 1.0d - (b * b) );
            double r2 = b;

            double phi1 = Math.Asin(2.0d * r - 1.0d);
            double phi2 = Math.Asin(2.0d * g - 1.0d);

            Complex c1 = r1 * Complex.Exp(new Complex(0, phi1));
            Complex c2 = r2 * Complex.Exp(new Complex(0, phi2));

            return new Qubit(c1, c2);
        }

        public static Qubit PixelToQubit(Color color)
        {
            return PixelToQubit(color.R /(double) 255, color.G /(double) 255, color.B /(double) 255);
        }

        public static Color QubitToPixel(Qubit qubit)
        {
            double phi1 = qubit.Alpha.Phase;
            double phi2 = qubit.Beta.Phase;

            int red = (int)((1 + Math.Sin(phi1)) / 2 * 255);
            int green = (int)((1 + Math.Sin(phi2)) / 2 * 255);
            int blue = (int)(qubit.Beta.Magnitude * 255);

            if (red == 127)
                red = 255;
            if (green == 127)
                green = 0;
            if (blue == 127)
                blue = 255;

            if (red < 0)
                red = 255;
            if (green < 0)
                green = 0;
            if (blue < 0)
                blue = 0;

            if (red > 255)
                red = 255;
            if (green > 255)
                green = 255;
            if (blue > 255)
                blue = 255;


            return Color.FromArgb(red ,green, blue );
        }
    }
}
