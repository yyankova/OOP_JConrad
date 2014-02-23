namespace JConradOOPProject.GameObjects.Tools.Weapons
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class DoubleAxe : Weapon
    {
        //constants 
        const int HitPoints = 100;

        // Fields
        private int doubleAxeHeadSharpness;
        private ColorEnum color;

        // Constructors
        public DoubleAxe() 
            : base()
        { }

        public DoubleAxe(string inputName, int inputPrice)
            : base(inputName, inputPrice)
        {
        }

        public DoubleAxe(string inputName, decimal inputPrice, int inputSharpness)
            : base(inputName, inputPrice)
        {
            this.DoubleAxeHeadSharpness = inputSharpness;
        }

        //properties
        public int DoubleAxeHeadSharpness
        {
            get 
            {
                return this.doubleAxeHeadSharpness;            
            }
            set 
            {
                this.doubleAxeHeadSharpness = value;
            }
        }

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
