using System;
using System.Collections.Generic;
using System.Text;

namespace CloudFlareDDNS_WPF.Lib
{
    class XMLWriter<T>
    {
        public static void write(T data, String filePath, String fileName)
        {
            System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(T));
            System.IO.FileStream file = System.IO.File.Create(filePath + fileName);
            writer.Serialize(file, data);
            file.Close();
        }
    }
}
