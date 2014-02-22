﻿namespace JConradOOPProject.GameObjects.Tools
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class Item
    {
        private string name;
        private decimal price;
        private string description;

        public Item()
        { }

        public Item(string inputName, decimal inputPrice)
        {
            this.Name = inputName;
            this.Price = inputPrice;
        }

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
                if (price <= 0)
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

        public override string ToString()
        {
            return base.ToString();
        }

    }
}
