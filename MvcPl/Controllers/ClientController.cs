using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Web.Mvc;
using Agregator.Infrastructure;
using Bll.Implementation.Clients;
using Dal.Interface;
using PagedList;

namespace Agregator.Controllers
{
    public class ClientController : Controller
    {
        private const string Path = @"D:\Кодинг\Git\Agregator\MvcPl\configDate.json";
        private readonly ObjectCache _cache;
        private readonly JsonParser _jsonParser;
        private IEnumerable<PartyModel> _tempList;

        private RelaxClient RelaxClient { get; }

        public ClientController()
        {
            _jsonParser = new JsonParser();
            _cache = MemoryCache.Default;
            RelaxClient = new RelaxClient();
        }

        public ClientController(RelaxClient relaxClient, JsonParser jsonParser)
        {
            RelaxClient = relaxClient;
            this._jsonParser = jsonParser;
        }

        public ActionResult Index()
        {
            var menu = _jsonParser.ParseJSONMenuItems(Path);
            return View(menu);
        }

        public ActionResult FilterCatalog(string key)
        {
            var menu = _jsonParser.ParseJSONMenuItems(Path);
            var catalog = menu?.Where(item => item.Key == key).ToList()[0].Value;
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
            var a = _cache["last"];
            _tempList = (List<PartyModel>) a;
            return PartialView(_tempList.ToPagedList(page, 20));
        }
    }
}