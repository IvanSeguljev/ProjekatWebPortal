using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projekat.Models
{
    public class VestModel
    {
        public VestModel()
        {
            DatumPostavljanja = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }
        public string Naslov { get; set; }
        public string Thumbnail { get; set; }
        public string Vest { get; set; }
        public string KratakOpis { get; set; }
        public DateTime DatumPostavljanja { get; set; }
    }
}