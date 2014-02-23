using JConradOOPProject.GameObjects.Tools.Shields;
using JConradOOPProject.GameObjects.Tools.Skills;
using JConradOOPProject.GameObjects.Tools.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JConradOOPProject.GameObjects.Creatures
{
    public partial class Lumberjack : Creature
    {
        public int CurrentLevel { get; set; }
        public int CurrentExperience { get; set; }
        public int GoldAmount { get; set; }
        
        public List<Skill> Skills { get; set; }
        public List<Skill> CurrentSkills { get; private set; } // max 3 skills; set is private because 
                           // we must add skills only from one place to make sure the slots are exactly 3
        public int SkillIndex { get; set; } //0, 1, 2: with which skill the attack is performed

        public List<Weapon> Weapons { get; set; }
        public Weapon CurrentWeapon { get; set; }

        public List<Shield> Shields { get; set; }
        public Shield CurrentShield { get; set; }

        public Lumberjack(string name, Position position) : base(name, position)
        { }
    }
}
