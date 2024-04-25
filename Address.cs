using System.Xml.Serialization;

namespace Assignment
{
    [XmlRoot(ElementName = "address")]
    public class Address
    {

        [XmlElement(ElementName = "street")]
        public string Street { get; set; }
        [XmlElement(ElementName = "city")]
        public string City { get; set; }
        [XmlElement(ElementName = "zipcode")]
        public string ZipCode { get; set; }
    }
}