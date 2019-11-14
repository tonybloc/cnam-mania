using cnam_mania.RiddleGame;
using cnam_mania.RiddleGame.Model;
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
    /// Logique d'interaction pour StereotypesInterface.xaml
    /// </summary>
    public partial class StereotypesInterface : Page, INotifyPropertyChanged
    {

        /// <summary>
        /// current story
        /// </summary>
        private Fact _fact;

        private int currentIndex = 0; 

        /// <summary>
        /// Facts manager
        /// </summary>
        private FactManager _factManager; 

        // Property change attribute
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// current fact
        /// </summary>
        public Fact Fact
        {
            get { return _fact; }
            set
            {
                if (_fact != value)
                {
                    _fact = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Class constructor
        /// </summary>
        public StereotypesInterface()
        {
            InitializeComponent();
            DataContext = this;
            
            _factManager = FactManager.Instance;
            Shuffle(this._factManager.Facts.Stereotypes);
            SetCurrentFact(this._factManager);
            
        }

        /// <summary>
        /// Initialize current fact
        /// </summary>
        /// <param name="manager"></param>
        public void SetCurrentFact(FactManager manager)
        {
            this._fact = manager.Facts.Stereotypes.ElementAt(0);
        }


        /// <summary>
        /// Shuffle method
        /// </summary>
        public static void Shuffle<T>(List<T> list)
        {
            Random rand = new Random();
            int nbMotion = list.Count;
            while (nbMotion > 1)
            {
                nbMotion--;
                int randomIndex = rand.Next(nbMotion + 1);
                T obj = list[randomIndex];
                list[randomIndex] = list[nbMotion];
                list[nbMotion] = obj;
            }

        }

        /// <summary>
        /// Generate random facts 
        /// </summary>
        public void GenerateRandomFact(object sender, RoutedEventArgs e)
        {
            if (this.currentIndex == this._factManager.Facts.Stereotypes.Count-1)
                this.currentIndex = 0;
            else
                this.currentIndex++;
            this.Fact = this._factManager.Facts.Stereotypes.ElementAt(this.currentIndex); 
        }

        /// <summary>
        /// Return to menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReturnToMenu(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Window.GetWindow(this)).MainContent.Content = null;
            ((MainWindow)Window.GetWindow(this)).MenuContent.Visibility = Visibility.Visible;
            this.Content = null;
        }


        #region Notify Bindable attribute
        /// <summary>
        /// Notify property changed
        /// </summary>
        /// <param name="propertyName">Property name</param>
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
