using Common.Entities;
using Common.Entities.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repositories.Infrastructure
{
    public interface IFirmRepository
    {
        Task<IList<Firmi>> GetFirmi(int faza, int rolq);
        Task<Firmi> GetFirma(string eik);

        #region montaj
        Task<IList<ViewFirmiIzpalniteli>> GetFirmiMontaz(int faza);
        Task <ViewFirmDogovor> GetMonDogovor(int iddog);
        Task<IList<ViewFirmDogovor>> GetMonDogovoriFirma(int idfirma);
        Task<int> SetMonDogovor(ViewFirmDogovor item);
        Task<IList<ViewFirmaDogovorUredi>> loadMonDogovorUredi(int iddogovor);
        Task<IList<ViewFirmDogovor>> loadMonDogovorPorychki(int iddogovor);

        #endregion

        #region demontaj
        Task<IList<ViewFirmiIzpalniteli>> GetFirmiDeMontaz(int faza);
        Task<ViewFirmDogovor> GetDeMonDogovor(int iddog);
        Task<int> SetDeMonDogovor(ViewFirmDogovor item);
        Task<IList<ViewFirmDogovor>> GetDeMonDogovoriFirma(int idfirma);
        Task<IList<ViewFirmaDogovorUredi>> loadDeMonDogovorUredi(int iddogovor);

        #endregion

    }
}
