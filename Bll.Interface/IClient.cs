using System.Collections.Generic;
using Dal.Interface;

namespace Bll.Interface
{
    public interface IClient
    {
        IEnumerable<PartyModel> GetParties();
    }
}
