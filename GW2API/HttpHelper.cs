using System.IO;
using System.Net;
using System.Text;

namespace GW2API
{
    class HttpHelper
    {
        public static string HttpPost(string URI, string Parameters)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(URI);
            req.ContentType = "application/x-www-form-urlencoded";
            req.Method = "POST";

            if (string.IsNullOrEmpty(Parameters))
                req.ContentLength = 0;
            else
            {
                byte[] bytes = Encoding.ASCII.GetBytes(Parameters);
                req.ContentLength = bytes.Length;

                using (Stream os = req.GetRequestStream())
                {
                    os.Write(bytes, 0, bytes.Length);
                    os.Close();
                }
            }

            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            if (resp == null) return null;

            using (StreamReader sr = new StreamReader(resp.GetResponseStream()))
                return sr.ReadToEnd().Trim();
        }

        public static string HttpGet(string URI)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(URI);
            req.ContentType = "application/x-www-form-urlencoded";
            req.Method = "GET";

            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            if (resp == null) return null;

            using (StreamReader sr = new StreamReader(resp.GetResponseStream()))
                return sr.ReadToEnd().Trim();
        }
    }
}
