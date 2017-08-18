using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekat.Models
{
    public class PremetPoSmeru
    {
        [Key, ForeignKey("PredmetModel"), Column(Order = 0)]
        public int predmetId { get; set; }

        [Key, ForeignKey("SmerModel"), Column(Order = 1)]
        public int smerId { get; set; }

        public PredmetModel PredmetModel { get; set; }
        public SmerModel SmerModel { get; set; }
    }
}