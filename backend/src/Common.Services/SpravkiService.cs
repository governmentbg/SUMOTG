using Common.DTO;
using Common.DTO.Spravki;
using Common.Entities;
using Common.Entities.Spravki;
using Common.Entities.Views;
using Common.Entities.Views.Spravki;
using Common.Repositories.Infrastructure;
using Common.Services.Infrastructure;
using Common.Utils;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
namespace Common.Services
{
    public class SpravkiService : BaseService, ISpravkiService
    {
        protected readonly ISpravkiRepository spravkiRepository;

        public SpravkiService(ISpravkiRepository spravkiRepository) : base()
        {
            this.spravkiRepository = spravkiRepository;
        }

        public async Task<IList<SpravkiDTO>> GetSpravki(int pFaza, bool includeDeleted = false)
        {
            var data = await spravkiRepository.GetSpravki(pFaza, includeDeleted);
            return data.Select(i => new SpravkiDTO
            {
                id = i.Id,
                Ime = i.Ime,
                Koment = i.Komentar,
                tip = i.Tip,
                nkod = i.nkod
            }).OrderBy(x=> x.nkod)
              .ToList();
        }


        public async Task<IList<Spravka1DTO>> GetSpravka1(Filter1DTO filter)
        {
            var flt1 = new Filter1
            {
                raionid = filter.raionid,
                ident = filter.ident,
                name = filter.name,
                unom = filter.unom,
                tochki = filter.tochki,
                faza = filter.faza,
            };

            var data = await spravkiRepository.GetSpravka1(flt1);
            return data.Select(i => new Spravka1DTO
            {
                idl = i.idl,
                idformulqr = i.idformulqr,
                unom = i.unom,
                Ime = i.Ime,
                tochki1 = i.tochki1,
                tochki2 = i.tochki2,
                tochki3 = i.tochki3,
                tochki4 = i.tochki4,
                tochki5 = i.tochki5,
                tochki6 = i.tochki6,
                tochki7 = i.tochki7,
                total = i.total,
                status = i.status
            }).ToList();
        }

        public async Task<IList<Spravka2DTO>> GetSpravka2(int type, FilterDTO filter)
        {
            var flt = new Filter
            {
                raionid = filter.raionid,
                tipuredi = filter.tipuredi,
                uredi = filter.uredi,
                olduredi = filter.olduredi,
                statusF = filter.statusF,
                statusDL = filter.statusDL,
                faza = filter.faza,
                unomer = filter.unomer,
                regnom = filter.regnom,
                adres = filter.adres,
                vid = filter.vid                
            };

            IList<ViewSpravka2> data;
            if (type == 2)
                data = await spravkiRepository.GetSpravka2a(flt);
            else
                data = await spravkiRepository.GetSpravka2(flt);

            return data.Select(i => new Spravka2DTO
            {
                idl = i.idl,
                idformulqr = i.idformulqr,
                unom = i.unom,
                raion = i.Raion,
                Ime = i.Ime,
                txturedi = i.txturedi,
                txtolduredi = i.txtolduredi,
                status = i.status,
                statusF = i.statusF,
                vidimot = i.vidimot,
                adres = i.adres,
                telefon = i.telefon,
                e_mail = i.e_mail,
                dognomer = i.dognomer,
                dogdate = (i.dogdate.HasValue ? String.Format("{0:dd.MM.yyyy}", i.dogdate) : ""),
                komentar = i.Comentar,
                dopspnom = i.DopSpRegN,
                dopspvid = i.DopSpVid

            }).ToList();
        }

        public async Task<IList<Spravka4DTO>> GetSpravka4(FilterDTO filter)
        {
            var flt = new Filter
            {
                raionid = filter.raionid,
                statusL = filter.statusL,
                statusF = filter.statusF,
                statusDL = filter.statusDL,
                faza = filter.faza,                
            };

            IList<ViewSpravka4> data = await spravkiRepository.GetSpravka4(flt);

            return data.Select(i => new Spravka4DTO
            {
                idl = i.idl,
                idformulqr = i.idformulqr,
                unom = i.unom,
                raion = i.raion,
                Ime = i.Ime,
                statusL = i.statusL,
                statusF = i.statusF,
                statusDL = i.statusDL,
            }).ToList();
        }

