using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Projekat.Models
{
    public class MaterijalContext : ApplicationDbContext, IMaterijalContext
    {
        public DbSet<MaterijalModel> materijali { get; set; }
        public DbSet<PredmetModel> predmeti { get; set; }
        public DbSet<SmerModel> smerovi { get; set; }
        public DbSet<PremetPoSmeru> predmetiPoSmeru { get; set; }

        IQueryable<MaterijalModel> IMaterijalContext.materijali
        {
            get { return materijali; }

        }

        IQueryable<PredmetModel> IMaterijalContext.predmeti
        {
            get { return predmeti; }
        }

        IQueryable<SmerModel> IMaterijalContext.smerovi
        {
            get { return smerovi; }
        }

        IQueryable<PremetPoSmeru> IMaterijalContext.predmetiPoSmeru
        {
            get { return predmetiPoSmeru; }
        }

        T IMaterijalContext.Add<T>(T entity)
        {
            return Set<T>().Add(entity);
        }

        T IMaterijalContext.Delete<T>(T entity)
        {
            return Set<T>().Remove(entity);
        }

        MaterijalModel IMaterijalContext.pronadjiMaterijalPoId(int id)
        {
            return Set<MaterijalModel>().Find(id);
        }

        MaterijalModel IMaterijalContext.pronadjiMaterijalPoNazivu(string naziv)
        {
            MaterijalModel materijal = (from m in Set<MaterijalModel>()
                                        where m.materijalNaziv == naziv
                                        select m).FirstOrDefault();
            return materijal;
        }

        int IMaterijalContext.SaveChanges()
        {

            return SaveChanges();
        }
    }
}