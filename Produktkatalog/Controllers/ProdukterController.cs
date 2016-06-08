using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Produktkatalog.DataAccessLayer;
using Produktkatalog.Models;

namespace Produktkatalog.Controllers
{
    public class ProdukterController : Controller
    {
        private ProduktContext db = new ProduktContext();

        // GET: Produkter
        public ActionResult Index(string sortOrder)
        {
            var produkter = db.Produkter.ToList();
            ViewBag.NamnSortParm = String.IsNullOrEmpty(sortOrder) ? "namn_descending" : "";
            ViewBag.PrisSortParm = sortOrder == "Pris" ? "pris_descending" : "Pris";

            switch (sortOrder)
            {
                case "namn_descending":
                    produkter = produkter.OrderByDescending(p => p.Namn).ToList();
                    break;
                case "pris_descending":
                    produkter = produkter.OrderByDescending(p => p.Pris).ToList();
                    break;
                case "Pris":
                    produkter = produkter.OrderBy(p => p.Pris).ToList();
                    break;
                default:
                    produkter = produkter.OrderBy(p => p.Namn).ToList();
                    break;
            }

            return View(produkter);
        }

        // GET: Produkter/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produkt produkt = db.Produkter.Find(id);
            if (produkt == null)
            {
                return HttpNotFound();
            }
            return View(produkt);
        }

        // GET: Produkter/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Produkter/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Namn,Pris,Beskrivning")] Produkt produkt)
        {
            if (ModelState.IsValid)
            {
                db.Produkter.Add(produkt);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(produkt);
        }

        // GET: Produkter/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produkt produkt = db.Produkter.Find(id);
            if (produkt == null)
            {
                return HttpNotFound();
            }
            return View(produkt);
        }

        // POST: Produkter/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Namn,Pris,Beskrivning")] Produkt produkt)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produkt).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(produkt);
        }

        // GET: Produkter/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produkt produkt = db.Produkter.Find(id);
            if (produkt == null)
            {
                return HttpNotFound();
            }
            return View(produkt);
        }

        // POST: Produkter/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produkt produkt = db.Produkter.Find(id);
            db.Produkter.Remove(produkt);
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
