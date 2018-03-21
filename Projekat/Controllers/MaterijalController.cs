﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projekat.Models;
using Projekat.ViewModels;
using System.Data.Entity;
using System.Web.Helpers;


namespace Projekat.Controllers
{
    [Authorize(Roles = "Učenik, Profesor, Urednik, Administrator")]
    public class MaterijalController : Controller
    {
        private IMaterijalContext context;

        public MaterijalController()
        {
            context = new MaterijalContext();
        }

        public MaterijalController(IMaterijalContext Context)
        {
            context = Context;
        }


        // GET: Materijal
        public ActionResult Index()
        {
            return View();
        }

        //TESTIRATI KAD MLADJA PROSLEDI EKSTENZIJU I ID TIPA!!!
        //VIDETI KAKO CE DA SE HENDLUJE SAMA NAMENA MATERIJALA I POJAVLJIVANJE NA STRANANMA
        //
        [HttpGet]
        [Authorize(Roles = "Učenik, Profesor, Urednik, Administrator")]
        public ActionResult MaterijaliPrikaz(string sort, List<string> formati, List<int> tipovi, int number = 0, int predmetId = 0)
        {
            List<OsiromaseniMaterijali> materijali;

            MaterijaliNaprednaPretragaViewModel vm;


            materijali = context.naprednaPretraga(formati, tipovi, predmetId).ToList();

            if (sort == "opadajuce")
            {
                materijali = context.naprednaPretraga(formati, tipovi, predmetId).ToList();
                materijali.Reverse();

                vm = new MaterijaliNaprednaPretragaViewModel
                {
                    osiromaseniMaterijali = materijali,
                    naprednaPretragaSelektovani = "",
                    tipoviMaterijala = context.tipMaterijala.ToList()


                };

                return PartialView("_Kartice", vm);

            }
            else if (sort == "rastuce")
            {
                materijali = context.naprednaPretraga(formati, tipovi, predmetId).ToList();

                vm = new MaterijaliNaprednaPretragaViewModel
                {
                    osiromaseniMaterijali = materijali,
                    naprednaPretragaSelektovani = "",
                    tipoviMaterijala = context.tipMaterijala.ToList()


                };
                return PartialView("_Kartice", vm);
            }


            vm = new MaterijaliNaprednaPretragaViewModel
            {
                osiromaseniMaterijali = materijali,
                naprednaPretragaSelektovani = "",
                tipoviMaterijala = context.tipMaterijala.ToList()
            };


            return View("MaterijaliPrikaz", vm);
        }
        //kod ove akcije treba dodati punjenje tabele namena materijala
        [HttpGet]
        [Authorize(Roles = "Profesor, Urednik, Administrator")]
        public ActionResult UploadMaterijal()
        {
            context = new MaterijalContext();

            MaterijalUploadViewModel viewModel = new MaterijalUploadViewModel
            {
                Predmeti = context.predmeti.ToList(),
                tipoviMaterijala = context.tipMaterijala.ToList(),
                nameneMaterijala = context.nameneMaterijala.ToList()
            };


            return View("UploadMaterijal", viewModel);
        }


        //kod ove akcije treba dodati punjenje tabele namena materijala
        [HttpPost]
        [Authorize(Roles = "Profesor, Urednik, Administrator")]
        public ActionResult UploadMaterijal(MaterijalModel materijal, HttpPostedFileBase file, MaterijalModel model/*, string hiddenPredmet*/)
        {

            // PredmetModel predmet = new PredmetModel();

            context = new MaterijalContext();

            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string nazivFajla = Path.GetFileName(file.FileName);

                    materijal.fileMimeType = file.ContentType;
                    materijal.materijalFile = new byte[file.ContentLength];
                    file.InputStream.Read(materijal.materijalFile, 0, file.ContentLength);
                    materijal.materijalNaziv = nazivFajla;
                    materijal.materijalEkstenzija = Path.GetExtension(nazivFajla);
                    model.materijalOpis = materijal.materijalOpis;
                    model.materijalNaslov = materijal.materijalNaslov;
                    context.Add<MaterijalModel>(materijal);
                    context.SaveChanges();
                }

                ViewBag.Message = "Uspešno ste postavili materijal!";

                return RedirectToAction("UploadMaterijal", "Materijal");
                // return View("UploadMaterijal", ViewModel);
            }
            else
            {
                ViewBag.Message = "Postavljanje materijala nije uspelo!";
                return RedirectToAction("UploadMaterijal", "Materijal");

                // return View("UploadMaterijal", ViewModel);
            }
        }

        [Authorize(Roles = "Učenik, Profesor, Urednik, Administrator")]
        public FileContentResult DownloadMaterijal(int id)
        {
            MaterijalModel materijal = context.pronadjiMaterijalPoId(id);
            if (materijal != null)
            {
                return File(materijal.materijalFile, materijal.fileMimeType, materijal.materijalNaziv);
            }
            else
            {
                return null;
            }
        }
        [Authorize(Roles = "Urednik, Administrator")]
        public ActionResult Delete(int id)
        {
            MaterijalModel materijal = context.pronadjiMaterijalPoId(id);
            if (materijal == null)
            {
                return HttpNotFound();
            }
            return View("Delete", materijal);
        }

        [HttpPost]
        //[ActionName("Delete")]
        //[Route("UploadMaterijal/DeleteConfirmed/{id:int}")]
        [Authorize(Roles = "Urednik, Administrator")]
        public ActionResult DeleteConfirmed(int id)
        {
            MaterijalModel materijal;
            try
            {
                materijal = context.pronadjiMaterijalPoId(id);
                context.Delete<MaterijalModel>(materijal);
                context.SaveChanges();
            }
            catch (Exception)
            {

            }

            return RedirectToAction("MaterijaliPrikaz");
        }



        //public ActionResult SortirajPoTipuMaterijala(int id)
        //{
        //    context = new MaterijalContext();
        //    List<MaterijalModel> model = context.materijali.Where(m => m.tipMaterijalId == id).ToList();


        //    return View("MaterijaliPrikaz", model);

        //}
        [Authorize(Roles = "Učenik, Profesor, Urednik, Administrator")]
        public void FiltrirajPoFormatuMaterijala(string ekstenzija, int id, ref List<MaterijalModel> materijali) //Refaktorisati naziv akcije kasnije jer se ffiltrira i tip materijala ne samo format
        {


            materijali = context.materijali.Where(m => m.materijalEkstenzija == ekstenzija && m.tipMaterijalId == id).ToList();//scuffed



        }

        // IF SCUFFED IN MATERIJALCONTEXT THIS.UNCOMMENT

        //public List<MaterijalModel> naprednaPretraga(List<string> ekstenzije, List<int> tipoviMaterijalaIds)
        //{
        //    List<MaterijalModel> materijali = new List<MaterijalModel>();
        //    foreach(MaterijalModel m in context.materijali)
        //    {
        //        if (ekstenzije.Contains(m.materijalEkstenzija) && tipoviMaterijalaIds.Contains(m.tipMaterijalId))
        //            materijali.Add(m);

        //    }
        //    return materijali;
        //}





    }
}