        public async Task<IList<Spravka5DTO>> GetSpravka5(FilterDTO filter)
        {
            var flt = new Filter
            {
                raionid = filter.raionid,
                tipuredi = filter.tipuredi,
                uredi = filter.uredi,
                statusU = filter.statusU,
                faza = filter.faza,
                unomer = filter.unomer,
                statusDL = filter.statusDL
            };

            IList<ViewSpravka5> data = await spravkiRepository.GetSpravka5(flt);

            return data.Select(i => new Spravka5DTO
            {
                idl = i.idl,
                idformulqr = i.idformulqr,
                unom = i.unom,
                raion = i.raion,
                Ime = i.Ime,
                adres = i.adres,
                nkod = i.nkod,
                ured = i.ured,
                statusU = i.statusU,
                broi = i.broi,
                idporychka = i.idporychka,
                regdog = i.regdog,
                statusDL = i.statusDL,
                tipuredime = i.tipuredime,
            }).ToList();
        }

        public async Task<IList<Spravka6DTO>> GetSpravka6(FilterDTO filter)
        {
            var flt = new Filter
            {
                uredi = filter.uredi,
                firma = filter.firma,
                dogovor = filter.dogovor
            };

            IList<ViewSpravka6> data = await spravkiRepository.GetSpravka6(flt);

            return data.Select(i => new Spravka6DTO
            {
                idfirma = i.idfirma,
                ime = i.ime,
                iddog = i.iddog,
                dogovor = i.dogovor,
                kodured = i.kodured,
                imeured = i.imeured,
                edcena = i.edcena,
                tspbroi = i.tspbroi,
                tsptotal = i.tsptotal,
                ordbroi = i.ordbroi,
                rembroi = i.rembroi,
                monbroi = i.monbroi,
                montotal = i.montotal,
                restbroi = i.restbroi,
                resttotal = i.resttotal,
            }).ToList();
        }

        public async Task<IList<Spravka7DTO>> GetSpravka7(FilterDTO filter)
        {
            var flt = new Filter
            {
                uredi = filter.uredi
            };

            IList<ViewSpravka7> data = await spravkiRepository.GetSpravka7(flt);

            return data.Select(i => new Spravka7DTO
            {
                kodured = i.kodured,
                imeured = i.imeured,
                edcena = i.edcena,
                tspbroi = i.tspbroi,
                tsptotal = i.tsptotal,
                ordbroi = i.ordbroi,
                monbroi = i.monbroi,
                montotal = i.montotal,
                restbroi = i.restbroi,
                resttotal = i.resttotal,
            }).ToList();
        }

        public async Task<IList<Spravka8DTO>> GetSpravka8(FilterDTO filter)
        {
            var flt = new Filter
            {
                faza = filter.faza,
                raionid = filter.raionid,
                tipuredi = filter.tipuredi,
                uredi = filter.uredi
            };

            IList<ViewSpravka8> data = await spravkiRepository.GetSpravka8(flt);

            return data.Select(i => new Spravka8DTO
            {
                kodured = i.kodured,
                imeured = i.imeured,
                dogbroi = i.dogbroi,
                ordbroi = i.ordbroi,
                tspbroi = i.tspbroi,
                inordbroi = i.inordbroi,
                restbroi = i.tspbroi - i.inordbroi,
                newrestbroi = i.dogbroi+i.ordbroi - (i.tspbroi - i.inordbroi),
            }).ToList();
        }

        public async Task<IList<Spravka5DTO>> GetSpravka9(FilterDTO filter)
        {
            var flt = new Filter
            {
                raionid = filter.raionid,
                olduredi = filter.olduredi,
                statusDU = filter.statusDU,
                faza = filter.faza,
                unomer = filter.unomer,
                statusDL = filter.statusDL
            };

            IList<ViewSpravka5> data = await spravkiRepository.GetSpravka9(flt);

            return data.Select(i => new Spravka5DTO
            {
                idl = i.idl,
                idformulqr = i.idformulqr,
                unom = i.unom,
                raion = i.raion,
                Ime = i.Ime,
                adres = i.adres,
                nkod = i.nkod,
                ured = i.ured,
                statusU = i.statusU,
                broi = i.broi,
                idporychka = i.idporychka,
                regdog = i.regdog,
                statusDL = i.statdog
            }).ToList();
        }

