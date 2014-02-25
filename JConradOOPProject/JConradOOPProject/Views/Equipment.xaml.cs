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

namespace JConradOOPProject.Views
{
    using GameObjects.Tools;
    using GameObjects.Tools.Skills;
    using GameObjects.Tools.Weapons;
    using GameObjects.Tools.Shields;

    /// <summary>
    /// Interaction logic for Equipment.xaml
    /// </summary>
    public partial class Equipment : UserControl
    {
        private GameEngine parent;
        private List<Item> inventory;
        private List<Skill> skills;
        private List<Item> shop;

        public Equipment(GameEngine parent)
        {
            InitializeComponent();
            this.parent = parent;
            byte id = 0;

            List<Item> inventory = new List<Item>();
            inventory.Add(new Axe(id++, "Axe", inputPrice: 65, imageSource: "item"));
            inventory.Last().Description = "TODO: add some description of Axe. to change image";

            inventory.Add(new Chopper(id++, "Chopper", inputPrice: 100, imageSource: "item"));
            inventory.Last().Description = "TODO: add description of Chopper, to change image";

            inventory.Add(new Cutter(id++, "Cutter", inputPrice: 200, imageSource: "item"));
            inventory.Last().Description = "TODO: add description of Cutter, to change image";

            Inventory.ItemsSource = inventory;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonUse_Click(object sender, RoutedEventArgs e)
        {
            if (this.Inventory.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an item.", "Select An Item");
                return;
            }

            byte selected = ((Item) this.Inventory.SelectedItem).IdItem;

            MessageBox.Show(selected.ToString());
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
        /// 
        /// </summary>
        /// <param name="items"></param>
        //private void FillInventoryTab(List<InventoryItem> items, Dictionary<string, int> equippedItems) // Change type afterwards.
        //{
        //    foreach (var item in items)
        //    {
        //        string specialValue = String.Empty;

        //        if (item is Weapon)
        //        {
        //            specialValue = String.Concat(((Weapon)item.HitPoints), " Attack");
        //        }
        //        else if (item is Shield)
        //        {
        //            specialValue = String.Concat(((Shield) item).DefPoints, " Defence");
        //        }
                
        //        //this.Inventory
        //    }
        //}

        //private void FillSkillsTab(List<Skill> skills, Dictionary<string, int> usedSkills)
        //{
        //    foreach (Skill skill in skills)
        //    {
        //        string specialValue = String.Concat("Damage Coef: ", skill.DamageCoeff, skill.DefenceCoeff, " Defence Coef; ");
        //    }
        //}
    }

    // To be deleted
    public class InventoryItem
    {
        public byte ItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SpecialValue { get; set; }
        public string ImageSource { get; set; }

        public InventoryItem(byte id, string name, string description, int specialValue, string image)
        {
            this.ItemId = id;
            this.Name = name;
            this.Description = description;
            this.SpecialValue = specialValue;
            this.ImageSource = "../Images/Items/" + image + ".png";
        }
    }
}
