
using Common.DTO;
using Common.DTO.Nomenclature;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.Services.Infrastructure
{
    public interface INomenclatureService
    {
        Task<IList<NomenDTO>> GetNomenclatures(int pFaza, bool includeDeleted = false);
        
#region n_nomobshti
        Task<IList<NomObshtiDTO>> GetNomObshti(string pKod, int pFaza, bool includeDeleted = false);
        Task<NomObshtiDTO> GetRowFormNomObshti(int id);
        Task<int>AddRowFormNomObshti(NomObshtiDTO item);
        Task<bool> SetRowFormNomObshti(NomObshtiDTO item);
        Task<bool> DelRowFormNomObshti(int id);

        #endregion n_nomobshti

#region n_nomjk
        Task<IList<NomJkDTO>> getNomenJk(int pFaza, bool includeDeleted = false);
        Task<NomJkDTO> getRowNomenJk(string id);
        Task<bool> SetRowNomenJk(NomJkDTO item);
        Task<int> AddRowNomenJk(NomJkDTO item);
        Task<bool> DelRowNomenJk(string id);
        Task<string> getMaxKodJk();
        #endregion n_nomjk

        #region n_nomkmetstva
        Task<IList<NomKmetstvoDTO>> getNomenKmetstva(int pFaza, bool includeDeleted = false);
        Task<NomKmetstvoDTO> getRowNomenKmetstva(string id);
        Task<bool> SetRowNomenKmetstva(NomKmetstvoDTO item);
        Task<int> AddRowNomenKmetstva(NomKmetstvoDTO item);
        Task<bool> DelRowNomenKmetstva(string id);

        #endregion n_nomkmetstva

        #region n_nomulici
        Task<IList<NomUlicaDTO>> getNomenUlici(int pFaza, bool includeDeleted = false);
        Task<NomUlicaDTO> getRowNomenUlici(string id);
        Task<bool> SetRowNomenUlici(NomUlicaDTO item);
        Task<int> AddRowNomenUlici(NomUlicaDTO item);
        Task<bool> DelRowNomenUlici(string id);
        Task<IList<NomUlicaDTO>> getUliciPerNsMqsto(string nkod);
        Task<string> getMaxKodUlici();
        #endregion n_nomulici

        #region n_nomnsmesta
        Task<IList<NomNsMqstoDTO>> getNomenNsMesta(int pFaza, bool includeDeleted = false);
        Task<NomNsMqstoDTO> getRowNomenNsMesta(string id);
        Task<bool> SetRowNomenNsMesta(NomNsMqstoDTO item);
        Task<int> AddRowNomenNsMesta(NomNsMqstoDTO item);
        Task<bool> DelRowNomenNsMesta(string id);
        Task<IList<NomNsMqstoDTO>> getNomenNsMestaByRaion(string pRaion);

        #endregion n_nomnsmesta

        #region n_nomraioni
        Task<IList<NomRaionDTO>> getNomenRaioni(int pFaza, bool includeDeleted = false);
        Task<NomRaionDTO> getRowNomenRaioni(string id);
        Task<bool> SetRowNomenRaioni(NomRaionDTO item);
        Task<int> AddRowNomenRaioni(NomRaionDTO item);
        Task<bool> DelRowNomenRaioni(string id);
        #endregion n_nomraioni


        #region n_nomuredi
        Task<IList<NomUrediDTO>> getNomenUredi(int pFaza, bool includeDeleted = false);
        Task<NomUrediDTO> getRowNomenUredi(int id);
        Task<int> SetRowNomenUredi(NomUrediDTO item);
        Task<int> AddRowNomenUredi(NomUrediDTO item);
        Task<bool> DelRowNomenUredi(int id);
        Task<IList<NomUrediDTO>> getKolektivNomenUredi(int pFaza);
        #endregion n_nomuredi

        #region nstatus
        Task<IList<NomStatusDTO>> GetNomStatusi(string type);

        #endregion

        #region nkid
        Task<IList<NomKidDTO>> GetNomKid();

        #endregion

        #region extra adresi
        Task<IList<AllExtraAddrDTO>> getAllExtraAddresses();
        Task<int> delExtraAddress(int id);
        Task<int> addRowExtraAddress(ExtraAddrDTO item);
        Task<int> setRowExtraAddress(ExtraAddrDTO item);
        Task <ExtraAddrDTO> getRowExtraAddress(int id);
        #endregion

        #region n_uredi_budget
        Task<IList<NomUredBudgetDTO>> getAllNomenUrediBudget(int pFaza, bool includeDeleted);
        Task<NomUredBudgetDTO> getRowNomenBudgetUredi(int id);
        Task<int> setRowNomenBudgetUredi(NomUredBudgetDTO item);
        #endregion
    }

}
