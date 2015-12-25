using Bll.Interface;
using DalInterface;

namespace Bll.Implementation
{
    public class PartiesInteractor:IPartiesInteractor
    {
        private IClient _client;
        private IRepository<PartyModel> _repository; 

        public PartiesInteractor(IClient client, IRepository<PartyModel> repository)
        {
            _client = client;
            _repository = repository;

        }

        public void RemoveParty(PartyModel party)
        {
            throw new System.NotImplementedException();
        }
    }
}
