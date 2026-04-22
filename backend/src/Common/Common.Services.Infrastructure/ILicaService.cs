
using Common.DTO;
using Common.DTO.Lica;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.Services.Infrastructure
{
    public interface ILicaService
    {
        #region lica
        Task<LiceDTO> GetLice(int id);
        Task<int> SetLice(string pIdUser, LiceDTO id);
        Task<IList<PersonsDTO>> GetPersons(FilterDTO filter, string iduser);
        Task<IList<PersonsDTO>> GetDogovorPersons(FilterDTO filter, string iduser);
        Task<LiceDogovorDTO> GetLiceDogovor(int id);
        Task<int> GetLiceDogovorStatus(int id);

        Task<int> SetLiceDogovor(string iduser, LiceDogovorDTO item);
        Task<int> SetLiceDogovorStatus(string iduser, int id, int status);
        Task<int> changeLiceTitulqr(string iduser, int idlice, int statuslice);
        Task<int> SetTitulqr(string pIdUser, int pIdL, LiceDTO items, bool isNew);
        Task<int> setLiceDogovorExpired(string iduser, int iddog);
        #endregion

        #region firma
        Task<FirmaDTO> GetFirma(int id);
        Task<int> SetFirma(string pIdUser, FirmaDTO item);
        Task<IList<FirmsDTO>> GetFirms(FilterDTO filter, string iduser);

        #endregion

        #region uredi
        Task<IList<UrediDTO>> GetUred(int id);
        Task SetUredi(string pIdUser, int pIdFormulqr, int pIdLice, List<UrediDTO> items);
        #endregion

        #region uredi
        Task<IList<UrediDTO>> GetOldUred(int id);
        Task SetOldUredi(string pIdUser, int pIdFormulqr, int pIdLice, List<UrediDTO> items);
        #endregion

        #region documenti
        Task SetDocuments(string pIdUser, int pIdLice, List<ListDocumentsDTO> items);
        #endregion

        #region systav
        Task<IList<LiceDTO>> GetKolektiv(int id);
        Task SetKolektiv(string pIdUser, int pIdLice, List<LiceDTO> items);
        Task SetChlen(string pIdUser, LiceDTO item);
        #endregion

        #region formulqr
        Task<IList<ListFormulqrDTO>> GetListFormulqrs(int pVid, FilterDTO filter, string iduser);
        Task<FormulqrDTO> GetFormulqr(int id);
        Task<int> AddFormulqr(string pIdUser, FormulqrDTO item);
        Task<int> SetFormulqr(string pIdUser, FormulqrDTO item);
        Task<IList<PersonsDTO>> getHistoryFormulqr(int id);
        Task<int> setFormulqrStatus(string iduser, int idformulqr, int status);
        Task<int> checkFormulqrUnomer(string unomer, int faza);
        Task<int> checkFormulqrAdres(AdresDTO adres);
        #endregion

        #region printdoc        
        Task<DogovorPrintDTO> getDogovorData(int id);
        #endregion

        Task<int> updOposDogovorNomer(string nomer, string data, string otnosno);
        Task<IList<ViewRadiatoriZaPrekodiraneDTO>> getRadiatoriZaPrekodirane(FilterDTO filter);
        Task<int> doPrekodiraneRadiatori(int iddog, string iduser);

        Task<AdresDTO> getAddress(int id);
        Task<int> setAddress(AdresDTO item);

    }
}
