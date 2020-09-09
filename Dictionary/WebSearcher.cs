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
        private const string SEARCH_URL = "https://vdict.com/{0},1,0,0.html";
        private bool IsNetworkAvailable()
        {
            return NetworkInterface.GetIsNetworkAvailable();
        }

        private string GetHtmlSource(string url)
        {
            if (!IsNetworkAvailable())
            {
                throw new WebException("Your network is not available, please check your connection");
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

        public List<WordView> Search(string word)
        {
            List<WordView> result = new List<WordView>();
            string htmlSource = GetHtmlSource(string.Format(SEARCH_URL, word));
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(htmlSource);
            HtmlNodeCollection data = doc.DocumentNode.SelectNodes("//div[@class='phanloai']");
            string means = "";
            string current = "";
            int startIndex = 0;
            int endIndex = 0;
            HtmlNodeCollection collect = null;
            HtmlDocument temp = new HtmlDocument();
            for (int i = 0; i < data.Count - 1; i++)
            {
                startIndex = data[i].StreamPosition;
                endIndex = data[i + 1].StreamPosition;
                current = htmlSource.Substring(startIndex, endIndex - startIndex);
                temp.LoadHtml(current);
                collect = temp.DocumentNode.SelectNodes("/ul[@class='list1']/li/b");
                for (int j = 0; j < collect.Count; j++)
                {
                    means += collect[j].InnerText + ", ";
                }
                means = means.Remove(means.Length - 2);
                result.Add(new WordView() { word = word, type = data[i].InnerText, mean = means});
            }
            HtmlNode node = data[data.Count - 1];
            startIndex = node.StreamPosition;
            endIndex = doc.DocumentNode.SelectNodes("//div[@class='relatedWord']")[0].StreamPosition;
            current = htmlSource.Substring(startIndex, endIndex - startIndex);
            temp.LoadHtml(current);
            collect = temp.DocumentNode.SelectNodes("/ul[@class='list1']/li/b");
            for (int j = 0; j < collect.Count; j++)
            {
                means += collect[j].InnerText + ", ";
            }
            means = means.Remove(means.Length - 2);
            result.Add(new WordView() { word = word, type = data[data.Count - 1].InnerText, mean = means });
            return result;
        }
    }
}