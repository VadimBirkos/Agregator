using System.Web.Helpers;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CommonInterface;
using  Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            var menu = new Dictionary<string, List<MenuItem>>(); 
            var token = JToken.Parse(File.ReadAllText(@"D:\Кодинг\Git\Agregator\Testing\configDate.json"));
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

        }
}
}
