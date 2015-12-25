using System.Net;
using Bll.Interface;

namespace Bll.Implementation.Parsers
{
    class VsemenuParser:IParser
    {
        private readonly IClient _client;

        public VsemenuParser(IClient client)
        {
            _client = client;
        }

        public object Parse()
        {
            throw new System.NotImplementedException();
        }
    }
}
