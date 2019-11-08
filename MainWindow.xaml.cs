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
        public MainWindow()
        {
            InitializeComponent();
            _VisualNovelManager = VisualNovelManager.Instance;
        }

        private void btnVisualNovel_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new PlayerChoiceInterface();
            MenuContent.Visibility = Visibility.Hidden;
        }

        private void btnRebus_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRiddle_Click(object sender, RoutedEventArgs e)
        {


        }
    }
}
