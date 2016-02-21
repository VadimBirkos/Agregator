using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Web.Mvc;
using Agregator.Infrastructure;
using Agregator.Models;
using Bll.Implementation.Clients;
using Dal.Interface;

namespace Agregator.Controllers
{
    public class ClientController : Controller
    {
        private const string PartialPath = "~/App_Data/configData.json";
        private const int PageSize = 30;
        private readonly ObjectCache _cache;
        private readonly IConfigurationManager _configurationManager;
        private RelaxClient RelaxClient { get; }

        public ClientController()
        {
            _configurationManager = new ConfigurationManager();
            _cache = MemoryCache.Default;   
            RelaxClient = new RelaxClient();
        }

        public ActionResult Index()
        {
            var menu = _configurationManager.ReadConfiguration(HttpContext.Server.MapPath(PartialPath));
            return View(menu);
        }

        public ActionResult FilterCatalog(string key)
        {
            var menu = _configurationManager.ReadConfiguration(HttpContext.Server.MapPath(PartialPath));
            var catalog = menu.FirstOrDefault(item => item.Key == key).Value;
            return PartialView(catalog);
        }

        private void GetParseList(string url)
        {
            if (_cache[url] == null) 
                _cache[url] = RelaxClient.GetParties(url);
            _cache["last"] = _cache[url];
        }

        public ActionResult Parse(int page, string url = null)
        {
            if (url != null) GetParseList(url);
            var cacheItem = (List<PartyModel>) _cache["last"];
            var pagingModel = new PagingModel()
            {
                PartyModelList = page > 1 
                ? cacheItem.Skip((page - 1) * PageSize).Take(PageSize) 
                : cacheItem.Take(PageSize),
                CurrentPage = page,
                CountPage = cacheItem.Count/PageSize
            };
            return PartialView(pagingModel);
        }
    }
}