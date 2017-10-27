using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projekat.ViewModels
{
    public class MaterijaliNaprednaPretragaViewModel
    {
        public  IEnumerable<Projekat.Models.MaterijalModel> materijali { get; set; }

        public string naprednaPretragaSelektovani { get; set; }
    }
}