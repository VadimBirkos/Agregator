using System;
using System.Collections.Generic;
using Bll.Interface;
using Dal.Interface;

namespace Bll.Implementation.Clients
{
    public class RelaxClient :IClient
    {
        private readonly IParser _parser;
        public RelaxClient(IParser parser)
        {
            _parser = parser;
        }

        public IEnumerable<PartyModel> GetParties()
        {            
            throw new NotImplementedException();
        }
    }
}
