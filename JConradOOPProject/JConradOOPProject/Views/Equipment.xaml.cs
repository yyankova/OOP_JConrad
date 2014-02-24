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
                new InventoryItem(2, "Qnko", 12, "item"),
                new InventoryItem(3, "Pesho", 50, "item"),
                new InventoryItem(4, "Dinko", 90, "item"),
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
            InventoryItem selected = (InventoryItem) this.Inventory.SelectedItem;

            MessageBox.Show(selected.Uid.ToString());
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
        public ushort Uid { get; set; }
        public string Title { get; set; }
        public int Completion { get; set; }
        public string Image { get; set; }

        public InventoryItem(ushort uid, string title, int completion, string image)
        {
            this.Uid = uid;
            this.Title = title;
            this.Completion = completion;
            this.Image = "../Images/Items/" + image + ".png";
        }
    }
}
