using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace TestTask.Algorithms
{
    class ContrastAlgorithm : IAlgorithm
    {

        public Bitmap MathPart(Bitmap input_picture)
        {
            int red, green, blue;
            var contrast = Math.Pow((100.0 + 5000) / 100.0, 2);

            for(int y = 0; y < input_picture.Height; y++)
            {
                for(int x = 0; x < input_picture.Width; x++)
                {
                    var old_color = input_picture.GetPixel(x, y);
                    double temp = ((((old_color.R / 255.0) - 0.5) * contrast) + 0.5 * 255.0);
                    red = (int)temp;
                    temp = ((((old_color.G / 255.0) - 0.5) * contrast) + 0.5 * 255.0);
                    green = (int)temp;
                    temp = ((((old_color.B / 255.0) - 0.5) * contrast) + 0.5 * 255.0);
                    blue = (int)temp;

                    if(red > 255) red = 255;
                    if(red < 0) red = 0;

                    if(green > 255) green = 255;
                    if(green < 0) green = 0;

                    if(blue > 255) blue = 255;
                    if(blue < 0) blue = 0;

                    input_picture.SetPixel(x, y, Color.FromArgb(old_color.A, red, green, blue));
                }
            }
            return input_picture;
        }
    }
}
