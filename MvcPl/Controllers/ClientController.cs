using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Caching;
using System.Web.Mvc;
using Bll.Implementation.Clients;
using CommonInterface;
using Dal.Interface;
using Newtonsoft.Json.Linq;
using PagedList;

namespace Agregator.Controllers
{
    public class ClientController : Controller
    {
        private const string Path = @"D:\Кодинг\Git\Agregator\MvcPl\configDate.json";
        private Dictionary<string, List<MenuItem>> menu;
        private ObjectCache _cache;
        private IEnumerable<PartyModel> _tempList;

        private RelaxClient RelaxClient { get; }

        public ClientController()
        {
            _cache = MemoryCache.Default;
            RelaxClient = new RelaxClient();
        }

        public ClientController(RelaxClient relaxClient)
        {
            RelaxClient = relaxClient;
        }

        // GET: Client

        #region menuContent

        private void ParseJSONMenuItems()
        {
            if (_cache["menu"] != null)
            {
                var tempMenu = _cache["menu"];
                menu = (Dictionary<string, List<MenuItem>>)tempMenu;
                return;
            }

            menu = new Dictionary<string, List<MenuItem>>();
            var token = JToken.Parse(System.IO.File.ReadAllText(Path));
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
        }

        #endregion

        public ActionResult Index()
        {
            if(menu==null) ParseJSONMenuItems();
            return View(menu);
        }

        public ActionResult FilterCatalog(string  key)
        {
            if (menu == null) ParseJSONMenuItems();
            var catalog = menu?.Where(item => item.Key == key).ToList()[0].Value;
            return PartialView(catalog);
        }

        private void GetParseList(string url)
        {
            if(_cache[url] == null)
            _cache[url] = RelaxClient.GetParties(url);
            _cache["last"] = _cache[url];
        }

        public ActionResult Parse(int page, string url = null)
        {
            if(url != null) GetParseList(url);
            var a = _cache["last"];
            _tempList = (List<PartyModel>)a;
            return PartialView(_tempList.ToPagedList(page,20));
        }
    }
}