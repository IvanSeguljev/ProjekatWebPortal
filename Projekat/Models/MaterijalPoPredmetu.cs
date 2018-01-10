using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Projekat.Models
{
    public class MaterijalPoPredmetu
    {
        [Key, ForeignKey("MaterijalModel"), Column(Order = 0)]
        public int materijalId { get; set; }


        [Key, ForeignKey("PredmetModel"), Column(Order = 1)]
        public int predmetId { get; set; }

        public MaterijalModel MaterijalModel { get; set; }

        public PredmetModel PredmetModel { get; set; }
    }
}