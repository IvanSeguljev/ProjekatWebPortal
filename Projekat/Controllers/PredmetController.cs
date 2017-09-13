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


            
            return View("DodajPredmet",viewModel);
        }

        [HttpPost]
        public ActionResult Action(DodajPremetViewModel viewModel)
        {

            //samo dodaj u bazu podatke
            return View();
        }



    }
}