using cnam_mania.VisualNovelGame.Manager;
using cnam_mania.VisualNovelGame.View;
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

namespace cnam_mania.View
{
    /// <summary>
    /// Logique d'interaction pour PlayerChoiceInterface.xaml
    /// </summary>
    public partial class PlayerChoiceInterface : Page
    {
        public PlayerChoiceInterface()
        {
            InitializeComponent();
        }

        private void onClickValidate(object sender, RoutedEventArgs e)
        {
            try
            {

                ((MainWindow)Window.GetWindow(this)).MainContent.Content = new EpisodeInterface();
                ((MainWindow)Window.GetWindow(this)).MenuContent.Visibility = Visibility.Hidden;
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }
    }
}
