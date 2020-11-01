using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    class Contrast : IRender
    {
        public void MathPart (Bitmap InputPicture)
        {
            int max = GetMax();
            int min = GetMin();
        }
        public int GetMax ()
        {
            int max = 0;
            //find max
            return max;
        }
        public int GetMin()
        {
            int min = 0;
            //find min
            return min;
        }
        
    }
}
