using Common.DTO;
using Common.DTO.Nomenclature;
using Common.Entities;
using Common.Entities.Views;
using Common.Repositories.Infrastructure;
using Common.Services.Infrastructure;
using Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Services
{
    public class NomenclatureService : BaseService, INomenclatureService
    {
        protected readonly INomenclatureRepository nomenclatureRepository;

        public NomenclatureService(INomenclatureRepository nomenclatureRepository) : base()
        {
            this.nomenclatureRepository = nomenclatureRepository;
        }


        public async Task<IList<NomenDTO>> GetNomenclatures(int pFaza, bool includeDeleted = false)
        {
            var data = await nomenclatureRepository.GetNomenclatures(pFaza, includeDeleted);
            return data.Select(i => new NomenDTO
            {
                KodNmn = i.KodNmn,
                TablicaVBazata = i.TablicaVBazata,
                Ime = i.Ime,
                Status = i.Status,
            }).ToList();
        }

        #region n_nomobshti
        public async Task<IList<NomObshtiDTO>> GetNomObshti(string pKod, int pFaza, bool includeDeleted = false) {
            var data = await nomenclatureRepository.GetNomObshti(pKod, pFaza, includeDeleted);
            return data.Select(i => new NomObshtiDTO
            {
                idkn = i.IdKn,
                kodnmn = i.KodNmn,
                kodpos = i.KodPozicia,
                Text = i.Text,
                status = i.Status,
            }).ToList();
        }

        public async Task<NomObshtiDTO> GetRowFormNomObshti(int id)
        {
            var data = await nomenclatureRepository.GetRowFormNomObshti(id);

            return new NomObshtiDTO
            {
                idkn = data.IdKn,
                kodnmn = data.KodNmn,
                kodpos = data.KodPozicia,
                Text = data.Text,
                status = data.Status,
            };
        }

        public async Task<int> AddRowFormNomObshti(NomObshtiDTO item)
        {
            var obj = new NNmnObshti()
            {
                KodNmn = item.kodnmn,
                KodPozicia = item.kodpos,
                Text = item.Text,
                Status = item.status,
                Faza = 0,
                Vypros = ""
            };
            return await nomenclatureRepository.AddRowFormNomObshti(obj);
        }
        public async Task<bool> SetRowFormNomObshti(NomObshtiDTO item)
        {
            var obj = new NNmnObshti()
            {
                IdKn = item.idkn,
                KodNmn = item.kodnmn,
                KodPozicia = item.kodpos,
                Text = item.Text,
                Status = item.status,
                Faza = 0,
                Vypros = ""
            };

            await nomenclatureRepository.SetRowFormNomObshti(obj);
            return true;
        }
        public async Task<bool> DelRowFormNomObshti(int id)
        {
            await nomenclatureRepository.DelRowFormNomObshti(id);
            return true;
        }

        #endregion


        #region n_nomrnJK
        public async Task<IList<NomJkDTO>> getNomenJk(int pFaza, bool includeDeleted = false)
        {
            var data = await nomenclatureRepository.getNomenJk(pFaza, includeDeleted);
            return data.Select(i => new NomJkDTO
            {
                nkod = i.Nkod,
                nime = i.Nime,
                status = i.Status,
            }).ToList();
        }

        public async Task<NomJkDTO> getRowNomenJk(string id)
        {
            var data = await nomenclatureRepository.getRowNomenJk(id);
            if (data != null)
                return new NomJkDTO
                {
                    nkod = data.Nkod,
                    nime = data.Nime,
                    status = data.Status
                };
            else
                return new NomJkDTO();
        }
        public async Task<bool> SetRowNomenJk(NomJkDTO item)
        {
            var obj = new NJk()
            {
                Nkod = item.nkod,
                Nime = item.nime,
                Status = item.status,
            };
            await nomenclatureRepository.SetRowNomenJk(obj);
            return true;
        }

        public async Task<int> AddRowNomenJk(NomJkDTO item)
        {
            var obj = new NJk()
            {
                Nkod = item.nkod,
                Nime = item.nime,
                Status = item.status,
            };
            return await nomenclatureRepository.AddRowNomenJk(obj);
        }

        public async Task<bool> DelRowNomenJk(string id)
        {
            await nomenclatureRepository.DelRowNomenJk(id);
            return true;
        }

        public async Task<String> getMaxKodJk()
        {
            return await nomenclatureRepository.getMaxKodJk();
        }
        #endregion


        #region n_nomkmetstva
        public async Task<IList<NomKmetstvoDTO>> getNomenKmetstva(int pFaza, bool includeDeleted = false)
        {
            var data = await nomenclatureRepository.getNomenKmetstva(pFaza, includeDeleted);
            return data.Select(i => new NomKmetstvoDTO
            {
                nkod = i.Nkod,
                nime = i.Nime,
                Status = i.Status
            }).ToList();
        }

        public async Task<NomKmetstvoDTO> getRowNomenKmetstva(string id)
        {
            var data = await nomenclatureRepository.getRowNomenKmetstva(id);
            return new NomKmetstvoDTO
            {
                nkod = data.Nkod,
                nime = data.Nime,
                Status = data.Status
            };
        }

        public async Task<bool> SetRowNomenKmetstva(NomKmetstvoDTO item)
        {
            var obj = new NKmetstva()
            {
                Nkod = item.nkod,
                Nime = item.nime,
                Status = item.Status,
            };
            await nomenclatureRepository.SetRowNomenKmetstva(obj);
            return true;
        }

        public async Task<int> AddRowNomenKmetstva(NomKmetstvoDTO item)
        {
            var obj = new NKmetstva()
            {
                Nkod = item.nkod,
                Nime = item.nime,
                Status = item.Status,
            };
            return await nomenclatureRepository.AddRowNomenKmetstva(obj);
        }

        public async Task<bool> DelRowNomenKmetstva(string id)
        {
            await nomenclatureRepository.DelRowNomenKmetstva(id);
            return true;
        }

        #endregion


        #region n_nomulici
        public async Task<IList<NomUlicaDTO>> getNomenUlici(int pFaza, bool includeDeleted = false)
        {
            var data = await nomenclatureRepository.getNomenUlici(pFaza, includeDeleted);
            return data.Select(i => new NomUlicaDTO
            {
                nkod = i.Nkod,
                nime = i.Nime,
                wnasm_nkod = i.WnasmNkod,
                wnuli_nkod = i.WnuliNkod,
                status = i.Status,
                wnasm = i.WnasmNime
            }).ToList();
        }

        public async Task<NomUlicaDTO> getRowNomenUlici(string id)
        {
            var data = await nomenclatureRepository.getRowNomenUlici(id);
            if (data != null)
                return new NomUlicaDTO
                {
                    nkod = data.Nkod,
                    nime = data.Nime,
                    wnasm_nkod = data.WnasmNkod,
                    wnuli_nkod = data.WnuliNkod,
                    status = data.Status,
                };
            else {
                return new NomUlicaDTO();
            }
        }

        public async Task<bool> SetRowNomenUlici(NomUlicaDTO item)
        {
            var obj = new NUlicii()
            {
                Nkod = item.nkod,
                Nime = item.nime,
                Status = item.status,
                WnasmNkod = item.wnasm_nkod,
                WnuliNkod = item.wnuli_nkod,

            };
            await nomenclatureRepository.SetRowNomenUlici(obj);
            return true;
        }

        public async Task<int> AddRowNomenUlici(NomUlicaDTO item)
        {
            var obj = new NUlicii()
            {
                Nkod = item.nkod,
                Nime = item.nime,
                Status = item.status,
                WnasmNkod = item.wnasm_nkod,
                WnuliNkod = item.wnuli_nkod,
            };
            return await nomenclatureRepository.AddRowNomenUlici(obj);
        }

        public async Task<bool> DelRowNomenUlici(string id)
        {
            await nomenclatureRepository.DelRowNomenUlici(id);
            return true;
        }

        public async Task<IList<NomUlicaDTO>> getUliciPerNsMqsto(string nkod)
        {
            var data = await nomenclatureRepository.getUliciPerNsMqsto(nkod);
            return data.Select(i => new NomUlicaDTO
            {
                nkod = i.Nkod,
                nime = i.Nime,
                wnasm_nkod = i.WnasmNkod,
                wnuli_nkod = i.WnuliNkod,
                status = i.Status,
                wnasm = i.WnasmNime
            }).ToList();
        }

        public async Task<String> getMaxKodUlici() {
            return await nomenclatureRepository.getMaxKodUlici();
        }

        #endregion n_ulici


        #region n_nomnsmesta
        public async Task<IList<NomNsMqstoDTO>> getNomenNsMesta(int pFaza, bool includeDeleted = false)
        {
            var data = await nomenclatureRepository.getNomenNsMesta(pFaza, includeDeleted);
            return data.Select(i => new NomNsMqstoDTO
            {
                nkod = i.Nkod,
                nime = i.Nime,
                Status = i.Status
            }).ToList();
        }

        public async Task<NomNsMqstoDTO> getRowNomenNsMesta(string id)
        {
            var data = await nomenclatureRepository.getRowNomenNsMesta(id);
            return new NomNsMqstoDTO
            {
                nkod = data.Nkod,
                nime = data.Nime,
                Status = data.Status
            };
        }
        public async Task<bool> SetRowNomenNsMesta(NomNsMqstoDTO item)
        {
            var obj = new NNsMestum()
            {
                Nkod = item.nkod,
                Nime = item.nime,
                Status = item.Status,
            };
            await nomenclatureRepository.SetRowNomenNsMesta(obj);
            return true;
        }

        public async Task<int> AddRowNomenNsMesta(NomNsMqstoDTO item)
        {
            var obj = new NNsMestum()
            {
                Nkod = item.nkod,
                Nime = item.nime,
                Status = item.Status,
            };
            return await nomenclatureRepository.AddRowNomenNsMesta(obj);
         }

        public async Task<bool> DelRowNomenNsMesta(string id)
        {
            await nomenclatureRepository.DelRowNomenNsMesta(id);
            return true;
        }

        public async Task<IList<NomNsMqstoDTO>> getNomenNsMestaByRaion(string pRaion)
        {
            var data = await nomenclatureRepository.getNomenNsMestaByRaion(pRaion);
            return data.Select(i => new NomNsMqstoDTO
            {
                nkod = i.Nkod,
                nime = i.Nime,
                Status = i.Status
            }).ToList();
        }
        #endregion n_nomnsmesta


        #region n_nomraioni
        public async Task<IList<NomRaionDTO>> getNomenRaioni(int pFaza, bool includeDeleted = false)
        {
            var data = await nomenclatureRepository.getNomenRaioni(pFaza, includeDeleted);
            return data.Select(i => new NomRaionDTO
            {
                nkod = i.Nkod,
                nime = i.Nime,
                Status = i.Status
            }).ToList();
        }

        public async Task<NomRaionDTO> getRowNomenRaioni(string id)
        {
            var data = await nomenclatureRepository.getRowNomenRaioni(id);
            return new NomRaionDTO
            {
                nkod = data.Nkod,
                nime = data.Nime,
                Status = data.Status,
            };
        }
        public async Task<bool> SetRowNomenRaioni(NomRaionDTO item)
        {
            var obj = new NRaioni()
            {
                Nkod = item.nkod,
                Nime = item.nime,
                Status = item.Status,
            };
            await nomenclatureRepository.SetRowNomenRaioni(obj);
            return true;
        }

        public async Task<int> AddRowNomenRaioni(NomRaionDTO item)
        {
            var obj = new NRaioni()
            {
                Nkod = item.nkod,
                Nime = item.nime,
                Status = item.Status,
            };
            return await nomenclatureRepository.AddRowNomenRaioni(obj);
         }

        public async Task<bool> DelRowNomenRaioni(string id)
        {
            await nomenclatureRepository.DelRowNomenRaioni(id);
            return true;
        }
        #endregion n_nomraioni



        #region n_nomuredi
        public async Task<IList<NomUrediDTO>> getNomenUredi(int pFaza, bool includeDeleted = false)
        {
            var data = await nomenclatureRepository.getNomenUredi(pFaza, includeDeleted);
            return data.Select(i => new NomUrediDTO
            {
                id = i.Id,
                faza = i.Faza,
                nkod = i.Nkod,
                nime = i.Nime,
                maxbr = i.MaxBr,
                doprad = i.DopRad,
                status = i.Status,
                kolectform = i.KolectForm,
                vid = i.Vid,
                nkod2 = i.Nkod2,
                nime2 = i.Nime2
            }).ToList();
        }
        public async Task<NomUrediDTO> getRowNomenUredi(int id)
        {
            var data = await nomenclatureRepository.getRowNomenUredi(id);
            return new NomUrediDTO
            {
                id = data.Id,
                faza = data.Faza,
                nkod = data.Nkod,
                nime = data.Nime,
                maxbr = data.MaxBr,
                doprad = data.DopRad,
                status = data.Status,
                kolectform = data.KolectForm,
                vid = data.Vid,
                nkod2 = data.Nkod2,
                nime2 = data.Nime2

            };
        }

        public async Task<int> SetRowNomenUredi(NomUrediDTO item)
        {
            var obj = new NUredi()
            {
                Id = item.id,
                Nkod = item.nkod,
                Nime = item.nime,
                MaxBr = item.maxbr,
                DopRad = item.doprad,
                Status = item.status,
                Faza = item.faza,
                KolectForm = item.kolectform,
                Vid = item.vid,
                Nkod2 = item.nkod2,
                Nime2 = item.nime2

            };
            await nomenclatureRepository.SetRowNomenUredi(obj);
            return 1;
        }

        public async Task<int> AddRowNomenUredi(NomUrediDTO item)
        {
            var obj = new NUredi()
            {
                Nkod = item.nkod,
                Nime = item.nime,
                MaxBr = item.maxbr,
                DopRad = item.doprad,
                Status = item.status,
                KolectForm = item.kolectform,
                Vid = item.vid,
                Nkod2 = item.nkod2,
                Nime2 = item.nime2
            };
            return await nomenclatureRepository.AddRowNomenUredi(obj);
        }

        public async Task<bool> DelRowNomenUredi(int id)
        {
            await nomenclatureRepository.DelRowNomenUredi(id);
            return true;
        }

        public async Task<IList<NomUrediDTO>> getKolektivNomenUredi(int pFaza)
        {
            var data = await nomenclatureRepository.getKolektivNomenUredi(pFaza);
            return data.Select(i => new NomUrediDTO
            {
                id = i.Id,
                faza = i.Faza,
                nkod = i.Nkod,
                nime = i.Nime,
                maxbr = i.MaxBr,
                doprad = i.DopRad,
                status = i.Status,
                kolectform = i.KolectForm,
                vid = i.Vid,
                nkod2 = i.Nkod2,
                nime2 = i.Nime2
            }).ToList();
        }
        #endregion n_nomuredi

        #region
        public async Task<IList<NomStatusDTO>> GetNomStatusi(string type)
        {
            var data = await nomenclatureRepository.GetNomStatusi(type);
            return data.Select(i => new NomStatusDTO
            {
                code = i.StatusCode,
                text = i.Text,
            }).ToList();
        }

        #endregion

        #region nkid
        public async Task<IList<NomKidDTO>> GetNomKid()
        {
            var data = await nomenclatureRepository.GetNomKid();
            return data.Select(i => new NomKidDTO
            {
                nkod = i.Nkod,
                nime = i.Nime,
                status = i.Status
            }).ToList();
        }

        #endregion

        #region extra adresi
        public async Task<IList<AllExtraAddrDTO>> getAllExtraAddresses()
        {
            var data = await nomenclatureRepository.getAllExtraAddresses();
            return data.Select(i => new AllExtraAddrDTO
            {
                id = i.id,
                tip = i.tip,
                opisanie = i.opisanie,
                status = i.status
            }).ToList();
        }

        public async Task<int> delExtraAddress(int id)
        {
            await nomenclatureRepository.delExtraAddress(id);
            return 0;
        }

        public async Task<int> addRowExtraAddress(ExtraAddrDTO item)
        {
            var obj = new FiltriAdres()
            {
                tip = item.tip,
                ARaion = item.admRaion,
                Nm = item.nasMqsto,
                Kv = item.kvartal,
                Jk = item.jk,
                Ul = item.ulica,
                Nomer = item.nomer,
                Blok = item.blok,
                Vh = item.vhod,
                Etaj = item.etaj,
                Ap = item.apart,
                Pk = item.postKode,
                status = item.status
            };
            return await nomenclatureRepository.addRowExtraAddress(obj);
        }
        public async Task<int> setRowExtraAddress(ExtraAddrDTO item)
        {
            var obj = new FiltriAdres()
            {
                Id = item.id,
                tip = item.tip,
                ARaion = item.admRaion,
                Nm = item.nasMqsto,
                Kv = item.kvartal,
                Jk = item.jk,
                Ul = item.ulica,
                Nomer = item.nomer,
                Blok = item.blok,
                Vh = item.vhod,
                Etaj = item.etaj,
                Ap = item.apart,
                Pk = item.postKode,
                status = item.status
            };
            return await nomenclatureRepository.setRowExtraAddress(obj);
        }

        public async Task<ExtraAddrDTO> getRowExtraAddress(int id)
        {
            var item = await nomenclatureRepository.getRowExtraAddress(id);
            return new ExtraAddrDTO
            {
                id = item.Id,
                tip = item.tip,
                admRaion = item.ARaion,
                nasMqsto = item.Nm,
                kvartal = item.Kv,
                jk = item.Jk,
                ulica = item.Ul,
                nomer = item.Nomer,
                blok = item.Blok,
                vhod = item.Vh,
                etaj = item.Etaj,
                apart = item.Ap,
                postKode = item.Pk,
                status = item.status
            };
        }

        #endregion

        #region
        public async Task<IList<NomUredBudgetDTO>> getAllNomenUrediBudget(int pFaza, bool includeDeleted)
        {
            var data = await nomenclatureRepository.getAllNomenUrediBudget(pFaza, includeDeleted);
            return data.Select(i => new NomUredBudgetDTO
            {
                id = i.id,
                faza = i.faza,
                nkod = i.nkod,
                nime = i.nime,
                quantity = i.quantity,
                price = i.price,
                status = i.status
            }).ToList();
        }
        public async Task<NomUredBudgetDTO> getRowNomenBudgetUredi(int id) {
            var data = await nomenclatureRepository.getRowNomenBudgetUredi(id);
            return new NomUredBudgetDTO
            {
                id = data.id,
                faza = data.faza,
                nkod = data.nkod,
                nime = data.nime,
                quantity = data.quantity,
                price = data.price,
                status = data.status
            };
        }

        public async Task<int> setRowNomenBudgetUredi(NomUredBudgetDTO item)
        {
            var obj = new ViewNomUredBudget()
            {
                id = item.id,
                faza = item.faza,
                nkod = item.nkod,
                nime = item.nime,
                quantity = item.quantity,
                price = item.price,
                status = item.status
            };
            return await nomenclatureRepository.setRowNomenBudgetUredi(obj);
        }
        #endregion

    }
}
