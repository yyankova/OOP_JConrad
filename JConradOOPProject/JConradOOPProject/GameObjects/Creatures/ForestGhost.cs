﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JConradOOPProject.GameObjects.Creatures
{
    public class ForestGhost: Enemy
    {
        public ForestGhost(string name, Position position, int width, int heigth)
            : base(name, position, width, heigth)
        { }
    }
}
