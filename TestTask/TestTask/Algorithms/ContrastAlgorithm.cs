using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace TestTask.Algorithms
{
    class ContrastAlgorithm : Algorithm
    {
        public override void MathPart(Bitmap input_picture)
        {
            var locked_bitmap = new BitmapLocker(input_picture);
            locked_bitmap.LockBits();

            var contrast = Math.Pow((100.0 + 50) / 100.0, 2);

            for(int y = 0; y < locked_bitmap.Height; y++)
            {
                for(int x = 0; x < locked_bitmap.Width; x++)
                {
                    var old_color = locked_bitmap.GetPixel(x, y);
                    var red = ((((old_color.R / 255.0) - 0.5) * contrast) + 0.5 * 255.0);
                    var green = ((((old_color.G / 255.0) - 0.5) * contrast) + 0.5 * 255.0);
                    var blue = ((((old_color.B / 255.0) - 0.5) * contrast) + 0.5 * 255.0);
                    
                    if(red > 255) red = 255;
                    if(green > 255) green = 255;
                    if(blue > 255) blue = 255;
                    
                    if(red < 0) red = 0;
                    if(green < 0) green = 0;
                    if(blue < 0) blue = 0;

                    var new_color = Color.FromArgb(old_color.A, (int) red, (int) green, (int) blue);
                    locked_bitmap.SetPixel(x, y, new_color);
                }
            }
            locked_bitmap.UnlockBits();
        }
    }
}
