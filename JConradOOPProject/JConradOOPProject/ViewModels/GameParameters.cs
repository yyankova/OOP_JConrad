using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JConradOOPProject.ViewModels
{
    public static class GameParameters
    {
        //Minimum experience required for level 1, 2, 3
        public static int[] levelMinExperience = new int[] { 0, 101, 201 };

        public static int GetCurrentLevel(int experience)
        {
            int level = 0;
            while (level < levelMinExperience.Length && experience >= levelMinExperience[level])
            {
                level++;
            }
            return level;
        }
    }
}