        public async Task<IList<Spravka6DTO>> GetSpravka10(FilterDTO filter)
        {
            var flt = new Filter
            {
                olduredi = filter.olduredi,
                demfirma = filter.demfirma,
                demdogovor = filter.demdogovor
            };

            IList<ViewSpravka6> data = await spravkiRepository.GetSpravka10(flt);

            return data.Select(i => new Spravka6DTO
            {
                idfirma = i.idfirma,
                ime = i.ime,
                iddog = i.iddog,
                dogovor = i.dogovor,
                kodured = i.kodured,
                imeured = i.imeured,
                edcena = i.edcena,
                tspbroi = i.tspbroi,
                tsptotal = i.tsptotal,
                ordbroi = i.ordbroi,
                rembroi = i.rembroi,
                monbroi = i.monbroi,
                montotal = i.montotal,
                restbroi = i.restbroi,
                resttotal = i.resttotal,
            }).ToList();
        }

        public async Task<IList<Spravka11DTO>> GetSpravka11(FilterDTO filter)
        {
            var flt = new Filter
            {
                raionid = filter.raionid,
                unomer = filter.unomer,
                firma = filter.firma,
                dogovor = filter.dogovor,
                statusG = filter.statusG,
                statusM = filter.statusM,
                porychkanom = filter.porychkanom,
                grafikdataot = filter.grafikdataot,
                grafikdatado = filter.grafikdatado,
                otchetdataot = filter.otchetdataot,
                otchetdatado = filter.otchetdatado
            };

            IList<ViewSpravka11> data = await spravkiRepository.GetSpravka11(flt);

            return data.Select(i => new Spravka11DTO
            {
                porychka = i.porychka,
                idfirma = i.idfirma,
                eik = i.eik,
                iddog = i.iddog,
                dogovor = i.dogovor,
                unomer = i.unomer,
                kodured = i.kodured,
                imeured = i.imeured,
                broi = i.broi,
                datag = i.datag,
                otchas = i.otchas,
                dochas = i.dochas,
                statusg = i.statusg,
                note = i.note,
                datam = i.datam,
                statusm = i.statusm,
                note2 = i.note2,
                ime = i.ime,
                adres = i.adres,
                model = i.model,
                fabrnomer = i.fabrnomer,
                garkarta = i.garkarta,
                gardata = i.gardata,
                protnomer = i.protnomer,
                protdata = i.protdata

            }).ToList();
        }

        public async Task<IList<Spravka11DTO>> GetSpravka12(FilterDTO filter)
        {
            var flt = new Filter
            {
                raionid = filter.raionid,
                unomer = filter.unomer,
                demfirma = filter.demfirma,
                demdogovor = filter.demdogovor,
                statusG = filter.statusG,
                statusM = filter.statusM,
                porychkanom = filter.demporychkanom,
                grafikdataot = filter.grafikdataot,
                grafikdatado = filter.grafikdatado,
                otchetdataot = filter.otchetdataot,
                otchetdatado = filter.otchetdatado
            };

            IList<ViewSpravka11> data = await spravkiRepository.GetSpravka12(flt);

            return data.Select(i => new Spravka11DTO
            {
                porychka = i.porychka,
                idfirma = i.idfirma,
                eik = i.eik,
                iddog = i.iddog,
                dogovor = i.dogovor,
                unomer = i.unomer,
                kodured = i.kodured,
                imeured = i.imeured,
                broi = i.broi,
                datag = i.datag,
                otchas = i.otchas,
                dochas = i.dochas,
                statusg = i.statusg,
                note = i.note,
                datam = i.datam,
                statusm = i.statusm,
                note2 = i.note2,
                ime = i.ime,
                adres = i.adres
            }).ToList();
        }
        public async Task<IList<Spravka13DTO>> GetSpravka13(FilterDTO filter)
        {
            var flt = new Filter
            {
                raionid = filter.raionid,
                tipuredi = filter.tipuredi,
            };

            IList<ViewSpravka13> data = await spravkiRepository.GetSpravka13(flt);

            return data.Select(i => new Spravka13DTO
            {
                kodured = i.kodured,
                imeured = i.imeured,
                l_dogbroi = i.l_dogbroi,
                l_ordbroi = i.l_ordbroi,
                l_inordbroi = i.l_inordbroi,
                p_ingrafik = i.p_ingrafik,
                p_inotchet = i.p_inotchet,
                p_montirani = i.p_montirani,
                l_otkazani = i.l_otkazani,
                p_otkazani = i.p_otkazani,
                p_izklucheni = i.p_izklucheni
            }).ToList();
        }

