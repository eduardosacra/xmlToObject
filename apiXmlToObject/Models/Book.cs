using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace apiXmlToObject.Models
{
    [XmlType("Book")]
    public class Book
    {
        //xml.Replace("xmlns: i =\"http://www.w3.org/2001/XMLSchema-instance\" xmlns=\"http://schemas.datacontract.org/2004/07/FakeRestAPI.Web.Models\", '');               
        [XmlAttribute("xmlnst")]
        public string Xmlnst { get; set; }

        [XmlAttribute("xmlns")]
        public string Xmlns { get; set; }


        [XmlElement("ID")]
        public int Id { get; set; }

        [XmlElement("Title")]
        public string Title { get; set; }

        [XmlElement("Description")]
        public string Description { get; set; }

        [XmlElement("PageCount")]
        public int PageCount { get; set; }

        [XmlElement("Excerpt")]
        public string Excerpt { get; set; }

        [XmlElement("PublishDate")]
        public string PublishDate { get; set; }

        public override string ToString()
        {
            return "ID:" + Id + " Title:" + Title;
        }
    }
}