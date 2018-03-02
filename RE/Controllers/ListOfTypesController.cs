using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RE;

namespace RE.Controllers
{
    public class ListOfTypesController : Controller
    {
        private REEntities db = new REEntities();

        // GET: ListOfTypes
        public ActionResult Index()
        {
            return View(db.ListOfTypes.OrderBy(m => m.Type).ToList());
        }

        // GET: ListOfTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListOfType listOfType = db.ListOfTypes.Find(id);
            if (listOfType == null)
            {
                return HttpNotFound();
            }
            return View(listOfType);
        }

        // GET: ListOfTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ListOfTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Type")] ListOfType listOfType)
        {
            if (ModelState.IsValid)
            {
                foreach (var type in listOfType.Type.Split(','))
                {
                    bool FoundType = db.ListOfTypes.Where(m => m.Type.Contains(listOfType.Type)).Count() > 0;
                    if (!FoundType)
                    {
                        db.ListOfTypes.Add(new ListOfType() {Type = type });
                        db.SaveChanges();
                    }
                }

                
                return RedirectToAction("Index");
            }

            return View(listOfType);
        }

        // GET: ListOfTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListOfType listOfType = db.ListOfTypes.Find(id);
            if (listOfType == null)
            {
                return HttpNotFound();
            }
            return View(listOfType);
        }

        // POST: ListOfTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Type,Hide")] ListOfType listOfType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(listOfType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(listOfType);
        }

        // GET: ListOfTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListOfType listOfType = db.ListOfTypes.Find(id);
            if (listOfType == null)
            {
                return HttpNotFound();
            }
            return View(listOfType);
        }

        // POST: ListOfTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ListOfType listOfType = db.ListOfTypes.Find(id);
            listOfType.Hide = true;
            db.ListOfTypes.Remove(listOfType);
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
