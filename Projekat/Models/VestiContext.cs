using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Projekat.Models
{
    public class VestiContext:ApplicationDbContext
    {
        public DbSet<VestModel> Vesti { get; set; }
    }
}