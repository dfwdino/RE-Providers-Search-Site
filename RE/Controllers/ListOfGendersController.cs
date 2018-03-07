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
    public class ListOfGendersController : Controller
    {
        private REEntities db = new REEntities();

        // GET: ListOfGenders
        public ActionResult Index()
        {
            return View(db.ListOfGenders.OrderBy(m => m.Gender).ToList());
        }

        // GET: ListOfGenders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListOfGender listOfGender = db.ListOfGenders.Find(id);
            if (listOfGender == null)
            {
                return HttpNotFound();
            }
            return View(listOfGender);
        }

        // GET: ListOfGenders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ListOfGenders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Hide,CreatedDate,Gender")] ListOfGender listOfGender)
        {
            if (ModelState.IsValid)
            {
                listOfGender.CreatedDate = DateTime.Now;
                db.ListOfGenders.Add(listOfGender);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(listOfGender);
        }

        // GET: ListOfGenders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListOfGender listOfGender = db.ListOfGenders.Find(id);
            if (listOfGender == null)
            {
                return HttpNotFound();
            }
            return View(listOfGender);
        }

        // POST: ListOfGenders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Hide,CreatedDate,Gender")] ListOfGender listOfGender)
        {
            if (ModelState.IsValid)
            {
                db.Entry(listOfGender).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(listOfGender);
        }

        // GET: ListOfGenders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListOfGender listOfGender = db.ListOfGenders.Find(id);
            if (listOfGender == null)
            {
                return HttpNotFound();
            }
            return View(listOfGender);
        }

        // POST: ListOfGenders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ListOfGender listOfGender = db.ListOfGenders.Find(id);
            //db.ListOfGenders.Remove(listOfGender);
            listOfGender.Hide = true;
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
