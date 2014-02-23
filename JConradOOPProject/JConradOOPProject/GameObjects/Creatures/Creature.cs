﻿
using JConradOOPProject.GameObjects.Tools.Shields;
using JConradOOPProject.GameObjects.Tools.Weapons;
using JConradOOPProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JConradOOPProject.GameObjects.Creatures
{
    public abstract class Creature : GameObject, IMovable
    {
        public virtual int InitialHealth
        { 
            get
            {
                return 100;
            }
        }
        public virtual int InitialAttackPower
        {
            get
            {
                return 100;
            }
        }
        public virtual int InitialDefencePower
        {
            get
            {
                return 100;
            }
        }
        public virtual int InitialPrecision
        {
            get
            {
                return 100;
            }
        }
        public virtual int InitialSpeed
        {
            get
            {
                return 100;
            }
        }

        public string Name { get; set; }
        public int Health { get; set; }
        public int AttackPower { get; set; }
        public int DefencePower { get; set; }
        public int Precision { get; set; }
        public int Speed { get; set; }
        public Weapon CurrentWeapon { get; set; }
        public Shield CurrentShield { get; set; }
        public bool IsAlive
        {
            get
            {
                return this.Health > 0;
            }
        }
       
        public Creature() : this(String.Empty, new Position(), 0, 0)
        { }
        public Creature(string name, Position position, int width, int heigth)
        {
            this.Name = name;
            this.Position = position;
            this.Width = width;
            this.Heigth = heigth;
            this.Health = InitialHealth;
            this.AttackPower = InitialAttackPower;
            this.DefencePower = InitialDefencePower;
            this.Precision = InitialPrecision;
            this.Speed = InitialSpeed;
        }

        public void Move(int deltaX, int deltaY)
        {
            this.Position.X += deltaX;
            this.Position.Y += deltaY;
        }

        public virtual int HitPower()
        {
            return this.AttackPower + this.CurrentWeapon.Power;
        }
    }
}
