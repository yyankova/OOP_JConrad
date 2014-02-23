using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JConradOOPProject.GameObjects.Tools.Skills
{
    public abstract class Skill : Item
    {
        public Skill(string inputName, decimal inputPrice)
            : base(inputName, inputPrice)
        { }
    }
}
