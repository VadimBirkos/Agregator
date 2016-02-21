using System.Collections.Generic;
using System.Runtime.Caching;
using CommonInterface;

namespace Agregator.Infrastructure
{
    public class ConfigurationManager:IConfigurationManager
    {
        private readonly ObjectCache _cache;
        private readonly IJsonMenuParser _menuParser;
        private readonly IFileReader _fileReader;

        public ConfigurationManager()
        {
            _fileReader = new FileReader();
            _menuParser = new JsonMenuParser();
            _cache = MemoryCache.Default;
        }

        private Dictionary<string, List<MenuItem>> CheckInCache(string key)
        {
            return (_cache[key] != null)? (Dictionary < string, List < MenuItem >>)_cache[key]: null;
        }

        public Dictionary<string, List<MenuItem>> ReadConfiguration(string path)
        {
            var menu = CheckInCache("menu");
            if (menu != null)
                return menu;
            menu = _menuParser.Parse(_fileReader.ReadFile(path));
            _cache["menu"] = menu;
            return menu;
        }
    }
}