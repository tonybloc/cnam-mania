using cnam_mania.VisualNovelGame.Manager;
using cnam_mania.VisualNovelGame.Model.Characters;
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
    public partial class EpisodeInterface : Page
    {

        // Property change attribute
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Game manager
        /// </summary>
        private VisualNovelManager _game;

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

        public Character Character
        {
            get { return this._game.characterManager.CharacterBuilder.Character; }
            set
            {
                if (this._game.characterManager.CharacterBuilder.Character != value)
                {
                    _game.characterManager.CharacterBuilder.Character.Food = value.Food;
                    _game.characterManager.CharacterBuilder.Character.Money = value.Money;
                    _game.characterManager.CharacterBuilder.Character.Popularity = value.Popularity;
                    _game.characterManager.CharacterBuilder.Character.Intellect = value.Intellect;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        /// <summary>
        /// Episode UI constructor
        /// </summary>
        public EpisodeInterface()
        {
            InitializeComponent();
            DataContext = this;

            _game = VisualNovelManager.Instance;
            //EpisodesListView.ItemsSource = _game.episodeManager.Serie.Episodes;

            Story = _game.episodeManager.CurrentStory;
            if (Story != null && Story.Choices != null && Story.Choices.Count == 2)
            {
                FirstChoice = Story.Choices[0];
                SecondChoice = Story.Choices[1];
            }
            else
            {
                FirstChoice = new Choice { Description = "Aucune idée" };
                SecondChoice = new Choice { Description = "Aucune idée" };
            }
        }

        /// <summary>
        /// Go to next story
        /// </summary>
        /// <param name="c"></param>
        private void NextStory(Choice c)
        {
            _game.episodeManager.NextStory(c);
            Story = _game.episodeManager.CurrentStory;

            OnPropertyChanged();
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


        /// <summary>
        /// Bind first choice to current story
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClickFirstChoice(object sender, EventArgs e)
        {
            NextStory(FirstChoice);
        }

        /// <summary>
        /// Bind second choice to current story
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClickSecondChoice(object sender, EventArgs e)
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
