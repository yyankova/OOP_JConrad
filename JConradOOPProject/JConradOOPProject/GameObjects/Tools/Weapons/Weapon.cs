namespace JConradOOPProject.GameObjects.Tools.Weapons
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class Weapon : Item
    {
        //fields

        public Weapon()
        { }
        public Weapon(string inputName, decimal inputPrice)
            : base(inputName, inputPrice)
        {
        }

        public Weapon(string inputName, decimal inputPrice, string imageSource)
            : base(inputName, inputPrice, imageSource)
        {
        }

        public abstract int Power
        {
            get;
        }
    }
}
