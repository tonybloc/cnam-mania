using cnam_mania.VisualNovelGame.Manager;
using cnam_mania.VisualNovelGame.Manager.Episodes;
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

namespace cnam_mania.VisualNovelGame.View
{
    /// <summary>
    /// Logique d'interaction pour DemoEpisode.xaml
    /// </summary>
    public partial class DemoEpisode : Page, INotifyPropertyChanged
    {
        // Property change attribute
        public event PropertyChangedEventHandler PropertyChanged;

        private VisualNovelManager _game;
        private Episode _episode;
        private Story _story;
        private Choice _firstChoice;
        private Choice _secondChoice;

        private bool _finalStory;
        private bool _choiceVisibility;

        #region Bindable Attributes
        public Episode Episode
        {
            get { return _episode; }
            set
            {
                if (_episode != value)
                {
                    _episode = value;
                    OnPropertyChanged();
                }
            }

        }
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
        public bool FinalStory
        {
            get { return _finalStory; }
            set
            {
                if (_finalStory != value)
                {
                    _finalStory = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool ChoiceVisibility
        {
            get { return _choiceVisibility; }
            set
            {
                if (_choiceVisibility != value)
                {
                    _choiceVisibility = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion


        /// <summary>
        /// Create new instance of demoepsiode
        /// </summary>
        public DemoEpisode()
        {
            InitializeComponent();
            DataContext = this;

            _game = VisualNovelManager.Instance;
            EpisodesListView.ItemsSource = _game.episodeManager.Serie.Episodes;

            LoadEpsiodeManagerAttributes(_game.episodeManager);
        }

        /// <summary>
        /// Retreive attribute from epsiode manager.
        /// </summary>
        /// <param name="manager">Manager of epsiode</param>
        private void LoadEpsiodeManagerAttributes(EpisodeManager manager)
        {
            // Update story attribute
            Story = manager.CurrentStory;

            // Update epsiode attribute
            Episode = manager.CurrentEpisode;

            // Update choices attribute
            if (Story != null && Story.Choices != null && Story.Choices.Count == 2)
            {
                FirstChoice = Story.Choices[0];
                SecondChoice = Story.Choices[1];
                FinalStory = false;
                ChoiceVisibility = true;
            }
            else
            {
                FinalStory = true;
                ChoiceVisibility = false;
            }
        }

        /// <summary>
        /// Get next story according choice
        /// </summary>
        /// <param name="c">Selected choice</param>
        private void NextStory(Choice c)
        {
            if (_game.episodeManager.NextStory(c))
            {
                LoadEpsiodeManagerAttributes(_game.episodeManager);
            }
            else
            {
                btnFirstChoice.Visibility = Visibility.Hidden;
                btnSecondChoice.Visibility = Visibility.Hidden;
            }
        }

        /// <summary>
        /// Click on first choice
        /// </summary>
        /// <param name="sender">Targeted object</param>
        /// <param name="e">Event source</param>
        private void OnClickFirstChoice(object sender, RoutedEventArgs e)
        {
            NextStory(FirstChoice);
        }

        /// <summary>
        /// Click on seconde choice
        /// </summary>
        /// <param name="sender">Targeted object</param>
        /// <param name="e">Event source</param>
        private void OnClickSecondChoice(object sender, RoutedEventArgs e)
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
