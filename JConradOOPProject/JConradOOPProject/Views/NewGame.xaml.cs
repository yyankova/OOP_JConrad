using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Text.RegularExpressions;
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
    /// Interaction logic for NewGame.xaml
    /// </summary>
    public partial class NewGame : UserControl
    {
        const string DEFAULT_TXTFIELD_TEXT = "Enter your name";
        private string playerName;

        /// <summary>
        /// playerName property
        /// </summary>
        public string PlayerName
        {
            get { return this.playerName; }
            private set
            {
                Regex alphanumeric = new Regex("^[a-zA-Z0-9]*$");

                if (value != DEFAULT_TXTFIELD_TEXT && value != String.Empty && alphanumeric.IsMatch(value) && value.Length >= 3 && value.Length <= 25)
                {
                    this.playerName = value;
                }
                else
                {
                    MessageBox.Show("Please enter a valid name. It can consists\nonly the following symbols: a-z, A-Z, 0-9\n(Length: 3-25)", "Oops!");
                }
            }
        }

        public NewGame()
        {
            InitializeComponent();

            this.NewGameName.Text = DEFAULT_TXTFIELD_TEXT;
            this.playerName = String.Empty;
        }

        /// <summary>
        /// Button BACK
        /// Returns the player back to the main menu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            MainMenu.SwitchWindowContent(new StartMenu());
        }

        /// <summary>
        /// Button START
        /// Sets new player name and proceeds with introducing the player to the game.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            this.PlayerName = this.NewGameName.Text;

            // Test value
            MessageBox.Show(this.PlayerName, "Printing NewGame.PlayerName");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxNewGameName_Focus(object sender, RoutedEventArgs e)
        {
            TextBox current = (TextBox)sender;
            current.Clear();
        }
    }
}
