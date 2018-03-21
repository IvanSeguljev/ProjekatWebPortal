using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projekat.Models;
using Projekat.ViewModels;

namespace Projekat.Controllers
{
    [Authorize(Roles = "Učenik, Profesor, Urednik, Administrator")]
    public class PredmetController : Controller
    {
        private IMaterijalContext context;
        // GET: Predmet
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        [Authorize(Roles = "Urednik, Administrator")]
        public ActionResult DodajPredmet()
        {

            context = new MaterijalContext();
            DodajPremetViewModel viewModel = new DodajPremetViewModel();
            viewModel.smerovi = context.smerovi.ToList();



            return View("DodajPredmet", viewModel);
        }

        [HttpPost]
        [Authorize(Roles = "Urednik, Administrator")]
        public ActionResult DodajPredmet(DodajPremetViewModel viewModel)
        {

            context = new MaterijalContext();



            try
            {
                context.Add<PredmetModel>(viewModel.predmet);

                foreach (int n in viewModel.smerIds)
                {

                    context.Add<PremetPoSmeru>(new PremetPoSmeru
                    {
                        predmetId = viewModel.predmet.predmetId,
                        smerId = n
                        //smerId = viewModel.smer.smerId
                    });
                }

                context.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }

            return RedirectToAction("DodajPredmet", "Predmet");
        }

        [HttpPost]
        [Authorize(Roles = "Urednik, Administrator")]
        public ActionResult Edit(int smerId, List<int> smeroviId, string predmetNaziv, string predmetOpis, int predmetId)
        {
            context = new MaterijalContext();

            PredmetModel predmetPromenjenji = context.predmeti.FirstOrDefault(m => m.predmetId == predmetId);
            List<int> smeroviIdIzBaze = context.predmetiPoSmeru.Where(m => m.predmetId == predmetId).Select(m => m.smerId).ToList();

            if (predmetPromenjenji == null)
            {
                return new HttpNotFoundResult("Nije nadjen ni jedan predmet u bazi sa datim ID-om");
            }
            predmetPromenjenji.predmetNaziv = predmetNaziv;
            predmetPromenjenji.predmetOpis = predmetOpis;

            foreach (int smerID in smeroviId)
            {
                if (!smeroviIdIzBaze.Contains(smerID))
                {
                    context.Add<PremetPoSmeru>(new PremetPoSmeru
                    {

                        predmetId = predmetId,
                        smerId = smerID

                    });
                }
            }
            foreach (int smerID in smeroviIdIzBaze)
            {
                if (!smeroviId.Contains(smerID))
                {

                    
                    List<PremetPoSmeru> lista = context.predmetiPoSmeru.Where(m => m.predmetId == predmetId).ToList();
                    foreach (PremetPoSmeru predmet in lista)
                    {
                        context.Delete(predmet);
                    }
                }
                    


            }

            foreach (int smerID in smeroviIdIzBaze)
            {
                if(!smeroviId.Contains(smerID) )
                {
                    List<PremetPoSmeru> lista = context.predmetiPoSmeru.Where(m => m.predmetId == predmetId).ToList();
                    foreach (PremetPoSmeru predmetPoSmeru in lista)
                    {
                        context.Delete(predmetPoSmeru);
                    }
                }

            }


            context.SaveChanges();





            return RedirectToAction("PredmetiPrikaz", new { id = smerId });

        }

        [HttpGet]
        [Authorize(Roles = "Učenik, Profesor, Urednik, Administrator")]
        public ActionResult VratiSmerove(int id)
        {
            context = new MaterijalContext();

            List<int> smeroviId= context.predmetiPoSmeru.Where(m => m.predmetId == id).Select(m => m.smerId).ToList();

            List<int> smeroviModel = new List<int>();

            foreach (int smerId in smeroviId)
            {
                int smer = context.smerovi.Where(m => m.smerId == smerId).Select(m=>m.smerId).Single();
                smeroviModel.Add(smer);
            }

            return Json(smeroviModel, JsonRequestBehavior.AllowGet);

        }


        //GET: /Predmet/PredmetiPrikaz
        [HttpGet]
        [Authorize(Roles = "Učenik, Profesor, Urednik, Administrator")]
        public ActionResult PredmetiPrikaz(int smerId)
        {
            context = new MaterijalContext();
            List<PremetPoSmeru> poSmeru = context.predmetiPoSmeru.Where(m => m.smerId == smerId).ToList();
            List<PredmetModel> model = new List<PredmetModel>();
            List<PredmetModel> tempPredmet = context.predmeti.ToList();
            List<SmerModel> smerovi = context.smerovi.ToList();

            foreach (PremetPoSmeru ps in poSmeru)
            {
                model.Add(tempPredmet.Where(m => m.predmetId == ps.predmetId).Single());
            }



            PredmetPoSmeruViewModel predmetiPoSmeru = new PredmetPoSmeruViewModel
            {
                predmeti = model,
                smerovi = smerovi,
                smerId = smerId

            };

            //try
            //{

            //}
            //catch (Exception)
            //{

            //    throw;
            //}

            return View("PredmetiPrikaz", predmetiPoSmeru);
        }



    }
}