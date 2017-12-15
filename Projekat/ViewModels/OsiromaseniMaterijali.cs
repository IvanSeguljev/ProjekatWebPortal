using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projekat.ViewModels
{
    public class OsiromaseniMaterijali
    {
        public int materijalId { get; set; }
        public string materijalNaslov { get; set; }
        public string materijaOpis{ get; set; }
        public string ImgPath { get; set; }
        public string ekstenzija { get; set; }
        public int tipMaterijalaId { get; set; }

    }
}