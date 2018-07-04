using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projekat.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Projekat.ViewModels
{
    public class ListaNaprednaPretragaViewModel
    {
        public List<ListaKorisnikaViewModel> Korisnici { get; set; }
        public IEnumerable<SmerModel> Smerovi { get; set; }
        public IEnumerable<SkolaModel> Skole { get; set; }
        public IEnumerable<IdentityRole> Uloge { get; set; }

        public int FilterSkolaID { get; set; }
        public string FilterUloga { get; set; }
        public int FilterSmerID { get; set; }
    }
}