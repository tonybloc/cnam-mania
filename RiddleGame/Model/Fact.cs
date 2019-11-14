using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace cnam_mania.RiddleGame.Model
{
    [Serializable]
    [XmlRoot("Fact")]
    public class Fact
    {
        [XmlElement("Id")]
        public int FactId { get; set; }


        [XmlElement("Description")]
        public String Description { get; set; }
    }
}
