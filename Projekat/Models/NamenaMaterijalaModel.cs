using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Web.Mvc;

namespace Projekat.Models
{
    public class NamenaMaterijalaModel
    {
        [Key]
        public int namenaMaterijalaId { get; set; }

        public string namenaMaterijalaNaziv { get; set; }

    }
}