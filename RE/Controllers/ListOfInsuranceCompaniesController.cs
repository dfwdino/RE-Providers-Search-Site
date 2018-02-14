using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RE;

namespace RE.Controllers
{
    public class ListOfInsuranceCompaniesController : Controller
    {
        private REEntities db = new REEntities();

        // GET: ListOfInsuranceCompanies
        public ActionResult Index()
        {
            return View(db.ListOfInsuranceCompanys.ToList());
        }

        // GET: ListOfInsuranceCompanies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListOfInsuranceCompany listOfInsuranceCompany = db.ListOfInsuranceCompanys.Find(id);
            if (listOfInsuranceCompany == null)
            {
                return HttpNotFound();
            }
            return View(listOfInsuranceCompany);
        }

        // GET: ListOfInsuranceCompanies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ListOfInsuranceCompanies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Hide")] ListOfInsuranceCompany listOfInsuranceCompany)
        {
            if (ModelState.IsValid)
            {
                db.ListOfInsuranceCompanys.Add(listOfInsuranceCompany);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(listOfInsuranceCompany);
        }

        // GET: ListOfInsuranceCompanies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListOfInsuranceCompany listOfInsuranceCompany = db.ListOfInsuranceCompanys.Find(id);
            if (listOfInsuranceCompany == null)
            {
                return HttpNotFound();
            }
            return View(listOfInsuranceCompany);
        }

        // POST: ListOfInsuranceCompanies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Hide")] ListOfInsuranceCompany listOfInsuranceCompany)
        {
            if (ModelState.IsValid)
            {
                db.Entry(listOfInsuranceCompany).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(listOfInsuranceCompany);
        }

        // GET: ListOfInsuranceCompanies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListOfInsuranceCompany listOfInsuranceCompany = db.ListOfInsuranceCompanys.Find(id);
            if (listOfInsuranceCompany == null)
            {
                return HttpNotFound();
            }
            return View(listOfInsuranceCompany);
        }

        // POST: ListOfInsuranceCompanies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ListOfInsuranceCompany listOfInsuranceCompany = db.ListOfInsuranceCompanys.Find(id);
            db.ListOfInsuranceCompanys.Remove(listOfInsuranceCompany);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
