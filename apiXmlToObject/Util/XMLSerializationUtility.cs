using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace apiXmlToObject.Util
{
    public class XMLSerializationUtility
    {
        public static T Deserialize<T>(Encoding encoding, string xml, Type tipo)
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(tipo);
                var valor_serealizado = new StringReader(xml);
                var result = (T)xmlSerializer.Deserialize(valor_serealizado);
                return result;
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }
    }
}