using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

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

        public class DDNSThread
        {
            public Thread thrd;
            private ManualResetEvent m = new ManualResetEvent(false);

            public string zone_id;
            public UserXAuth xauth;
            public DDNSRequest ddnsrequest;
            public int period;                  // unit: minute

            public DDNSThread(string zone_id, UserXAuth xauth, DDNSRequest ddnsrequest, int period)
            {
                this.zone_id = zone_id;
                this.xauth = xauth;
                this.ddnsrequest = ddnsrequest;
                this.period = period;
            }

            public void Start()
            {
                thrd = new Thread(this.ReportThread);
                thrd.Start();
                Console.WriteLine("[INFO]: Service started.");
            }

            public void Stop()
            {
                m.WaitOne();    // Wait for signal (finished)
                Console.WriteLine("[INFO]: Service stopping.");
                thrd.Abort();
            }

            private void ReportThread()
            {
                try
                {
                    while (true)
                    {
                        m.Reset();  // set no signal
                        Report(zone_id, xauth, ddnsrequest);
                        m.Set();    // set signal
                        Thread.Sleep(period * 60000);
                    }
                }
                catch (ThreadAbortException) { }
                finally
                {
                    Console.WriteLine("[INFO]: Service stopped.");
                }
            }
        }

        public static string Report(string zone_id, UserXAuth xauth, DDNSRequest ddnsrequest)
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
