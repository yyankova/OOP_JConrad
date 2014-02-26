using JConradOOPProject.Commands;
using JConradOOPProject.GameObjects;
using JConradOOPProject.GameObjects.Creatures;
using JConradOOPProject.GameObjects.Tools.Shields;
using JConradOOPProject.GameObjects.Tools.Weapons;
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
        private string playerName;
        private Lumberjack player;
        private Enemy enemy;
        private bool playerCanAttack;
        private bool playerIsOnMainMap;
        private ICommand attack;
        private ICommand run;

        public GameEngine()
        {
            InitializeEnemy();
            InitializePlayer();
        }

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
        public int AttackWithSkill //0, 1, 2
        {
            get
            {
                return this.player.SkillIndex;
            }
            set
            {
                this.player.SkillIndex = value;
            }
        }
        public Weapon CurrentWeapon
        {
            get
            {
                return this.player.CurrentWeapon;
            }
        }
        public Shield CurrentShield
        {
            get
            {
                return this.player.CurrentShield;
            }
        }
        public decimal PlayerGold
        {
            get
            {
                return this.player.GoldAmount;
            }
        }
        public decimal PlayerHealth
        {
            get
            {
                return this.player.Health;
            }
        }
        public decimal EnemyHealth
        {
            get
            {
                return this.enemy.Health;
            }
        }
        public int PlayerExperience
        {
            get
            {
                return this.player.CurrentExperience;
            }
        }
        public string PlayerName
        {
            get
            {
                return this.player.Name;
            }
            set
            {
                this.playerName = value;
            }
        }
        
        public Lumberjack Player
        {
            get
            {
                return this.player;
            }
        }
        public void StartGame()
        {
            while (this.player.IsAlive && this.enemy.IsAlive)
            {
                if (!this.PlayerCanAttack)
                {
                    EnemyAttack();
                }
            }
        }

        private void InitializeEnemy()
        {
            int i = randomGen.Next(0, 3);
            switch (i)
            {
                case (0):
                    this.enemy = new Bear("");
                    break;
                case (1):
                    this.enemy = new ForestGhost("");
                    break;
                default:
                    this.enemy = new EnemyLumberjack("");
                    break;
            }
        }

        private void InitializePlayer()
        {
            this.player = new Lumberjack(this.playerName, GameParameters.InitialLevel, GameParameters.InitialExperience, GameParameters.InitialGold);
            this.PlayerCanAttack = (this.player.Speed > this.enemy.Speed);
        }

        void HandlePlayerAttack(object player)
        {
            int currentAttackHitCoeff = randomGen.Next(1, 101);
            decimal skillHitCoeff = this.player.CurrentSkills[this.player.SkillIndex].HitRateCoeff;
            if (currentAttackHitCoeff * skillHitCoeff > GameParameters.PlayerHitChance)
            {
                this.player.Hit(this.enemy);
                if (this.enemy.IsAlive)
                {
                    this.PlayerCanAttack = false;
                }
            }
            OnPropertyChanged("EnemyHealth");
            OnPropertyChanged("PlayerGold");
            OnPropertyChanged("PlayerExperience");
        }

        bool CanPlayerAttack(object player)
        {
            return this.PlayerCanAttack;
        }

        void EnemyAttack()
        {
            int currentAttackHitCoeff = randomGen.Next(1, 101);
            if (currentAttackHitCoeff > GameParameters.EnemyHitChance)
            {
                this.enemy.Hit(this.player);
            }

            if (this.player.IsAlive)
            {
                this.PlayerCanAttack = true;
            }
            OnPropertyChanged("PlayerHealth");
        }

        void HandleRun(object player)
        { }
        
        bool CanRun(object player)
        {
            return true;
        }
    }
}
