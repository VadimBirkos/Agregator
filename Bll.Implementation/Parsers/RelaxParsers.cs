using System.Collections.Generic;
using Bll.Interface;
using Dal.Interface;

namespace Bll.Implementation.Parsers
{
    public class RelaxParser : IParser
    {
        private readonly IClient _client;

        public RelaxParser(IClient client)
        {
            _client = client;
        }

        public List<PartyModel> Parse(string url)
        {
            throw new System.NotImplementedException();
        }
    }
}
