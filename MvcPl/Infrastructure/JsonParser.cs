using System.Collections.Generic;
using System.IO;
using System.Runtime.Caching;
using CommonInterface;
using Newtonsoft.Json.Linq;

namespace Agregator.Infrastructure
{
    public class JsonParser
    {
        private ObjectCache _cache;


        public JsonParser()
        {
            _cache = MemoryCache.Default;
            
        }

        public Dictionary<string, List<MenuItem>> ParseJSONMenuItems(string path)
        {
            var menu = new Dictionary<string, List<MenuItem>>();
            if (_cache["menu"] != null)
            {
                var tempMenu = _cache["menu"];
                menu = (Dictionary<string, List<MenuItem>>) tempMenu;
                return menu;
            }
            var token = JToken.Parse(File.ReadAllText(path));
            foreach (var upper in token)
            {
                foreach (var menuHeader in upper)
                {
                    foreach (var menuItem in menuHeader["Content"])
                    {
                        if (menu.ContainsKey(menuHeader["Name"].ToString()))
                            menu[menuHeader["Name"].ToString()].Add(
                                new MenuItem(menuItem["Name"].ToString(), menuItem["Link"].ToString()));
                        else
                            menu.Add(menuHeader["Name"].ToString(), new List<MenuItem>()
                            {
                                new MenuItem(menuItem["Name"].ToString(), menuItem["Link"].ToString())
                            });
                    }
                }
            }
            _cache["menu"] = menu;
            return menu;
        }


    }
}