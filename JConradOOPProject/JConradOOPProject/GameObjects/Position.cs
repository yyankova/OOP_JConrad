﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JConradOOPProject.GameObjects
{
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Position()
        {
            this.X = 0;
            this.Y = 0;
        }
        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
