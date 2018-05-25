using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projekat.Models
{
    public class SkolaModel
    {
        [Key]
        public int IdSkole { get; set; }
        public string NazivSkole { get; set; }
        public string Skraceno { get; set; }
    }
}