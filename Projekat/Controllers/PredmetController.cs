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
        

        //GET: /Predmet/PredmetiPrikaz
        [HttpGet]
        public ActionResult PredmetiPrikaz (int id)
        {
            context = new MaterijalContext();   
            List<PremetPoSmeru> poSmeru = context.predmetiPoSmeru.Where(m => m.smerId == id).ToList();
            List<PredmetModel> model = new List<PredmetModel>();
            List<PredmetModel> tempPredmet = context.predmeti.ToList();

            foreach (PremetPoSmeru ps in poSmeru)
            {
                model.Add(tempPredmet.Where(m => m.predmetId == ps.predmetId).Single());
            }

           

            PredmetPoSmeruViewModel predmetiPoSmeru = new PredmetPoSmeruViewModel
            {
                predmeti = model
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