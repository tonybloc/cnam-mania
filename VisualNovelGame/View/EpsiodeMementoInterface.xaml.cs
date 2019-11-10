using cnam_mania.VisualNovelGame.Manager;
using cnam_mania.VisualNovelGame.Model.Memento;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Logique d'interaction pour Memento.xaml
    /// </summary>
    public partial class EpisodeMementoInterface : Page, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        public VisualNovelManager _manager;

        public ObservableCollection<SavingPointMemento> Saves { get; set; }

        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set
            {
                if (_selectedIndex != value)
                {
                    _selectedIndex = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _selectedIndex;

        public EpisodeMementoInterface()
        {
            InitializeComponent();
            this.DataContext = this;
            _manager = VisualNovelManager.Instance;
            Saves = new ObservableCollection<SavingPointMemento>(_manager.history);
            SelectedIndex = 0;
        }

        private void OnClickRestor(object sender, RoutedEventArgs e)
        {
            if (SelectedIndex != 0)
            {
                this._manager.RestorSavingPoint(SelectedIndex);
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
            else
            {
                try
                {
                    ((MainWindow)Window.GetWindow(this)).MainContent.Content = null;
                    ((MainWindow)Window.GetWindow(this)).MenuContent.Visibility = Visibility.Visible;
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
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
