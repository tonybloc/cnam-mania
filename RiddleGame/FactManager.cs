using cnam_mania.Game;
using cnam_mania.RiddleGame.Model;
using cnam_mania.Settings;
using cnam_mania.VisualNovelGame.Service.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cnam_mania.RiddleGame
{
    public class FactManager : AbsGameManager
    {
        // Unique instance of manager
        private static FactManager _instance;


        #region Variables

        #region Bindable Attributes
        public Facts Facts
        {
            get { return _facts; }
            set
            {
                if (_facts != value)
                {
                    _facts = value;
                }
            }
        }
        public Fact CurrentFact
        {
            get { return _fact; }
            set
            {
                if (_fact != value)
                {
                    _fact = value;
                }
            }
        }
        #endregion 


        #region Variable (private)
        private Facts _facts { get; set; }
        private Fact _fact { get; set; }
        #endregion
        #endregion


        #region Constructor / Instance

        /// <summary>
        /// Create new instance of EpisodeManager
        /// </summary>
        private FactManager()
        {
            try
            {
                this.Facts = XmlDataAccess.XMLDeserializeObject<Facts>(Config.filePath_XmlFacts);
                this.CurrentFact = this.Facts.Stereotypes[0];
            }
            catch (Exception exp)
            {
                Console.WriteLine(string.Format("Une erreur est survenu lors de la déserialisation ! {0}", exp.Message));
                this.CurrentFact = null;
            }

        }

        /// <summary>
        /// Get unique instance of manager
        /// </summary>
        public static FactManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FactManager();
                }
                return _instance;
            }
        }

        #endregion
        public override void Play()
        {

        }
        
    }
}
