using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RE.Controllers
{
    public class HomeController : Controller
    {
        private REEntities db = new REEntities();
        // GET: Home
        public ActionResult Index()
        {
            List<Provider> providers = db.Providers.Where(m => m.Hide == false).ToList();


            return View(providers);
        }
    }
}