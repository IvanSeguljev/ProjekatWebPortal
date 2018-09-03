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
        private VestModel VratiGlavnuVest()
        {
            VestiContext context = new VestiContext();            
            string Path = Server.MapPath("~/Content/Konfiguracija/GlavnaVest.txt");
            if (!System.IO.File.Exists(Path))
            {
                return context.Vesti.OrderByDescending(m=>m.DatumPostavljanja).FirstOrDefault();
            }
            else
            {
                int ID;
                DateTime datum;
                TextReader tr = new StreamReader(Path);
                string config = tr.ReadLine();
                tr.Close();
                
                try                   
                {
                    ID = int.Parse(config.Remove(config.IndexOf('|')));
                    datum = Convert.ToDateTime(config.Remove(0, config.IndexOf('|') + 1));
                }
                catch(Exception)
                {
                    return context.Vesti.OrderByDescending(m => m.DatumPostavljanja).FirstOrDefault();
                }
                if ( DateTime.Today.Date<=datum.Date)
                {
                    VestModel Vest = context.Vesti.FirstOrDefault(m => m.Id == ID);
                    return Vest;
                }
                else
                {
                    return context.Vesti.OrderByDescending(m => m.DatumPostavljanja).FirstOrDefault();
                }
            }
        }

        private void SnimiGlavnuVest(int ID,DateTime DatDo)
        {
            string Path = Server.MapPath("~/Content/Konfiguracija/GlavnaVest.txt");
            if(!System.IO.File.Exists(Path))
            {
                System.IO.File.Create(Path).Close();
                
            }
            TextWriter tw = new StreamWriter(Path);
            string Config = ID + "|" + DatDo.ToShortDateString();
            tw.Write(Config);
            tw.Close();
        }

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
            TeloVestiModel Telo = new TeloVestiModel();
            Vest.Naslov = vm.Naslov;
            
            Vest.KratakOpis = vm.KratakOpis;
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
            Telo.TeloVesti = vm.Vest;
            Telo.VestId = Vest.Id;
            context.TelaVesti.Add(Telo);
            context.SaveChanges();
            return RedirectToAction("PrikazVesti", "Vesti");
        }
        [HttpGet]
        public ActionResult PrikazVesti()
        {
            VestModel GlavnaVest = VratiGlavnuVest();
            return View(GlavnaVest);
        }
        [HttpGet]
        public ActionResult PosaljiVesti(int pageindex, int pagesize,int idGlavne)
        {
            VestiContext context = new VestiContext();
            List<VestModel> vesti = context.Vesti.OrderByDescending(m=>m.DatumPostavljanja).Where(m=>m.Id != idGlavne).Skip(pageindex * pagesize).Take(pagesize).ToList();
            return Json(vesti.ToList(), JsonRequestBehavior.AllowGet);

        }
    }
}