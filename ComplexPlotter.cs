using System;
using System.Drawing;
using System.Numerics;

namespace ComplexFunctions
{
    public class ComplexPlotter
    {
        private Bitmap bitmap;
        private int imgW;
        private int imgH;

        public ComplexPlotter(Bitmap bitmap)
        {
            this.bitmap = bitmap;
            this.imgW = bitmap.Width;
            this.imgH = bitmap.Height;
        }

        public void ComplexPlotZ5Z10(int v)
        {
            int rr = 2, ii = 0;
            if (v == 1) { rr = 0; ii = 2; }
            else if (v == 2) { rr = 2; ii = 2; }
            for (int x = 0; x < imgW; x++)
            {
                for (int y = 0; y < imgH; y++)
                {
                    Complex z = new Complex((2 * x / (double)imgW - 1) * ((double)imgW / (double)imgH), (2 * y / (double)imgH - 1));
                    z = z * 3;
                    z = Complex.Divide(Complex.Pow(z, 5) - 1, Complex.Pow(z, 10) - 512);
                    z = Complex.Pow(z, new Complex(rr, -ii));
                    int color = (int)(180 * (1 - z.Phase / Math.PI)) % 360;
                    bitmap.SetPixel(x, y, ColorFromHSV(color, 1.0, 1.0));
                }
            }
        }

        public void ComplexPlotSinZ()
        {
            for (int x = 0; x < imgW; x++)
            {
                for (int y = 0; y < imgH; y++)
                {
                    Complex z = new Complex((2 * x / (double)imgW - 1) * ((double)imgW / (double)imgH), (2 * y / (double)imgH - 1));
                    z = z * 2;
                    z = Complex.Divide(Complex.Sin(Complex.Multiply(2 * Math.PI, z)), Complex.Pow(z, 3));
                    if (Double.IsInfinity(z.Magnitude)) continue;
                    int color = (int)(180 * (1 - z.Phase / Math.PI)) % 360;
                    bitmap.SetPixel(x, y, ColorFromHSV(color, 1.0, 1.0));
                }
            }
        }

        public void ComplexPlotMixed()
        {
            for (int x = 0; x < imgW; x++)
            {
                for (int y = 0; y < imgH; y++)
                {
                    Complex z = new Complex((2 * x / (double)imgW - 1) * ((double)imgW / (double)imgH), (2 * y / (double)imgH - 1));
                    z = z * 2.5;
                    var z1 = Complex.Pow(Complex.Add(z, new Complex(1, 1)), 3);
                    var z2 = Complex.Multiply(Complex.Pow(z, 2) + 1, Complex.Exp(Complex.Divide(3, z)));
                    var z3 = Complex.Multiply(Complex.Pow(z - 1, 2), z + 1);
                    z = Complex.Divide(Complex.Multiply(z1, z2), z3);
                    if (Double.IsNaN(z.Magnitude)) continue;
                    int color = (int)(180 * (1 - z.Phase / Math.PI)) % 360;
                    bitmap.SetPixel(x, y, ColorFromHSV(color, 1.0, 1.0));
                }
            }
        }

        public Bitmap JuliaSet(int zoom, int offX, int offY)
        {
            const double cX = -0.7;
            const double cY = 0.27015;
            double zx, zy, tmp;
            for (int x = 0; x < imgW; x++)
            {
                for (int y = 0; y < imgH; y++)
                {
                    zx = 1.5 * (x - imgW / 2 + offX) / (zoom * imgW / 2);
                    zy = 1.0 * (y - imgH / 2 + offY) / (zoom * imgH / 2);
                    int i = 255;
                    while (zx * zx + zy * zy < 4 && i > 1)
                    {
                        tmp = zx * zx - zy * zy + cX;
                        zy = 2.0 * zx * zy + cY;
                        zx = tmp; 
                        i--;
                    }
                    double hue = (i % 256) * 360.0 / 256.0;
                    double saturation = 1.0;
                    double value = i < 255 ? 1.0 : 0.0;
                    Color color = ColorFromHSV(hue, saturation, value);
                    bitmap.SetPixel(x, y, color);
                    if (zoom == 1 && i > 245)
                    {
                        bitmap.SetPixel(x, y, Color.LightCyan);
                    }
                }
            }
            return bitmap;
        }

        private Color ColorFromHSV(double hue, double saturation, double value)
        {
            int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
            double f = hue / 60 - Math.Floor(hue / 60);
            value = value * 255;
            int v = Convert.ToInt32(value);
            int p = Convert.ToInt32(value * (1 - saturation));
            int q = Convert.ToInt32(value * (1 - f * saturation));
            int t = Convert.ToInt32(value * (1 - (1 - f) * saturation));
            switch (hi)
            {
                case 0:
                    return Color.FromArgb(255, v, t, p);
                case 1:
                    return Color.FromArgb(255, q, v, p);
                case 2:
                    return Color.FromArgb(255, p, v, t);
                case 3:
                    return Color.FromArgb(255, p, q, v);
                case 4:
                    return Color.FromArgb(255, t, p, v);
                default:
                    return Color.FromArgb(255, v, p, q);
            }
        }
    }
}
