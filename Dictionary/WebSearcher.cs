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
                throw new System.Net.WebException("Your network is not available, please check your connection");
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
<<<<<<< HEAD
            List<WordView> result = new List<WordView>();
=======
            List<Word> result = new List<Word>();
>>>>>>> 443a72d8de5ae5828dff712e3f73c64ff5c87876
            string htmlSource = GetHtmlSource(string.Format(searchUrl, word));
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(htmlSource);
            HtmlNodeCollection data = doc.DocumentNode.SelectNodes("//div[@class='phanloai']");
<<<<<<< HEAD
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
=======
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
>>>>>>> 443a72d8de5ae5828dff712e3f73c64ff5c87876
        }
    }
}