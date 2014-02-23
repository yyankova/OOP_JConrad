using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JConradOOPProject.GameObjects.Tools.Skills
{
    class Attack : Skill
    {
        //fields
        private byte levelOfSkill;
        private bool alwaysHit;

        //constructors
        public Attack(string inputName, decimal inputPrice)
            : base(inputName, inputPrice)
        { }

        public Attack(string inputName, decimal inputPrice, byte inputLevel)
            : base(inputName, inputPrice)
        {
            this.levelOfSkill = inputLevel;
        }

        //properties
        public bool AlwaysHit
        {
            get
            {
                return this.alwaysHit;
            }
            set 
            {
                this.alwaysHit = true;
            }
        }

        //methods

    }
}
