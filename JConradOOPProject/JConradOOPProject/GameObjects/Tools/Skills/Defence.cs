using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JConradOOPProject.GameObjects.Tools.Skills
{
    class Defence : Skill
    {
        //fields
        private byte levelOfSkill;

        //constructors
        public Defence(string inputName, decimal inputPrice)
            : base(inputName, inputPrice)
        { }

        public Defence(string inputName, decimal inputPrice, byte inputLevel)
            : base(inputName, inputPrice)
        {
            this.levelOfSkill = inputLevel;
        }

        //properties
        

        //methods

    }
}
