using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JConradOOPProject.GameObjects.Creatures
{
    public abstract class Enemy: Creature
    {
        public Enemy()
            : base(String.Empty, new Position(), 0, 0)
        { }
        public Enemy(string name, Position position, int width, int height)
            : base(name, position, width, height)
        { }
    }
}
