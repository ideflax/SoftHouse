using System.Xml.Serialization;

namespace Assignment
{
    [XmlRoot(ElementName = "phone")]
    public class Phone
    {

        [XmlElement(ElementName = "mobile")]
        public string Mobile { get; set; }
        public string LandLine { get; set; }
    }
}