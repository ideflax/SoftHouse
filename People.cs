using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Assignment
{
    [XmlRoot(ElementName = "people")]
    public class People
    {

        [XmlElement(ElementName = "person")]
        public List<Person> Person { get; set; }
    }
}
