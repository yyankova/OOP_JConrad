namespace JConradOOPProject.GameObjects.Tools.Weapons
{
    using System;

    class Chopper : Item
    {
        //constants 
        const int HitPoints = 150;

        // Fields
        private int axeHeadSharpness;
        private ColorEnum color;

        // Constructors
        public Chopper() 
            : base()
        { }

        public Chopper(string inputName, int inputPrice)
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
