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
        /// <summary>
        /// Options chosen by player
        /// </summary>
        private Options chosenOptions = null;

        /// <summary>
        /// Bind game mode and player type with interface
        /// </summary>
        public PlayerChoiceInterface()
        {
            InitializeComponent();
            this.chosenOptions = new Options();
            this.chosenOptions.gameMode = VisualNovelGame.Enumeration.GameMode.EASY;
            this.chosenOptions.playerType = VisualNovelGame.Enumeration.PlayerType.POPULAR;
            this.DataContext = this.chosenOptions;
        }

        /// <summary>
        /// Set game mode and player type
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onClickValidate(object sender, RoutedEventArgs e)
        {
            try
            {
                //MessageBox.Show(string.Format("Mode :{0}, Joueur{1}", this.chosenOptions.gameMode, this.chosenOptions.playerType));
                VisualNovelManager.Instance.InitGame(this.chosenOptions.playerType, this.chosenOptions.gameMode);
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
