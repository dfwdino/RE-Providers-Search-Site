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
    public class ListOfServicesController : Controller
    {
        private REEntities db = new REEntities();

        // GET: ListOfServices
        public ActionResult Index()
        {
            return View(db.ListOfServices.ToList());
        }

        // GET: ListOfServices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListOfService listOfService = db.ListOfServices.Find(id);
            if (listOfService == null)
            {
                return HttpNotFound();
            }
            return View(listOfService);
        }

        // GET: ListOfServices/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ListOfServices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Hide")] ListOfService listOfService)
        {
            if (ModelState.IsValid)
            {
                db.ListOfServices.Add(listOfService);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(listOfService);
        }

        // GET: ListOfServices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListOfService listOfService = db.ListOfServices.Find(id);
            if (listOfService == null)
            {
                return HttpNotFound();
            }
            return View(listOfService);
        }

        // POST: ListOfServices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Hide")] ListOfService listOfService)
        {
            if (ModelState.IsValid)
            {
                db.Entry(listOfService).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(listOfService);
        }

        // GET: ListOfServices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListOfService listOfService = db.ListOfServices.Find(id);
            if (listOfService == null)
            {
                return HttpNotFound();
            }
            return View(listOfService);
        }

        // POST: ListOfServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ListOfService listOfService = db.ListOfServices.Find(id);
            db.ListOfServices.Remove(listOfService);
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
