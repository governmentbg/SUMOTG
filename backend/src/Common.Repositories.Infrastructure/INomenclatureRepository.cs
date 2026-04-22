using Common.Entities;
using Common.Entities.Nomenclatures;
using Common.Entities.Views;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.Repositories.Infrastructure
{
    public interface INomenclatureRepository
    {
        Task<IList<NSpisykNmn>> GetNomenclatures(int pFaza, bool includeDeleted);

        #region n_nomobshti
        Task<IList<NNmnObshti>> GetNomObshti(string pKod, int pFaza, bool includeDeleted);
        Task<NNmnObshti> GetRowFormNomObshti(int id);
        Task<int> AddRowFormNomObshti(NNmnObshti item);
        Task SetRowFormNomObshti(NNmnObshti item);
        Task<int> DelRowFormNomObshti(int id);

        #endregion

        #region n_nomjk
        Task<IList<NJk>> getNomenJk(int pFaza, bool includeDeleted);
        Task<NJk> getRowNomenJk(string id);
        Task SetRowNomenJk(NJk item);
        Task<int> AddRowNomenJk(NJk item);
        Task<int> DelRowNomenJk(string id);
        Task<string> getMaxKodJk();
        #endregion


        #region n_nomkmetstva
        Task <IList<NKmetstva>> getNomenKmetstva(int pFaza, bool includeDeleted);
        Task <NKmetstva>  getRowNomenKmetstva(string id);
        Task SetRowNomenKmetstva(NKmetstva item);
        Task<int> AddRowNomenKmetstva(NKmetstva item);
        Task<int> DelRowNomenKmetstva(string id);
        #endregion


        #region n_nomulici
        Task<IList<ViewNUlici>> getNomenUlici(int pFaza, bool includeDeleted);

        Task<NUlicii> getRowNomenUlici(string id);
        Task SetRowNomenUlici(NUlicii item);
        Task<int> AddRowNomenUlici(NUlicii item);
        Task<int> DelRowNomenUlici(string id);
        Task<IList<ViewNUlici>> getUliciPerNsMqsto(string nkod);
        Task<string> getMaxKodUlici();
        #endregion n_ulici


        #region n_nomnsmesta
        Task<IList<NNsMestum>> getNomenNsMesta(int pFaza, bool includeDeleted);

        Task<NNsMestum> getRowNomenNsMesta(string id);
        Task SetRowNomenNsMesta(NNsMestum item);
        Task<int> AddRowNomenNsMesta(NNsMestum item);
        Task<int> DelRowNomenNsMesta(string id);
        Task<IList<NNsMestum>> getNomenNsMestaByRaion(string pRaion);

        #endregion n_nomnsmesta


        #region n_nomraioni
        Task<IList<NRaioni>> getNomenRaioni(int pFaza, bool includeDeleted);
        Task<NRaioni> getRowNomenRaioni(string id);
        Task SetRowNomenRaioni(NRaioni item);
        Task<int> AddRowNomenRaioni(NRaioni item);
        Task<int> DelRowNomenRaioni(string id);
        #endregion n_nomraioni


        #region n_nomuredi
        Task<IList<NUredi>> getNomenUredi(int pFaza, bool includeDeleted);
        Task<NUredi> getRowNomenUredi(int id);
        Task SetRowNomenUredi(NUredi item);
        Task<int> AddRowNomenUredi(NUredi item);
        Task<int> DelRowNomenUredi(int id);
        Task<IList<NUredi>> getKolektivNomenUredi(int pFaza);
        #endregion n_nomuredi

        #region
        Task<IList<NStatusi>> GetNomStatusi(string type);

        #endregion

        #region nkid
        Task<IList<NKid>> GetNomKid();

        #endregion

        #region extra adresi
        Task<IList<ViewFiltriAdres>> getAllExtraAddresses();
        Task<int> delExtraAddress(int id);
        Task<int> addRowExtraAddress(FiltriAdres item);
        Task<int> setRowExtraAddress(FiltriAdres item);
        Task<FiltriAdres> getRowExtraAddress(int id);
        #endregion

        #region n_uredi_budget
        Task<IList<ViewNomUredBudget>> getAllNomenUrediBudget(int pFaza, bool includeDeleted);
        Task<ViewNomUredBudget> getRowNomenBudgetUredi(int id);
        Task<int> setRowNomenBudgetUredi(ViewNomUredBudget item);
        #endregion

    }
}