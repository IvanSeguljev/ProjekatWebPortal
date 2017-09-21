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
        public ActionResult MaterijaliPrikaz(int number = 0,int id = 0)
        {
            List<MaterijalModel> materijali;
            materijali = context.materijali.ToList();
            if (number == 0)
            {
                materijali = context.materijali.Where(m => m.predmetId == id).ToList();
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
            context = new MaterijalContext();

            MaterijalUploadViewModel viewModel = new MaterijalUploadViewModel
            {
                Predmeti = context.predmeti.ToList(),
                tipoviMaterijala = context.tipMaterijala.ToList()
            };


            return View("UploadMaterijal", viewModel);
        }

        [HttpPost]
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
                    materijal.materijalOpis = model.materijalOpis;

                }

                ViewBag.Message = "Uspešno ste postavili materijal!";
                context.Add<MaterijalModel>(materijal);
                context.SaveChanges();
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
    }
}