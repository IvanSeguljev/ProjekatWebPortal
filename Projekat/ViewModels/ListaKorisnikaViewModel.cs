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
        public IEnumerable<ApplicationUser> Korisnici { get; set; }
    }
}