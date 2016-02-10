using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Bll.Implementation.Clients;
using CommonInterface;
using Dal.Interface;
using PagedList.Mvc;
using PagedList;

namespace Agregator.Controllers
{
    public class ClientController : Controller
    {
        private IEnumerable<PartyModel> _temp;
        private readonly RelaxClient _relaxClient;

        public ClientController()
        {
            _relaxClient = new RelaxClient();
        }

        public ClientController(RelaxClient relaxClient)
        {
            _relaxClient = relaxClient;
        }

        // GET: Client

        #region

        private readonly string[] list = {"Развлечения", "Все для праздника", "Здоровье и красота"}; 
        private readonly Dictionary<string, List<MenuItem>> _menu = new Dictionary<string, List<MenuItem>>()
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

        public RelaxClient RelaxClient
        {
            get
            {
                return _relaxClient;
            }
        }

        #endregion

        public ActionResult Index()
        {
            return View(_menu);
        }

        [HttpPost]
        public ActionResult FilterCatalog(string  key)
        {
            var catalog = _menu.Where(item => item.Key == key).ToList()[0].Value;
            return PartialView(catalog);
        }

        private void GetParseList(string url)
        {
            _temp = RelaxClient.GetParties(url);
        }

        public ActionResult Parse(int page, string url = null)
        {
            if(url != null) GetParseList(url);
            return PartialView(_temp.ToPagedList(page,20));
        }

        public ActionResult TestPage()
        {
            return View();
        }
    }
}