        public async Task<IList<Spravka14DTO>> GetSpravka14(FilterDTO filter)
        {
            var flt = new Filter
            {
                raionid = filter.raionid,
                porychkanom = filter.porychkanom,
                demporychkanom = filter.demporychkanom,
                firma = filter.firma,
                dogovor = filter.dogovor,
                unomer = filter.unomer
            };

            IList<ViewSpravka14> data = await spravkiRepository.GetSpravka14(flt);

            return data.Select(l => new Spravka14DTO
            {
                idl = l.idl,
                idformulqr = l.idformulqr,
                dognomer = l.dognomer,
                dogdate = l.dogdate,
                unom = l.unom,
                ime = l.ime,
                raion = l.raion,
                adres = l.adres,
                txturedi = l.txturedi,
                statusM = l.statusM,
                dataM = l.dataM,
                porychkaM = (l.porychkaM>0 ? l.porychkaM.ToString() : ""),
                izpalnitel = l.izpalnitel,
                izpdogovor = l.izpdogovor,
                txtolduredi = l.txtolduredi,
                statusD = l.statusD ,
                dataD = l.dataD ,
                porychkaD = (l.porychkaD > 0 ? l.porychkaD.ToString() : ""),
                statusDl = l.statusDl,
                txtkamina = l.txtkamina
            }).ToList();
        }

        public async Task<IList<Spravka15DTO>> GetSpravka15(FilterDTO filter)
        {
            var flt = new Filter
            {
                raionid = filter.raionid,
                dogovor = filter.dogovor,
                unomer = filter.unomer,
                dpregnom = filter.dpregnom,
                viddpspor = filter.viddpspor
            };

            IList<ViewSpravka15> data = await spravkiRepository.GetSpravka15(flt);

            return data.Select(l => new Spravka15DTO
            {
                idl = l.idl,
                idformulqr = l.idformulqr,
                unom = l.unom,
                raion = l.raion,
                dogovor = l.dogovor,
                statusDl = l.statusDl,
                dopspor = l.dopspor,
                viddopspor = l.viddopspor,
                komentar = l.komentar,
                koga = l.koga
            }).ToList();
        }

        public async Task<IList<Spravka20DTO>> GetSpravka20(FilterDTO filter)
        {
            var flt = new Filter
            {
                faza = filter.faza,
                raionid = filter.raionid
            };

            IList<ViewSpravka20> data = await spravkiRepository.GetSpravka20(flt);

            return data.Select(i => new Spravka20DTO
            {
                raion = i.raion,
                unom = i.unom,
                ime = i.ime,
                status = i.status,
                ime2 = i.ime2,
            }).ToList();
        }

        public async Task<IList<Spravka21DTO>> GetSpravka21(FilterDTO filter)
        {
            var flt = new Filter
            {
                faza = filter.faza,
            };

            IList<ViewSpravka21> data = await spravkiRepository.GetSpravka21(flt);

            return data.Select(i => new Spravka21DTO
            {
                nkod = i.nkod,
                raion = i.raion,
                formulqri = i.formulqri,
                dogovori = i.dogovori,
                doguredi = i.doguredi,
                monuredi = i.monuredi,
                monurpel = i.monurpel,
                monurgaz = i.monurgaz,
                monurklm = i.monurklm,
                monurrad = i.monurrad,
                monuredid = i.monuredid,
                monurpeld = i.monurpeld,
                monurgazd = i.monurgazd,
                monurklmd = i.monurklmd,
            }).ToList();
        }

