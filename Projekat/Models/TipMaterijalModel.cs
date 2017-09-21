using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projekat.Models
{
    public class TipMaterijalModel
    {
        [Key]
        public int tipMaterijalId { get; set; }
        public string nazivTipMaterijal { get; set; }
        

    }
}