using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Blog6ITN.Models;

namespace Blog6ITN.Controllers
{
    public class NieuwsController : Controller
    {
        private BiibContext db = new BiibContext();

        // GET: Nieuws
        public ActionResult Overzicht()
        {
            return View(db.Nieuws.ToList());
        }

        // GET: Nieuws/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nieuws nieuws = db.Nieuws.Find(id);
            if (nieuws == null)
            {
                return HttpNotFound();
            }
            return View(nieuws);
        }

        // GET: Nieuws/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Nieuws/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Titel,Inhoud,PublicatieDatum,Auteur")] Nieuws nieuws)
        {
            if (ModelState.IsValid)
            {
                db.Nieuws.Add(nieuws);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nieuws);
        }

        // GET: Nieuws/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nieuws nieuws = db.Nieuws.Find(id);
            if (nieuws == null)
            {
                return HttpNotFound();
            }
            return View(nieuws);
        }

        // POST: Nieuws/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Titel,Inhoud,PublicatieDatum,Auteur")] Nieuws nieuws)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nieuws).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nieuws);
        }

        // GET: Nieuws/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nieuws nieuws = db.Nieuws.Find(id);
            if (nieuws == null)
            {
                return HttpNotFound();
            }
            return View(nieuws);
        }

        // POST: Nieuws/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Nieuws nieuws = db.Nieuws.Find(id);
            db.Nieuws.Remove(nieuws);
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
