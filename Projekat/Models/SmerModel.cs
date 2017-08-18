using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projekat.Models
{
    public class SmerModel
    {
        [Key]
        public int smerId { get; set; }

        public string smerNaziv { get; set; }

        public string smerOpis { get; set; }

        public IEnumerable<SmerModel> smerovi { get; set; }//ovo mozda napravi problem
    }
}