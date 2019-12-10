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