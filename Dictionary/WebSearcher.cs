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
        private DatabaseManagement manager;
        
        public WebSearcher()
        {
            if (!IsNetworkAvailable())
            {
                throw new Exception("Your network is not available, please check your connection");
            }
            else
            {
                manager = new DatabaseManagement();
            }
        }
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
            List<Word> result = new List<Word>();
            string htmlSource = GetHtmlSource(string.Format(searchUrl, word));
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(htmlSource);
            HtmlNodeCollection data = doc.DocumentNode.SelectNodes("//div[@class='phanloai']");
            List<string> listType = manager.GetListsTypesString();
            for (int i = 0; i < data.Count - 1; i++)
            {
                if (!listType.Contains(data[i].InnerText))
                {
                    manager.AddType(data[i].InnerText);
                }
                int preIndex = data[i].StreamPosition;
                int nextIndex = data[i + 1].StreamPosition;
                string current = htmlSource.Substring(preIndex, nextIndex - preIndex);
                HtmlDocument temp = new HtmlDocument();
                temp.LoadHtml(current);
                HtmlNodeCollection collect = temp.DocumentNode.SelectNodes("/ul[@class='list1']/li/b");
                string means = "";
                for (int j = 0; j < collect.Count; j++)
                {
                    means += collect[i].InnerText + ", ";
                }
                means = means.Remove(means.Length - 2);
                int id = manager.GetIDOfType(data[i].InnerText);
                result.Add(new Word() { word_o = word, type_id = id, word_m = means, Type = manager.GetTypeOfId(id) });
            }
            return result.Count.ToString();
        }
    }
}
