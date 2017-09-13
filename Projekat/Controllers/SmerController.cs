using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projekat.Models;

namespace Projekat.Controllers
{
    public class SmerController : Controller
    {
        private IMaterijalContext context;

        public SmerController()
        {
            context = new MaterijalContext();
        }

        public SmerController(IMaterijalContext Context)
        {
            context = Context;
        }

        // GET: Smer
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SmeroviPrikaz()
        {
            List<SmerModel> smeroviInDb;
            smeroviInDb = context.smerovi.ToList();
            SmerModel smer = new SmerModel();
            smer.smerovi = smeroviInDb;

            return View("SmeroviPrikaz", smer);
        }

        [HttpGet]
        public ActionResult DodajSmer()
        {
            
            return View();
        }

        [HttpPost]

        public ActionResult DodajSmer(SmerModel smer)
        {
            if (ModelState.IsValid)
            {
                context.Add<SmerModel>(smer);
                context.SaveChanges();
            }
            return View();
        }
    }
}