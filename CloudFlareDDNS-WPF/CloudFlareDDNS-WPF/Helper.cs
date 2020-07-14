using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CloudFlareDDNS_WPF
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
    }
}
