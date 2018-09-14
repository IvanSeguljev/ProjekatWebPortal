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
    /// <summary>
    /// Kontroler koji upravlja vestima
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class VestiController : Controller
    {

        /// <summary>
        /// Vraca glavnu vest ako je ima u konfiguraciji. Ako ne, vraca najnoviju vest.
        /// </summary>
        /// <returns><see cref="VestModel"/></returns>
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


        /// <summary>
        /// Snima Id vesti i datum do kada ce ova vest biti glavna u konfiguraciji
        /// </summary>
        /// <param name="ID">Id vesti koja treba da postane glavna.</param>
        /// <param name="DatDo">Datum do kada ce se vest gledati kao glavna vest.</param>
        private void SnimiGlavnuVest(int ID,DateTime DatDo)
        {
            XDocument xmlFajl = XDocument.Load(Server.MapPath("~/MojaKonfiguracija.xml"));
            var Konfiguracija = xmlFajl.Descendants("glavnaVest").FirstOrDefault();
            Konfiguracija.Attribute("datumIsteka").SetValue(DatDo.ToShortDateString());
            Konfiguracija.Attribute("idGlavne").SetValue(ID.ToString());
            xmlFajl.Save(Server.MapPath("~/MojaKonfiguracija.xml"));
        }

        /// <summary>
        /// Vraca view NovaVest, na kome je forma za unos nove vesti.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult NovaVest()
        {
            DodajVestViewModel vm = new DodajVestViewModel();
            return View(vm);
        }

        /// <summary>
        /// Snima vest u bazu. Thumbnail vesti se drzi u folderu content/Uploads/Thumbnails
        /// </summary>
        /// <param name="Fajl">Odabrani thumbnail.</param>
        /// <param name="vm">View model.</param>
        /// <returns></returns>
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult SnimiVest(HttpPostedFileBase Fajl, DodajVestViewModel vm)
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
                string path = Path.Combine(Server.MapPath("~/Content/uploads/Thumbnails/"), fileId + ekstenzija);
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

        /// <summary>
        /// Vraca prikaz vesti. kao model joj prosledjuje glavnu vest.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult PrikazVesti()
        {
            
            VestModel GlavnaVest = VratiGlavnuVest();
           
                return View(GlavnaVest);
          
        }

        /// <summary>
        /// Akcija koja odgovara na ajax request i salje odgovarajuci broj vesti. Pomocu ove akcije se realizuje endless scroll na pregledu vesti
        /// </summary>
        /// <param name="pageindex">Index(broj) "stranice na kojoj je korisnik"</param>
        /// <param name="pagesize">Velicina "stranice" koja se prikazuje korisniku</param>
        /// <param name="idGlavne">ID glavne vesti, da ne bi doslo do ponovnog prikaza iste</param>
        /// <returns>Json sa odgovarajucim brojem vesti</returns>
        [HttpGet]
        public ActionResult PosaljiVesti(int pageindex, int pagesize, int idGlavne)
        {
            VestiContext context = new VestiContext();
            List<VestModel> vesti = context.Vesti.OrderByDescending(m => m.DatumPostavljanja).Where(m => m.Id != idGlavne).Skip(pageindex * pagesize).Take(pagesize).ToList();
            return Json(vesti.ToList(), JsonRequestBehavior.AllowGet);

        }

        /// <summary>
        /// Akcija koja vrsi pretragu po naslovu vesti
        /// </summary>
        /// <param name="kveri">Deo naslova ili naslov koji je korisnik uneo</param>
        /// <returns>Json sa vestima ciji naslovi podlezu pretrazi</returns>
        [HttpGet]
        public ActionResult PretragaPoNaslovu(string kveri)
        {
            VestiContext context = new VestiContext();
            List<VestModel> RezultatPretrage = context.Vesti.Where(x => x.Naslov.ToLower().Contains(kveri.ToLower())).Take(10).ToList();
            return Json(RezultatPretrage, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Brise vest.
        /// </summary>
        /// <param name="Id">Id vesti za brisanje.</param>
        /// <param name="glavna">Da li je vest glavna vest, ako jeste, brise se i iz konfiguracije.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult BrisanjeVesti(int Id, bool glavna = false)
        {
            VestiContext context = new VestiContext();
            VestModel ZaBrisanje = context.Vesti.FirstOrDefault(x => x.Id == Id);
            if (glavna)
            {
                XDocument xmlFajl = XDocument.Load(Server.MapPath("~/MojaKonfiguracija.xml"));
                var Konfiguracija = xmlFajl.Descendants("glavnaVest").FirstOrDefault();
                Konfiguracija.Attribute("datumIsteka").SetValue("");
                Konfiguracija.Attribute("idGlavne").SetValue("");
                xmlFajl.Save(Server.MapPath("~/MojaKonfiguracija.xml"));
            }
            if (ZaBrisanje != null)
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