using CloudFlareDDNS_WPF.Config;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace CloudFlareDDNS_WPF.Lib
{
    class Helper
    {
        public static void OpenWebsite(String url)
        {
            var psi = new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            };
            Process.Start(psi);
        }

        public static void ResetAPIConfiguration()
        {
            FileStream fs = new FileStream(CfDdnsProperty.CONFIG_FILE_PATH + CfDdnsProperty.CONFIG_API_FILE_NAME, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(
                "<?xml version=\"1.0\"?>\n" +
                "\n" +
                "<config>\n" +
                "    <ipapis>\n" +
                "        <api>http://ipinfo.io/ip</api>\n" +
                "        <api>http://ip.42.pl/raw</api>\n" +
                "        <api>https://api.ipify.org</api>\n" +
                "        <api>http://ipv4bot.whatismyipaddress.com/</api>\n" +
                "        <api>http://bot.whatismyipaddress.com/</api>\n" +
                "    </ipapis>\n" +
                "</config>"
            );
            sw.Flush();
            sw.Close();
            fs.Close();
        }
    }
}
