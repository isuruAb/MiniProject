using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ThirdYearMiniProject.Models;

namespace ThirdYearMiniProject.Controllers
{
    public class RdInvoicesController : Controller
    {
        private MiniProjectDbContext db = new MiniProjectDbContext();

        // GET: RdInvoices
        public ActionResult Index()
        {
            var rdInvoices = db.RdInvoices.Include(r => r.Rd);
            return View(rdInvoices.ToList());
        }

        // GET: RdInvoices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RdInvoice rdInvoice = db.RdInvoices.Find(id);
            if (rdInvoice == null)
            {
                return HttpNotFound();
            }
            return View(rdInvoice);
        }

        // GET: RdInvoices/Create
        public ActionResult Create()
        {
            var rdnames = (from t1 in db.Persons
                               join t2 in db.Rds
                               on t1.PersonId equals t2.PersonId
                               select new
                               {
                                   t1.PersonName,
                                   t2.RdId
                               }).ToList();
            Dictionary<int, string> dictNames = new Dictionary<int, string>();
            foreach (var item in rdnames)
            {
                dictNames.Add(item.RdId, item.PersonName);
            }
            ViewBag.RdDropDown = dictNames;
            ViewBag.RdId = new SelectList(db.Rds, "RdId", "RdId");
            return View();
        }

        // POST: RdInvoices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase upload, [Bind(Include = "RdInvoiceId,RdId,RdInvoiceDate")] RdInvoice rdInvoice)
        {
            if (ModelState.IsValid)
            {
                db.RdInvoices.Add(rdInvoice);
                db.SaveChanges();

                //Insert data into RdProduct Table from CSV file.
                RdProduct product = new RdProduct();
                var invoId = (from cust in db.RdInvoices
                              select cust).OrderByDescending(m => m.RdInvoiceId).First();
                StreamReader csvreader = new StreamReader(upload.InputStream);
                while (!csvreader.EndOfStream)
                {
                    var line = csvreader.ReadLine();
                    var values = line.Split(',');
                    product.RdInvoiceId = invoId.RdInvoiceId;
                    product.ModelName = values[0].ToString();
                    product.EmiNo = values[1].ToString();


                    db.RdProducts.Add(product);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }

            ViewBag.RdId = new SelectList(db.Rds, "RdId", "RdId", rdInvoice.RdId);


            return View(rdInvoice);
        }

        // GET: RdInvoices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RdInvoice rdInvoice = db.RdInvoices.Find(id);
            if (rdInvoice == null)
            {
                return HttpNotFound();
            }
            ViewBag.RdId = new SelectList(db.Rds, "RdId", "RdId", rdInvoice.RdId);
            return View(rdInvoice);
        }

        // POST: RdInvoices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RdInvoiceId,RdId,RdInvoiceDate")] RdInvoice rdInvoice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rdInvoice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RdId = new SelectList(db.Rds, "RdId", "RdId", rdInvoice.RdId);
            return View(rdInvoice);
        }

        // GET: RdInvoices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RdInvoice rdInvoice = db.RdInvoices.Find(id);
            if (rdInvoice == null)
            {
                return HttpNotFound();
            }
            return View(rdInvoice);
        }

        // POST: RdInvoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RdInvoice rdInvoice = db.RdInvoices.Find(id);
            db.RdInvoices.Remove(rdInvoice);
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
