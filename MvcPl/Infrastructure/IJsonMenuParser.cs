using System.Collections.Generic;
using CommonInterface;

namespace Agregator.Infrastructure
{
    interface IJsonMenuParser
    {
        Dictionary<string, List<MenuItem>> Parse(string path);
    }
}
