using cnam_mania.Game;
using cnam_mania.VisualNovelGame.Manager;
using cnam_mania.VisualNovelGame.Model.Episodes;
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
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        // Property change attribute
        public event PropertyChangedEventHandler PropertyChanged;

        private VisualNovelManager _game;

        private Story _story;
        private Choice _firstChoice;
        private Choice _secondChoice;


        #region Bindable Attributes
        public Story Story
        {
            get { return _story; }
            set
            {
                if (_story != value)
                {
                    _story = value;
                    OnPropertyChanged();
                }
            }
        }
        public Choice FirstChoice
        {
            get { return _firstChoice; }
            set
            {
                if (_firstChoice != value)
                {
                    _firstChoice = value;
                    OnPropertyChanged();
                }
            }
        }
        public Choice SecondChoice
        {
            get { return _secondChoice; }
            set
            {
                if (_secondChoice != value)
                {
                    _secondChoice = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion



        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            _game = VisualNovelManager.Instance;
            EpisodesListView.ItemsSource = _game.episodeManager.Serie.Episodes;

            Story = _game.episodeManager.CurrentStory;
            FirstChoice = Story.Choices[0];
            SecondChoice = Story.Choices[1];
        }


        private void NextStory(Choice c)
        {
            _game.episodeManager.NextStory(c);
            Story = _game.episodeManager.CurrentStory;
            FirstChoice = Story.Choices[0];
            SecondChoice = Story.Choices[1];
        }


        private void onClickFirstChoice(object sender, RoutedEventArgs e)
        {
            NextStory(FirstChoice);
        }

        private void onClickSecondChoice(object sender, RoutedEventArgs e)
        {
            NextStory(SecondChoice);
        }


        #region Notify Bindable attribute
        /// <summary>
        /// Notify propery changed
        /// </summary>
        /// <param name="propertyName">Property name</param>
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
