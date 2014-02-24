﻿namespace JConradOOPProject.GameObjects.Tools.Shields
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using JConradOOPProject.GameObjects.Tools.Weapons;

    class SweatCloth : Shield
    {
        //constants 
        const int DefencePoints = 100;

        // Fields
        private ColorEnum color;

        // Constructors
        public SweatCloth() 
            : base()
        { }

        public SweatCloth(string inputName, decimal inputPrice)
            : base(inputName, inputPrice)
        {
        }

        public SweatCloth(string inputName, decimal inputPrice, string imageSource)
            : base(inputName, inputPrice, imageSource)
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
