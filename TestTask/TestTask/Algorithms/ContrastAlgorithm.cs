using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Algorithms
{
    class ContrastAlgorithm : Algorithm
    {
        public override void MathPart(Bitmap input_picture, int threshold)
        {
            var locked_bitmap = new BitmapLocker(input_picture);
            locked_bitmap.LockBits();
        }
    }
}
