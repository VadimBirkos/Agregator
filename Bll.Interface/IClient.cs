using System.Collections.Generic;
using DalInterface;

namespace Bll.Interface
{
    public interface IClient
    {
        IEnumerable<PartyModel> GetParties();
    }
}