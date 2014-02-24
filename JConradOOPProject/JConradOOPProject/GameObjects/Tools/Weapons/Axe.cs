namespace JConradOOPProject.GameObjects.Tools.Weapons
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Axe : Weapon
    {
        //constants 
        const int HitPoints = 100;

        // Fields
        private int axeHeadSharpness; //do not use it for now
        private ColorEnum color;

        // Constructors
        public Axe() 
            : base()
        { }

        public Axe(string inputName, int inputPrice)
            : base(inputName, inputPrice)
        {
        }

        public Axe(string inputName, int inputPrice, string imageSource)
            : base(inputName, inputPrice, imageSource)
        {
        }

        public Axe(string inputName, decimal inputPrice, int inputSharpness)
            : base(inputName, inputPrice)
        {
            this.AxeHeadSharpness = inputSharpness;
        }

        //properties

        public int AxeHeadSharpness //do not use it for now
        {
            get 
            {
                return this.axeHeadSharpness;            
            }
            set 
            {
                this.axeHeadSharpness = value;
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

        public override int Power
        {
            get
            {
                return HitPoints;
            }

        }
    }
}
