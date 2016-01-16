using System.Collections.Generic;
using Dal.Interface;

namespace Bll.Interface
{
    public interface IParser
    {
        List<PartyModel> Parse(string url);
    }
}
