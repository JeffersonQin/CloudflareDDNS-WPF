using System.Net;

namespace CloudFlareDDNS_WPF
{
    class DDNS
    {
        public class UserXAuth
        {
            public string X_Auth_Email { get; set; }
            public string X_Auth_Key { get; set; }
        }

        public class DDNSRequest
        {
            public string name { get; set; }
            public string content { get; set; }
            public int? ttl { get { return ttl; } set { ttl = (value ?? 120) <1 ? 1 : (value ?? 120); } }
            public bool proxied { get; set; }
        }

        public DDNS() { }

        public string Report(string zone_id, UserXAuth xauth, DDNSRequest ddnsrequest)
        {
            HttpClient client = new HttpClient();
            WebHeaderCollection headers = new WebHeaderCollection();

            string url = "https://api.cloudflare.com/client/v4/zones/"+ zone_id + "/dns_records";

            headers.Add("X-Auth-Email", xauth.X_Auth_Email);
            headers.Add("X-Auth-Key", xauth.X_Auth_Key);
            headers.Add("Content-Type", "application/json");

            string data = 
                @"{""type"":""A"        +
                @""",""name"":"""       + ddnsrequest.name      + 
                @""",""content"":"""    + ddnsrequest.content   + 
                @""",""ttl"":"          + ddnsrequest.ttl       + 
                @",""proxied"":"        + ddnsrequest.proxied   + 
                "}";

            string retdata = client.Put(url, headers, data);

            return retdata;
        }
    }
}
