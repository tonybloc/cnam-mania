using cnam_mania.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cnam_mania.Settings
{
    /// <summary>
    /// Paramètre global
    /// </summary>
    public static class Config
    {
        // XML files path
        public static readonly string filePath_XmlStory = "./VisualNovelGame/Resources/XML/XMLEpisodes.xml";

        // Setting player
        public static int FOOD = 50;
        public static int SMART = 50;
        public static int POPULARITY = 50;
        public static int MONEY = 50;
    }
}
