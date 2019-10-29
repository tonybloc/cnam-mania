using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Settings
{
    /// <summary>
    /// Paramètre global
    /// </summary>
    public static class Config
    {
        // XML files path
        public static readonly string filePath_XmlStory = "../../Resources/XML/XMLBoardCell.xml";
        public static readonly string filePath_XmlBank = "../../Resources/XML/XMLBank.xml";
        public static readonly string filePath_XmlCommunityCard = "../../Resources/XML/XMLCommunityCard.xml";
        public static readonly string filePath_XmlChanceCard = "../../Resources/XML/XMLChanceCard.xml";

        
        // Setting game
        public static int NUMBER_MAX_OF_HOTEL = 16;
        public static int NUMBER_MAX_OF_HOUSE = 32;
        public static int INITIAL_BANCK_BALANCE = 1500;
    }

    /// <summary>
    /// Paramètre de couleurs
    /// </summary>
    public static class SettingColor
    {
        
        public static readonly List<string> PawnColors = new List<string>(){
            "#F44336",
            "#E91E63",
            "#9C27B0",
            "#673AB7",
            "#3F51B5",
            "#2196F3",
            "#0319F4",
            "#00BCD4",
            "#009688",
            "#4CAF50",
            "#8BC34A",
            "#CDDC39",
            "#FFEB3B",
            "#FFC107",
            "#FF9800",
        };

        public static readonly int RED = 0;
        public static readonly int PINK = 1;
        public static readonly int PURPLE = 2;
        public static readonly int DEEP_PURPLE = 3;
        public static readonly int INDIGO = 4;
        public static readonly int LIGHT_BLUE = 5;
        public static readonly int CYAN = 6;
        public static readonly int TEAL = 7;
        public static readonly int GREEN = 8;
        public static readonly int LIGHT_GREEN = 9;
        public static readonly int LIME = 10;
        public static readonly int YELLOW = 11;
        public static readonly int AMBER = 12;
        public static readonly int ORANGE = 13;
                               

        public static void ChangeResourceTheme()
        {
            /*
            ResourceDictionary rdMaterialDesignDefault = new ResourceDictionary();
            ResourceDictionary rdMaterialDesignLight = new ResourceDictionary();
            ResourceDictionary rdMaterialDesignPrimartColor = new ResourceDictionary();
            ResourceDictionary rdMaterialDesignAccentColor = new ResourceDictionary();

            rdMaterialDesignLight.Source = new Uri("pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Light.xaml", UriKind.RelativeOrAbsolute);
            rdMaterialDesignDefault.Source = new Uri("pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Defaults.xaml", UriKind.RelativeOrAbsolute);
            rdMaterialDesignAccentColor.Source = new Uri("pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Accent/MaterialDesignColor.Lime.xaml", UriKind.RelativeOrAbsolute);
            rdMaterialDesignPrimartColor.Source = new Uri("pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.Orange.xaml", UriKind.RelativeOrAbsolute);

            Application.Current.Resources.MergedDictionaries.Clear();

            Application.Current.Resources.MergedDictionaries.Add(rdMaterialDesignLight);
            Application.Current.Resources.MergedDictionaries.Add(rdMaterialDesignDefault);
            Application.Current.Resources.MergedDictionaries.Add(rdMaterialDesignAccentColor);
            Application.Current.Resources.MergedDictionaries.Add(rdMaterialDesignPrimartColor);
            */
        }
    }
}
