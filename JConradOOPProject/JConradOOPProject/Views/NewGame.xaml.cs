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

                if (value == DEFAULT_TXTFIELD_TEXT || value == String.Empty)
                {
                    throw new ArgumentException("Please enter a name!");
                }
                else if (!alphanumeric.IsMatch(value))
                {
                    throw new ArgumentException("The name can contain only the following symbols: a-z, A-Z, 0-9");
                }
                else if (!(value.Length >= 3 && value.Length <= 25))
                {
                    throw new ArgumentException("The lengths of the name must be between 3 and 25 symbols.");
                }

                this.playerName = value;
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
            try
            {
                this.PlayerName = this.NewGameName.Text;

                // New Game intro >>

                PushIntroAction continueAction = delegate()
                {
                    MainMenu.SwitchWindowContent(new GameMap(), true);
                };

                MainMenu.SwitchWindowContent(new Intro("newgame_intro.jpg", "Somekind of description", continueAction), true);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Invalid name");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fatal error");
            }
        }

        /// <summary>
        /// Clears the default content of the textbox on focus.
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
