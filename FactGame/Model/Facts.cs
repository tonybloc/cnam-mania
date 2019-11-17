using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace cnam_mania.FactGame.Model
{
    [Serializable]
    [XmlRoot("Facts")]
    public class Facts
    {
        #region Variables
        /// <summary>
        /// Instance of Facts
        /// </summary>
        [XmlIgnore]
        private static Facts _instance = null;

        /// <summary>
        /// List of available facts. 
        /// </summary>
        [XmlElement("Fact")]
        public List<Fact> Stereotypes { get; set; }
        #endregion

        #region Constructeur
        /// <summary>
        /// Creation of the Facts
        /// </summary>
        public Facts()
        {
            Stereotypes = new List<Fact>();
        }

        /// <summary>
        /// Return the unique instance of the class
        /// </summary>        
        public static Facts Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Facts();
                }
                return _instance;
            }
        }
        #endregion

       
    }
}
