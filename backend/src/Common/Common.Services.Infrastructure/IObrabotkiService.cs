using Common.DTO;
using Common.DTO.Obrabotki;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services.Infrastructure
{
    public interface IObrabotkiService
    {
        #region montazj       
        Task<IList<ListOrderDTO>> getMonListOrders(int faza);
        Task<OrderDTO> GetMonOrder(int id);
        Task<IList<UrediDogovorDTO>> getDogovorFirmaUredi(int iddogovorfirma);
        Task<IList<RaioniDogovorDTO>> getDogovorFirmaRaioni(int iddogovorfirma);
        Task<IList<PersUrediOrderDTO>> getPersonsWihtDogUredi(int iddogovorfirma, string raion, int faza);
        Task<IList<PersUrediOrderDTO>> getPersonUredi(int iddogovorfirma, int idlice);
        Task<int> setMonOrder(string pIdUser, OrderDTO item);
        Task<int> SetMonUrediDogovor(string iduser, List<UrediDogovorDTO> items);
        Task<int> DelMonUrediDogovor(int idporychkamain, int idlicedogovor);
        Task<int> DelMonOrder(int idporychkamain);
        Task<IList<ListOrderDTO>> getMonOrdersWithoutDemPorychka();
        Task<int> canDeleteMonOrder(int idporychkamain);

        #endregion

        #region demontazj       
        Task<IList<ListOrderDTO>> getDemonListOrders(int faza);
        Task<OrderDTO> GetDemonOrder(int id);
        Task<IList<UrediDogovorDTO>> getDemonDogovorFirmaUredi(int iddogovorfirma);
        Task<IList<RaioniDogovorDTO>> getDemonDogovorFirmaRaioni(int iddogovorfirma);
        Task<IList<PersUrediOrderDTO>> getDemonPersonsWihtDogUredi(int iddogovorfirma, string raion, int faza);
        Task<IList<PersUrediOrderDTO>> getDemonPersonUredi(int iddogovorfirma, int idlice);
        Task<int> setDemonOrder(string pIdUser, OrderDTO item);
        Task<int> SetDemonUrediDogovor(string iduser, List<UrediDogovorDTO> items);
        Task<int> DelDemonUrediDogovor(int idporychkamain, int idlicedogovor);
        Task<int> DelDemonOrder(int idporychkamain);
        Task<IList<PersUrediOrderDTO>> getDemonUrediFromMonPorychka(int iddogovorfirma, int idmonporychka);
        Task<int> setDemonOtchetUredi(string opos, string dogovor, string data);
        #endregion


        #region fakturi       
        Task<IList<ListFakturiDTO>> getMonListFakturi(int vid);
        Task<FakturaDTO> GetFaktura(int idfaktura);
        Task<int> SetFaktura(string pIdUser, FakturaDTO item);
        Task<int> DelFaktura(int idfaktura);
        Task<IList<ListAttachmentsDTO>> GetDocuments(int id, int typedoc);
        Task<DocumentDTO> GetDocument(int id);
        Task AddDocument(string pIdUser, DocumentDTO item);
        Task DelDocument(int id);
        #endregion

        #region profilaktika
        Task<IList<ProfOrderItemDTO>> getProfOrder(Filter1DTO filter);
        Task<int> setMonProfilaktika(int id, string otchdata, string note, int status_pf, int idprofilaktika);
        Task<IList<ProfOrderItemDTO>> getProfOrderById(int idprofilaktika);
        Task<int> getProfilaktikaNextId();
        #endregion
    }
}
