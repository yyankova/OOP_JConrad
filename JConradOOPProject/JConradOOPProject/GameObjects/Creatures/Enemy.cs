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
            : base(String.Empty, new Position())
        { }
        public Enemy(string name, Position position)
            : base(name, position)
        { }
    }
}
