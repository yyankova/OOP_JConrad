namespace JConradOOPProject.GameObjects.Tools.Weapons
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Axe : Item
    {
        // Fields
        private int axeHeadSharpness;

        // Constructors
        public Axe() 
            : base()
        { }

        public Axe(string inputName, int inputPrice)
            : base(inputName, inputPrice)
        {
        }

        public Axe(string inputName, decimal inputPrice, int inputSharpness)
            : base(inputName, inputPrice)
        {
            this.AxeHeadSharpness = inputSharpness;
        }

        //properties
        public int AxeHeadSharpness
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

        public override string ToString()
        {
            return base.ToString();
        } 
    }
}
