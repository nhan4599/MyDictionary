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
                manager = new DatabaseManagement();
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

        public List<Word> Search(string word)
        {
            List<Word> result = new List<Word>();
            string htmlSource = GetHtmlSource(string.Format(searchUrl, word));
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(htmlSource);
            HtmlNodeCollection data = doc.DocumentNode.SelectNodes("//div[@class='phanloai']");
            var listsType = manager.GetTypesString();
            string means = "";
            string current = "";
            int startIndex = 0;
            int endIndex = 0;
            int type_id = -1;
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
                type_id = manager.GetIdOfType(data[i].InnerText);
                result.Add(new Word() {word_o = word, type_id = type_id, word_m = means, Type = manager.GetTypeOfId(type_id) });
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
            type_id = manager.GetIdOfType(node.InnerText);
            result.Add(new Word() { word_o = word, type_id = type_id, word_m = means , Type = manager.GetTypeOfId(type_id)});
            return result;
        }
    }
}