using Common.DTO;
using Common.DTO.Firmi;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services.Infrastructure
{
    public interface IFirmService
    {
        Task<IList<IzpylnitelDTO>> GetFirmi(int faza, int rolq);
        Task<IzpylnitelDTO> GetFirma(string eik);

        #region montazj
        Task<IList<FirmaIzpalnitelDTO>> GetFirmiMontaz(int faza);
        Task<FirmaDogovorDTO> GetMonDogovor(int iddog);
        Task<int> SetMonDogovor(string pIdUser, FirmaDogovorDTO item);
        Task<IList<FirmaDogovorDTO>> GetMonDogovoriFirma(int idfirma);
        Task<IList<FirmaUrediDTO>> loadMonDogovorUredi(int iddogovor);
        Task<IList<FirmaDogovorDTO>> loadMonDogovorPorychki(int iddogovor);

        #endregion

        #region demontazj
        Task<IList<FirmaIzpalnitelDTO>> GetFirmiDeMontaz(int faza);
        Task<FirmaDogovorDTO> GetDeMonDogovor(int iddog);
        Task<int> SetDeMonDogovor(string pIdUser, FirmaDogovorDTO item);
        Task<IList<FirmaDogovorDTO>> GetDeMonDogovoriFirma(int idfirma);
        Task<IList<FirmaUrediDTO>> loadDeMonDogovorUredi(int iddogovor);

        #endregion

    }
}
