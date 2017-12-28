using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekat.ViewModels;

namespace Projekat.Models
{
    public interface IMaterijalContext
    {
        IQueryable<MaterijalModel> materijali { get; }
        IQueryable<PredmetModel> predmeti { get; }
        IQueryable<SmerModel> smerovi { get; }
        IQueryable<NamenaMaterijalaModel> nameneMaterijala { get; }
        IQueryable<PremetPoSmeru> predmetiPoSmeru { get; }
        IQueryable<TipMaterijalModel> tipMaterijala { get; }

        int SaveChanges();

        T Add<T>(T entity) where T : class;

        MaterijalModel pronadjiMaterijalPoId(int id);

        MaterijalModel pronadjiMaterijalPoNazivu(string naziv);

        T Delete<T>(T entity) where T : class;

        IQueryable<OsiromaseniMaterijali> naprednaPretraga(List<string> ekstenzije, List<int> tipoviMaterijalaIds,int predmetId);

        IQueryable<OsiromaseniMaterijali> poPredmetu(int predmetId);


        
        
    }
}
