using System;
using System.Collections.Generic;
using System.Text;

namespace CloudFlareDDNS_WPF.Config
{
    public class UserConfiguration
    {
        public static String xauth_email = "";
        public static String xauth_key = "";
        public static String zone_id = "";
        public static String record_name = "";
        public static int record_ttl = 1;
        public static bool record_proxied = false;
        public static bool auto_start = false;
        public static bool auto_activate = false;

        public static UserConfigurationData GetUserConfigurationData()
        {
            return new UserConfigurationData
            {
                xauth_email = xauth_email,
                xauth_key = xauth_key,
                zone_id = zone_id,
                record_name = record_name,
                auto_start = auto_start,
                auto_activate = auto_activate
            };
        }
    }

    public class UserConfigurationData
    {
        public String xauth_email = "";
        public String xauth_key = "";
        public String zone_id = "";
        public String record_name = "";
        public int record_ttl = 1;
        public bool record_proxied = false;
        public bool auto_start = false;
        public bool auto_activate = false;

        public void save()
        {
            UserConfiguration.xauth_email = this.xauth_email;
            UserConfiguration.xauth_key = this.xauth_key;
            UserConfiguration.zone_id = this.zone_id;
            UserConfiguration.record_name = this.record_name;
            UserConfiguration.auto_start = this.auto_start;
            UserConfiguration.auto_activate = this.auto_activate;
        }
    }
}
