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
        Position position;
        public int Heigth { get; set; }
        public int Width { get; set; }
    }
}
