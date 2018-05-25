using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekat.Models
{
    public class StrucnaSpremaModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdSS { get; set; }
        public string NazivSS { get; set; }
        public string SkracenoSS { get; set; }
    }
}