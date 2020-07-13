using System.Text;
using System.Net;
using System.IO;

// Source : https://www.cnblogs.com/lastcode/p/4878436.html

namespace CloudFlareDDNS_WPF
{
    class HttpClient
    {
        public HttpClient()
        {
        }

        #region DELETE方式
        public string Delete(string url, WebHeaderCollection headers, string data) => CommonHttpRequest(url, headers, data, "DELETE");

        public string Delete(string url)
        {
            //Web访问对象64
            string serviceUrl = url;
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
            myRequest.Method = "DELETE";
            // 获得接口返回值68
            HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
            StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
            //string ReturnXml = HttpUtility.UrlDecode(reader.ReadToEnd());
            string ReturnXml = reader.ReadToEnd();
            reader.Close();
            myResponse.Close();
            return ReturnXml;
        }
        #endregion

        #region PUT方式
        public string Put(string url, WebHeaderCollection headers, string data) => CommonHttpRequest(url, headers, data, "PUT");
        #endregion

        #region POST方式
        public string Post(string url, WebHeaderCollection headers, string data) => CommonHttpRequest(url, headers, data, "POST");
        #endregion

        #region GET方式
        public string Get(string url)
        {
            //Web访问对象64
            string serviceUrl = url;

            //构造一个Web请求的对象
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
            // 获得接口返回值68
            //获取web请求的响应的内容
            HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();

            //通过响应流构造一个StreamReader
            StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
            //string ReturnXml = HttpUtility.UrlDecode(reader.ReadToEnd());
            string ReturnXml = reader.ReadToEnd();
            reader.Close();
            myResponse.Close();
            return ReturnXml;
        }
        #endregion

        #region HTTP请求函数
        public string CommonHttpRequest(string url, WebHeaderCollection headers, string data, string type)
        {
            //Web访问对象，构造请求的url地址
            string serviceUrl = string.Format(url);

            //构造http请求的对象
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
            //转成网络流
            byte[] buf = System.Text.Encoding.GetEncoding("UTF-8").GetBytes(data);

            //设置
            myRequest.Method = type;
            myRequest.Headers = headers;
            myRequest.ContentLength = buf.Length;
            myRequest.ContentType = "application/json";
            myRequest.MaximumAutomaticRedirections = 1;
            myRequest.AllowAutoRedirect = true;
            // 发送请求
            Stream newStream = myRequest.GetRequestStream();
            newStream.Write(buf, 0, buf.Length);
            newStream.Close();
            // 获得接口返回值
            HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
            StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
            string ReturnXml = reader.ReadToEnd();
            reader.Close();
            myResponse.Close();
            return ReturnXml;
            #endregion
        }
    }
}
