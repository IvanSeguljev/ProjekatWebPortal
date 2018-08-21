using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projekat.Models;
using Projekat.ViewModels;

namespace Projekat.Controllers
{
    public class VestiController : Controller
    {
        [HttpGet]
        public ActionResult NovaVest()
        {
            DodajVestViewModel vm = new DodajVestViewModel();
            return View(vm);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult SnimiVest(HttpPostedFileBase Fajl,DodajVestViewModel vm)
        {
            VestiContext context = new VestiContext();
            VestModel Vest = new VestModel();
            Vest.Naslov = vm.Naslov;
            Vest.Vest = vm.Vest;

            if (Fajl != null)
            {
                Vest.Thumbnail = new byte[Fajl.ContentLength];
                Fajl.InputStream.Read(Vest.Thumbnail, 0, Fajl.ContentLength);
            }
            context.Vesti.Add(Vest);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult PrikazVesti()
        {
            VestiContext Context = new VestiContext();
            List<VestModel> lista = Context.Vesti.Take(12).ToList();
            return View(lista);
        }
    }
}