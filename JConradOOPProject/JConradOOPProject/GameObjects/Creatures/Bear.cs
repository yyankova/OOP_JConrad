﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JConradOOPProject.GameObjects.Creatures
{
    public class Bear : Enemy
    {
        public override int InitialPrecision
        {
            get
            {
                return 50;
            }
        }
    }
}
