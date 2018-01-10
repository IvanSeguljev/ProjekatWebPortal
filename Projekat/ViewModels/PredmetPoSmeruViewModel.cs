using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projekat.Models;


namespace Projekat.ViewModels
{
    public class PredmetPoSmeruViewModel
    {
    

        public List<PredmetModel> predmeti { get; set; }


        public List<SmerModel> smerovi { get; set; }

        public List<int> smeroviId { get; set; }
        public int smerId { get; set; }
        public int predmetId { get; set; }
        public string predmetNaziv { get; set; }
        public string predmetOpis { get; set; }




    }
}