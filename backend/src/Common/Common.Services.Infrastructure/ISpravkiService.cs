using Common.DTO;
using Common.DTO.Spravki;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.Services.Infrastructure
{
    public interface ISpravkiService
    {
        Task<IList<SpravkiDTO>> GetSpravki(int pFaza, bool includeDeleted = false);
        Task<IList<Spravka1DTO>> GetSpravka1(Filter1DTO filter);
        Task<IList<Spravka2DTO>> GetSpravka2(int type, FilterDTO filter);
        Task<IList<Spravka4DTO>> GetSpravka4(FilterDTO filter);
        Task<IList<Spravka5DTO>> GetSpravka5(FilterDTO filter);
        Task<IList<Spravka6DTO>> GetSpravka6(FilterDTO filter);
        Task<IList<Spravka7DTO>> GetSpravka7(FilterDTO filter);
        Task<IList<Spravka8DTO>> GetSpravka8(FilterDTO filter);
        Task<IList<Spravka5DTO>> GetSpravka9(FilterDTO filter);
        Task<IList<Spravka6DTO>> GetSpravka10(FilterDTO filter);
        Task<IList<Spravka11DTO>> GetSpravka11(FilterDTO filter);
        Task<IList<Spravka11DTO>> GetSpravka12(FilterDTO filter);
        Task<IList<Spravka13DTO>> GetSpravka13(FilterDTO filter);
        Task<IList<Spravka14DTO>> GetSpravka14(FilterDTO filter);
        Task<IList<Spravka15DTO>> GetSpravka15(FilterDTO filter);
        Task<IList<Spravka20DTO>> GetSpravka20(FilterDTO filter);
        Task<IList<Spravka21DTO>> GetSpravka21(FilterDTO filter);
        Task<IList<Spravka5DTO>> GetSpravka23(FilterDTO filter);
        Task<IList<Spravka24DTO>> GetSpravka24();
        Task<IList<Spravka25DTO>> GetSpravka25(FilterDTO filter);
        Task<IList<OposPortretDTO>> GetOposPortret(FilterDTO filter);
        Task<IList<Spravka50DTO>> GetSpravka50(FilterDTO filter);
        Task<IList<Spravka51DTO>> GetSpravka51(FilterDTO filter);
        Task<IList<Spravka52DTO>> GetSpravka52();
        Task<IList<Spravka53DTO>> GetSpravka53();
        Task<IList<Spravka54DTO>> GetSpravka54();
        Task<IList<Spravka55DTO>> GetSpravka55(int type);
        Task<IList<Spravka55DTO>> GetSpravka56();

        Task<IList<Spravka60DTO>> GetSpravka60(Filter1DTO filter);
        Task<IList<Spravka60DTO>> GetSpravka61(Filter1DTO filter);
        Task<IList<Spravka70DTO>> GetSpravka70(int tip, Filter1DTO filter);
        Task<IList<Spravka78DTO>> GetSpravka72(int tip, Filter1DTO filter);
        Task<IList<Spravka78DTO>> GetSpravka78(Filter1DTO filter);
        Task<IList<Spravka70DTO>> GetSpravka79(Filter1DTO filter);

        Task<int> setPorychkaStatus(int idporychka, int status);
        Task<int> setPorychkaUnSign(int idporychka);
    }
}
