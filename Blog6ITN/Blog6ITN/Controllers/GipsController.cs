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
    public class GipsController : Controller
    {
        private BiibContext db = new BiibContext();

        // GET: Gips
        public ActionResult Overzicht()
        {
            ViewBag.Gips = db.Gips.ToList();
            return View();
        }

        // GET: Gips/Details/5
        public ActionResult Details(int? id = 0)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gip gip = db.Gips.Find(id);
            if (gip == null)
            {
                return HttpNotFound();
            }
            return View("Details", gip);
        }

        // GET: Gips/Create
        public ActionResult Toevoegen()
        {
            return View();
        }

        // POST: Gips/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Toevoegen([Bind(Include = "Id,Naam,Intro")] Gip gip)
        {
            if (ModelState.IsValid)
            {
                gip.LaatseAanpassing = DateTime.Now;
                gip.PersoonLaatsteAanpassing = User.Identity.Name;
                db.Gips.Add(gip);
                db.SaveChanges();
                return RedirectToAction("Overzicht");
            }

            return View(gip);
        }

        // GET: Gips/Edit/5
        public ActionResult Aanpassen(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gip gip = db.Gips.Find(id);
            if (gip == null)
            {
                return HttpNotFound();
            }
            return View(gip);
        }

        // POST: Gips/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Naam,Intro,LaatseAanpassing")] Gip gip)
        {
            if (ModelState.IsValid)
            {
                gip.LaatseAanpassing = DateTime.Now;
                gip.PersoonLaatsteAanpassing = User.Identity.Name;

                db.Entry(gip).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Overzicht");
            }
            return View(gip);
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
