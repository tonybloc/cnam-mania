using cnam_mania.Game;
using cnam_mania.View;
using cnam_mania.VisualNovelGame.Manager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace cnam_mania
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initialize first window
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Launch Visual novel game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVisualNovel_Click(object sender, RoutedEventArgs e)
        {
            MiniGamesFactory.createGamesManager("VisualNovel");
            MainContent.Content = new PlayerChoiceInterface();
            MenuContent.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Launch Rebus game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRebus_Click(object sender, RoutedEventArgs e)
        {
            MiniGamesFactory.createGamesManager("Rebus");
        }

        /// <summary>
        /// Launch Riddle game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRiddle_Click(object sender, RoutedEventArgs e)
        {
            MiniGamesFactory.createGamesManager("Riddle");

        }
    }
}
