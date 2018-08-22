using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projekat.Models;
using Projekat.ViewModels;
using System.IO;

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
                string ekstenzija = Fajl.FileName.Remove(0, Fajl.FileName.LastIndexOf('.'));
                string fileId = Guid.NewGuid().ToString().Replace("-", "");
                string path = Path.Combine(Server.MapPath("~/Content/uploads/Thumbnails/"), fileId+ekstenzija);
                string pathzaserver = "/Content/uploads/Thumbnails/" + fileId + ekstenzija;
                Fajl.SaveAs(path);
                Vest.Thumbnail = pathzaserver;
            }
            context.Vesti.Add(Vest);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult PrikazVesti()
        {
            return View();
        }
        public ActionResult PosaljiVesti(int pageindex, int pagesize)
        {
            VestiContext context = new VestiContext();
            List<VestModel> vesti = context.Vesti.OrderByDescending(m=>m.DatumPostavljanja).Skip(pageindex * pagesize).Take(pagesize).ToList();
            return Json(vesti.ToList(), JsonRequestBehavior.AllowGet);

        }
    }
}