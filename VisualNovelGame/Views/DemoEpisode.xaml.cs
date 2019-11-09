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

namespace cnam_mania.VisualNovelGame.Views
{
    /// <summary>
    /// Logique d'interaction pour DemoEpisode.xaml
    /// </summary>
    public partial class DemoEpisode : Page, INotifyPropertyChanged
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



        public DemoEpisode()
        {
            InitializeComponent();
            DataContext = this;

            _game = VisualNovelManager.Instance;
            EpisodesListView.ItemsSource = _game.episodeManager.Serie.Episodes;

            Story = _game.episodeManager.CurrentStory;
            if (Story != null && Story.Choices != null && Story.Choices.Count == 2)
            {
                FirstChoice = Story.Choices[0];
                SecondChoice = Story.Choices[1];
            }
            else
            {
                FirstChoice = new Choice { Description = "Aucune idéee" };
                SecondChoice = new Choice { Description = "Aucune idéee" };
            }
        }


        private void NextStory(Choice c)
        {
            _game.episodeManager.NextStory(c);
            Story = _game.episodeManager.CurrentStory;
            if (Story != null && Story.Choices != null && Story.Choices.Count == 2)
            {
                FirstChoice = Story.Choices[0];
                SecondChoice = Story.Choices[1];
            }
            else
            {
                FirstChoice = new Choice { Description = "Aucune idéee" };
                SecondChoice = new Choice { Description = "Aucune idéee" };
            }
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
