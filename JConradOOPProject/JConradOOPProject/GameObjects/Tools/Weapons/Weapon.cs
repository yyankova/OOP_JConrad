namespace JConradOOPProject.GameObjects.Tools.Weapons
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Weapon : Item
    {
        public Weapon()
        { }
        public Weapon(string inputName, decimal inputPrice)
            : base(inputName, inputPrice)
        {

        }
    }
}
