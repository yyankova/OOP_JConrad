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
    /// Button CONTINUE action delegate
    /// </summary>
    public delegate void PushIntroAction();

    /// <summary>
    /// Interaction logic for Intro.xaml
    /// </summary>
    public partial class Intro : UserControl
    {
        private PushIntroAction action;

        public Intro(string background, string description, PushIntroAction currentAction)
        {
            InitializeComponent();

            this.SetBackground(background);
            this.SetDescription(description);

            this.action = currentAction;
        }

        /// <summary>
        /// Sets background description.
        /// </summary>
        /// <param name="background"></param>
        private void SetBackground(string background)
        {
            this.IntroBackground.Source = new BitmapImage(new Uri(@"/JConradOOPProject;Component/Images/" + background, UriKind.Relative));
        }

        /// <summary>
        /// Sets intro description.
        /// </summary>
        /// <param name="description"></param>
        private void SetDescription(string description)
        {
            this.IntroDescription.Text = description;
        }

        /// <summary>
        /// Button CONTINUE
        /// Works by a given action delegate.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonContinue_Click(object sender, RoutedEventArgs e)
        {
            this.action();
        }
    }
}
