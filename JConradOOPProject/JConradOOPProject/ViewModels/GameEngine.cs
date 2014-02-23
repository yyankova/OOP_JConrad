using JConradOOPProject.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace JConradOOPProject.ViewModels
{
    public class GameEngine : BaseViewModel
    {
        //Members
        private ICommand attack;
        private ICommand run;

        //Constructor
        public GameEngine()
        { }

        //Properties : to be bound to the buttons
        public ICommand Attack
        {
            get
            {
                if (this.attack == null)
                {
                    attack = new RelayCommand(
                        this.HandleAttack,
                        this.CanAttack
                        );
                }
                return this.attack;
            }
        }
        public ICommand Run
        {
            get
            {
                if (this.run == null)
                {
                    run = new RelayCommand(
                        this.HandleRun,
                        this.CanRun
                        );
                }
                return this.run;
            }
        }

        //Methods to initialize the commands with
        void HandleAttack(object player)
        { }
        bool CanAttack(object player)
        {
            return true;
        }
        void HandleRun(object player)
        { }
        bool CanRun(object player)
        {
            return true;
        }
    }
}
