using System;
using System.Net;
using System.Net.NetworkInformation;
using Dictionary.Data;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Dictionary
{
    class WebSearcher
    {
        private const string searchUrl = "https://vdict.com/{0},1,0,0.html";
        private bool IsNetworkAvailable()
        {
            return NetworkInterface.GetIsNetworkAvailable();
        }

        private string GetHtmlSource(string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                Stream stream = request.GetResponse().GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                string result = reader.ReadToEnd();
                reader.Close();
                return result;
            }catch (Exception)
            {
                return string.Empty;
            }
        }

        public string Search(string word)
        {
            string htmlSource = GetHtmlSource(string.Format(searchUrl, word));
            Regex regex = new Regex("<body>(.*\\s*)*</body>");
            string str = regex.Match(htmlSource).Value;
            Regex re2 = new Regex("<div class=\"phanloai\">.*</div>");
            return re2.Match(str).Value;
        }
    }
}
