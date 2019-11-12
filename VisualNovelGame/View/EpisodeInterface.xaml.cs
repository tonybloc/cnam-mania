using cnam_mania.VisualNovelGame.Manager;
using cnam_mania.VisualNovelGame.Model.Characters;
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
    /// Logique d'interaction pour EpisodeInterface.xaml
    /// </summary>
    public partial class EpisodeInterface : Page, INotifyPropertyChanged
    {

        // Property change attribute
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Game manager
        /// </summary>
        private VisualNovelManager _game;

        
        #region Private Bindable Attributes

        /// <summary>
        /// Current epsiode
        /// </summary>
        private Episode _episode;

        /// <summary>
        /// current story
        /// </summary>
        private Story _story;

        /// <summary>
        /// current story, first choice related
        /// </summary>
        private Choice _firstChoice;

        /// <summary>
        /// current story, second choice related
        /// </summary>
        private Choice _secondChoice;

        /// <summary>
        /// Define if the story is the lastest
        /// </summary>
        private bool _finalStory;

        /// <summary>
        /// Define visibilty of choice buttons
        /// </summary>
        private bool _choiceVisibility;

        /// <summary>
        /// Character stats 
        /// </summary>
        private Character _character; 

        #endregion

        #region Bindable Attributes
        /// <summary>
        /// current story
        /// </summary>
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
                
        /// <summary>
        /// current story, first choice related
        /// </summary>
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

        /// <summary>
        /// current story, second choice related
        /// </summary>
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

        /// <summary>
        /// current character
        /// </summary>
        public Character Character
        {
            get { return _character; }
            set
            {
                if (_character != value)
                {
                    _character = value; 
                    OnPropertyChanged();
                }
            }
        }
        /// <summary>
        /// Define if the story is the lastest
        /// </summary>
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
        /// <summary>
        /// Define visibilty of choice buttons
        /// </summary>
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

        /// <summary>
        /// Current epsiode
        /// </summary>
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
        #endregion

        /// <summary>
        /// Create new instance of demoepsiode
        /// </summary>
        public EpisodeInterface()
        {
            InitializeComponent();
            DataContext = this;

            _game = VisualNovelManager.Instance;
            LoadEpsiodeManagerAttributes(_game.EpisodeManager);
            _character = _game.CharacterManager.CharacterBuilder.GetCharacter();

            ShowStoryBackground();
        }

        private void ShowStoryBackground()
        {
            ImageBrush brush = new ImageBrush();
            Image image = new Image();
            //image.Source = new BitmapImage(new Uri("Resources/../../../VisualNovelGame/Resources/Pictures/reignCnamania_"+ Story.Id.ToString()+".png", UriKind.Relative));
            image.Source = new BitmapImage(new Uri("VisualNovelGame/Resources/Pictures/"+ Episode.EpisodeId.ToString() + "-"+ Story.Id.ToString()+".png", UriKind.Relative));

            brush.ImageSource = image.Source;

            StoryGrid.Background = brush;
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
            if (_game.SwitchStory(c))
            {
                LoadEpsiodeManagerAttributes(_game.EpisodeManager);
            }
            else
            {
                FinalStory = true;
                ChoiceVisibility = false;
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
            ShowStoryBackground();
        }

        /// <summary>
        /// Click on seconde choice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClickSecondChoice(object sender, RoutedEventArgs e)
        {
            NextStory(SecondChoice);
            ShowStoryBackground();
        }


        private void OnClickContinue(object sender, RoutedEventArgs e)
        {
            try
            {
                ((MainWindow)Window.GetWindow(this)).MainContent.Content = new EpisodeMementoInterface();
                ((MainWindow)Window.GetWindow(this)).MenuContent.Visibility = Visibility.Hidden;
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
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
