using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projekat.Models;

namespace Projekat.ViewModels
{
    public class MaterijaliNaprednaPretragaViewModel
    {
        public  IEnumerable<Projekat.Models.MaterijalModel> materijali { get; set; }

        public MaterijalModel materijal { get; set; }

        public string naprednaPretragaSelektovani { get; set; }
    }
}