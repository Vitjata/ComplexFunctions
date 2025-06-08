using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace ComplexFunctions
{
    public class ComplexFramelessForm : FramelessForm
    {
        private int julia = 1;
        private int z5z10 = 0;

        public ComplexFramelessForm(int width, int height) : base(width, height)
        {
            caption = "Complex Functions";
            string[] buttonNames = { "Function 1,2,3", "Function Sin", "Function Mix", "Julia Set x1.. x16" };
            InitializeButtons(buttonNames);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            int clientWidth = this.ClientSize.Width;
            int clientHeight = this.ClientSize.Height;
            Bitmap bitmap = new Bitmap(clientWidth - 100, clientHeight - 100, PixelFormat.Format32bppArgb);
            ComplexPlotter plotter = new ComplexPlotter(bitmap);
            switch (drawFigure)
            {
                case 0:
                    // No figure
                    break;
                case 1:
                    plotter.ComplexPlotZ5Z10(z5z10);
                    g.DrawImage(bitmap, new Point(50, 50));
                    z5z10 += 1;
                    z5z10 = z5z10 % 3;
                    break;
                case 2:
                    plotter.ComplexPlotSinZ();
                    g.DrawImage(bitmap, new Point(50, 50));
                    break;
                case 3:
                    plotter.ComplexPlotMixed();
                    g.DrawImage(bitmap, new Point(50, 50));
                    break;
                case 4:
                    plotter.JuliaSet(julia, 0, 0);
                    e.Graphics.DrawImage(bitmap, new Point(50, 50));
                    julia *= 2;
                    if (julia > 16)
                    {
                        julia = 1;
                    }
                    break;
            }
        }
    }
}
