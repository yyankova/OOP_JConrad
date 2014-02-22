namespace JConradOOPProject.GameObjects.Tools.Weapons
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Axe : Item
    {
        private int axeHeadSharpness;

        public Axe() 
            : base()
        { }

        public Axe(string inputName, int inputPrice)
            : base(inputName, inputPrice)
        {
            this.Name = inputName;
            this.Price = inputPrice;
        }

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
