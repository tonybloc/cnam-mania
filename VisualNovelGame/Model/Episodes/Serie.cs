using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace cnam_mania.VisualNovelGame.Model.Episodes
{
    [Serializable]
    [XmlRoot("Serie")]
    public class Serie
    {
        #region Variables
        /// <summary>
        /// Instance of serie
        /// </summary>
        [XmlIgnore]
        private static Serie _instance = null;

        /// <summary>
        /// List of available episodes. 
        /// </summary>
        [XmlElement("Episode")]
        public List<Episode> Episodes { get; set; }
        #endregion

        #region Constructeur
        /// <summary>
        /// Creation of the serie
        /// </summary>
        public Serie()
        {
            Episodes = new List<Episode>();
        }

        /// <summary>
        /// Return the unique instance of the class
        /// </summary>        
        public static Serie Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Serie();
                }
                return _instance;
            }
        }
        #endregion
    }
}
