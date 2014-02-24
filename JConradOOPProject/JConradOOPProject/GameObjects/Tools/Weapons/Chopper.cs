namespace JConradOOPProject.GameObjects.Tools.Weapons
{
    using System;

    class Chopper : Weapon
    {
        //constants 
        const int HitPoints = 150;

        // Fields
        private ColorEnum color;

        // Constructors
        public Chopper() 
            : base()
        { }

        public Chopper(string inputName, int inputPrice)
            : base(inputName, inputPrice)
        {
        }

        public Chopper(string inputName, int inputPrice, string imageSource)
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
        
        public override int Power
        {
            get
            {
                return HitPoints;
            }
        }
    }
}
