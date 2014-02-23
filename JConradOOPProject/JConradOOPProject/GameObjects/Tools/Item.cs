namespace JConradOOPProject.GameObjects.Tools
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class Item
    {
        //fields
        private string name;
        private decimal price;
        private string description;

        //constructors
        public Item()
        { }

        public Item(string inputName, decimal inputPrice)
        {
            this.Name = inputName;
            this.Price = inputPrice;
        }

        //properties
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            set 
            {
                if (value <= 0)
                {
                    throw new Exception("The price must be postive number.");
                }
                this.price = value; 
            }
        }

        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new Exception("The inputed description must have at least one character.");
                }
                this.description = value;
            }
        }

        //methods
        public override string ToString()
        {
            return base.ToString();
        }

    }
}
