using System;
using System.Collections.Generic;
using System.Text;

namespace CloudFlareDDNS_WPF.Lib
{
    class XMLReader<T>
    {
        public static T read(String filePath, String fileName)
        {
            System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(T));
            System.IO.StreamReader file = new System.IO.StreamReader(filePath + fileName);
            return (T)reader.Deserialize(file);
        }
    }
}
