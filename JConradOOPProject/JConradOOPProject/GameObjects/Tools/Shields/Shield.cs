namespace JConradOOPProject.GameObjects.Tools.Shields
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using JConradOOPProject.GameObjects.Tools.Weapons;

    public abstract class Shield : Item
    {
        public Shield()
        { }

        public Shield(string inputName, decimal inputPrice)
            : base(inputName, inputPrice)
        {
        }
    }
}
