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
    public class ProvidersController : Controller
    {
        private REEntities db = new REEntities();

        // GET: Providers
        public ActionResult Index()
        {
            var providers = db.Providers.Include(p => p.State);
            return View(providers.ToList());
        }

        // GET: Providers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Provider provider = db.Providers.Find(id);
            if (provider == null)
            {
                return HttpNotFound();
            }
            return View(provider);
        }

        // GET: Providers/Create
        public ActionResult Create()
        {
            ViewBag.StateID = new SelectList(db.States, "ID", "Name");
            ViewBag.ListOfInsuranceCompanys = db.ListOfInsuranceCompanys.Where(m => m.Hide == false).ToList();
            ViewBag.ListOfServices = db.ListOfServices.Where(m => m.Hide == false).ToList();
            ViewBag.ListOfTypes = db.ListOfTypes.Where(m => m.Hide == false).ToList();
            ViewBag.DiscountCashPay = new List<SelectListItem> {
                                new SelectListItem { Text = "--- Select ---", Value = "" },
                                new SelectListItem { Text = "Unknown", Value = "" },
                                new SelectListItem { Text = "Yes", Value = true.ToString() },
                                new SelectListItem { Text = "No", Value = false.ToString() }};

            ViewBag.SlidingScale = ViewBag.DiscountCashPay;
            return View();
        }

        // POST: Providers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Provider provider)
        {

            if (ModelState.IsValid)
            {

                Provider tempprovider = new Provider();
                tempprovider.Services = new List<Service>();
                tempprovider.Insurances = new List<Insurance>();
                

                tempprovider.Name = provider.Name;
                tempprovider.Phone = provider.Phone;

                tempprovider.SlidingScale = provider.SlidingScale;
                tempprovider.DiscountCashPay = provider.DiscountCashPay;
                tempprovider.StateID = provider.StateID;
                tempprovider.Street = provider.Street;
                tempprovider.Zip = provider.Zip;
                tempprovider.Website = provider.Website;
                tempprovider.City = provider.City;
                tempprovider.Email = provider.Email;

                foreach (var service in provider.Services)
                {
                    foreach (var selectedservice in service.SelectedService)
                    {
                        Service newservice = new Service();

                        //newservice.ProviderID = tempprovider.ID;
                        newservice.ServiceID = selectedservice;

                        tempprovider.Services.Add(newservice);

                    }
                }

                foreach (var insurances in provider.Insurances)
                {
                    foreach (var selectedinsurances in insurances.SelectedInsurance)
                    {
                        Insurance newinsurances = new Insurance();

                        newinsurances.InsureanceID = selectedinsurances;
                        newinsurances.ProviderID = tempprovider.ID;
                        

                        tempprovider.Insurances.Add(newinsurances);

                    }
                }

                foreach (var type in provider.Types)
                {
                    foreach (var selectedtype in type.SelectedType)
                    {
                        Type newtype = new Type();

                        newtype.TypeID = selectedtype;
                        newtype.ProviderID = tempprovider.ID;
                        
                        tempprovider.Types.Add(newtype);

                    }
                }



                db.Providers.Add(tempprovider);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StateID = new SelectList(db.States, "ID", "Name", provider.StateID);
            return View(provider);
        }

        // GET: Providers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Provider provider = db.Providers.Find(id);
            if (provider == null)
            {
                return HttpNotFound();
            }
            ViewBag.StateID = new SelectList(db.States, "ID", "Name", provider.StateID);
            return View(provider);
        }

        // POST: Providers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Street,City,StateID,Zip,Email,Phone,Website,SlidingScale,DiscountCashPay,Hide")] Provider provider)
        {
            if (ModelState.IsValid)
            {
                db.Entry(provider).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StateID = new SelectList(db.States, "ID", "Name", provider.StateID);
            return View(provider);
        }

        // GET: Providers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Provider provider = db.Providers.Find(id);
            if (provider == null)
            {
                return HttpNotFound();
            }
            return View(provider);
        }

        // POST: Providers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Provider provider = db.Providers.Find(id);
            db.Providers.Remove(provider);
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
