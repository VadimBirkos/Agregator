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
            var newMenu = new Dictionary<string, List<MenuItem>>();
        var menu = new Dictionary<string, List<MenuItem>>()
        {
            {
                "Развлечения", new List<MenuItem>()
                {
                    new MenuItem("Ночные клубы", @"http://www.relax.by/cat/ent/clubs/"),
                    new MenuItem("Караоке-клубы", @"http://www.relax.by/cat/ent/karaoke/"),
                    new MenuItem("Боулинг", @"http://www.relax.by/cat/ent/bowlings/"),
                    new MenuItem("Бильярд", @"http://www.relax.by/cat/ent/billiards/"),
                    new MenuItem("Бани и сауны", @"http://www.relax.by/cat/ent/clubs/"),
                    new MenuItem("Коттеджи и усадьбы", @"http://www.relax.by/cat/tourism/cottages/"),
                    new MenuItem("Интернет кафе", @"http://www.relax.by/cat/ent/internet-cafe/"),
                    new MenuItem("Кинотеатры", @"http://www.relax.by/cat/ent/kino/"),
                    new MenuItem("Театры", @"http://www.relax.by/cat/ent/theatres/"),
                    new MenuItem("Музеи и галереи", @"http://www.relax.by/cat/ent/museums/"),
                    new MenuItem("Концертные залы", @"http://www.relax.by/cat/ent/halls/"),
                    new MenuItem("Квесты", @"http://www.relax.by/cat/active/quest/")
                }
            },
            {
                "Все для праздника", new List<MenuItem>()
                {
                    new MenuItem("Свадебные салоны", @"http://www.relax.by/cat/holiday/wedding/")

                }
            },
            {
                "Здоровье и красота", new List<MenuItem>()
                {
                    new MenuItem("Салон красоты", @"http://www.relax.by/cat/health/beauty/")
                }
            }
        };
            var j = JToken.Parse(File.ReadAllText(@"D:\Кодинг\Git\Agregator\Testing\configDate.json"));
            foreach(var item in j)
            {
                foreach (var subItem in item)
                {
                    foreach (var menuItem in subItem["Content"])
                    {
                        if (newMenu.ContainsKey(subItem["Name"].ToString()))
                            newMenu[subItem["Name"].ToString()].Add(
                                new MenuItem(menuItem["Name"].ToString(), menuItem["Link"].ToString()));
                        else
                            newMenu.Add(subItem["Name"].ToString(), new List<MenuItem>()
                            {
                                new MenuItem(menuItem["Name"].ToString(), menuItem["Link"].ToString())
                            });
                    }
                }
            }

        }
}
}