        public async Task<IList<Spravka5DTO>> GetSpravka23(FilterDTO filter)
        {
            var flt = new Filter
            {
                raionid = filter.raionid,
                tipuredi = filter.tipuredi,
                uredi = filter.uredi,
                statusU = filter.statusU,
                faza = filter.faza,
                unomer = filter.unomer,
                statusDL = filter.statusDL
            };

            IList<ViewSpravka5> data = await spravkiRepository.GetSpravka23(flt);

            return data.Select(i => new Spravka5DTO
            {
                idl = i.idl,
                idformulqr = i.idformulqr,
                unom = i.unom,
                raion = i.raion,
                Ime = i.Ime,
                adres = i.adres,
                nkod = i.nkod,
                ured = i.ured,
                statusU = i.statusU,
                broi = i.broi,
                idporychka = i.idporychka,
                regdog = i.regdog,
                statusDL = i.statusDL,
                tipuredime = i.tipuredime,
            }).ToList();
        }

        public async Task<IList<Spravka24DTO>> GetSpravka24()
        {
            IList<ViewSpravka24> data = await spravkiRepository.GetSpravka24();

            return data.Select(i => new Spravka24DTO
            {
                idl = i.idl,
                idformulqr = i.idformulqr,
                opos = i.opos,
                ime = i.ime,
                adres = i.adres,
                status_dl = i.status_dl,
            }).ToList();
        }

        public async Task<IList<Spravka25DTO>> GetSpravka25(FilterDTO filter)
        {
            var flt = new Filter
            {
                raionid = filter.raionid,
                adres = filter.adres,
            };

            IList<ViewSpravka25> data = await spravkiRepository.GetSpravka25(flt);

            return data.Select(i => new Spravka25DTO
            {
                raion = i.raion,
                ime = i.ime,
                dbroi = i.dbroi,
                vbroi = i.vbroi,
                sbroi = i.sbroi,
                montazj = i.montazj,
                mbroi = i.mbroi,
                adres = i.adres,
                tel = i.tel,
                email = i.email,
                descript = i.descript,
            }).ToList();
        }

        public async Task<IList<OposPortretDTO>> GetOposPortret(FilterDTO filter)
        {
            var flt = new Filter
            {
                faza = filter.faza,
                unomer = filter.unomer,
                vidformulqr = filter.vidformulqr,
                vidportret = filter.vidportret
            };

            IList<ViewOposPortret> data = await spravkiRepository.GetOposPortret(flt);

            return data.Select(i => new OposPortretDTO
            {
                code = i.code,
                text = i.text,
                text2 = i.text2,
                isbold = i.isbold
            }).ToList();
        }

        public async Task<IList<Spravka50DTO>> GetSpravka50(FilterDTO filter)
        {
            var flt = new Filter
            {
                firma = filter.firma,
                limit = filter.limit
            };

            IList<ViewSpravka50> data = await spravkiRepository.GetSpravka50(flt);

            return data.Select(i => new Spravka50DTO
            {
                idured = i.idured,
                ured = i.ured,
                price = i.price,
                broi = i.broi,
                budget = i.budget,
                calcbudget = i.calcbudget,
                procbudget = i.procbudget
            }).ToList();
        }

        public async Task<IList<Spravka51DTO>> GetSpravka51(FilterDTO filter)
        {
            var flt = new Filter
            {
                tipuredi = filter.tipuredi,
                uredi = filter.uredi
            };

            IList<ViewSpravka51> data = await spravkiRepository.GetSpravka51(flt);

            return data.Select(i => new Spravka51DTO
            {
                idured = i.idured,
                ured = i.ured,
                price = i.price,
                broi = i.broi,
                budget = i.budget,
                calcbudget = i.calcbudget,
                procbudget = i.procbudget,
                tip = i.tip
            }).ToList();
        }
        public async Task<IList<Spravka52DTO>> GetSpravka52()
        {
            IList<ViewSpravka52> data = await spravkiRepository.GetSpravka52();

            return data.Select(i => new Spravka52DTO
            {
                id = i.id,
                nime = i.nime,
                broi = i.broi
            }).ToList();
        }

