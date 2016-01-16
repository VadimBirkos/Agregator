using System;
using System.Collections.Generic;
using Bll.Interface;
using Dal.Interface;

namespace Bll.Implementation.Parsers
{
    class VsemenuParser : IParser
    {
        private readonly IClient _client;

        public VsemenuParser(IClient client)
        {
            _client = client;
        }

        public List<PartyModel> Parse(string url)
        {
            throw new NotImplementedException();
        }
    }
}
