using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projekat.Models;
using Projekat.ViewModels;

namespace Projekat.Controllers
{
    public class PredmetController : Controller
    {
        private IMaterijalContext context;
        // GET: Predmet
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult DodajPredmet()
        {

            context = new MaterijalContext();
            DodajPremetViewModel viewModel = new DodajPremetViewModel();
            viewModel.smerovi = context.smerovi.ToList();



            return View("DodajPredmet", viewModel);
        }

        [HttpPost]
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
        public ActionResult Edit(DodajPremetViewModel viewModel, int trenutiSmer,List<int>smeroviId)//Dodaj predmet viewmodel vise smerova
        {

            if (viewModel.predmet != null)
            {
                try
                {
                    PredmetModel predmetPromenjenji = context.predmeti.FirstOrDefault(m => m.predmetId == viewModel.predmet.predmetId);
                    if (predmetPromenjenji == null)
                    {
                        return new HttpNotFoundResult("Nije nadjen ni jedan predmet u bazi sa datim ID-om");
                    }
                    predmetPromenjenji.predmetNaziv = viewModel.predmet.predmetNaziv;
                    predmetPromenjenji.predmetOpis = viewModel.predmet.predmetOpis;

                    foreach (int smerID in smeroviId)
                    {
                        context.Add<PremetPoSmeru>(new PremetPoSmeru
                        {

                            predmetId = viewModel.predmet.predmetId,
                            smerId = smerID

                        });
                    }

                    context.SaveChanges();


                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                return new HttpNotFoundResult("losi parametri");
            }

            return RedirectToAction("PredmetiPrikaz", new { id = trenutiSmer });

        }

        [HttpGet]
        public ActionResult VratiSmerove(int id)
        {
            List<PremetPoSmeru> predmetPoSmerovima = context.predmetiPoSmeru.Where(m => m.predmetId == id).ToList();

            List<SmerModel> smeroviModel = new List<SmerModel>();

            foreach(PremetPoSmeru predmetPoSmeru in predmetPoSmerovima)
            {
                SmerModel smer = context.smerovi.Where(m => m.smerId == predmetPoSmeru.smerId).Single();
                smeroviModel.Add(smer);      
            }

            return Json(smeroviModel,JsonRequestBehavior.AllowGet);
            
        }


        //GET: /Predmet/PredmetiPrikaz
        [HttpGet]
        public ActionResult PredmetiPrikaz(int id)
        {
            context = new MaterijalContext();
            List<PremetPoSmeru> poSmeru = context.predmetiPoSmeru.Where(m => m.smerId == id).ToList();
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
                smerovi = smerovi
                
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