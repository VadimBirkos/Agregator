using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Caching;
using System.Web.Mvc;
using Agregator.Infrastructure;
using Agregator.Models;
using Bll.Implementation.Clients;
using Bll.Interface;
using Dal.Interface;
using Bll.Implementation;

namespace Agregator.Controllers
{
    public class ClientController : Controller
    {
        private const string LastItemKey = "LastList";
        private const string PartialPath = "~/App_Data/configData.json";
        private const int PageSize = 30;
        private readonly ObjectCache _cache;
        private readonly IConfigurationManager _configurationManager;
        private RelaxClient RelaxClient { get; }
        private readonly IExcelExporter _excelExporter;

        public ClientController()
        {
            _excelExporter = new ExcelExporter();
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
            _cache[LastItemKey] = _cache[url];
        }

        public ActionResult Parse(int page, string url = null)
        {
            if (url != null) GetParseList(url);
            var cacheItem = (List<PartyModel>) _cache[LastItemKey];
            var pagingModel = new PagingModel()
            {
                PartyModelList = page > 1
                    ? cacheItem.Skip((page - 1)*PageSize).Take(PageSize)
                    : cacheItem.Take(PageSize),
                CurrentPage = page,
                CountPage = cacheItem.Count/PageSize
            };
            return PartialView(pagingModel);
        }


        public FileResult Save(string url)
        {
            GetParseList(url);
            var list = (List<PartyModel>) _cache[url];
            _excelExporter.Export(list, Server.MapPath("~/Files"));
            const string fileName = "listItems.xlsx";
            const string typeFile = "xlsx";
            FileStream fs = null;
            var filePath =
                Server.MapPath("~/Files/exportData" + DateTime.Now.ToShortDateString().Replace(".", "") + ".xlsx");
            fs = new FileStream(filePath, FileMode.Open);
            return File(fs, typeFile, fileName);
        }
    }
}