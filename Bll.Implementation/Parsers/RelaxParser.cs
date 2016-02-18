using System.Collections.Generic;
using Bll.Interface;
using Dal.Interface;
using HtmlAgilityPack;

namespace Bll.Implementation.Parsers
{
    public class RelaxParser : IParser
    {
        private int _index;

        public List<PartyModel> Parse(HtmlDocument htmlDoc)
        {
            var resultList = new List<PartyModel>();
            var catalogListNode =
                GetNode(htmlDoc.DocumentNode, "div class=\"b-institution_description\"").ParentNode;
            foreach (var childNode in catalogListNode.ChildNodes)
            {
                if (childNode.InnerHtml.Contains("class=\"link link--underline") &&
                    !childNode.InnerHtml.Contains("reklama"))
                {
                    var tempEntity = Parse(childNode);
                    resultList.Add(new PartyModel()
                    {
                        Name = tempEntity.Name,
                        Email = tempEntity.Email,
                        Site = tempEntity.Site
                    });
                }
            }
            return resultList;
        }

        private PartyModel Parse(HtmlNode node)
        {
            var name = GetValue(node, "class=\"link link--underline");
            var email = (node.InnerHtml.Contains("E-mail:"))
                ? GetValue(node, "<noindex><b>E-mail:")
                    .Replace("E-mail:", "")
                : "Email отсутствует";
            var site = (node.InnerHtml.Contains("<a class=\"link link--colored link--"))
                ? GetValue(node, "<a class=\"link link--colored link--")
                : "Сайт отсутствует";
            return new PartyModel() { Name = name, Email = email, Site = site };
        }

        private string GetValue(HtmlNode node, string condition)
        {
            return GetNode(node, condition).InnerText.Replace("  ", "").Replace("\n", "").Replace("\t", "").Replace("&#039;", "'");
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
