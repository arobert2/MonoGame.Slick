﻿using Microsoft.Xna.Framework;
using SlickEngine.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlickEngine.Shapes
{
    public class Line
    {
        public Point Point1 { get; set; }
        public Point Point2 { get; set; }

        public double Length { get => Point1.Distance(Point2); }
    }
}
