using System;
using System.Net;
using System.Net.Http;
using Bll.Interface;
using static System.Net.WebRequestMethods;

namespace Bll.Implementation.Parsers
{
    public class RelaxParser:IParser
    {
        private readonly IClient _client;

        public RelaxParser(IClient client)
        {
            _client = client;
        }

        public object Parse()
        {
                return null;
        }
    }
}
