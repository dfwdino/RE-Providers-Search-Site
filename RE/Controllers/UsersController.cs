﻿using System;
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
    public class UsersController : Controller
    {
        private REEntities db = new REEntities();

        // GET: Users
        public ActionResult Index()
        {
            List<Models.JSONUsersViewModel> users = new List<Models.JSONUsersViewModel>();

            foreach (User tempuser in db.Users)
            {
                Models.JSONUsersViewModel jsonuser = new Models.JSONUsersViewModel();

                jsonuser.Disable = tempuser.Disable;
                jsonuser.ID = tempuser.ID;
                jsonuser.LoginName = tempuser.LoginName;
                jsonuser.UserTypeName = tempuser.UserType.Type;

                users.Add(jsonuser);

            }

            return View(users);
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            List<UserType> listOfUserTypes = db.UserTypes.ToList();
            listOfUserTypes.Add(new UserType() { ID = 3, Type = " ---Select---" });

            ViewBag.UserTypeID = new SelectList(listOfUserTypes.OrderBy(m => m.Type), "ID", "Type");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
         

            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            List<UserType> listOfUserTypes = db.UserTypes.ToList();
            listOfUserTypes.Add(new UserType() { ID = 3, Type = " ---Select---" });

            ViewBag.UserTypeID = new SelectList(listOfUserTypes.OrderBy(m => m.Type), "ID", "Type");

            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            List<UserType> listOfUserTypes = db.UserTypes.ToList();
            listOfUserTypes.Add(new UserType() { ID = 3, Type = " ---Select---" });

            ViewBag.UserTypeID = new SelectList(listOfUserTypes.OrderBy(m => m.Type), "ID", "Type",user.UserTypeID);

            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            //db.Users.Remove(user);
            user.Disable = true;
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
