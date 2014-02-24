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

namespace JConradOOPProject.Views
{
    using GameObjects.Tools;
    using GameObjects.Tools.Skills;

    /// <summary>
    /// Interaction logic for Equipment.xaml
    /// </summary>
    public partial class Equipment : UserControl
    {
        private List<Item> inventory;
        private List<Skill> skills;
        private List<Item> shop;

        public Equipment()
        {
            InitializeComponent();

            List<InventoryItem> items = new List<InventoryItem>
            {
                new InventoryItem(2, "Qnko", "A description a description a description", 12, "item"),
                new InventoryItem(3, "Pesho", "A description a description a description", 50, "item"),
                new InventoryItem(4, "Dinko", "A description a description a description", 90, "item"),
            };

            Inventory.ItemsSource = items;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonUse_Click(object sender, RoutedEventArgs e)
        {
            byte selected = ((InventoryItem) this.Inventory.SelectedItem).ItemId;

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
            MainMenu.SwitchWindowContent(new GameMap(), true);
        }
    }

    // To be deleted
    public class InventoryItem
    {
        public byte ItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SpecialValue { get; set; }
        public string Image { get; set; }

        public InventoryItem(byte id, string name, string completion, int specialValue, string image)
        {
            this.ItemId = id;
            this.Name = name;
            this.Description = completion;
            this.SpecialValue = specialValue;
            this.Image = "../Images/Items/" + image + ".png";
        }
    }
}
