using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projekat.Models;

namespace Projekat.ViewModels
{
    public class MaterijalUploadViewModel
    {

        public MaterijalModel  Materijal { get; set; }
        public IEnumerable<PredmetModel> Predmeti { get; set; }

        public IEnumerable<TipMaterijalModel> tipoviMaterijala { get; set; }

        public IEnumerable<NamenaMaterijalaModel> nameneMaterijala { get; set; }

        public IEnumerable<SmerModel> Smerovi { get; set; }

        public IEnumerable<PredmetModel> PredmetPoSmeru { get; set; }
        public int smerId { get; set; }
        public int predmetId { get; set; }


    }
}