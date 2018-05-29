using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Projekat.Models;

namespace Projekat.ViewModels
{
    public class ListaKorisnikaViewModel
    {
        public ApplicationUser Korisnik { get; set; }
        public string Smer { get; set; }
        public string Skola { get; set; }
    }
}