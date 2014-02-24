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
    /// Interaction logic for LoadGame.xaml
    /// </summary>
    public partial class LoadGame : UserControl
    {
        private int playerUniqID;

        public LoadGame()
        {
            InitializeComponent();

            // Testing purposes. Remove Later

            List<Player> players = new List<Player>
            {
                new Player(0, "Pesho", 12),
                new Player(1, "Dinko", 21),
                new Player(2, "Zafir", 25)
            };

            this.SavedGamesList.ItemsSource = players;
        }

        public int PlayerUniqID
        {
            get { return this.playerUniqID; }
            
            // Does NOT need setter. The user cannot access/modify the variable.
        }

        /// <summary>
        /// Button PLAY
        /// Starts the game of the selected player from the list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonPlay_Click(object sender, RoutedEventArgs e)
        {
            if (this.SavedGamesList.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a player to play with first.", "Select A Player");
                return;
            }

            byte uID = ((Player)this.SavedGamesList.SelectedItem).Id;

            // Assigns the ID
            this.playerUniqID = uID;

            // Test purposes
            MessageBox.Show(this.playerUniqID.ToString(), "Prints player ID");
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
    }

    // To be deleted
    public class Player
    {
        public byte Id { get; set; }
        public string Name { get; set; }
        public byte Level { get; set; }

        public Player(byte playerId, string playerName, byte playerLvl)
        {
            this.Id = playerId;
            this.Name = playerName;
            this.Level = playerLvl;
        }
    }
}