using System.Collections.Generic;
using CommonInterface;

namespace Agregator.Infrastructure
{
    interface IConfigurationManager
    {
        Dictionary<string, List<MenuItem>> ReadConfiguration(string path);
    }
}
