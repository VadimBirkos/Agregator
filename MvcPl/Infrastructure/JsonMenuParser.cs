using System.Collections.Generic;
using CommonInterface;
using Newtonsoft.Json.Linq;

namespace Agregator.Infrastructure
{
    public class JsonMenuParser: IJsonMenuParser
    {
        private const string NameKey = "Name";
        public Dictionary<string, List<MenuItem>> Parse(string text)
        {
            var menu = new Dictionary<string, List<MenuItem>>();
            var token = JToken.Parse(text);

            foreach (var upper in token)
            {
                foreach (var menuHeader in upper)
                {
                    foreach (var menuItem in menuHeader["Content"])
                    {
                        if (menu.ContainsKey(menuHeader[NameKey].ToString()))
                            menu[menuHeader[NameKey].ToString()].Add(
                                new MenuItem(menuItem[NameKey].ToString(), menuItem["Link"].ToString()));
                        else
                            menu.Add(menuHeader[NameKey].ToString(), new List<MenuItem>()
                            {
                                new MenuItem(menuItem[NameKey].ToString(), menuItem["Link"].ToString())
                            });
                    }
                }
            }
            return menu;
        }
    }
}