﻿using JConradOOPProject.GameObjects.Tools.Shields;
using JConradOOPProject.GameObjects.Tools.Skills;
using JConradOOPProject.GameObjects.Tools.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JConradOOPProject.GameObjects.Creatures
{
    class Lumberjack : Creature
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int CurrentLevel { get; set; }
        public int CurrentExperience { get; set; }
        public int GoldAmount { get; set; }
        public int AttackPower { get; set; }
        public int DefencePower { get; set; }
        public int Precision { get; set; }
        public int Speed { get; set; }

        public List<Skill> Skills { get; set; } // list of skills
        public Skill CurrentSkill { get; set; } // 1, 2, 3: with which skill the attack is performed

        public List<Weapon> Weapons { get; set; }
        public Weapon CurrentWeapon { get; set; }

        public List<Shield> Shields { get; set; }
        public Shield CurrentShield { get; set; }
    }
}
