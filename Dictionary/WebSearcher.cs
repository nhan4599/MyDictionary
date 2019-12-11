using System;
using System.Net;
using System.Net.NetworkInformation;
using Dictionary.Data;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using HtmlAgilityPack;

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

        public string Search(string word)
        {
            //List<Word> result = new List<Word>();
            string htmlSource = GetHtmlSource(string.Format(searchUrl, word));
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(htmlSource);

            HtmlNodeCollection data = doc.DocumentNode.SelectNodes("//div[@class='phanloai']");
            string result = "";
            for (int i = 0; i < data.Count - 1; i++)
            {
                int preIndex = data[i].StreamPosition;
                int nextIndex = data[i + 1].StreamPosition;
                string current = htmlSource.Substring(preIndex, nextIndex - preIndex);
                HtmlDocument temp = new HtmlDocument();
                temp.LoadHtml(current);
                HtmlNodeCollection collect = temp.DocumentNode.SelectNodes("/ul[@class='list1']/li/b");
                for (int j = 0; j < collect.Count; j++)
                {
                    result += collect[j].InnerText + "\n";
                }
            }
            return result;
        }
    }
}
