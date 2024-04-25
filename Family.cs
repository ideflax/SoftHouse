using System.Xml.Serialization;

namespace Assignment
{
    [XmlRoot(ElementName = "family")]
    public class Family
    {

        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "born")]
        public string Born { get; set; }

        [XmlElement(ElementName = "address")]
        public Address Address { get; set; }
        [XmlElement(ElementName = "phone")]
        public Phone Phone { get; set; }
    }
}