        public async Task<IList<Spravka53DTO>> GetSpravka53()
        {
            IList<ViewSpravka53> data = await spravkiRepository.GetSpravka53();

            return data.Select(i => new Spravka53DTO
            {
                idured = i.idured,
                nkod = i.nkod,
                nime = i.nime,
                broimon = i.broimon,
                broizaq = i.broizaq,
                price = i.price,
                budget = i.budget
            }).ToList();
        }

        public async Task<IList<Spravka54DTO>> GetSpravka54()
        {
            IList<ViewSpravka54> data = await spravkiRepository.GetSpravka54();

            return data.Select(i => new Spravka54DTO
            {
                vid = i.vid,
                col2 = i.col2,
                col3 = i.col3,
                col4 = i.col4,
                col5 = i.col5,
                col6 = i.col6,
                col7 = i.col7,
                col8 = i.col8,
                col9 = i.col9,
                col10 = i.col10,
                col11 = i.col11,
                col12 = i.col12,
            }).ToList();
        }
        public async Task<IList<Spravka55DTO>> GetSpravka55(int type)
        {
            IList<ViewSpravka55> data = await spravkiRepository.GetSpravka55(type);

            return data.Select(i => new Spravka55DTO
            {
                id = i.id,
                nime = i.nime,
                broi = i.broi,
                calc = i.calc,
                broiuredi = i.broiuredi,
                calcuredi = i.calcuredi
            }).ToList();
        }

        public async Task<IList<Spravka55DTO>> GetSpravka56()
        {
            IList<ViewSpravka55> data = await spravkiRepository.GetSpravka56();

            return data.Select(i => new Spravka55DTO
            {
                id = i.id,
                nime = i.nime,
                broi = i.broi,
                calc = i.calc
            }).ToList();
        }

        public async Task<IList<Spravka60DTO>> GetSpravka60(Filter1DTO filter)
        {
            var flt = new Filter1
            {
                raionid = filter.raionid,
                unomer = filter.unomer,
                firma = filter.firma,
                otdata = filter.otdata,
                dodata = filter.dodata,
                statusPF = filter.statusPF,
                porychkanom = filter.porychkanom,
                dogovor = filter.dogovor
            };

            IList<ViewSpravka60> data = await spravkiRepository.GetSpravka60(flt);

            return data.Select(i => new Spravka60DTO
            {
                raion = i.raion,
                unom = i.unom,
                ured = i.ured,
                ime= i.ime,
                adres = i.adres,
                period = i.period,
                pnomer = i.pnomer,
                data = i.data,
                otchdata = i.otchdata,
                status = i.status,
                idporychka = i.idporychka,
                note = i.note,
                dogfirma = i.dogfirma,
                namefirma = i.namefirma
            }).ToList();
        }
        public async Task<IList<Spravka60DTO>> GetSpravka61(Filter1DTO filter){
            var flt = new Filter1
            {
                raionid = filter.raionid,
                unomer = filter.unomer,
                otdata = filter.otdata,
                dodata = filter.dodata,
                firma = filter.firma,
                statusPF = filter.statusPF,
                porychkanom = filter.porychkanom,
                dogovor = filter.dogovor

            };

            IList<ViewSpravka60> data = await spravkiRepository.GetSpravka61(flt);

            return data.Select(i => new Spravka60DTO
                    {
                        raion = i.raion,
                        unom = i.unom,
                        ured = i.ured,
                        ime = i.ime,
                        adres = i.adres,
                        period = i.period,
                        pnomer = i.pnomer,
                        data = i.data,
                        otchdata = i.otchdata,
                        status = i.status,
                        idporychka = i.idporychka,
                        dogfirma = i.dogfirma,
                        namefirma = i.namefirma
            }).ToList();
        }

