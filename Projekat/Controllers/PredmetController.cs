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

                context.Add<PremetPoSmeru>(new PremetPoSmeru
                {
                    predmetId = viewModel.predmet.predmetId,
                    smerId = viewModel.smer.smerId
                });
                context.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }






            return RedirectToAction("DodajPredmet", "Predmet");
        }



    }
}