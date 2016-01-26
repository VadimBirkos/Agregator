using System.Collections.Generic;
using Bll.Interface;
using Dal.Interface;

namespace Bll.Implementation.Clients
{
    class VsemenuClient:IClient
    {
        private readonly IParser _parser;

        public VsemenuClient(IParser parser)
        {
            _parser = parser;
        }

        public IEnumerable<PartyModel> GetParties(string url)
        {
            throw new System.NotImplementedException();
        }
    }
}
