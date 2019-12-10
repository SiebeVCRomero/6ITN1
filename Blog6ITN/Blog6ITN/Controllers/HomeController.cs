using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Blog6ITN.Models;

namespace Blog6ITN.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        BiibContext db = new BiibContext();
        public HomeController()
        {
            if (db.Users.ToList().Count == 0)
            {
                User siebe = new User { Voornaam = "Siebe", Familienaam = "Van Campenhout", Email = "Siebe.VanCampenhout@student.romerocollege.be", Rol = "Admin" };
                User jens = new User { Voornaam = "Jens", Familienaam = "Van den Eynde", Email = "Jens.VandenEynde@student.romerocollege.be", Rol = "Admin" };
                User robin = new User { Voornaam = "Robin", Familienaam = "Vermeir", Email = "Robin.Vermeir@student.romerocollege.be", Rol = "Admin" };
                User kerem = new User { Voornaam = "Kerem Emre", Familienaam = "Yilmaz", Email = "KeremEmre.Yilmaz@student.romerocollege.be", Rol = "Admin" };
                User mnr = new User { Voornaam = "Evert", Familienaam = "De Boeck", Email = "evert.deboeck@romerocollege.be", Rol = "Admin" }; ;
                db.Users.Add(siebe);
                db.Users.Add(jens);
                db.Users.Add(robin);
                db.Users.Add(kerem);
                db.Users.Add(mnr);
                db.SaveChanges();
            }
        }

        public ActionResult Welkom()
        {
            List<Nieuws> nieuws = db.Nieuws.ToList();
            ViewBag.Nieuws = nieuws;
            List<Gip> gips = db.Gips.ToList();
            ViewBag.Gips = gips;

            return View();
        }
    }
}