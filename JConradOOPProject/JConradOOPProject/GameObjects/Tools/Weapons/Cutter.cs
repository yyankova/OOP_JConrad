namespace JConradOOPProject.GameObjects.Tools.Weapons
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Cutter : Weapon
    {
        //constants 
        const int HitPoints = 150;

        //fields
        private int cutterSpeed;

        //constructors
        public Cutter(string inputName, decimal inputPrice)
            : base(inputName, inputPrice)
        { }

        public Cutter(string inputName, decimal inputPrice, int inputSpeed)
            : base(inputName, inputPrice)
        {
            this.CutterSpeed = inputSpeed;
        }

        public int CutterSpeed
        {
            get 
            {
                return this.cutterSpeed;
            }
            set 
            {
                this.cutterSpeed = value;
            }
        }
    }
}
