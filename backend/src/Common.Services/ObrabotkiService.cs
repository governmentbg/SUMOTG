using Common.DTO;
using Common.DTO.Obrabotki;
using Common.Entities;
using Common.Entities.Demontaz;
using Common.Entities.Fakturi;
using Common.Entities.Montaz;
using Common.Entities.Spravki;
using Common.Entities.Views;
using Common.Repositories.Infrastructure;
using Common.Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Services
{
    public class ObrabotkiService : BaseService, IObrabotkiService
    {
        protected readonly IObrabotkiRepository obrabotkiRepository;

        public ObrabotkiService(IObrabotkiRepository obrabotkiRepository) : base()
        {
            this.obrabotkiRepository = obrabotkiRepository;
        }

        #region porychki montazj
        public async Task<IList<ListOrderDTO>> getMonListOrders(int faza)
        {
            var data = await obrabotkiRepository.getMonListOrders(faza);
            return data.Select(f => new ListOrderDTO
            {
                nomer = f.nomer,
                faza = f.faza,
                data = f.data,
                idfirma = f.idfirma,
                eik = f.eik,
                ime = f.ime,
                email = f.email,
                telefon = f.telefon,
                idporychka = f.idporychka,
                dogovor = f.dogovor,
                statusPM = f.statusPM,
                status = f.status,
                note = f.note,
                spm = f.spm
            }).ToList();
        }

        public async Task<OrderDTO> GetMonOrder(int id)
        {
            var data = await obrabotkiRepository.GetMonOrder(id);
            return new OrderDTO
            {
                idporychkamain = data.idporychkamain,
                faza = data.faza,
                nomer = data.nomer,
                data = data.data,
                idfirma = data.idfirma,
                iddogovorfirma = data.iddogovorfirma,
                raion = data.raion,
                porychkaitems = convertViewOrderItemToOrderItemDTO(data.porychkaitems),
                status = data.status,
                startdata = data.startData,
                enddata = data.endData,
                status_pm = data.status_pm,
                note = data.note
            };
        }

        public async Task<IList<MonOrderItemDTO>> getPersonsDogovorUredi(int id)
        {
            var data = await obrabotkiRepository.getPersonsDogovorUredi(id);
            return data.Select(i => new MonOrderItemDTO
            {
                iddogovorlice = i.iddogovorlice,
                idl = i.idl,
                idured = i.idured,
                broi = i.broi,
            }).ToList();
        }

        public async Task<IList<UrediDogovorDTO>> getDogovorFirmaUredi(int iddogovorfirma)
        {
            var data = await obrabotkiRepository.getDogovorFirmaUredi(iddogovorfirma);
            return data.Select(f => new UrediDogovorDTO
            {
                idspdost = f.idspdost,
                id = f.id,
                name = f.name,
                edcena = f.edcena,
                broi = f.broi,
                maxbroi = f.maxbroi,
                broiporychani = f.broiporychani,
                vidured = f.vidured
            }).ToList();
        }

        public async Task<IList<RaioniDogovorDTO>> getDogovorFirmaRaioni(int iddogovorfirma)
        {
            var data = await obrabotkiRepository.getDogovorFirmaRaioni(iddogovorfirma);
            return data.Select(f => new RaioniDogovorDTO
            {
                nkod = f.Nkod,
            }).ToList();
        }


        public async Task<IList<PersUrediOrderDTO>> getPersonsWihtDogUredi(int iddogovorfirma, string raion, int faza)
        {
            var data = await obrabotkiRepository.getPersonsWihtDogUredi(iddogovorfirma, raion, faza);
            return data.Select(f => new PersUrediOrderDTO
            {
                iddogovorlice = f.iddogovorlice,
                IdL = f.IdL,
                ident = f.ident,
                ime = f.ime,
                adres = f.adres,
                vidimot = f.vidimot,
                email = f.email,
                telefon = f.telefon,
                ischeck = 0,
                unom = f.unom,
                uredname = f.uredname,
            }).ToList();
        }


        public async Task<IList<PersUrediOrderDTO>> getPersonUredi(int iddogovorfirma, int idlice)
        {
            var data = await obrabotkiRepository.getPersonUredi(iddogovorfirma, idlice);
            return data.Select(f => new PersUrediOrderDTO
            {
                iddogovorlice = f.iddogovorlice,
                idured = f.idured,
                broi = f.broi,
                IdL = f.IdL,
                ident = f.ident,
                ime = f.ime,
                adres = f.adres,
                vidimot = f.vidimot,
                email = f.email,
                telefon = f.telefon,
                ischeck = 0,
                unom = f.unom,
                uredname = f.uredname,
                vidured = f.vidured,
                raion = f.raion,
                note3 = f.note3
            }).ToList();
        }

        public async Task<int> setMonOrder(string pIdUser, OrderDTO item)
        {
            //dobawqne na formulqra
            var data = new MonPorychkaMain
            {
                IdPorachkaMain = item.idporychkamain,
                Faza = (short)item.faza,
                Nomer = item.nomer,
                Data = item.data,
                IdFirma = item.idfirma,
                IdDogovorFirma = item.iddogovorfirma,
                ARaion = item.raion,
                Status = item.status,
                StatusPM = item.status_pm,
                User = pIdUser,
                Koga = DateTime.Now,
                StartData = item.startdata,
                EndData = item.enddata,
                Note = item.note
            };

            int id = await obrabotkiRepository.setMonOrder(data);

            //dobawqne na porychkite
            if (item.status_pm == 1)
            {
                //updeitwame tehnicheskoto zadanie
                await SetMonUrediDogovor(pIdUser, item.uredi);

                await SetPorychkaBody(pIdUser, id, item.porychkaitems);
                //update na statusite na dog.uredi
                await SetLiceDogovorUredi(pIdUser, item.porychkaitems, 3);
            }
            else if (item.status_pm == 2)
            {
                //update na grafika na uredite
                await UpdPorychkaBodyGrafik(pIdUser, item.iddogovorfirma, item.porychkaitems);
            }
            else if (item.status_pm == 3)
            {
                //update na grafika na uredite
                await UpdPorychkaBodyOtchet(pIdUser, item.iddogovorfirma, item.porychkaitems);
            }
            else if (item.status_pm == 9)
            {
                //update na grafika na uredite
                await obrabotkiRepository.DelPorychkaBody(id);
            }
            return id;
        }

        public async Task<int> SetPorychkaBody(string pIdUser, int id, List<MonOrderItemDTO> items)
        {
             var data = items
                        .Where(x => x.idured > 0)
                        .Select(item => new MonPorychka
                        {
                            IdPorachkaMain = id,
                            IdDogovorLice = item.iddogovorlice,
                            IdUred = item.idured,
                            Model = item.model,
                            Broi = item.broi,
                            StatusG = (short)item.status_g,
                            DoData = item.dodata,
                            OtChas = item.otchas,
                            DoChas = item.dochas,
                            Note = item.note,
                            StatusM = (short)item.status_m,
                            MonData = item.mondata,
                            FabrNomer = item.fabrnomer,
                            GarCard = item.garkarta,
                            GarCardData = item.gardata,
                            ProtNomer = item.protnomer,
                            ProtData = item.protdata,
                            Status = (short)item.status,
                            Snimka = item.snimka,
                            User = pIdUser,
                            Koga = DateTime.Now,
                            Note2 = item.note2
                        })
                        .ToList();

            await obrabotkiRepository.SetPorychkaBody(id, data);
            return 1;
        }

        public async Task<int> UpdPorychkaBodyGrafik(string pIdUser, int iddog, List<MonOrderItemDTO> items)
        {
            var r = items.Where(x => x.status_g > 0 && x.status == 9).ToList();

            foreach (MonOrderItemDTO item in r)
            {
                var data = new MonPorychka
                {
                    IdPorachkaBody = item.idporychkabody,
                    IdDogovorLice = item.iddogovorlice,
                    IdUred = item.idured,
                    StatusG = (short)item.status_g,
                    DoData = item.dodata,
                    OtChas = item.otchas,
                    DoChas = item.dochas,
                    Note = item.note,
                    User = pIdUser,
                    Koga = DateTime.Now
                };

                await obrabotkiRepository.UpdPorychkaBodyGrafik(iddog, data);
            }

            return 1;
        }

        public async Task<int> UpdPorychkaBodyOtchet(string pIdUser, int iddog, List<MonOrderItemDTO> items)
        {
            var r = items.Where(x => x.status_m > 0 && x.status == 9).ToList();

            foreach (MonOrderItemDTO item in r)
            {
                var data = new MonPorychka
                {
                    IdPorachkaBody = item.idporychkabody,
                    StatusM = (short)item.status_m,
                    MonData = item.mondata,
                    FabrNomer = item.fabrnomer,
                    GarCard = item.garkarta,
                    GarCardData = item.gardata,
                    ProtNomer = item.protnomer,
                    ProtData = item.protdata,
                    Model = item.model,
                    Note2 = item.note2,
                    Snimka = item.snimka,
                    User = pIdUser,
                    Koga = DateTime.Now
                };

                await obrabotkiRepository.UpdPorychkaBodyOtchet(iddog, data);
            }

            return 1;
        }

        public async Task<int> SetLiceDogovorUredi(string pIdUser, List<MonOrderItemDTO> items, short status)
        {
            foreach (MonOrderItemDTO item in items)
            {
                if (item.idured > 0 && item.status_g == 0 && item.status_m==0)
                {
                    var data = new LicaDogovorUredi
                    {
                        IdDogL = item.iddogovorlice,
                        IdL = item.idl,
                        IdKt = item.idured,
                        StatusU = status,
                        User = pIdUser,
                        Koga = DateTime.Now,
                        Porychani = item.broi
                    };

                    await obrabotkiRepository.SetLiceDogovorUredi(data);
                }
            }

            return 1;
        }

        public async Task<int> SetMonUrediDogovor(string iduser, List<UrediDogovorDTO> items)
        {
            foreach (UrediDogovorDTO item in items)
            {
                if (item.idspdost > 0)
                {
                    var data = new MonDgvUredi
                    {
                        IdSpDost = item.idspdost,
                        Broi = item.broi,
                        User = iduser,
                        Koga = DateTime.Now
                    };

                    await obrabotkiRepository.SetMonUrediDogovor(data);
                }
            }

            return 1;
        }


        public async Task<int> DelMonUrediDogovor(int idporychkamain, int idlicedogovor)
        {
            await obrabotkiRepository.DelMonUrediDogovor(idporychkamain, idlicedogovor);
            return 1;
        }

        public async Task<int> DelMonOrder(int idporychkamain)
        {
            await obrabotkiRepository.DelМonOrder(idporychkamain);
            return 1;
        }

        public async Task<IList<ListOrderDTO>> getMonOrdersWithoutDemPorychka()
        {
            var data = await obrabotkiRepository.getMonOrdersWithoutDemPorychka();
            return data.Select(f => new ListOrderDTO
            {
                nomer = f.nomer,
                faza = f.faza,
                data = f.data,
                idfirma = f.idfirma,
                eik = f.eik,
                ime = f.ime,
                email = f.email,
                telefon = f.telefon,
                idporychka = f.idporychka,
                dogovor = f.dogovor,
                statusPM = f.statusPM,
                status = f.status,
                note = f.note,
                spm = f.spm
            }).ToList();
        }

        public async Task<int> canDeleteMonOrder(int idporychkamain)
        {
            return await obrabotkiRepository.canDeleteMonOrder(idporychkamain);
        }

        #endregion

        #region porychki demontazj
        public async Task<IList<ListOrderDTO>> getDemonListOrders(int faza)
        {
            var data = await obrabotkiRepository.getDemonListOrders(faza);
            return data.Select(f => new ListOrderDTO
            {
                nomer = f.nomer,
                faza = f.faza,
                data = f.data,
                idfirma = f.idfirma,
                eik = f.eik,
                ime = f.ime,
                email = f.email,
                telefon = f.telefon,
                idporychka = f.idporychka,
                dogovor = f.dogovor,
                statusPM = f.statusPM,
                status = f.status,
                note = f.note
            }).ToList();
        }

        public async Task<OrderDTO> GetDemonOrder(int id)
        {
            var data = await obrabotkiRepository.GetDemonOrder(id);
            return new OrderDTO
            {
                idporychkamain = data.idporychkamain,
                faza = data.faza,
                nomer = data.nomer,
                data = data.data,
                idfirma = data.idfirma,
                iddogovorfirma = data.iddogovorfirma,
                raion = data.raion,
                porychkaitems = convertViewOrderItemToOrderItemDTO(data.porychkaitems),
                status = data.status,
                startdata = data.startData,
                enddata = data.endData,
                status_pm = data.status_pm,
                note = data.note,
                idmonporychka = data.idmonporychka
            };
        }

        public async Task<IList<MonOrderItemDTO>> getDemonPersonsDogovorUredi(int id)
        {
            var data = await obrabotkiRepository.getDemonPersonsDogovorUredi(id);
            return data.Select(i => new MonOrderItemDTO
            {
                iddogovorlice = i.iddogovorlice,
                idl = i.idl,
                idured = i.idured,
                broi = i.broi,
            }).ToList();
        }

        public async Task<IList<UrediDogovorDTO>> getDemonDogovorFirmaUredi(int iddogovorfirma)
        {
            var data = await obrabotkiRepository.getDemonDogovorFirmaUredi(iddogovorfirma);
            return data.Select(f => new UrediDogovorDTO
            {
                idspdost = f.idspdost,
                id = f.id,
                name = f.name,
                edcena = f.edcena,
                broi = f.broi,
                maxbroi = f.maxbroi,
                broiporychani = f.broiporychani,
                vidured = f.vidured
            }).ToList();
        }

        public async Task<IList<RaioniDogovorDTO>> getDemonDogovorFirmaRaioni(int iddogovorfirma)
        {
            var data = await obrabotkiRepository.getDemonDogovorFirmaRaioni(iddogovorfirma);
            return data.Select(f => new RaioniDogovorDTO
            {
                nkod = f.Nkod,
            }).ToList();
        }


        public async Task<IList<PersUrediOrderDTO>> getDemonPersonsWihtDogUredi(int iddogovorfirma, string raion, int faza)
        {
            var data = await obrabotkiRepository.getDemonPersonsWihtDogUredi(iddogovorfirma, raion, faza);
            return data.Select(f => new PersUrediOrderDTO
            {
                iddogovorlice = f.iddogovorlice,
                IdL = f.IdL,
                ident = f.ident,
                ime = f.ime,
                adres = f.adres,
                vidimot = f.vidimot,
                email = f.email,
                telefon = f.telefon,
                ischeck = 0,
                unom = f.unom,
                uredname = f.uredname,
            }).ToList();
        }


        public async Task<IList<PersUrediOrderDTO>> getDemonPersonUredi(int iddogovorfirma, int idlice)
        {
            var data = await obrabotkiRepository.getDemonPersonUredi(iddogovorfirma, idlice);
            return data.Select(f => new PersUrediOrderDTO
            {
                iddogovorlice = f.iddogovorlice,
                idured = f.idured,
                broi = f.broi,
                IdL = f.IdL,
                ident = f.ident,
                ime = f.ime,
                adres = f.adres,
                vidimot = f.vidimot,
                email = f.email,
                telefon = f.telefon,
                ischeck = 0,
                unom = f.unom,
                uredname = f.uredname,
                vidured = f.vidured,
                raion = f.raion
            }).ToList();
        }

        public async Task<int> setDemonOrder(string pIdUser, OrderDTO item)
        {
            //dobawqne na formulqra
            var data = new DemPorychkaMain
            {
                IdPorachkaMain = item.idporychkamain,
                Faza = (short)item.faza,
                Nomer = item.nomer,
                Data = item.data,
                IdFirma = item.idfirma,
                IdDogovorFirma = item.iddogovorfirma,
                ARaion = item.raion,
                Status = item.status,
                StatusDM = item.status_pm,
                User = pIdUser,
                Koga = DateTime.Now,
                StartData = item.startdata,
                EndData = item.enddata,
                Note = item.note,
                IdMonPorachka = item.idmonporychka
            };

            int id = await obrabotkiRepository.setDemonOrder(data);

            //dobawqne na porychkite
            if (item.status_pm == 1)
            {
                //updeit na tehninicheskoto zadanie
                await SetDemonUrediDogovor(pIdUser, item.uredi);

                await SetDemonPorychkaBody(pIdUser, id, item.porychkaitems);
                //update na statusite na dog.uredi
                await SetLiceDogovorOldUredi(pIdUser, item.porychkaitems, 3);
            }
            else if (item.status_pm == 2)
            {
                //update na grafika na uredite
                await UpdDemPorychkaBodyGrafik(pIdUser, item.iddogovorfirma, item.porychkaitems);
            }
            else if (item.status_pm == 3)
            {
                //update na grafika na uredite
                await UpdDemPorychkaBodyOtchet(pIdUser, item.iddogovorfirma, item.porychkaitems);
            }
            else if (item.status_pm == 9)
            {
                // iztrivame uredite ot porychkata
                await obrabotkiRepository.DelDemonPorychkaBody(id);
            }

            return id;

        }

        public async Task<int> SetDemonPorychkaBody(string pIdUser, int id, List<MonOrderItemDTO> items)
        {

            var data = items
                       .Where(x => x.idured > 0)
                       .Select(item => new DemPorychka
                       {
                            IdPorachkaMain = id,
                            IdDogovorLice = item.iddogovorlice,
                            IdUred = item.idured,
                            Broi = item.broi,
                            StatusG = (short)item.status_g,
                            DoData = item.dodata,
                            OtChas = item.otchas,
                            DoChas = item.dochas,
                            Note = item.note,
                            StatusM = (short)item.status_m,
                            DemData = item.mondata,
                            Note2 = item.note2,
                            Snimka = item.snimka,
                            Status = (short)item.status,
                            User = pIdUser,
                            Koga = DateTime.Now
                        })
                        .ToList();

            await obrabotkiRepository.SetDemonPorychkaBody(id,data);

            return 1;
        }

        public async Task<int> UpdDemPorychkaBodyGrafik(string pIdUser, int iddog, List<MonOrderItemDTO> items)
        {
            var r = items.Where(x => x.status_g > 0 && x.status == 9).ToList();

            foreach (MonOrderItemDTO item in r)
            {
                var data = new DemPorychka
                {
                    IdPorachkaBody = item.idporychkabody,
                    IdDogovorLice = item.iddogovorlice,
                    IdUred = item.idured,
                    StatusG = (short)item.status_g,
                    DoData = item.dodata,
                    OtChas = item.otchas,
                    DoChas = item.dochas,
                    Note = item.note,
                    User = pIdUser,
                    Koga = DateTime.Now
                };

                await obrabotkiRepository.UpdDemPorychkaBodyGrafik(iddog, data);
            }

            return 1;
        }

        public async Task<int> UpdDemPorychkaBodyOtchet(string pIdUser, int iddog, List<MonOrderItemDTO> items)
        {
            var r = items.Where(x => x.status_m > 0 && x.status == 9).ToList();

            foreach (MonOrderItemDTO item in r)
            {
                var data = new DemPorychka
                {
                    IdPorachkaBody = item.idporychkabody,
                    StatusM = (short)item.status_m,
                    DemData = item.mondata,
                    Note2 = item.note2,
                    Snimka = item.snimka,
                    User = pIdUser,
                    Koga = DateTime.Now
                };

                await obrabotkiRepository.UpdDemPorychkaBodyOtchet(iddog, data);
            }

            return 1;
        }

        public async Task<int> SetLiceDogovorOldUredi(string pIdUser, List<MonOrderItemDTO> items, short status)
        {
            foreach (MonOrderItemDTO item in items)
            {
                if (item.idured > 0 && item.status_g == 0 && item.status_m == 0)
                {
                    var data = new LicaDogovorOldUredi
                    {
                        IdDogL = item.iddogovorlice,
                        IdL = item.idl,
                        IdKt = item.idured,
                        StatusDU = status,
                        User = pIdUser,
                        Koga = DateTime.Now,
                    };

                    await obrabotkiRepository.SetLiceDogovorOldUredi(data);
                }
            }

            return 1;
        }

        public async Task<int> SetDemonUrediDogovor(string iduser, List<UrediDogovorDTO> items)
        {
            foreach (UrediDogovorDTO item in items)
            {
                if (item.idspdost > 0)
                {
                    var data = new DemDgvOlduredi
                    {
                        IdSpDm = item.idspdost,
                        Broi = item.broi,
                        User = iduser,
                        Koga = DateTime.Now
                    };

                    await obrabotkiRepository.SetDemonUrediDogovor(data);
                }
            }

            return 1;
        }

        public async Task<int> DelDemonUrediDogovor(int idporychkamain, int idlicedogovor)
        {
            await obrabotkiRepository.DelDemonUrediDogovor(idporychkamain, idlicedogovor);
            return 1;
        }

        public async Task<int> DelDemonOrder(int idporychkamain)
        {
            await obrabotkiRepository.DelDemonOrder(idporychkamain);
            return 1;
        }

        public async Task<IList<PersUrediOrderDTO>> getDemonUrediFromMonPorychka(int iddogovorfirma, int idmonporychka)
        {
            var data = await obrabotkiRepository.getDemonUrediFromMonPorychka(iddogovorfirma, idmonporychka);
            return data.Select(f => new PersUrediOrderDTO
            {
                iddogovorlice = f.iddogovorlice,
                IdL = f.IdL,
                ident = f.ident,
                ime = f.ime,
                adres = f.adres,
                vidimot = f.vidimot,
                email = f.email,
                telefon = f.telefon,
                ischeck = 0,
                unom = f.unom,
                uredname = f.uredname,
            }).ToList();
        }

        public async Task<int> setDemonOtchetUredi(string opos, string dogovor, string data)
        {
            return await obrabotkiRepository.setDemonOtchetUredi(opos, dogovor, data);
        }

        #endregion



        #region fakturi
        public async Task<IList<ListFakturiDTO>> getMonListFakturi(int vid)
        {
            var data = await obrabotkiRepository.getMonListFakturi(vid);
            return data.Select(f => new ListFakturiDTO
            {
                idfaktura = f.idfaktura,
                faknomer = f.faknomer,
                fakdata = f.fakdata,
                idfirma = f.idfirma,
                eik = f.eik,
                ime = f.ime,
                total = f.total
            }).ToList();
        }

        public async Task<FakturaDTO> GetFaktura(int idfaktura)
        {
            var f = await obrabotkiRepository.GetFaktura(idfaktura);
            return new FakturaDTO
            {
                idfactura = f.idfactura,
                vidfirma = f.vidfirma,
                facnomer = f.facnomer,
                facdata = f.facdata,
                idfirma = f.idfirma,
                suma = f.suma,
                dds = f.dds,
                total = f.total,
                status = f.status,
                broifiles = f.broifiles,
                vidpayment = f.vidpayment,
                forperiod = f.forperiod,
                fakturaitems = convertViewFakturaItemToFakturaItemDTO(f.fakturaitems),
            };
        }


        public async Task<int> SetFaktura(string pIdUser, FakturaDTO item)
        {
            var f = new FacturiMain
            {
                IdFactura = item.idfactura,
                VidFirma = item.vidfirma,
                IdFirma = item.idfirma,
                FacNomer = item.facnomer,
                FacData = item.facdata,
                idDogovorFirma = item.iddogovorfirma,
                Suma = item.suma,
                DDS = item.dds,
                Total = item.total,
                BroiFiles = item.broifiles,
                Status = item.status,
                VidPayment = item.vidpayment,
                ForPeriod = item.forperiod,
            };

            int id = await obrabotkiRepository.SetFaktura(f);

            await SetFakturaBody(pIdUser, id, item.fakturaitems);

            return id;
        }

        public async Task<int> DelFaktura(int idfaktura)
        {
            return await obrabotkiRepository.DelFaktura(idfaktura);
        }

        private async Task<int> SetFakturaBody(string pIdUser, int id, List<FakturaItemDTO> items)
        {
            await obrabotkiRepository.DelFakturaBody(id);

            foreach (FakturaItemDTO item in items)
            {
                if (item.id != null) { 
                    var data = new FacturiRows
                    {
                        IdFactura = id,
                        IdKn = Int32.Parse(item.id.ToString()),
                        EdCena = item.edcena,
                        Broi = item.broi,
                        Suma = item.total,
                        Status = item.status
                    };
                    await obrabotkiRepository.SetFakturaBody(data);
                }
            }

            return id;
        }


        public async Task<IList<ListAttachmentsDTO>> GetDocuments(int id, int typedoc)
        {
            var data = await obrabotkiRepository.GetDocuments(id, typedoc);

            return data.Select(i => new ListAttachmentsDTO
            {
                id = i.IdDok,
                iddog = i.IdFactura,
                description = i.DocDescription,
                filename = i.FileName
            }).ToList();

        }

        public async Task<DocumentDTO> GetDocument(int id)
        {
            FacturiDokumenti data = await obrabotkiRepository.GetDocument(id);

            if (data != null)
                return new DocumentDTO
                {
                    doctype = data.DocType,
                    id = data.IdDok,
                    iddog = data.IdFactura,
                    filename = data.FileName,
                    savedfilename = data.SavedFileName
                };
            else
                return new DocumentDTO();
        }

        public async Task AddDocument(string pIdUser, DocumentDTO item)
        {
            FacturiDokumenti data = convertDocsDTOtoDocs(pIdUser, item);
            await obrabotkiRepository.SetDocument(data);
        }

        public async Task DelDocument(int id)
        {
            await obrabotkiRepository.DelDocument(id);
        }
        #endregion



        #region profilaktika
        public async Task<IList<ProfOrderItemDTO>> getProfOrder(Filter1DTO filter)
        {
            var flt = new Filter1
            {
                firma = filter.firma,
                dogovor = filter.dogovor,
                porychkanom = filter.porychkanom,
                statusPF = filter.statusPF                
            };

            var data = await obrabotkiRepository.getProfOrder(flt);

            return data.Select(f => new ProfOrderItemDTO
                {
                    id = f.id,
                    idporychkamain = f.idporychkamain,
                    idporychka = f.idporychka,
                    unom = f.unom,
                    idured = f.idured,
                    nkod = f.nkod,
                    nomer = f.nomer,
                    ured = f.ured,
                    broi = f.broi,
                    ime = f.ime,
                    adres = f.adres,
                    plandata = f.plandata,
                    otchdata = f.otchdata,
                    status = f.status,
                    status_pf = f.status_pf,
                    model = f.model,
                    note = f.note,
                    status_pfstr = f.status_pfstr,
                    idprofilaktika = f.idprofilaktika,
                    dogfirma = f.dogfirma,
                    namefirma = f.namefirma
            }).ToList();
        }

        public async Task<int> setMonProfilaktika(int id, string otchdata, string note, int status_pf, int idprofilaktika)
        {
            return await obrabotkiRepository.setMonProfilaktika(id, otchdata, note, status_pf, idprofilaktika);
        }

        public async Task<IList<ProfOrderItemDTO>> getProfOrderById(int idprofilaktika)
        {
            var data = await obrabotkiRepository.getProfOrderById(idprofilaktika);

            return data.Select(f => new ProfOrderItemDTO
            {
                id = f.id,
                idporychkamain = f.idporychkamain,
                idporychka = f.idporychka,
                unom = f.unom,
                idured = f.idured,
                nkod = f.nkod,
                nomer = f.nomer,
                ured = f.ured,
                broi = f.broi,
                ime = f.ime,
                adres = f.adres,
                plandata = f.plandata,
                otchdata = f.otchdata,
                status = f.status,
                status_pf = f.status_pf,
                model = f.model,
                note = f.note,
                status_pfstr = f.status_pfstr
            }).ToList();
        }


        public async Task<int> getProfilaktikaNextId()
        {
           return await obrabotkiRepository.getProfilaktikaNextId();
        }

        #endregion

        #region private ***************************************
        private FacturiDokumenti convertDocsDTOtoDocs(string pIdUser, DocumentDTO item)
        {
            return new FacturiDokumenti
            {
                IdDok = item.id,
                IdFactura = item.iddog,
                DocType = item.doctype,
                DocDescription = item.text,
                FileName = item.filename,
                Koga = DateTime.Now,
                User = pIdUser,
                Status = item.status,
                SavedFileName = item.savedfilename,
            };
        }
        private List<DocumentDTO> convertDocsToDocsDTO(List<FacturiDokumenti> data)
        {
            return data.Select(item => new DocumentDTO
            {
                iddog = item.IdDok,
                doctype = item.DocType,
                id = item.IdFactura,
                text = item.DocDescription,
                filename = item.FileName,
                status = item.Status,
                savedfilename = item.SavedFileName,
            }).ToList();
        }
        private List<FakturaItemDTO> convertViewFakturaItemToFakturaItemDTO(List<ViewFakturaItems> item)
        {
            if (item != null)
                return item.Select(data => new FakturaItemDTO
                {
                    idfactura = data.idfaktura,
                    id = data.idured.ToString(),
                    edcena = data.edcena,
                    broi = data.broi,
                    total = data.edcena* data.broi,
                    status = data.status,
                }).ToList();
            else
                return null;
        }

        private List<MonOrderItemDTO> convertViewOrderItemToOrderItemDTO(List<ViewMonOrderItem> item)
        {
            if (item != null)
                return item.Select(data => new MonOrderItemDTO
                {
                    idporychkabody = data.idporychkabody,
                    idl = data.idl,
                    unom = data.unom,
                    iddogovorlice = data.iddogovorlice,
                    idured = data.idured,
                    model = data.model,
                    broi = data.broi,
                    dodata = data.dodata,
                    otchas = data.otchas,
                    dochas = data.dochas,
                    note = data.note,
                    mondata = data.mondata,
                    protnomer = data.protnomer,
                    protdata = data.protdata,
                    fabrnomer = data.fabrnomer,
                    garkarta = data.garkarta,
                    gardata = data.gardata,
                    note2 = data.note2,
                    status_g = data.statusG,
                    status_m = data.statusM,
                    status = data.status,
                    uredname = data.uredname,
                    ident = data.ident,
                    ime = data.ime,
                    vidimot = data.vidimot,
                    adres = data.adres,
                    email = data.email,
                    telefon = data.telefon,
                    snimka = data.Snimka,
                    safeurl = data.Snimka,
                    vidured = data.vidured,
                    raion = data.raion,
                    note3 = data.note3
                }).ToList();
            else
                return null;
        }

        #endregion

    }
}
