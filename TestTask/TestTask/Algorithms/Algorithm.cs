﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Algorithms
{
    abstract class Algorithm
    {
        public abstract void MathPart(Bitmap input_picture, int threshold);
    }
}