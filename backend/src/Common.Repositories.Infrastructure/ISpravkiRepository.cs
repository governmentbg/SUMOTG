using Common.Entities;
using Common.Entities.Spravki;
using Common.Entities.Views;
using Common.Entities.Views.Spravki;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Common.Repositories.Infrastructure
{
    public interface ISpravkiRepository
    {
        Task<IList<NSpravki>> GetSpravki(int pFaza, bool includeDeleted);
        Task<IList<ViewSpravka1>> GetSpravka1(Filter1 filter);
        Task<IList<ViewSpravka2>> GetSpravka2(Filter filter);
        Task<IList<ViewSpravka2>> GetSpravka2a(Filter filter);
        Task<IList<ViewSpravka4>> GetSpravka4(Filter filter);
        Task<IList<ViewSpravka5>> GetSpravka5(Filter filter);
        Task<IList<ViewSpravka6>> GetSpravka6(Filter filter);
        Task<IList<ViewSpravka7>> GetSpravka7(Filter filter);
        Task<IList<ViewSpravka8>> GetSpravka8(Filter filter);
        Task<IList<ViewSpravka5>> GetSpravka9(Filter filter);
        Task<IList<ViewSpravka6>> GetSpravka10(Filter filter);
        Task<IList<ViewSpravka11>> GetSpravka11(Filter filter);
        Task<IList<ViewSpravka11>> GetSpravka12(Filter filter);
        Task<IList<ViewSpravka13>> GetSpravka13(Filter filter);
        Task<IList<ViewSpravka14>> GetSpravka14(Filter filter);
        Task<IList<ViewSpravka15>> GetSpravka15(Filter filter);
        Task<IList<ViewSpravka20>> GetSpravka20(Filter filter);
        Task<IList<ViewSpravka21>> GetSpravka21(Filter filter);
        Task<IList<ViewSpravka5>> GetSpravka23(Filter filter);
        Task<IList<ViewSpravka24>> GetSpravka24();
        Task<IList<ViewSpravka25>> GetSpravka25(Filter filter);
        Task<IList<ViewOposPortret>> GetOposPortret(Filter filter);
        Task<IList<ViewSpravka50>> GetSpravka50(Filter filter);
        Task<IList<ViewSpravka51>> GetSpravka51(Filter filter);
        Task<IList<ViewSpravka52>> GetSpravka52();
        Task<IList<ViewSpravka53>> GetSpravka53();
        Task<IList<ViewSpravka54>> GetSpravka54();
        Task<IList<ViewSpravka55>> GetSpravka55(int type);
        Task<IList<ViewSpravka55>> GetSpravka56();

        Task<IList<ViewSpravka60>> GetSpravka60(Filter1 filter);
        Task<IList<ViewSpravka60>> GetSpravka61(Filter1 filter);

        Task<IList<ViewSpravka70>> GetSpravka70(int tip, Filter1 filter);
        Task<IList<ViewSpravka78>> GetSpravka72(int tip, Filter1 filter);
        Task<IList<ViewSpravka78>> GetSpravka78(Filter1 filter);
        Task<int> setPorychkaStatus(int idporychka, int status);
        Task<int> setPorychkaUnSign(int idporychka);

    }
}
