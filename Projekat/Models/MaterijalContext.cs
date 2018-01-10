using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Projekat.ViewModels;

namespace Projekat.Models
{
    public class MaterijalContext : ApplicationDbContext, IMaterijalContext
    {
        public DbSet<MaterijalModel> materijali { get; set; }
        public DbSet<PredmetModel> predmeti { get; set; }
        public DbSet<SmerModel> smerovi { get; set; }
        public DbSet<NamenaMaterijalaModel> nameneMaterijala { get; set; }
        public DbSet<PremetPoSmeru> predmetiPoSmeru { get; set; }
        public DbSet<TipMaterijalModel> tipMaterijala { get; set; }
        public DbSet<MaterijalPoTipu> materijaliPoTipu { get; set; }
        public DbSet<MaterijalPoPredmetu> materijalPoPredmetu { get; set; }

        IQueryable<MaterijalModel> IMaterijalContext.materijali
        {
            get { return materijali; }

        }

        IQueryable<TipMaterijalModel> IMaterijalContext.tipMaterijala
        {
            get { return tipMaterijala; }
            
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

        IQueryable<NamenaMaterijalaModel> IMaterijalContext.nameneMaterijala
        {
            get { return nameneMaterijala; }
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

        
        
        


        IQueryable<OsiromaseniMaterijali> IMaterijalContext.poPredmetu(int predmetId)
        {
            IQueryable<OsiromaseniMaterijali> materijali;
            materijali = this.materijali.Where(m => m.predmetId == predmetId).Select(m => new OsiromaseniMaterijali
            {
                materijalId = m.materijalId,
                ekstenzija = m.materijalEkstenzija,
                materijalNaslov = m.materijalNaslov,
                materijalOpis = m.materijalOpis,
                tipMaterijalaId = m.tipMaterijalId
            });

            return materijali;
        }



        IQueryable<OsiromaseniMaterijali> IMaterijalContext.naprednaPretraga(List<string> ekstenzije, List<int> tipoviMaterijalaIds, int predmetId)//Dodati parametre 
        {
            // && (a => tipoviMaterijalaIds.Any(s => a.tipMaterijalaId)

           
            IMaterijalContext context = new MaterijalContext();
           var queriable = context.poPredmetu( predmetId);

            if (ekstenzije != null && tipoviMaterijalaIds != null)
            {

                queriable = queriable.
                   Where(a => ekstenzije.Any(s => a.ekstenzija.Contains(s))); 
                                    

                queriable = queriable.
                    Where(a => tipoviMaterijalaIds.Any(s => a.tipMaterijalaId.ToString().Contains(s.ToString())));


                return queriable;

            }

            else if (ekstenzije == null && tipoviMaterijalaIds != null)
            {
                queriable = queriable.
                Where(a => tipoviMaterijalaIds.Any(s => a.tipMaterijalaId.ToString().Contains(s.ToString())));


                return queriable;

            }

            else if (ekstenzije != null && tipoviMaterijalaIds == null)
            {

               queriable = queriable.
               Where(a => ekstenzije.Any(s => a.ekstenzija.Contains(s)));

             
                return queriable;

            }
            else
                return queriable;


        }

      
    }
}