using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projekat.Models;

namespace Projekat.ViewModels
{
    public class DodajPremetViewModel
    {
        public IEnumerable<SmerModel> smerovi { get; set; }
        public PredmetModel predmet { get; set; }

        public SmerModel smer { get; set; }
    }
}