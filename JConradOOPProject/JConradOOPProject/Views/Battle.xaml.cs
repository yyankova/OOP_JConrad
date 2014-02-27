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
    /// Interaction logic for Battle.xaml
    /// </summary>
    public partial class Battle : UserControl
    {
        private string location; // The field is not accessed directly nor can be modified by the user

        public Battle(string inputLocation)
        {
            InitializeComponent();

            this.location = inputLocation;
            this.SetLocation();

            // Test purposes
            this.SetHealthBarPts(this.PlayerHealthBar, 45);
            this.SetHealthBarPts(this.EnemyHealthBar, 82);
        }

        /// <summary>
        /// Sets the background to the location accordingly
        /// </summary>
        private void SetLocation()
        {
            string path = String.Concat("../Images/BattleGrounds/", this.location.ToLower(), ".jpg");
            this.BattleBackground.Source = new BitmapImage(new Uri(path, UriKind.Relative));
        }

        /// <summary>
        /// Updates the specified health bar by a given value (health points)
        /// </summary>
        /// <param name="target"></param>
        /// <param name="points"></param>
        private void SetHealthBarPts(object target, byte points)
        {
            Border bar = (Border)target;
            int barWidth = 264 * points / 100; // 264 - Bar Max Width

            bar.DataContext = new { Health = points, HealthPerc = barWidth };
        }

        /// <summary>
        /// Provides a smooth animation of health decreasing
        /// </summary>
        /// <param name="target"></param>
        /// <param name="decreaseWith"></param>
        private void DecreaseHealth(object target, byte decreaseWith)
        {
            byte currentHealth = 45; // HARDCODED - TO BE CHANGED

            if (decreaseWith > currentHealth)
            {
                throw new ArgumentOutOfRangeException("The decreasing value must not exceed the total health.");
            }

            for (byte health = currentHealth; health >= currentHealth - decreaseWith; health--)
            {
                System.Threading.Thread.Sleep(150);
                this.SetHealthBarPts(target, health);
            }
        }
    }
}
