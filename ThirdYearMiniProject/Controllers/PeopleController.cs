﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ThirdYearMiniProject.Models;

namespace ThirdYearMiniProject.Controllers
{
    public class PeopleController : Controller
    {
        private MiniProjectDbContext db = new MiniProjectDbContext();

        // GET: People
        public ActionResult Index()
        {
            var persons = db.Persons.Include(p => p.Location).Include(p => p.Login);
       
            
            foreach (var item in persons)
            {
                if (Convert.ToInt32(item.Occupid)==1)
                {
                    item.Occupid = "Regional Distributor";
                }
                else if(Convert.ToInt32(item.Occupid) == 2)
                {
                    item.Occupid = "Sales Representative";
                }
                else if(Convert.ToInt32(item.Occupid) == 3)
                {
                    item.Occupid = "Product Specialist";
                }
                else
                {
                    item.Occupid = "Not-Occupid";
                }
          
            }
            
            return View(persons.ToList());
        }

        // GET: People/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.Persons.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // GET: People/Create
        public ActionResult Create()
        {
            Dictionary<int, string> position = new Dictionary<int, string>();
            position.Add(0, "not-occupid");
            position.Add(1, "RD");
            position.Add(2, "SR");
            position.Add(3, "MPS");
            ViewBag.postionList = position;
            ViewBag.LocationId = new SelectList(db.Locations, "LocationId", "LocationName");
            ViewBag.PersonId = new SelectList(db.Logins, "PersonId", "Nic");
            return View();
        }

        // POST: People/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonId,LocationId,PersonName,PersonAddress,Occupid,Nic,Password")] Person person)
        {
            if (ModelState.IsValid)
            {
                db.Persons.Add(person);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LocationId = new SelectList(db.Locations, "LocationId", "LocationName", person.LocationId);
            ViewBag.PersonId = new SelectList(db.Logins, "PersonId", "Nic", person.PersonId);
            return View(person);
        }

        // GET: People/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.Persons.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            Dictionary<int, string> position = new Dictionary<int, string>();
            position.Add(0, "not-occupid");
            position.Add(1, "RD");
            position.Add(2, "SR");
            position.Add(3, "MPS");
            ViewBag.postionList = position;
            ViewBag.slectedPosition = person.Occupid.ToString();
            ViewBag.LocationId = new SelectList(db.Locations, "LocationId", "LocationName", person.LocationId);
            ViewBag.PersonId = new SelectList(db.Logins, "PersonId", "Nic", person.PersonId);
            return View(person);
        }

        // POST: People/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonId,LocationId,PersonName,PersonAddress,Occupid,Nic,Password")] Person person)
        {
            if (ModelState.IsValid)
            {
                db.Entry(person).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LocationId = new SelectList(db.Locations, "LocationId", "LocationName", person.LocationId);
            ViewBag.PersonId = new SelectList(db.Logins, "PersonId", "Nic", person.PersonId);
            return View(person);
        }

        // GET: People/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.Persons.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Person person = db.Persons.Find(id);
            db.Persons.Remove(person);
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
