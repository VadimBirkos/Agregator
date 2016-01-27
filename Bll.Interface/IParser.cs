using System.Collections.Generic;
using Dal.Interface;
using HtmlAgilityPack;

namespace Bll.Interface
{
    public interface IParser
    {
        List<PartyModel> Parse(HtmlDocument htmlDoc);
    }
}
