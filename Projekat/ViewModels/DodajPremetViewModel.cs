using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projekat.Models;

namespace Projekat.ViewModels
{
    public class DodajPremetViewModel
    {
        public IEnumerable<SmerModel> smerovi { get; set; } //Za citanje
        public PredmetModel predmet { get; set; }
        public List<int> smerIds { get; set; } //Za upisivanje u bazu
    }
}