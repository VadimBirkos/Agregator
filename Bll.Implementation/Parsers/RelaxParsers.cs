using Bll.Interface;

namespace Bll.Implementation.Parsers
{
    public class RelaxParser : IParser
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
