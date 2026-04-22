using Common.DataAccess.EFCore;
using Common.Entities;
using Common.Entities.Nomenclatures;
using Common.Entities.Views;
using Common.Repositories.Infrastructure;
using Common.Services.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Repositories
{
    public class NomenclatureRepository : INomenclatureRepository
    {
        private readonly DataContext _dbContext;

        public NomenclatureRepository(DataContext context)
        {
            _dbContext = context;
        }
        public async Task<IList<NSpisykNmn>> GetNomenclatures(int pFaza, bool includeDeleted)
        {
            if (includeDeleted)
                return await _dbContext.Set<NSpisykNmn>()
                    .Where(obj => (obj.Faza == pFaza || obj.Faza == 0))
                    .ToListAsync();
            else
                return await _dbContext.Set<NSpisykNmn>()
                    .Where(obj => (obj.Faza == pFaza || obj.Faza == 0)
                                && (obj.Status == 1))
                    .ToListAsync();
        }

        #region n_nomobshti
        public async Task<IList<NNmnObshti>> GetNomObshti(string pKod, int pFaza, bool includeDeleted)
        {
            if (includeDeleted)
                return await _dbContext.Set<NNmnObshti>()
                   .Where(obj => (obj.KodNmn == pKod)
                            && (obj.Faza == pFaza || obj.Faza == 0)
                          )
                   .OrderBy(x => x.KodPozicia)
                   .ToListAsync();
            else
                return await _dbContext.Set<NNmnObshti>()
                   .Where(obj => (obj.KodNmn == pKod)
                            && (obj.Faza == pFaza || obj.Faza == 0)
                            && (obj.Status == 1)
                          )
                   .OrderBy(x => x.KodPozicia)
                   .ToListAsync();
        }

        public async Task<NNmnObshti> GetRowFormNomObshti(int id)
        {
            return await _dbContext
                    .Set<NNmnObshti>()
                    .Where(obj => obj.IdKn == id)
                    .FirstOrDefaultAsync();
        }
        public async Task SetRowFormNomObshti(NNmnObshti item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<int> AddRowFormNomObshti(NNmnObshti item)
        {
            var result = _dbContext.NNmnObshtis
                            .SingleOrDefault(b => b.Faza == item.Faza
                                       && b.KodNmn == item.KodNmn
                                       && b.KodPozicia == item.KodPozicia
                                       && b.Status == 1);
            if (result == null)
            {
                _dbContext.Entry(item).State = EntityState.Added;
                await _dbContext.SaveChangesAsync();
                return 1;
            } else
            {
                return -1;
            }

        }
        public Task<int> DelRowFormNomObshti(int id)
        {
            var result = _dbContext.NNmnObshtis.SingleOrDefault(b => b.IdKn == id);
            if (result != null)
            {
                _dbContext.Entry(result).State = EntityState.Deleted;
                _dbContext.SaveChanges();
            }
            return Task.FromResult(1);
        }

        #endregion

        #region n_nomjk
        public async Task<IList<NJk>> getNomenJk(int pFaza, bool includeDeleted)
        {
            if (includeDeleted)
                return await _dbContext.NJks
                    .ToListAsync();
            else
                return await _dbContext.NJks
                    .Where(x => x.Status == 1)
                    .ToListAsync();
        }
        public async Task<NJk> getRowNomenJk(string id)
        {
            return await _dbContext
                   .Set<NJk>()
                   .Where(obj => obj.Nkod == id)
                   .FirstOrDefaultAsync();
        }

        public async Task SetRowNomenJk(NJk item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<int> AddRowNomenJk(NJk item)
        {
            var result = _dbContext.NJks
                             .SingleOrDefault(b => b.Nkod == item.Nkod
                                            && b.Status == 1);
            if (result == null)
            {
                _dbContext.Entry(item).State = EntityState.Added;
                await _dbContext.SaveChangesAsync();
                return 1;
            }
            else
            {
                return -1;
            }
        }

        public Task<int> DelRowNomenJk(string id)
        {
            var result = _dbContext.NJks.SingleOrDefault(b => b.Nkod == id);
            if (result != null)
            {
                _dbContext.Entry(result).State = EntityState.Deleted;
                _dbContext.SaveChanges();
            }
            return Task.FromResult(1);
        }

        public async Task<string> getMaxKodJk()
        {
            int number = _dbContext.NJks.Max(p => Convert.ToInt32(p.Nkod));
            number += 1;
            return number.ToString("D3");
        }
        #endregion

        #region n_nomkmetstva
        public async Task<IList<NKmetstva>> getNomenKmetstva(int pFaza, bool includeDeleted)
        {
            if (includeDeleted)
                return await _dbContext.NKmetstvas.ToListAsync();
            else
                return await _dbContext.NKmetstvas
                    .Where(x => x.Status == 1)
                    .ToListAsync();
        }
        public async Task<NKmetstva> getRowNomenKmetstva(string id)
        {
            return await _dbContext.NKmetstvas
                  .Where(obj => obj.Nkod == id)
                  .FirstOrDefaultAsync();
        }

        public async Task SetRowNomenKmetstva(NKmetstva item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<int> AddRowNomenKmetstva(NKmetstva item)
        {
            var result = _dbContext.NKmetstvas
                              .SingleOrDefault(b => b.Nkod == item.Nkod
                                             && b.Status == 1);
            if (result == null)
            {
                _dbContext.Entry(item).State = EntityState.Added;
                await _dbContext.SaveChangesAsync();
                return 1;
            }
            else
            {
                return -1;
            }
        }

        public Task<int> DelRowNomenKmetstva(string id)
        {
            var result = _dbContext.NKmetstvas.SingleOrDefault(b => b.Nkod == id);
            if (result != null)
            {
                _dbContext.Entry(result).State = EntityState.Deleted;
                _dbContext.SaveChanges();
            }
            return Task.FromResult(1);
        }
        #endregion


        #region n_nomulici
        public async Task<IList<ViewNUlici>> getNomenUlici(int pFaza, bool includeDeleted)
        {
            if (includeDeleted)
                return await (from u in _dbContext.NUliciis
                              from n in _dbContext.NNsMesta
                                       .Where(m => m.Nkod == u.WnasmNkod)
                                       .DefaultIfEmpty()
                              select new ViewNUlici
                              {
                                  Nkod = u.Nkod,
                                  WnasmNkod = u.WnasmNkod,
                                  WnuliNkod = u.WnuliNkod,
                                  Nime = u.Nime,
                                  KodNmn = u.KodNmn,
                                  Status = u.Status,
                                  WnasmNime = n.Nime
                              }).ToListAsync();
            else
                return await (from u in _dbContext.NUliciis
                            .Where(m => m.Status == 1)
                              from n in _dbContext.NNsMesta
                                  .Where(m => m.Nkod == u.WnasmNkod)
                                  .DefaultIfEmpty()
                              select new ViewNUlici
                              {
                                  Nkod = u.Nkod,
                                  WnasmNkod = u.WnasmNkod,
                                  WnuliNkod = u.WnuliNkod,
                                  Nime = u.Nime,
                                  KodNmn = u.KodNmn,
                                  Status = u.Status,
                                  WnasmNime = n.Nime
                              }).ToListAsync();

        }

        public async Task<NUlicii> getRowNomenUlici(string id)
        {
            return await _dbContext
                   .Set<NUlicii>()
                   .Where(obj => obj.Nkod == id)
                   .FirstOrDefaultAsync();

        }

        public async Task SetRowNomenUlici(NUlicii item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<int> AddRowNomenUlici(NUlicii item)
        {
            var result = _dbContext.NUliciis
                              .SingleOrDefault(b => b.Nkod == item.Nkod
                                             && b.Status == 1);
            if (result == null)
            {
                _dbContext.Entry(item).State = EntityState.Added;
                await _dbContext.SaveChangesAsync();
                return 1;
            }
            else
            {
                return -1;
            }

        }

        public Task<int> DelRowNomenUlici(string id)
        {
            var result = _dbContext.NUliciis.SingleOrDefault(b => b.Nkod == id);
            if (result != null)
            {
                _dbContext.Entry(result).State = EntityState.Deleted;
                _dbContext.SaveChanges();
            }
            return Task.FromResult(1);
        }

        public async Task<IList<ViewNUlici>> getUliciPerNsMqsto(string nkod)
        {
            return await (from u in _dbContext.NUliciis
                            .Where(m => m.Status == 1 && m.WnasmNkod == nkod)
                          select new ViewNUlici
                          {
                              Nkod = u.Nkod,
                              WnasmNkod = u.WnasmNkod,
                              WnuliNkod = u.WnuliNkod,
                              Nime = u.Nime,
                              KodNmn = u.KodNmn,
                              Status = u.Status,
                          }).ToListAsync();

        }

        public async Task<string> getMaxKodUlici()
        {
            var data = _dbContext.NUliciis.Max(p => p.Nkod);
            int number = Convert.ToInt32(data);
            number += 1;
            return number.ToString("D5");
        }
        #endregion n_ulici


        #region n_nomnsmesta
        public async Task<IList<NNsMestum>> getNomenNsMesta(int pFaza, bool includeDeleted)
        {
            if (includeDeleted)
                return await _dbContext.NNsMesta.ToListAsync();
            else
                return await _dbContext.NNsMesta.Where(x => x.Status == 1)
                .ToListAsync();
        }

        public async Task<NNsMestum> getRowNomenNsMesta(string id)
        {
            return await _dbContext.NNsMesta
                   .Where(obj => obj.Nkod == id)
                   .FirstOrDefaultAsync();
        }

        public async Task SetRowNomenNsMesta(NNsMestum item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<int> AddRowNomenNsMesta(NNsMestum item)
        {
            var result = _dbContext.NNsMesta
                               .SingleOrDefault(b => b.Nkod == item.Nkod
                                              && b.Status == 1);
            if (result == null)
            {
                _dbContext.Entry(item).State = EntityState.Added;
                await _dbContext.SaveChangesAsync();
                return 1;
            }
            else
            {
                return -1;
            }

        }

        public Task<int> DelRowNomenNsMesta(string id)
        {
            var result = _dbContext.NNsMesta.SingleOrDefault(b => b.Nkod == id);
            if (result != null)
            {
                _dbContext.Entry(result).State = EntityState.Deleted;
                _dbContext.SaveChanges();
            }

            return Task.FromResult(1);
        }

        public async Task<IList<NNsMestum>> getNomenNsMestaByRaion(string pRaion)
        {
            if (pRaion == "21" || pRaion == "23" || pRaion == "24")
                return await _dbContext.NNsMesta
                                .Where(x => x.Status == 1 && x.Kmetstvo == pRaion)
                                .OrderBy(x => x.KodNmn)
                                .ToListAsync();
            else
                return await _dbContext.NNsMesta
                                .Where(x => x.Status == 1 && (x.Kmetstvo == pRaion || x.Kmetstvo == "01"))
                                .OrderBy(x=> x.KodNmn)
                                .ToListAsync();

        }

        #endregion n_nomnsmesta


        #region n_nomraioni
        public async Task<IList<NRaioni>> getNomenRaioni(int pFaza, bool includeDeleted)
        {
            if (includeDeleted)
                return await _dbContext.NRaionis.ToListAsync();
            else
                return await _dbContext.NRaionis.Where(x => x.Status == 1)
                .ToListAsync();

        }
        public async Task<NRaioni> getRowNomenRaioni(string id)
        {
            return await _dbContext
                   .Set<NRaioni>()
                   .Where(obj => obj.Nkod == id)
                   .FirstOrDefaultAsync();

        }

        public async Task SetRowNomenRaioni(NRaioni item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<int> AddRowNomenRaioni(NRaioni item)
        {
            var result = _dbContext.NRaionis
                               .SingleOrDefault(b => b.Nkod == item.Nkod
                                              && b.Status == 1);
            if (result == null)
            {
                _dbContext.Entry(item).State = EntityState.Added;
                await _dbContext.SaveChangesAsync();
                return 1;
            }
            else
            {
                return -1;
            }
        }

        public Task<int> DelRowNomenRaioni(string id)
        {
            var result = _dbContext.NRaionis.SingleOrDefault(b => b.Nkod == id);
            if (result != null)
            {
                _dbContext.Entry(result).State = EntityState.Deleted;
                _dbContext.SaveChanges();
            }
            return Task.FromResult(1);
        }

        #endregion n_nomraioni


        #region n_nomuredi
        public async Task<IList<NUredi>> getNomenUredi(int pFaza, bool includeDeleted)
        {
            var data = (from f in _dbContext.NUredi
                        select new NUredi()
                        {
                            Id = f.Id,
                            Faza = f.Faza,
                            Nkod = f.Nkod,
                            Nime = f.Nime,
                            MaxBr = f.MaxBr,
                            DopRad = f.DopRad,
                            Status = f.Status,
                            KolectForm = f.KolectForm,
                            Vid = f.Vid,
                            Nkod2 = f.Nkod2,
                            Nime2 = f.Nime2
                        });

            if (!includeDeleted)
                data = data.Where(x => x.Status == 1);

            if (pFaza > 0)
                data = data.Where(x => x.Faza == 0 || x.Faza == pFaza);


            return await data
                .OrderBy(x => x.Nkod)
                .ToListAsync();
        }

        public async Task<NUredi> getRowNomenUredi(int id)
        {
            return await _dbContext.NUredi
                   .Where(obj => obj.Id == id)
                   .FirstOrDefaultAsync();
        }

        public async Task SetRowNomenUredi(NUredi item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<int> AddRowNomenUredi(NUredi item)
        {
            var result = _dbContext.NUredi
                               .SingleOrDefault(b => b.Faza == item.Faza
                                              && b.Nkod == item.Nkod
                                              && b.Status == 1);
            if (result == null)
            {
                _dbContext.Entry(item).State = EntityState.Added;
                await _dbContext.SaveChangesAsync();
                return 1;
            }
            else
            {
                return -1;
            }
        }

        public Task<int> DelRowNomenUredi(int id)
        {
            var result = _dbContext.NUredi.SingleOrDefault(b => b.Id == id);
            if (result != null)
            {
                _dbContext.Entry(result).State = EntityState.Deleted;
                _dbContext.SaveChanges();
            }
            return Task.FromResult(1);
        }
        public async Task<IList<NUredi>> getKolektivNomenUredi(int pFaza)
        {
            return await _dbContext.NUredi
                .Where(x => (x.Faza == 0 || x.Faza == pFaza) && x.Status == 1 && x.KolectForm == 1)
                .OrderBy(x => x.Nkod)
                .ToListAsync();
        }

        #endregion n_nomuredi    

        #region
        public async Task<IList<NStatusi>> GetNomStatusi(string type)
        {
            return await _dbContext.NStatusis
                 .Where(x => x.StatusName == type && x.Status == 1)
                 .OrderBy(x => x.StatusCode)
                 .ToListAsync();
        }

        #endregion

        #region nkid
        public async Task<IList<NKid>> GetNomKid()
        {
            return await _dbContext.NKid
                 .Where(x => x.Status == 1)
                 .OrderBy(x => x.Nkod)
                 .ToListAsync();
        }

        #endregion

        #region extra adresi
        public async Task<IList<ViewFiltriAdres>> getAllExtraAddresses()
        {
            string lcsql = "select id,tip,dbo.genFullAddress(A_Raion,NM,JK,UL,Nomer,Blok,vh,etaj,AP) opisanie" +
                           ", status from filtri_adresi";

            var data = _dbContext.ViewFiltriAdres.FromSqlRaw(lcsql);

            return await data
                        .Select(i => new ViewFiltriAdres
                        {
                            id = i.id,
                            tip = (Int16)(i.tip),
                            opisanie = i.opisanie,
                            status = i.status
                        })
                        .OrderBy(x=>x.tip)
                        .ToListAsync();
        }

        public Task<int> delExtraAddress(int id)
        {
            var result = _dbContext.FiltriAdres.SingleOrDefault(b => b.Id == id);
            if (result != null)
            {
                _dbContext.Entry(result).State = EntityState.Deleted;
                _dbContext.SaveChanges();
            }
            return Task.FromResult(1);
        }

        public async Task<int> addRowExtraAddress(FiltriAdres item)
        {
            var result = _dbContext.FiltriAdres
                                .SingleOrDefault(b => b.Id == item.Id);
            if (result == null)
            {
                _dbContext.Entry(item).State = EntityState.Added;
                await _dbContext.SaveChangesAsync();
                return 1;
            }
            else
            {
                return -1;
            }
        }
        public async Task<int> setRowExtraAddress(FiltriAdres item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return 0;
        }

        public async Task<FiltriAdres> getRowExtraAddress(int id)
        {
            return await _dbContext
                               .Set<FiltriAdres>()
                               .Where(obj => obj.Id == id)
                               .FirstOrDefaultAsync();
        }

        #endregion

        #region n_uredi_budget
        public async Task<IList<ViewNomUredBudget>> getAllNomenUrediBudget(int pFaza, bool includeDeleted)
        {
            var data = from f in _dbContext.NUredi
                       where f.Status == 1
                       from l in _dbContext.NUrediBudget
                       where f.Id ==  l.Id
                       select new ViewNomUredBudget
                       {
                           id = f.Id,
                           faza = f.Faza,
                           nkod = f.Nkod, 
                           nime  = f.Nime, 
                           quantity  = l.Quantity,
                           price  = l.Price,
                           status  = f.Status
                       };

            return await data
                    .OrderBy(x => x.nkod)
                    .ToListAsync();
        }

        public async Task<ViewNomUredBudget> getRowNomenBudgetUredi(int id)
        {
            var data = from f in _dbContext.NUredi
                       where f.Status == 1 && f.Id == id
                       from l in _dbContext.NUrediBudget
                       where f.Id == l.Id 
                       select new ViewNomUredBudget
                       {
                           id = f.Id,
                           faza = f.Faza,
                           nkod = f.Nkod,
                           nime = f.Nime,
                           quantity = l.Quantity,
                           price = l.Price,
                           status = f.Status
                       };

            return await data.FirstOrDefaultAsync();
        }
        public async Task<int> setRowNomenBudgetUredi(ViewNomUredBudget item)
        {
            var result = _dbContext.NUrediBudget
                     .SingleOrDefault(b => b.Id == item.id);

            if (result != null)
            {
                result.Quantity = item.quantity;
                result.Price = item.price;

                _dbContext.Entry(result).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return 1;
            }

            return 0;
        }
        #endregion
    }
}
