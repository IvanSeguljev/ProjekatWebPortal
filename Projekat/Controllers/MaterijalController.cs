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
    /// <summary>
    /// Materijal kontroler
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
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
        /// <summary>
        /// Index akcija
        /// </summary>
        /// <returns>Index view</returns>
        public ActionResult Index()
        {
            return View();
        }

        //TESTIRATI KAD MLADJA PROSLEDI EKSTENZIJU I ID TIPA!!!
        //VIDETI KAKO CE DA SE HENDLUJE SAMA NAMENA MATERIJALA I POJAVLJIVANJE NA STRANANMA
        //

        /// <summary>
        /// Prikaz materijala sa sortiranjem
        /// </summary>
        /// <param name="sort">String po kome se sortiraju materijali.</param>
        /// <param name="formati">Lista formata za prikaz.</param>
        /// <param name="tipovi">Lista tipova materijala za prikaz.</param>
        /// <param name="number">The number.</param>
        /// <param name="id">Id predmeta za koji su materijali, ako je id = null, predpostavlja se da je dati materijal za profesore</param>
        /// <returns>Parcijalni pregled karticw</returns>
        [HttpGet]

        public ActionResult MaterijaliPrikaz(string sort, List<string> formati, List<int> tipovi, int number = 0, int? id = null)
        {
            List<OsiromaseniMaterijali> materijali;

            MaterijaliNaprednaPretragaViewModel vm;
            int namenaID = 1;
            if (id == null)
            {
                namenaID = 2;
            }

            materijali = context.naprednaPretraga(formati, tipovi, id, namenaID).ToList();

            if (sort == "opadajuce")
            {
                materijali = context.naprednaPretraga(formati, tipovi, id, namenaID).ToList();
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
                materijali = context.naprednaPretraga(formati, tipovi, id, namenaID).ToList();

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
        /// <summary>
        /// Vraca view na kome je forma za dodavanje predmeta
        /// </summary>
        /// <param name="smerId">Id smera za koji je predmet koji se dodaje.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult UploadMaterijal(int? smerId)
        {
            context = new MaterijalContext();

            MaterijalUploadViewModel viewModel = new MaterijalUploadViewModel
            {
                Predmeti = context.predmeti.ToList(),
                tipoviMaterijala = context.tipMaterijala.ToList(),
                nameneMaterijala = context.nameneMaterijala.ToList(),
                Smerovi = context.smerovi.ToList()
            };

            if (smerId == null)
            {
                smerId = viewModel.Smerovi.ToList()[0].smerId;

                var predmetiposmeru = context.predmetiPoSmeru.Where(x => x.smerId == smerId).Select(c => c.predmetId).ToList();
                viewModel.PredmetPoSmeru = (viewModel.Predmeti.Where(x => predmetiposmeru.Contains(x.predmetId)));

                return View("UploadMaterijal", viewModel);
            }

            else
            {
                var predmetiposmeru = context.predmetiPoSmeru.Where(x => x.smerId == smerId).Select(c => c.predmetId).ToList();

                viewModel.PredmetPoSmeru = (viewModel.Predmeti.Where(x => predmetiposmeru.Contains(x.predmetId)));

                return PartialView("_PredmetiNaSmeru", viewModel);
            }
        }


        //kod ove akcije treba dodati punjenje tabele namena materijala
        /// <summary>
        /// Dodaje materijal u bazu
        /// </summary>
        /// <param name="materijal">Materijal model.</param>
        /// <param name="file">Uploadovani fajl.</param>
        /// <param name="predmet">Predmet za koji je materijal.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UploadMaterijal(MaterijalModel materijal, HttpPostedFileBase file, PredmetPoSmeru predmet/*, string hiddenPredmet*/)
        {

            // PredmetModel predmet = new PredmetModel();
            materijal.predmetId = predmet.predmetId;
            context = new MaterijalContext();
            if (materijal.namenaMaterijalaId == 2)
            {
                materijal.predmetId = null;
            }
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
                    materijal.materijalOpis = materijal.materijalOpis;
                    materijal.materijalNaslov = materijal.materijalNaslov;

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

        /// <summary>
        /// Skida selektovani materijal
        /// </summary>
        /// <param name="id">Id materijala za download.</param>
        /// <returns></returns>
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

        public ActionResult Delete(int id)
        {
            MaterijalModel materijal = context.pronadjiMaterijalPoId(id);
            if (materijal == null)
            {
                return HttpNotFound();
            }
            return View("Delete", materijal);
        }

        /// <summary>
        /// Brise materijal
        /// </summary>
        /// <param name="id">Id materijala za brisanje</param>
        /// <returns></returns>
        [HttpPost]
        //[ActionName("Delete")]
        //[Route("UploadMaterijal/DeleteConfirmed/{id:int}")]
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

        /// <summary>
        /// Filtrira materijal po formatu i tipu materijala.
        /// </summary>
        /// <param name="ekstenzija">Zeljena ekstenzija po kojoj se filtrira.</param>
        /// <param name="id">Id tipa materijala po kome se filtrira.</param>
        /// <param name="materijali">Lista materijala za filtriranje.</param>
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