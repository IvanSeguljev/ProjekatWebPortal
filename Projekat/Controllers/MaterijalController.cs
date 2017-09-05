using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projekat.Models;
using Projekat.ViewModels;
using System.Data.Entity;


namespace Projekat.Controllers
{
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

        [HttpGet]
        public ActionResult MaterijaliPrikaz(int number = 0)
        {
            List<MaterijalModel> materijali;
            materijali = context.materijali.ToList();
            if (number == 0)
            {
                materijali = context.materijali.ToList();
            }
            else
            {
                materijali = (from p in context.materijali
                              select p).Take(number).ToList();
            }

            return View("MaterijaliPrikaz", materijali);
        }

        [HttpGet]
        public ActionResult UploadMaterijal()
        {
            List<PredmetModel> predmeti;
            predmeti = context.predmeti.ToList();
            MaterijalViewModel ViewModel = new MaterijalViewModel();
            //MaterijalModel model = new MaterijalModel();
            ViewModel.predmetiLista = predmeti;


            return View("UploadMaterijal", ViewModel);
        }

        [HttpPost]
        public ActionResult UploadMaterijal(MaterijalViewModel ViewModel, HttpPostedFileBase file, MaterijalViewModel model/*, string hiddenPredmet*/)
        {


            // PredmetModel predmet = new PredmetModel();

            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string nazivFajla = Path.GetFileName(file.FileName);

                    ViewModel.materijal.fileMimeType = file.ContentType;
                    ViewModel.materijal.materijalFile = new byte[file.ContentLength];
                    file.InputStream.Read(ViewModel.materijal.materijalFile, 0, file.ContentLength);
                    ViewModel.materijal.materijalNaziv = nazivFajla;
                    ViewModel.materijal.materijalEkstenzija = Path.GetExtension(nazivFajla);
                    ViewModel.materijal.materijalOpis = model.materijal.materijalOpis;
                    ViewModel.materijal.predmetId = model.materijal.predmetId;     //predmet id prop

                }

                ViewBag.Message = "Uspešno ste postavili materijal!";
                context.Add<MaterijalModel>(ViewModel.materijal);
                context.SaveChanges();
                return RedirectToAction("UploadMaterijal", "UploadMaterijal");
                // return View("UploadMaterijal", ViewModel);
            }
            else
            {
                ViewBag.Message = "Postavljanje materijala nije uspelo!";
                return RedirectToAction("UploadMaterijal", "UploadMaterijal");

                // return View("UploadMaterijal", ViewModel);
            }
        }

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

        [HttpGet]
        //[ActionName("Delete")]
        //[Route("UploadMaterijal/DeleteConfirmed/{id:int}")]
        public ActionResult DeleteConfirmed(int id)
        {
            MaterijalModel materijal = context.pronadjiMaterijalPoId(id);
            context.Delete<MaterijalModel>(materijal);
            context.SaveChanges();

            return RedirectToAction("MaterijaliPrikaz");
        }
    }
}