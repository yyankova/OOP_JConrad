﻿namespace JConradOOPProject.GameObjects.Tools.Shields
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using JConradOOPProject.GameObjects.Tools.Weapons;

    class ChainArmour : Shield
    {
        //constants 
        const int DefencePoints = 100;

        // Fields
        private ColorEnum color;

        // Constructors
        public ChainArmour() 
            : base()
        { }

        public ChainArmour(string inputName, decimal inputPrice)
            : base(inputName, inputPrice)
        {
        }

        //properties

        public ColorEnum Color
        {
            get 
            {
                return this.color;
            }
            set
            {
                try
                {
                    this.color = value;
                }
                catch (Exception)
                {                    
                    throw new Exception("Invalid color");
                }                
            }

        }
        public override string ToString()
        {
            return base.ToString();
        } 
    }
}
