using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.ComponentModel;
using System.Web.Mvc;

namespace Projekat.Models
{
    public class PredmetModel
    {
        [Key]
        public int predmetId { get; set; }
        public string predmetNaziv { get; set; }
        public string predmetOpis { get; set; }

        public IEnumerable<PredmetModel> predmeti { get; set; }
    }
}