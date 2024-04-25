using System.Net;
using System.Numerics;
using System.Xml.Serialization;

namespace Assignment
{
    [XmlRoot(ElementName = "person")]
    public class Person
    {

        [XmlElement(ElementName = "firstname")]
        public string Firstname { get; set; }

        [XmlElement(ElementName = "lastname")]
        public string Lastname { get; set; }

        [XmlElement(ElementName = "address")]
        public Address Address { get; set; }

        [XmlElement(ElementName = "phone")]
        public Phone Phone { get; set; }

        [XmlElement(ElementName = "family")]
        public List<Family> Family { get; set; }
    }
}