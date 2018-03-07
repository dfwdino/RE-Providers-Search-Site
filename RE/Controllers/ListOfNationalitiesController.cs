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
    public class ListOfNationalitiesController : Controller
    {
        private REEntities db = new REEntities();

        // GET: ListOfNationalities
        public ActionResult Index()
        {
            return View(db.ListOfNationalities.OrderBy(m => m.Nationality) .ToList());
        }

        // GET: ListOfNationalities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListOfNationality listOfNationality = db.ListOfNationalities.Find(id);
            if (listOfNationality == null)
            {
                return HttpNotFound();
            }
            return View(listOfNationality);
        }

        // GET: ListOfNationalities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ListOfNationalities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Hide,CreatedDate,Nationality")] ListOfNationality listOfNationality)
        {
            if (ModelState.IsValid)
            {
                listOfNationality.CreatedDate = DateTime.Now;
                db.ListOfNationalities.Add(listOfNationality);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(listOfNationality);
        }

        // GET: ListOfNationalities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListOfNationality listOfNationality = db.ListOfNationalities.Find(id);
            if (listOfNationality == null)
            {
                return HttpNotFound();
            }
            return View(listOfNationality);
        }

        // POST: ListOfNationalities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Hide,CreatedDate,Nationality")] ListOfNationality listOfNationality)
        {
            if (ModelState.IsValid)
            {
                db.Entry(listOfNationality).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(listOfNationality);
        }

        // GET: ListOfNationalities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListOfNationality listOfNationality = db.ListOfNationalities.Find(id);
            if (listOfNationality == null)
            {
                return HttpNotFound();
            }
            return View(listOfNationality);
        }

        // POST: ListOfNationalities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ListOfNationality listOfNationality = db.ListOfNationalities.Find(id);
            listOfNationality.Hide = true;
            //db.ListOfNationalities.Remove(listOfNationality);
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
