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

            AddSavedGameToList("Pesho", 25, 0xA);
            AddSavedGameToList("Dinko", 10, 0xF);
            AddSavedGameToList("Smesko", 15, 0x0);

            // Setting style of ListBoxItems
            //Style tableLayout = this.FindResource("tableLayoutStatic") as Style;
            //tableLayout.TargetType = typeof(ListBoxItem);
            //this.SavedGamesList.Resources.Add(typeof(ListBoxItem), tableLayout);
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

            string uIDText = ((StackPanel)this.SavedGamesList.SelectedItem).Name;
            int uID = Int32.Parse(uIDText.Split('_')[1]);

            // Assigns the ID
            this.playerUniqID = uID;

            // Test purposes
            MessageBox.Show(this.playerUniqID.ToString());
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
        /// Adds visual information about an existing player to the list in 'Load Game' from the saved files.
        /// </summary>
        /// <param name="playerName">Player name</param>
        /// <param name="playerLevel">Player's current level</param>
        /// <param name="uID">Unique ID used for reference</param>
        private void AddSavedGameToList(string playerName, int playerLevel, int uID)
        {
            TextBlock name = new TextBlock(),
                      level = new TextBlock();

            StackPanel record = new StackPanel();

            record.Name = String.Concat("UID_", uID);

            name.Text = playerName;
            level.Text = String.Concat(playerLevel, " LVL");

            // Adding design
            this.AddListBoxStyle(name, level);

            name.Width = 590;
            level.Width = 100;

            record.Children.Add(name);
            record.Children.Add(level);

            this.SavedGamesList.Items.Add(record);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        private void AddListBoxStyle(params TextBlock[] targets)
        {
            foreach (TextBlock item in targets)
            {
                item.FontSize = 17;
                item.Foreground = new SolidColorBrush(Colors.White);
            }
        }

        private void AddSavedGames()
        {
        }
    }
}