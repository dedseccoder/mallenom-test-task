﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Algorithms
{
    public interface IAlgorithm
    {
        Bitmap MathPart(Bitmap input_picture);
    }
}