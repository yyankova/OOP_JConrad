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
    /// <summary>
    /// Interaction logic for StartMenu.xaml
    /// </summary>
    public partial class StartMenu : UserControl
    {
        public StartMenu()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Button NEW GAME
        /// Redirects the player to the new game menu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonNewGame_Click(object sender, RoutedEventArgs e)
        {
            MainMenu.SwitchWindowContent(new NewGame());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonLoadGame_Click(object sender, RoutedEventArgs e)
        {
            MainMenu.SwitchWindowContent(new LoadGame());
        }

        /// <summary>
        /// Button QUIT
        /// Shuts down the application.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonQuit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
