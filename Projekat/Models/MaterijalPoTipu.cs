using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Projekat.Models
{
    public class MaterijalPoTipu
    {
        [Key, ForeignKey("MaterijalModel"), Column(Order = 0)]
        public int materijalId { get; set; }

        [Key, ForeignKey("TipMaterijalModel"), Column(Order = 1)]
        public int tipMaterijalaId { get; set; }

        public TipMaterijalModel TipMaterijalModel { get; set; }

        public MaterijalModel MaterijalModel { get; set; }
    }
}