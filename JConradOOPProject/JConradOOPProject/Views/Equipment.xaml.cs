namespace JConradOOPProject.Views
{
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using JConradOOPProject.ViewModels;
    using GameObjects.Tools;
    using GameObjects.Tools.Skills;
    using GameObjects.Tools.Weapons;
    using GameObjects.Tools.Shields;
    using System.Collections.ObjectModel;

    /// <summary>
    /// Interaction logic for Equipment.xaml
    /// </summary>
    public partial class Equipment : UserControl
    {
        private GameEngine parent;
        //private ObservableCollection<Item> inventory; //weapons and shields
        //private ObservableCollection<Skill> skills;
        //private ObservableCollection<Item> shop;

        public Equipment(GameEngine parent)
        {
            InitializeComponent();
            this.parent = parent;
            byte id = 0;

            FillInventoryTab(ref id);
            FillSkillsTab(ref id);
            FillShopTab(ref id);
        }

        /// <summary>
        /// Process the OnClick event of button "Use"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonUse_Click(object sender, RoutedEventArgs e)
        {
            TabItem ti = this.TabControl.SelectedItem as TabItem;

            if (ti.Header.ToString().Equals("Inventory", StringComparison.Ordinal) == true)
            {
                if (this.Inventory.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select an item.", "Select An Item");
                    return;
                }

                Equip((Item)this.Inventory.SelectedItem);

            }
            else if (ti.Header.ToString().Equals("Skills", StringComparison.Ordinal) == true)
            {
                if (this.Skills.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select an item.", "Select An Item");
                    return;
                }

                Equip((Item)this.Skills.SelectedItem);
            }
            else if (ti.Header.ToString().Equals("Shop", StringComparison.Ordinal) == true)
            {
                if (this.Shop.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select an item.", "Select An Item");
                    return;
                }
                try
                {
                    Buy((Item)this.Shop.SelectedItem);
                }
                catch (ArgumentOutOfRangeException ex) //TODO: custom exception here
                {
                    string msg = string.Format("Your gold ({0}) is not enough to buy {1} ({2})",
                        parent.Player.GoldAmount, ((Item)this.Shop.SelectedItem).Name,
                        ((Item)this.Shop.SelectedItem).Price);
                    MessageBox.Show(msg, "Not enough money");
                }
            }
            else
            {
                //TODO: raise exception here!
            }
        }

        /// <summary>
        /// Button BACK
        /// Returns the player to the game map
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            MainMenu.SwitchWindowContent(new GameMap(this.parent), true);
        }

        /// <summary>
        /// Fill Inventory tab with stock weapons and armors
        /// </summary>
        /// <param name="items"></param>
        private void FillInventoryTab(ref byte id)
        {
            if (parent.Inventory == null)
            {
                parent.Inventory = new ObservableCollection<Item>();
                parent.Inventory.Add(new Axe(id++, "Axe", inputPrice: 65, imageSource: "item"));
                parent.Inventory.Last().Description = "TODO: add some description of Axe. to change image";
                parent.Inventory.Add(new Chopper(id++, "Chopper", inputPrice: 100, imageSource: "item"));
                parent.Inventory.Last().Description = "TODO: add description of Chopper, to change image";
                parent.Inventory.Add(new Cutter(id++, "Cutter", inputPrice: 200, imageSource: "item"));
                parent.Inventory.Last().Description = "TODO: add description of Cutter, to change image";
                parent.Inventory.Add(new ChainArmour(id++, "Chain Armour", inputPrice: 125, imageSource: "item"));
                parent.Inventory.Last().Description = "TODO: add description of Chain Armor, change image";
                parent.Inventory.Add(new SweatCloth(id++, "Sweat Cloth", inputPrice: 85, imageSource: "item"));
                parent.Inventory.Last().Description = "TODO: add description";
            }

            Inventory.ItemsSource = parent.Inventory;

            //TODO: add handling of property SpecialValue, where?
            //if (item is Weapon)
            //    specialValue = String.Concat(((Weapon)item.HitPoints), " Attack");
            //else if (item is Shield)
            //    specialValue = String.Concat(((Shield) item).DefPoints, " Defence");
        }

        /// <summary>
        /// Fill Skills tab with stock skills
        /// </summary>
        /// <param name="items"></param>
        private void FillSkillsTab(ref byte id)
        {
            if (parent.Skills == null)
            {
                parent.Skills = new ObservableCollection<Skill>();
                parent.Skills.Add(new Skill(id++, "Some skill 1", 85, 1m, 1m, 1m, "item"));
                parent.Skills.Last().Description = "TODO: add description, change image";
                parent.Skills.Add(new Skill(id++, "Some skill 2", 150, 2m, 2m, 2m, "item"));
                parent.Skills.Last().Description = "TODO: add description, change image";
            }

            Skills.ItemsSource = parent.Skills;

            //TODO: add handling of specialValue, where?
            //string specialValue = String.Concat("Damage Coef: ", skill.DamageCoeff, skill.DefenceCoeff, " Defence Coef; ");
        }

        /// <summary>
        /// Fill the shop with stock weapons, armors and skills
        /// </summary>
        /// <param name="items"></param>
        private void FillShopTab(ref byte id)
        {
            if (parent.Shop == null)
            {
                parent.Shop = new ObservableCollection<Item>();

                parent.Shop.Add(new DoubleAxe(id++, "Double Axe", 100, imageSource: "item"));
                parent.Shop.Last().Description = "TODO: add description";
                parent.Shop.Add(new Knife(id++, "Knife", 100, imageSource: "item"));
                parent.Shop.Last().Description = "TODO: add description";
                parent.Shop.Add(new Skill(id++, "Some skill 3", 85, 1m, 1m, 1m, "item"));
                parent.Shop.Last().Description = "TODO: add description, change image";
                parent.Shop.Add(new Skill(id++, "Some skill 4", 150, 2m, 2m, 2m, "item"));
                parent.Shop.Last().Description = "TODO: add description, change image";
            }

            Shop.ItemsSource = parent.Shop;

            //TODO: add handling of SpecialValue
            //string specialValue = String.Concat("Damage Coef: ", skill.DamageCoeff, skill.DefenceCoeff, " Defence Coef; ");

            //if (item is Weapon)
            //    specialValue = String.Concat(((Weapon)item.HitPoints), " Attack");
            //else if (item is Shield)
            //    specialValue = String.Concat(((Shield) item).DefPoints, " Defence");
        }

        /// <summary>
        /// Handle equipping the hero with a weapon, shield or skill
        /// </summary>
        public void Equip(Item item)
        {
            if (item is Weapon)
            {
                //take the weapon that the hero currently has and place it in the inventory
                if (parent.Player.CurrentWeapon != null)
                {
                    parent.Inventory.Add(parent.Player.CurrentWeapon);
                }

                parent.Player.CurrentWeapon = (Weapon)item;
                parent.Inventory.Remove(item);
            }
            else if (item is Shield)
            {
                //take the shield that the hero currently has and place it in the inventory
                if (parent.Player.CurrentShield != null)
                {
                    parent.Inventory.Add(parent.Player.CurrentShield);
                }

                parent.Player.CurrentShield = (Shield)item;
                parent.Inventory.Remove(item);
            }
            else if (item is Skill)
            {
                //TODO: here get the correct slot!!!
                int slot = 0;

                if (parent.Player.CurrentSkills[slot] != null)
                {
                    parent.Skills.Add(parent.Player.CurrentSkills[slot]);
                }
                parent.Player.CurrentSkills[slot] = (Skill)item;
                parent.Skills.Remove((Skill)item);
            }
        }

        /// <summary>
        /// Buy a weapon/shield/skill from the shop
        /// </summary>
        public void Buy(Item item)
        {
            if (item.Price > parent.Player.GoldAmount)
            {
                //TODO: here we can use custom exception
                throw new ArgumentOutOfRangeException(string.Format("Not enough gold to buy {0}", item.Name));
            }
            if (item is Weapon || (item is Shield))
            {
                parent.Inventory.Add(item);
            }
            else if (item is Skill)
            {
                parent.Skills.Add((Skill)item);
            }

            parent.Player.GoldAmount -= (int)item.Price;
            parent.Shop.Remove(item);
        }
    }
}
