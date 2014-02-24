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
    /// <summary>
    /// Interaction logic for GameMap.xaml
    /// </summary>
    public partial class GameMap : UserControl
    {
        private GameEngine parent;
        public GameMap(GameEngine parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        /// <summary>
        /// Button EXIT
        /// Closes the current game session, saves the content and returns the user to the main menu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            MainMenu.SwitchWindowContent(new StartMenu());
        }

        /// <summary>
        /// Button EQUIPMENT
        /// Navigates to the equipment menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonEquipment_Click(object sender, RoutedEventArgs e)
        {
            MainMenu.SwitchWindowContent(new Equipment(this.parent), true);
        }
    }
}
