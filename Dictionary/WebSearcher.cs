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
            if (!IsNetworkAvailable())
            {
                throw new Exception("Your network is not available, please check your connection");
            }
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

        public void Search(string word)
        {
            string htmlSource = GetHtmlSource(string.Format(searchUrl, word));
            Regex bodyReg = new Regex("<body>(.*\\s*)*</body>");
            string bodyPartition = bodyReg.Match(htmlSource).Value;
            Regex mainReg = new Regex("<div class=\"phanloai\">.*</div>");
            MatchCollection matches = mainReg.Matches(bodyPartition);
            File.WriteAllLines(@"D:\test.txt", new string[] { matches[0].Value, matches[1].Value });
        }
    }
}
