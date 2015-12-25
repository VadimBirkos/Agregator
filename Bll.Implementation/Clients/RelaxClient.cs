using System.Collections.Generic;
using Bll.Interface;
using DalInterface;

namespace Bll.Implementation.Clients
{
    class RelaxClient:IClient
    {
        private readonly IParser _parser;
        public RelaxClient(IParser parser)
        {
            _parser = parser;
        }

        public IEnumerable<PartyModel> GetParties()
        {
            throw new System.NotImplementedException();
        }
    }
}
