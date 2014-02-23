using JConradOOPProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JConradOOPProject.GameObjects
{
    public abstract class GameObject : BaseViewModel
    {
        protected Position position;
        public Position Position
        {
            get
            {
                return this.position;
            }
            set
            {
                this.position = value;
            }
        }
        public int Heigth { get; set; }
        public int Width { get; set; }
    }
}