        public async Task<IList<Spravka70DTO>> GetSpravka70(int tip, Filter1DTO filter)
        {
            var flt = new Filter1();

            if (tip == 0)
            {
                DateTime sleddata = (filter.sleddata <= DateTime.Now ? filter.sleddata : new DateTime(2000, 1, 1));
                flt = new Filter1
                {
                    unomer = filter.unomer,
                    raionid = filter.raionid,
                    uredi = filter.uredi,
                    otdata = (sleddata < new DateTime(2000, 1, 1) ? new DateTime(2000, 1, 1) : sleddata),
                    dodata = DateTime.Now
                };
            }
            else
            {
                DateTime kymdata = (filter.kymdata >= DateTime.Now ? filter.kymdata : new DateTime(2100, 12, 31));

                flt = new Filter1
                {
                    unomer = filter.unomer,
                    raionid = filter.raionid,
                    uredi = filter.uredi,
                    otdata = DateTime.Now,
                    dodata = kymdata
                };
            }

            IList<ViewSpravka70> data = await spravkiRepository.GetSpravka70(tip, flt);

            return data.Select(i => new Spravka70DTO
            {
                raion = i.raion,
                unom = i.unom,
                ured = i.ured,
                ime = i.ime,
                adres = i.adres,
                srok = i.srok,
                data = i.data,
                idporychka = i.idporychka,
                dogfirma = i.dogfirma
            }).ToList();
        }

        public async Task<IList<Spravka78DTO>> GetSpravka72(int tip, Filter1DTO filter)
        {
            var flt = new Filter1();

            if (tip == 0)
            {
                DateTime sleddata = (filter.sleddata <= DateTime.Now ? filter.sleddata : new DateTime(2000, 1, 1));
                flt = new Filter1
                {
                    unomer = filter.unomer,
                    raionid = filter.raionid,
                    uredi = filter.uredi,
                    otdata = (sleddata < new DateTime(2000, 1, 1) ? new DateTime(2000, 1, 1) : sleddata),
                    dodata = DateTime.Now
                };
            }
            else
            {
                DateTime kymdata = (filter.kymdata >= DateTime.Now ? filter.kymdata : new DateTime(2100, 12, 31));

                flt = new Filter1
                {
                    unomer = filter.unomer,
                    raionid = filter.raionid,
                    uredi = filter.uredi,
                    otdata = DateTime.Now,
                    dodata = kymdata
                };
            }

            IList<ViewSpravka78> data = await spravkiRepository.GetSpravka72(tip, flt);

            return data.Select(i => new Spravka78DTO
            {
                raion = i.raion,
                unom = i.unom,
                dogovor = i.dogovor,
                ime = i.ime,
                adres = i.adres,
                srok = i.srok,
                data = i.data,
                iddogovor = i.iddogovor,
                dogfirma = i.dogfirma

            }).ToList();
        }

        public async Task<IList<Spravka78DTO>> GetSpravka78(Filter1DTO filter)
        {
            var flt = new Filter1
            {
                unomer = filter.unomer,
                raionid = filter.raionid,
                otdata = new DateTime(2000, 1, 1),
                dodata = (filter.kymdata < new DateTime(2000, 1, 1) ? filter.kymdata : filter.dodata),
            };

            IList<ViewSpravka78> data = await spravkiRepository.GetSpravka78(flt);

            return data.Select(i => new Spravka78DTO
            {
                raion = i.raion,
                unom = i.unom,
                dogovor = i.dogovor,
                ime = i.ime,
                adres = i.adres,
                srok = i.srok,
                data = i.data,
                iddogovor = i.iddogovor,
                dogfirma = i.dogfirma
            }).ToList();
        }

        public async Task<IList<Spravka70DTO>> GetSpravka79(Filter1DTO filter)
        {
            var flt = new Filter1
            {
                raionid = filter.raionid,
                unomer = filter.unomer,
                otdata = new DateTime(2000, 1, 1),
                dodata = filter.kymdata,
                uredi = filter.uredi
            };

            IList<ViewSpravka70> data = await spravkiRepository.GetSpravka70(0, flt);

            return data.Select(i => new Spravka70DTO
            {
                raion = i.raion,
                unom = i.unom,
                ured = i.ured,
                ime = i.ime,
                adres = i.adres,
                srok = i.srok,
                data = i.data,
                idporychka = i.idporychka,
            }).ToList();
        }

        public async Task<int> setPorychkaStatus(int idporychka, int status)
        {
            var data = await spravkiRepository.setPorychkaStatus(idporychka, status);
            return data;
        }

        public async Task<int> setPorychkaUnSign(int idporychka)
        {
            var data = await spravkiRepository.setPorychkaUnSign(idporychka);
            return data;
        }
    }
}