using JConradOOPProject.Commands;
using JConradOOPProject.GameObjects;
using JConradOOPProject.GameObjects.Creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace JConradOOPProject.ViewModels
{
    public class GameEngine : BaseViewModel
    {
        private static readonly Random randomGen = new Random();

        private Lumberjack player;
        private Enemy enemy;
        private bool playerCanAttack;
        private bool playerIsOnMainMap;
        private ICommand attack;
        private ICommand run;

        public GameEngine()
        { }

        //Properties to be bound
        public ICommand Attack
        {
            get
            {
                if (this.attack == null)
                {
                    attack = new RelayCommand(
                        this.HandlePlayerAttack,
                        this.CanPlayerAttack
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
        public bool PlayerIsOnMainMap
        {
            get
            {
                return this.playerIsOnMainMap;
            }
            set
            {
                this.playerIsOnMainMap = value;
                OnPropertyChanged("PlayerIsOnMainMap");
            }
        }
        public bool PlayerCanAttack
        {
            get
            {
                return this.playerCanAttack;
            }
            set
            {
                this.playerCanAttack = value;
                OnPropertyChanged("PlayerCanAttack");
            }
        }
       
        public void StartGame()
        {
            InitializeEnemy();
            InitializePlayer();
            //...

            while (this.player.IsAlive && this.enemy.IsAlive)
            {
                if (!this.PlayerCanAttack)
                {
                    EnemyAttack();
                    if (this.enemy.IsAlive && this.player.IsAlive)
                    {
                        this.PlayerCanAttack = true;
                    }
                    //TODO: Calculate damage on player
                }
                else
                {
                    //TODO: Wait for user input?    
                }
            }
            if (this.player.IsAlive)
            {
                this.player.GoldAmount += 0; //TODO
                this.player.CurrentExperience += 0; //TODO
                this.player.CurrentLevel = GameParameters.GetCurrentLevel(this.player.CurrentExperience);
                this.PlayerIsOnMainMap = true;
            }
            else // this.enemy.IsAlive
            {
                //TODO: calculate damage;
            }

            //...
        }

        private void InitializeEnemy()
        {
            //TODO: Generate enemy depending on selected area or generate random enemy
            this.enemy = new ForestGhost("Ghost", new Position());
        }
        private void InitializePlayer()
        {
            //TODO: Pass name parameter
            this.player = new Lumberjack("Jack", new Position());
            this.PlayerCanAttack = (this.player.Speed > this.enemy.Speed);
        }
        void HandlePlayerAttack(object player)
        {
            //TODO: set selected skill in this.player.SkillIndex before calling the method
        }
        bool CanPlayerAttack(object player)
        {
            return this.PlayerCanAttack;
        }
        void EnemyAttack()
        {
            //TODO
        }
        void HandleRun(object player)
        { }
        bool CanRun(object player)
        {
            return true;
        }
    }
}
