using Common.Entities;
using Common.Entities.Demontaz;
using Common.Entities.Fakturi;
using Common.Entities.Montaz;
using Common.Entities.Spravki;
using Common.Entities.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repositories.Infrastructure
{
    public interface IObrabotkiRepository
    {
        #region montazj
        Task<IList<ViewListOrder>> getMonListOrders(int faza);
        Task<ViewOrder> GetMonOrder(int id);
        Task<IList<ViewUrediOrder>> getDogovorFirmaUredi(int iddogovorfirma);
        Task<IList<MonRajoni>> getDogovorFirmaRaioni(int iddogovorfirma);
        Task<IList<ViewPersUrediOrder>> getPersonsWihtDogUredi(int iddogovorfirma, string raion, int faza);
        Task<IList<ViewPersUrediOrder>> getPersonUredi(int iddogovorfirma, int idlice);
        Task<IList<ViewMonOrderItem>> getPersonsDogovorUredi(int id);
        Task<int> setMonOrder(MonPorychkaMain item);
        Task SetPorychkaBody(int IdPorachkaMain, List<MonPorychka> items);
        Task DelPorychkaBody(int idPorychkaMain);
        Task SetLiceDogovorUredi(LicaDogovorUredi item);
        Task SetMonUrediDogovor(MonDgvUredi item);
        Task DelMonUrediDogovor(int idporychkamain, int idlicedogovor);
        Task UpdPorychkaBodyGrafik(int iddog, MonPorychka items);
        Task UpdPorychkaBodyOtchet(int iddog, MonPorychka items);
        Task DelМonOrder(int idporychkamain);
        Task<IList<ViewListOrder>> getMonOrdersWithoutDemPorychka();
        Task<int> canDeleteMonOrder(int idporychkamain);
        #endregion

        #region demontazj
        Task<IList<ViewListOrder>> getDemonListOrders(int faza);
        Task<ViewOrder> GetDemonOrder(int id);
        Task<IList<ViewUrediOrder>> getDemonDogovorFirmaUredi(int iddogovorfirma);
        Task<IList<MonRajoni>> getDemonDogovorFirmaRaioni(int iddogovorfirma);
        Task<IList<ViewPersUrediOrder>> getDemonPersonsWihtDogUredi(int iddogovorfirma, string raion, int faza);
        Task<IList<ViewPersUrediOrder>> getDemonPersonUredi(int iddogovorfirma, int idlice);
        Task<IList<ViewMonOrderItem>> getDemonPersonsDogovorUredi(int id);
        Task<int> setDemonOrder(DemPorychkaMain item);
        Task SetDemonPorychkaBody(int IdPorachkaMain, List<DemPorychka> items);
        Task DelDemonPorychkaBody(int idPorychkaMain);
        Task SetLiceDogovorOldUredi(LicaDogovorOldUredi item);
        Task SetDemonUrediDogovor(DemDgvOlduredi item);
        Task DelDemonUrediDogovor(int idporychkamain, int idlicedogovor);
        Task UpdDemPorychkaBodyGrafik(int iddog, DemPorychka items);
        Task UpdDemPorychkaBodyOtchet(int iddog, DemPorychka items);
        Task DelDemonOrder(int idporychkamain);
        Task<IList<ViewPersUrediOrder>> getDemonUrediFromMonPorychka(int iddogovorfirma, int idmonporychka);
        Task<int> setDemonOtchetUredi(string opos, string dogovor, string data);
        #endregion

        #region fakturi
        Task<IList<ViewListFakturi>> getMonListFakturi(int vid);
        Task<ViewFaktura> GetFaktura(int idfaktura);
        Task<int> SetFaktura(FacturiMain item);
        Task SetFakturaBody(FacturiRows data);
        Task<int> DelFaktura(int idFactura);
        Task DelFakturaBody(int idFactura);
        Task<List<FacturiDokumenti>> GetDocuments(int id, int typedoc);
        Task<FacturiDokumenti> GetDocument(int id);
        Task SetDocument(FacturiDokumenti data);
        Task DelDocument(int Id);
        #endregion

        #region profilaktika
        Task<IList<ProfOrderItem>> getProfOrder(Filter1 filter);
        Task<int> setMonProfilaktika(int id, string otchdata, string note, int status_pf, int idprofilaktika);
        Task<IList<ProfOrderItem>> getProfOrderById(int idprofilaktika);
        Task<int> getProfilaktikaNextId();
       #endregion
    }
}
