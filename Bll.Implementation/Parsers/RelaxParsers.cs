using System.Collections.Generic;
using System.Net;
using System.Text;
using Bll.Interface;
using Dal.Interface;
using HtmlAgilityPack;

namespace Bll.Implementation.Parsers
{
    public class RelaxParser : IParser
    {
        private int _index = 0;

        public List<PartyModel> Parse(string url)
        {
            throw new System.NotImplementedException();
        }

        private  HtmlDocument LoadHtml(string adress)
        {
            var client = new WebClient();
            try
            {
                var byteArr = client.DownloadData(adress);
                var htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(Encoding.UTF8.GetString(byteArr));
                return htmlDoc;
            }
            catch (WebException)
            {
                return null;
            }
            finally
            {
                client.Dispose();
            }
        }

        private  PartyModel Parse(HtmlNode node)
        {
            if (!node.InnerHtml.Contains("class=\"link link--underline") ||
                node.InnerHtml.Contains("reklama"))
                return null;
            var name = GetValue(node, "class=\"link link--underline");
            var email = (node.InnerHtml.Contains("E-mail:"))
                ? GetValue(node, "<noindex><b>E-mail:")
                    .Replace("E-mail:", "")
                : "Отсутствует";
            var site = (node.InnerHtml.Contains("<a class=\"link link--colored link--"))
                ? GetValue(node, "<a class=\"link link--colored link--")
                : "Отсутствует";
            return new PartyModel() {Name = name,Email = email,Site = site};
        }

        private string GetValue(HtmlNode node, string condition)
        {
            return GetNode(node, condition).InnerText.Replace("  ", "").Replace("\n", "").Replace("\t", "");
        }

        private HtmlNode GetNode(HtmlNode node, string condition)
        {
            if (!node.InnerHtml.Contains(condition))
            {
                if (_index >= node.ParentNode.ChildNodes.Count - 1)
                    return node.ParentNode;
                _index++;
                return GetNode(node.ParentNode.ChildNodes[_index], condition);
            }
            _index = 0;
            return GetNode(node.ChildNodes[_index], condition);
        }
    }
}
