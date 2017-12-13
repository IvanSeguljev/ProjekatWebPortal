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
        public DbSet<NamenaMaterijalaModel> nameneMaterijala { get; set; }
        public DbSet<PremetPoSmeru> predmetiPoSmeru { get; set; }
        public DbSet<TipMaterijalModel> tipMaterijala { get; set; }

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

        public  List<MaterijalModel> naprednaPretraga(List<string> ekstenzije, List<int> tipoviMaterijalaIds)
        {
            IMaterijalContext context = new MaterijalContext();
            List<MaterijalModel> materijali = new List<MaterijalModel>();
            foreach (MaterijalModel m in context.materijali)
            {
                
                if (ekstenzije != null)
                {
                    if (ekstenzije.Contains(m.materijalEkstenzija) /*|| tipoviMaterijalaIds.Contains(m.tipMaterijalId)*/)
                            materijali.Add(m);
                }

            }
            return materijali;
        } //TREBA TESTIRATI OVO KAD SE PREKO JS PROSLEDE LISTE

        List<MaterijalModel> IMaterijalContext.naprednaPretraga(List<string> ekstenzije, List<int> tipoviMaterijalaIds)
        {
            throw new NotImplementedException();
        }

        List<object> IMaterijalContext.skiniPodatke(List<MaterijalModel> listaMaterijala )
        {
            List<object> trimovano = new List<object>();
            foreach(MaterijalModel m in listaMaterijala)
            {
                trimovano.Add(new
                {
                    materijalId = m.materijalId,
                    materijalNaslov = m.materijalNaslov,
                    materijalOpis = m.materijalOpis,
                    ImgPath = m.ImgPath

                });
            }

            return trimovano;

        }
    }
}