﻿namespace JConradOOPProject.GameObjects.Tools.Weapons
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Knife : Item
    {
         //constants 
        const int HitPoints = 100;

        // Fields
        private ColorEnum color;

        // Constructors
        public Knife() 
            : base()
        { }

        public Knife(string inputName, int inputPrice)
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
