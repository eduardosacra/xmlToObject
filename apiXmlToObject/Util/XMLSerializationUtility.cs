using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace apiXmlToObject.Util
{
    public class XMLSerializationUtility
    {
        public static T DeserializeObject<T>(Encoding encoding, string xml, Type tipo)
        {
            try
            {
                //xml.Replace("xmlns: i =\"http://www.w3.org/2001/XMLSchema-instance\" xmlns=\"http://schemas.datacontract.org/2004/07/FakeRestAPI.Web.Models\", '');               
                xml = xml.Replace("xmlns:i", "xmlnst");
                using (var memoryStream = new MemoryStream(StringToByteArray(encoding, xml)))
                {
                    using (var xmlTextWriter = new XmlTextWriter(memoryStream, encoding))
                    {
                        //var xmlSerializer = new XmlSerializer(typeof(T));
                        //var result= (T)xmlSerializer.Deserialize(memoryStream);
                        //return result;
                    }
                }
            }


                //// Construct an instance of the XmlSerializer with the type
                //// of object that is being deserialized.
                //XmlSerializer mySerializer = new XmlSerializer(typeof(T));
                //// To read the file, create a FileStream.
                //FileStream myFileStream = new FileStream(xml, FileMode.Open);
                //// Call the Deserialize method and cast to the object type.
                //T myObject = (T)mySerializer.Deserialize(myFileStream);
                //return myObject;
        }
            catch (Exception error)
            {
                return default(T);
            }

            //try
            //{
            //    XmlSerializer xml2 = new XmlSerializer(tipo);
            //    var valor_serealizado = new StringReader(xml);
            //    var result = (T)xml2.Deserialize(valor_serealizado);
            //    return result;
            //    //return xml2.Deserialize(valor_serealizado);
            //}
            //catch(Exception error)
            //{
            //    throw;
            //}
        }

        private static Byte[] StringToByteArray(Encoding encoding, string xml)
        {
            return encoding.GetBytes(xml);
        }

        private static string ByteArrayToString(Encoding encoding, byte[] byteArray)
        {
            return encoding.GetString(byteArray);
        }
    }
}