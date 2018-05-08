﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Projekat.ViewModels;

namespace Projekat.Models
{
    /// <summary>
    /// MaterijalContext class
    /// </summary>
    /// <seealso cref="Projekat.Models.ApplicationDbContext" />
    /// <seealso cref="Projekat.Models.IMaterijalContext" />
    public class MaterijalContext : ApplicationDbContext, IMaterijalContext
    {
        /// <summary>
        /// Gets the queryable data source for materijali.
        /// </summary>
        /// <value>
        /// Queryable selection of MaterijalModel Classes.
        /// </value>
        public DbSet<MaterijalModel> materijali { get; set; }
        /// <summary>
        /// Gets the queryable data source for predmeti.
        /// </summary>
        /// <value>
        /// The queryable selection of PredmetModelClasses.
        /// </value>
        public DbSet<PredmetModel> predmeti { get; set; }
        /// <summary>
        /// Gets the queryable data source for smerovi.
        /// </summary>
        /// <value>
        /// The queryable selection of SmerModel Classes.
        /// </value>
        public DbSet<SmerModel> smerovi { get; set; }
        /// <summary>
        /// Gets the queryable data source for NamenaMaterijala.
        /// </summary>
        /// <value>
        /// The queryable selection of NamenaMaterijalaModel Classes.
        /// </value>
        public DbSet<NamenaMaterijalaModel> nameneMaterijala { get; set; }
        /// <summary>
        /// Gets the queryable data source for PredmetiPoSmeru.
        /// </summary>
        /// <value>
        /// The queryable selection of PredmetPoSmeru Classes.
        /// </value>
        public DbSet<PremetPoSmeru> predmetiPoSmeru { get; set; }
        /// <summary>
        /// Gets the queryable data source for TipMaterijala.
        /// </summary>
        /// <value>
        /// The queryable selection of TipMaterijala Classes.
        /// </value>
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
            var queriable = context.poPredmetu(predmetId);

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