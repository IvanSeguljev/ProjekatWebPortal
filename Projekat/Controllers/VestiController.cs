using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projekat.Models;
using Projekat.ViewModels;
using System.IO;
using System.Xml.Linq;
using System.Xml;

namespace Projekat.Controllers
{
    public class VestiController : Controller
    {

        private VestModel VratiGlavnuVest()
        {
            VestiContext context = new VestiContext();
            XDocument xmlFajl = XDocument.Load(Server.MapPath("~/MojaKonfiguracija.xml"));

            
                int ID;
                DateTime datum;
                var Konfiguracija = xmlFajl.Descendants("glavnaVest").FirstOrDefault();
                try                   
                {
                    ID = (int)Konfiguracija.Attribute("idGlavne");
                    datum = (DateTime)Konfiguracija.Attribute("datumIsteka");
                }
                catch
                {
                    return context.Vesti.OrderByDescending(m => m.DatumPostavljanja).FirstOrDefault();
                }
                if ( DateTime.Today.Date<=datum.Date)
                {
                    VestModel Vest = context.Vesti.FirstOrDefault(m => m.Id == ID);
                    if(Vest != null)
                        return Vest;
                    else
                        return context.Vesti.OrderByDescending(m => m.DatumPostavljanja).FirstOrDefault();
                }
                else
                {
                    return context.Vesti.OrderByDescending(m => m.DatumPostavljanja).FirstOrDefault();
                }
          }
        

        private void SnimiGlavnuVest(int ID,DateTime DatDo)
        {
            XDocument xmlFajl = XDocument.Load(Server.MapPath("~/MojaKonfiguracija.xml"));
            var Konfiguracija = xmlFajl.Descendants("glavnaVest").FirstOrDefault();
            Konfiguracija.Attribute("datumIsteka").SetValue(DatDo.ToShortDateString());
            Konfiguracija.Attribute("idGlavne").SetValue(ID.ToString());
            xmlFajl.Save(Server.MapPath("~/MojaKonfiguracija.xml"));
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
        [HttpGet]
        public ActionResult PretragaPoNaslovu(string kveri)
        {
            VestiContext context = new VestiContext();
            List<VestModel> RezultatPretrage = context.Vesti.Where(x => x.Naslov.ToLower().Contains(kveri.ToLower())).Take(10).ToList();
            return Json(RezultatPretrage, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult BrisanjeVesti(int Id,bool glavna = false)
        {
            VestiContext context = new VestiContext();
            VestModel ZaBrisanje = context.Vesti.FirstOrDefault(x => x.Id == Id);
            if(glavna)
            {
                XDocument xmlFajl = XDocument.Load(Server.MapPath("~/MojaKonfiguracija.xml"));
                var Konfiguracija = xmlFajl.Descendants("glavnaVest").FirstOrDefault();
                Konfiguracija.Attribute("datumIsteka").SetValue("");
                Konfiguracija.Attribute("idGlavne").SetValue("");
                xmlFajl.Save(Server.MapPath("~/MojaKonfiguracija.xml"));
            }
            if(ZaBrisanje != null)
            {
                string Thumbnail = Server.MapPath(ZaBrisanje.Thumbnail);
                if (System.IO.File.Exists(Thumbnail))
                {
                   System.IO.File.Delete(Thumbnail);
                }
                TeloVestiModel telo = context.TelaVesti.FirstOrDefault(x => x.VestId == Id);
                if (telo != null)
                    context.TelaVesti.Remove(telo);
                context.Vesti.Remove(ZaBrisanje);
               
               
               context.SaveChanges();
            }
            return RedirectToAction("PrikazVesti");
        }
    }
}