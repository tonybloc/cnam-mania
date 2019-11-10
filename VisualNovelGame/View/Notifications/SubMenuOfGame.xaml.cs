using cnam_mania.VisualNovelGame.Manager;
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

namespace cnam_mania.VisualNovelGame.View.Notifications
{
    /// <summary>
    /// Logique d'interaction pour SubMenuOfGame.xaml
    /// </summary>
    public partial class SubMenuOfGame : UserControl
    {
        public SubMenuOfGame()
        {
            InitializeComponent();
        }

        private void onClick_btnQuit(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Window.GetWindow(this)).Close();
        }

        private void onClick_btnHome(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Window.GetWindow(this)).MainContent.Content = null;
            ((MainWindow)Window.GetWindow(this)).MenuContent.Visibility = Visibility.Visible;
            ((MainWindow)Window.GetWindow(this)).MainContent.DataContext = null;
            VisualNovelManager.Reset();
            this.Content = null;
        }

        private void onClick_btnResume(object sender, RoutedEventArgs e)
        {
            this.Content = null;
        }
    }
}
