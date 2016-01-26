using System.Collections.Generic;
using System.Web.Mvc;
using Bll.Interface;
using CommonInterface;

namespace Agregator.Controllers
{
    public class ClientController : Controller
    {
        private IClient _client;
        // GET: Client
        #region
        private readonly Dictionary<string, List<MenuItem>> _menu = new Dictionary<string, List<MenuItem>>()
        {
            {
                "Развлечения", new List<MenuItem>() { new MenuItem("Ночные клубы", @"http://www.relax.by/cat/ent/clubs/"),
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
                }},
            {"Все для праздника", new List<MenuItem>()
            {
                new MenuItem("Свадебные салоны", @"http://www.relax.by/cat/holiday/wedding/") 
            
            } },
            {"Здоровье и красота", new List<MenuItem>()
            {
                new MenuItem("Салон красоты", @"http://www.relax.by/cat/health/beauty/")
            }
            }};

        public IClient Client
        {
            get
            {
                return _client;
            }

            set
            {
                _client = value;
            }
        }
        #endregion
        
        public ActionResult Index()
        {
            return View(_menu);
        }

        public ActionResult Parse()
        {
            return View(_client.GetParties(@"http://www.relax.by/cat/holiday/wedding/"));
        }
    }
}