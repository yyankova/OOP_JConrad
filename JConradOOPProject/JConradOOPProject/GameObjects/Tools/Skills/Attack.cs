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
        private decimal damageCoeff;

        //constructors
        public Attack(byte id, string inputName, decimal inputPrice)
            : base(id, inputName, inputPrice)
        { }

        public Attack(byte id, string inputName, decimal inputPrice, byte inputLevel)
            : base(id, inputName, inputPrice)
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

        public decimal DamageCoeff
        {
            get
            {
                return this.damageCoeff;
            }
            set
            {
                this.damageCoeff = value;
            }
        }

        //methods

    }
}
