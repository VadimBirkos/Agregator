using System.Collections.Generic;
using System.Net;
using System.Text;
using Bll.Implementation.Parsers;
using Bll.Interface;
using Dal.Interface;
using HtmlAgilityPack;

namespace Bll.Implementation.Clients
{
    public class RelaxClient 
    {
        private readonly IParser _parser;

        public RelaxClient()
        {
            _parser = new RelaxParser();
        }

        public RelaxClient(IParser parser)
        {
            _parser = parser;
        }

        public IEnumerable<PartyModel> GetParties(string url)
        {
            var resultList = new List<PartyModel>();
            var page = 1;
            while (true)
            {
                var htmlDoc = (page <= 1) ? LoadHtml(url) : LoadHtml(url + $"?page={page}");
                if(htmlDoc == null) break;
                resultList.AddRange(_parser.Parse(htmlDoc));
                page++;
            }
            return resultList;
        }

        private HtmlDocument LoadHtml(string adress)
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
    }
}
