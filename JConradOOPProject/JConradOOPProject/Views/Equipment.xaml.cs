using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using JConradOOPProject.ViewModels;
using System.Linq;

namespace JConradOOPProject.Views
{
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
        private ObservableCollection<Item> inventory; //weapons and shields
        private ObservableCollection<Skill> skills;
        private ObservableCollection<Item> shop;

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
            Console.WriteLine(ti.Header);

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
                Console.WriteLine("we are in Shop tab");
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
                    MessageBox.Show("Please select an item.", "Select An Item");
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
            this.inventory = new ObservableCollection<Item>();
            this.inventory.Add(new Axe(id++, "Axe", inputPrice: 65, imageSource: "item"));
            this.inventory.Last().Description = "TODO: add some description of Axe. to change image";

            this.inventory.Add(new Chopper(id++, "Chopper", inputPrice: 100, imageSource: "item"));
            this.inventory.Last().Description = "TODO: add description of Chopper, to change image";

            this.inventory.Add(new Cutter(id++, "Cutter", inputPrice: 200, imageSource: "item"));
            this.inventory.Last().Description = "TODO: add description of Cutter, to change image";

            //stock shields
            this.inventory.Add(new ChainArmour(id++, "Chain Armour", inputPrice: 125, imageSource: "item"));
            this.inventory.Last().Description = "TODO: add description of Chain Armor, change image";

            this.inventory.Add(new SweatCloth(id++, "Sweat Cloth", inputPrice: 85, imageSource: "item"));
            this.inventory.Last().Description = "TODO: add description";

            Inventory.ItemsSource = this.inventory;

            //TODO: add handling of property SpecialValue, where?
        //        if (item is Weapon)
        //            specialValue = String.Concat(((Weapon)item.HitPoints), " Attack");
        //        else if (item is Shield)
        //            specialValue = String.Concat(((Shield) item).DefPoints, " Defence");
        }

        /// <summary>
        /// Fill Skills tab with stock skills
        /// </summary>
        /// <param name="items"></param>
        private void FillSkillsTab(ref byte id)
        {
            this.skills = new ObservableCollection<Skill>();
            skills.Add(new Skill(id++, "Some skill 1", 85, 1m, 1m, 1m, "item"));
            skills.Last().Description = "TODO: add description, change image";

            skills.Add(new Skill(id++, "Some skill 2", 150, 2m, 2m, 2m, "item"));
            skills.Last().Description = "TODO: add description, change image";

            Skills.ItemsSource = skills;

            //TODO: add handling of specialValue, where?
            //string specialValue = String.Concat("Damage Coef: ", skill.DamageCoeff, skill.DefenceCoeff, " Defence Coef; ");
        }

        /// <summary>
        /// Fill the shop with stock weapons, armors and skills
        /// </summary>
        /// <param name="items"></param>
        private void FillShopTab(ref byte id)
        {
            this.shop = new ObservableCollection<Item>();
            shop.Add(new DoubleAxe(id++, "Double Axe", 100, imageSource: "item"));
            shop.Last().Description = "TODO: add description";

            shop.Add(new Knife(id++, "Knife", 100, imageSource: "item"));
            shop.Last().Description = "TODO: add description";

            shop.Add(new Skill(id++, "Some skill 3", 85, 1m, 1m, 1m, "item"));
            shop.Last().Description = "TODO: add description, change image";
                
            shop.Add(new Skill(id++, "Some skill 4", 150, 2m, 2m, 2m, "item"));
            shop.Last().Description = "TODO: add description, change image";

            Shop.ItemsSource = shop;

            //TODO: add handling of SpecialValue
        //        string specialValue = String.Concat("Damage Coef: ", skill.DamageCoeff, skill.DefenceCoeff, " Defence Coef; ");

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
            Console.WriteLine("Jack has {0} gold", parent.Player.GoldAmount);

            if (item is Weapon)
            {
                Console.WriteLine("Jack wants a weapon");
                //take the weapon that the hero currently has and place it in the inventory
                if (parent.Player.CurrentWeapon != null)
                {
                    this.inventory.Add(parent.Player.CurrentWeapon);
                }

                parent.Player.CurrentWeapon = (Weapon)item;
                inventory.Remove(item);

                Console.WriteLine("Inventory now-------");
                foreach (var it in inventory) Console.WriteLine("{0} {1}", it.IdItem, it.Name);
            }
            else if (item is Shield)
            {
                Console.WriteLine("Jack wants a shield");
                //take the shield that the hero currently has and place it in the inventory
                if (parent.Player.CurrentShield != null)
                {
                    this.inventory.Add(parent.Player.CurrentShield);
                }

                parent.Player.CurrentShield = (Shield)item;
                this.inventory.Remove(item);

                Console.WriteLine("Inventory now-------");
                foreach (var it in inventory) Console.WriteLine("{0} {1}", it.IdItem, it.Name);
            }
            else if (item is Skill)
    {
                Console.WriteLine("jack wants a skill");

                //TODO: here get the correct slot!!!
                int slot = 0;

                if (parent.Player.CurrentSkills[slot] != null)
        {
                    this.skills.Add(parent.Player.CurrentSkills[slot]);
                }
                parent.Player.CurrentSkills[slot] = (Skill)item;
                this.skills.Remove((Skill)item);
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
                this.inventory.Add(item);
            }
            else if (item is Skill)
            {
                this.skills.Add((Skill)item);
            }

            parent.Player.GoldAmount -= (int)item.Price;
            this.shop.Remove(item);
        }
    }

}
