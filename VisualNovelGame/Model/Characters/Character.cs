using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace cnam_mania.VisualNovelGame.Model.Characters
{
    public class Character : INotifyPropertyChanged
    {
        #region Attributes
        #region Bindable Attributes
        public int Intellect
        {
            get { return _intellect; }
            set
            {
                if( _intellect != value)
                {
                    _intellect = value;
                    OnPropertyChanged();
                }
            }
        }
        public int Food
        {
            get { return _food; }
            set
            {
                if (_food != value)
                {
                    _food = value;
                    OnPropertyChanged();
                }
            }
        }
        public int Popularity
        {
            get { return _popularity; }
            set
            {
                if (_popularity != value)
                {
                    _popularity = value;
                    OnPropertyChanged();
                }
            }
        }
        public int Money
        {
            get { return _money; }
            set
            {
                if (_money != value)
                {
                    _money = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        #region Private bindable attributes
        private int _intellect;
        private int _food;
        private int _popularity;
        private int _money;
        #endregion
        #endregion

        /// <summary>
        /// Create new instance of 'character' class.
        /// </summary>
        public Character() { }

        /// <summary>
        /// Create new instance of 'character' class.
        /// </summary>
        /// <param name="intel">Value of initial intelligence</param>
        /// <param name="food">Value of initial food</param>
        /// <param name="popularity">Value of inital popularity</param>
        /// <param name="money">Value of initial money</param>
        public Character(int intel, int food, int popularity, int money)
        {
            this.Intellect = intel;
            this.Food = food;
            this.Popularity = popularity;
            this.Money = money;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #region Notify Bindable attribute
        /// <summary>
        /// Notify propery changed
        /// </summary>
        /// <param name="propertyName">Property name</param>
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public Character Clone()
        {
            Character c = Activator.CreateInstance<Character>();
            c.Food = this.Food;
            c.Intellect = this.Intellect;
            c.Money = this.Money;
            c.Popularity = this.Popularity;
            return c;
        }
        #endregion
    }
}
