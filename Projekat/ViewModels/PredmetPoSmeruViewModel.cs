using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projekat.Models;


namespace Projekat.ViewModels
{
    public class PredmetPoSmeruViewModel
    {
        public PredmetModel predmet { get; set; }

        public List<PredmetModel> predmeti { get; set; }



    }
}