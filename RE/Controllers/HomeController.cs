using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace RE.Controllers
{
    public class HomeController : Controller
    {
        private REEntities db = new REEntities();
        // GET: Home
        public ActionResult Index()
        {
            List<State> states = db.States.ToList();
            states.Add(new State() {ID=0,Name = " ---Select---" });
            
            ViewBag.StateID = new SelectList(states.OrderBy(m => m.Name), "ID", "Name");
            
            ViewBag.ListOfInsuranceCompanys = db.ListOfInsuranceCompanys.Where(m => m.Hide == false).OrderBy(m => m.Name).ToList();
            ViewBag.ListOfServices = db.ListOfServices.Where(m => m.Hide == false).OrderBy(m => m.Name).ToList();
            ViewBag.ListOfTypes = db.ListOfTypes.Where(m => m.Hide == false).OrderBy(m => m.Type).ToList();
            ViewBag.GenderID = new SelectList(db.ListOfGenders.Where(m => m.Hide == false), "ID", "Gender");
            ViewBag.NationalityID = new SelectList(db.ListOfNationalities.Where(m => m.Hide == false), "ID", "Nationality");

            return View(new List<Models.ProviderCreateModel>());
        }
        
        [HttpPost]
        public ActionResult Index(Models.ProviderCreateModel providersearch)
        {
            List<State> states = db.States.ToList();
            states.Add(new State() { ID = 0, Name = " ---Select---" });

            ViewBag.StateID = new SelectList(states.OrderBy(m => m.Name), "ID", "Name");
            ViewBag.ListOfInsuranceCompanys = db.ListOfInsuranceCompanys.Where(m => m.Hide == false).OrderBy(m => m.Name).ToList();
            ViewBag.ListOfServices = db.ListOfServices.Where(m => m.Hide == false).OrderBy(m => m.Name).ToList();
            ViewBag.ListOfTypes = db.ListOfTypes.Where(m => m.Hide == false).OrderBy(m => m.Type).ToList();

            var providers = db.Providers.Include(c => c.Insurances).Include(c => c.Services).Include(c => c.State).Where(m => m.Hide == false);

            if (providersearch.Name != null)
            {
                providers = providers.Where(m => m.Name.Contains(providersearch.Name));
            }

            if (providersearch.City != null)
            {
                providers = providers.Where(m => m.City == providersearch.City);
            }

            if (!providersearch.StateID.Equals(0))
            {
                providers = providers.Where(m => m.StateID == providersearch.StateID);
            }

            if (providersearch.Zip != null)
            {
                providers = providers.Where(m => m.Zip == providersearch.Zip);
            }

            if (providersearch.SlidingScale == true)
            {
                providers = providers.Where(m => m.SlidingScale == providersearch.SlidingScale);
            }

            if (providersearch.DiscountCashPay == true)
            {
                providers = providers.Where(m => m.DiscountCashPay == providersearch.DiscountCashPay);
            }

            if (!providersearch.GenderID.Equals(0))
            {
                providers = providers.Where(m => m.GenderID == providersearch.GenderID);
            }

            if (!providersearch.NationalityID.Equals(0))
            {
                providers = providers.Where(m => m.NationalityID == providersearch.NationalityID);
            }

            List<Provider> searchproviders = providers.ToList();

            if (providersearch.Services.Count > 0 && searchproviders.Count > 0)
            {
                foreach (var item in providersearch.Services.First()?.SelectedService)
                {
                    List<Provider> temp = db.Services.Where(aa => aa.ServiceID == item).Select(mm => mm.Provider).ToList();
                    for (int i = searchproviders.Count() - 1; i >= 0; i--)
                    {
                        if(temp.Where(m => m.ID == searchproviders[i].ID).Count().Equals(0))
                            searchproviders.RemoveAt(i);
                    }
                    
                }
            }

            if (providersearch.Insurances.Count > 0 && searchproviders.Count > 0)
            {
                foreach (var item in providersearch.Insurances.First()?.SelectedInsurance)
                {
                    List<Provider> temp = db.Insurances.Where(aa => aa.InsureanceID == item).Select(mm => mm.Provider).ToList();
                    for (int i = searchproviders.Count() - 1; i > 0; i--)
                    {
                        if (temp.Where(m => m.ID == searchproviders[i].ID).Count().Equals(0))
                            searchproviders.RemoveAt(i);
                    }

                }
            }

            if (providersearch.Types.Count > 0 && searchproviders.Count > 0)
            {
                foreach (var item in providersearch.Types.First()?.SelectedType)
                {
                    List<Provider> temp = db.Types.Where(aa => aa.TypeID == item).Select(mm => mm.Provider).ToList();
                    for (int i = searchproviders.Count() - 1; i > 0; i--)
                    {
                        if (temp.Where(m => m.ID == searchproviders[i].ID).Count().Equals(0))
                            searchproviders.RemoveAt(i);
                    }

                }
            }

            TempData["SearchProvider"] = searchproviders;
            //return RedirectToAction("Search", "Home", searchproviders.ToList());
            return View(new List<Models.ProviderCreateModel>());

        }

        public ActionResult ProviderDetails(int id){

            return View(db.Providers.Where(m => m.ID == id).Include(m=>m.Insurances).Include(m => m.Services).Single());
        }

    }
}