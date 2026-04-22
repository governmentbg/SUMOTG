using Common.Entities;
using Common.Entities.Views;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.Repositories.Infrastructure
{
    public interface ILicaRepository
    {
        #region lice
        Task<ViewLica> GetLice(int id);
        Task<int> SetLice(Lica data);
        Task<IList<ViewPersons>> GetPersons(Filter filter, string iduser);
        Task<IList<ViewPersons>> GetDogovorPersons(Filter filter, string iduser);
        Task<ViewLiceDogovor> GetLiceDogovor(int id);
        int GetLiceDogovorNomer(int idlice);
        Task<int> updOposDogovorNomer(string nomer, string data, string otnosno);
        Task<int> GetLiceDogovorStatus(int id);
        Task<int> SetLiceDogovor(string iduser, LicaDogovor data);
        Task<int> SetLiceDogovorStatus(string iduser, int id, int status);
        Task<int> SetLiceStatus(string iduser, int idlice, int status);
        Task<int> changeLiceTitulqr(string iduser, int idlice, int statuslice);
        Task<int> setLiceDogovorExpired(string iduser, int iddog);
        #endregion

        #region firma
        Task<IList<ViewFirms>> GetFirms(Filter filter, string iduser);
        Task<LicaFormuliarFirma> GetFirma(int id);
        Task<int> SetFirma(LicaFormuliarFirma data);
        #endregion

        #region uredi
        Task<List<LicaFormuliarUredi>> GetUredi(int id);
        Task SetUredi(LicaFormuliarUredi data);
        Task DelUredi(int liceId);
        Task DelDogovorUredi(int dogovorId);
        Task SetDogovorUredi(LicaDogovorUredi data);
        Task SetDogovorUrediArhiv(int pIdDog, List<LicaDogovorUredi> data);

        #endregion

        #region olduredi
        Task<List<LicaFormuliarOldUredi>> GetOldUredi(int id);
        Task SetOldUredi(LicaFormuliarOldUredi data);
        Task DelOldUredi(int liceId);
        Task DelDogovorOldUredi(int dogovorId);
        Task SetDogovorOldUredi(LicaDogovorOldUredi data);

        #endregion

        #region documenti
        Task<List<LicaDokumenti>> GetDocuments(int id);
        Task<LicaDokumenti> GetDocument(int id);
        Task SetDocument(LicaDokumenti data);
        Task DelDocuments(int liceId);
        #endregion

        #region kolektiv
        Task<List<LicaFormuliarKolektiv>> GetKolektiv(int id);
        Task<int> SetKolektiv(LicaFormuliarKolektiv data);
        Task<int> UpdKolektiv(LicaFormuliarKolektiv data);
        Task DelKolektiv(int liceId);
        #endregion

        #region formulqr
        Task<ViewDogovorPrint> getDogovorData(int pFaza);

        Task<IList<ViewListFormulqr>> GetListFormulqrs(int pVid, Filter filter, string iduser);
        Task<ViewFormulqr> GetFormulqr(int id);
        Task<int> AddFormulqr(
            Lica lice, 
            LicaFormuliar formulqr, 
            LicaFormuliarKolektiv titular, 
            LicaFormuliarFirma firma, 
            List<LicaFormuliarOldUredi> olduredi, 
            List<LicaFormuliarUredi> uredi,
            List<LicaFormuliarKolektiv> systav,
            List<LicaDokumenti> dokumenti 
        );
        Task<int> SetFormulqr(LicaFormuliar item, int vid, int unomer);
        Task<IList<ViewPersons>> getHistoryFormulqr(int id);
        Task<int> setFormulqrStatus(string iduser, int idformulqr, int status);
        Task<int> checkFormulqrUnomer(string unomer, int faza);
        Task<int> checkFormulqrAdres(Address adres);

        #endregion

        #region dop. sporazumeniq
        Task DelDogovorDopSp(int IdLice);
        Task SetDogovorDopSp(LicaDopSporazumeniq data);
        #endregion

        Task<IList<ViewRadiatoriZaPrekodirane>> getRadiatoriZaPrekodirane(Filter filter);
        Task<int> doPrekodiraneRadiatori(int iddog, string iduser);
        Task<Address> getAddress(int id);
        Task<int> setAddress(Address adres);

    }
}
