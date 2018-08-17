using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projekat.Models
{
    public class VestModel
    {
        [Key]
        public int Id { get; set; }
        public string Naslov { get; set; }
        public byte[] Thumbnail { get; set; }
        public string Vest { get; set; }
    }
}