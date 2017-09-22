using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projekat.Models;
using Projekat.ViewModels;

namespace Projekat.ViewModels
{
    public class MaterijalViewModel
    {
        public IEnumerable<MaterijalModel> materijaliLista { get; set; }
        public MaterijalModel materijal { get; set; }



        public PredmetModel predmet { get; set; }
        public IEnumerable<PredmetModel> predmetiLista { get; set; }



       

        //public string materijalNaziv { get; set; }
        //public HttpPostedFileBase File { get; set; }
    }
}