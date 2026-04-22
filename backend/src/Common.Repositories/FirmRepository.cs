using Common.DataAccess.EFCore;
using Common.Entities;
using Common.Entities.Views;
using Common.Repositories.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Repositories
{
    public class FirmRepository : IFirmRepository
    {
        private readonly DataContext _dbContext;

        public FirmRepository(DataContext context)
        {
            _dbContext = context;
        }

        public async Task<IList<Firmi>> GetFirmi(int faza, int rolq)
        {
            return  await _dbContext.Firmi
                            .Where (obj=> obj.Rolq == rolq && obj.Status == 1)
                            .ToListAsync();
        }

        public async Task<Firmi> GetFirma(string eik)
        {
            var firma = await _dbContext.Firmi
                           .Where(obj => obj.EIK == eik && obj.Status == 1)
                           .FirstOrDefaultAsync();
            return firma;
        }

        #region montaz
        public async Task<IList<ViewFirmiIzpalniteli>> GetFirmiMontaz(int faza)
        {
            var firmi = (from f in _dbContext.Firmi
                         where f.Rolq == 1 && f.Status == 1
                         select new
                         {
                             idFirma = f.IdFirma,
                             EIK = f.EIK,
                             Ime = f.Ime,
                         });

            var dogovor = (from f in _dbContext.MonDogovors
                           where f.Status == 1 && f.StatusDm < 9
                           select new
                           {
                               idFirma = f.IdFirma,
                               iddog = f.IdFirmaMn,
                               dognom = f.RegIndex,
                               datadognom = f.DataRegN,
                               status_dl = f.StatusDm
                           });

            var data = (from sdv in dogovor
                        from f in firmi
                                .Where(m => m.idFirma == sdv.idFirma)
                        from s3 in _dbContext.NStatusis
                                .Where(s => s.StatusName.Equals("Status_DF") && sdv.status_dl == s.StatusCode && s.Status == 1)
                                .DefaultIfEmpty()
                        from u in _dbContext.MonDgvUredis
                                .Where(s => s.IdFirmaMn == sdv.iddog && s.Status == 1)
                                .DefaultIfEmpty()
                                .GroupBy(x=> x.IdFirmaMn)
                                .Select (z => new {
                                    count = z.Count()
                                })
                        select new ViewFirmiIzpalniteli()
                        {
                            idFirma = f.idFirma,
                            EIK = f.EIK,
                            Ime = f.Ime,
                            IdDog = sdv.iddog,
                            RegIndex = sdv.dognom,
                            DataRegN = sdv.datadognom,
                            StatusDm = sdv.status_dl > 0 ? s3.Text : "Няма",
                            StatusUr = u.count > 0 ? "Има" :"Няма"
                        });

            return await (data).ToListAsync();
        }
      
        public async Task<ViewFirmDogovor> GetMonDogovor(int iddog)
        {
            var dogovor = await (from f in _dbContext.MonDogovors
                             where f.IdFirmaMn == iddog
                                 select new ViewFirmDogovor
                             {
                                IdDog = f.IdFirmaMn,
                                Faza = f.Faza,
                                IdFirma = f.IdFirma,
                                RegIndex = f.RegIndex,
                                DataRegN = f.DataRegN,
                                NomDgVSudso = f.NomDgVSudso,
                                NachalnaData = f.NachalnaData,
                                ObshtSrokGrf = f.ObshtSrokGrf,
                                ObshtaCenaBezDds = f.ObshtaCenaBezDds,
                                ObshtaCenaSDds = f.ObshtaCenaSDds,
                                StatusDm = f.StatusDm,
                                Status = f.Status
                            })
            				.FirstOrDefaultAsync();

            if (dogovor != null)
            {
                var uredi = await _dbContext.MonDgvUredis
                            .Where(obj => obj.IdFirmaMn == iddog && obj.Status == 1)
                            .ToListAsync();

                dogovor.uredi = uredi;

                var firma = await _dbContext.Firmi
                            .Where(obj => obj.IdFirma == dogovor.IdFirma && obj.Status == 1)
                            .FirstOrDefaultAsync();

                dogovor.firma = firma;

                var raioni = await _dbContext.MonRajonis
                            .Where(obj => obj.IdFirmaMn == dogovor.IdDog && obj.Status == 1)
                            .ToListAsync();

                dogovor.raioni = raioni;

                var payments = await _dbContext.MonPayments
                            .Where(obj => obj.IdFirmaMn == dogovor.IdDog)
                            .ToListAsync();

                dogovor.payments = payments;

            }

            return dogovor;
        }

        public async Task<IList<ViewFirmDogovor>> GetMonDogovoriFirma(int idfirma)
        {
           return await (from f in _dbContext.MonDogovors
                            where f.IdFirma == idfirma && f.StatusDm == 2
                            select new ViewFirmDogovor
                            {
                                IdDog = f.IdFirmaMn,
                                Faza = f.Faza,
                                IdFirma = f.IdFirma,
                                RegIndex = f.RegIndex,
                                DataRegN = f.DataRegN,
                                NomDgVSudso = f.NomDgVSudso,
                                NachalnaData = f.NachalnaData,
                                ObshtSrokGrf = f.ObshtSrokGrf,
                                ObshtaCenaBezDds = f.ObshtaCenaBezDds,
                                ObshtaCenaSDds = f.ObshtaCenaSDds,
                                StatusDm = f.StatusDm,
                                Status = f.Status
                            })
                    .ToListAsync();
        }

        public async Task<int> SetMonDogovor(ViewFirmDogovor data)
        {
            var item = new MonDogovor
            {
                IdFirmaMn = data.IdDog,
                Faza = data.Faza,
                IdFirma = data.IdFirma,
                RegIndex = data.RegIndex,
                DataRegN = data.DataRegN,
                NomDgVSudso = data.NomDgVSudso,
                NachalnaData = data.NachalnaData,
                ObshtSrokGrf = data.ObshtSrokGrf,
                ObshtaCenaBezDds = data.ObshtaCenaBezDds,
                ObshtaCenaSDds = data.ObshtaCenaSDds,
                StatusDm = data.StatusDm,
                Status = data.Status
            };

            var firma = data.firma;
            if (firma.IdFirma == 0) { 
                var f = await _dbContext.Firmi
                         .Where(obj => obj.EIK == firma.EIK && obj.Status == 1)
                         .FirstOrDefaultAsync();
                if (f == null)
                {
                    _dbContext.Entry(firma).State = EntityState.Added;
                    await _dbContext.SaveChangesAsync();
                }
            } else
            {
                _dbContext.Entry(firma).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
            }

            item.IdFirma = firma.IdFirma;
            var objectExists = (item.IdFirmaMn > 0);
            _dbContext.Entry(item).State = objectExists ? EntityState.Modified : EntityState.Added;
            await _dbContext.SaveChangesAsync();

            //get next sequence value
            using (var dbContextTransaction = _dbContext.Database.BeginTransaction())
            {

                _dbContext.MonDgvUredis
                         .RemoveRange(_dbContext.MonDgvUredis
                                                .Where(x => x.IdFirmaMn == item.IdFirmaMn));

                data.uredi.ForEach(x =>
                {
                    x.IdFirmaMn = item.IdFirmaMn;
                    _dbContext.Entry(x).State = EntityState.Added;
                });

                _dbContext.MonRajonis
                          .RemoveRange(_dbContext.MonRajonis
                                                 .Where(x => x.IdFirmaMn == item.IdFirmaMn));

                data.raioni.ForEach(x =>
                {
                    x.IdFirmaMn = item.IdFirmaMn;
                    _dbContext.Entry(x).State = EntityState.Added;
                });

                _dbContext.MonPayments
                          .RemoveRange(_dbContext.MonPayments
                                                 .Where(x => x.IdFirmaMn == item.IdFirmaMn));

                data.payments.ForEach(x =>
                {
                    x.IdFirmaMn = item.IdFirmaMn;
                    _dbContext.Entry(x).State = EntityState.Added;
                });

                await _dbContext.SaveChangesAsync();
                dbContextTransaction.Commit();
            }

            return item.IdFirmaMn;
        }

        public async Task<IList<ViewFirmaDogovorUredi>> loadMonDogovorUredi(int iddogovor)
        {
            return await (from d in _dbContext.MonDgvUredis
                             where d.IdFirmaMn == iddogovor && d.Status == 1
                             from n in _dbContext.NUredi
                             where n.Id == d.IdKn
                             select new ViewFirmaDogovorUredi
                             {
                                 IdKt = d.IdKn,
                                 Broi = d.Broi,
                                 Edcena = d.EdCena,
                                 Name = n.Nime,
                                 Total = d.EdCena * d.Broi
                             }).ToListAsync();
        }

        public async Task<IList<ViewFirmDogovor>> loadMonDogovorPorychki(int iddogovor)
        {
            return await (from d in _dbContext.MonPorychkaMain
                          where d.IdDogovorFirma == iddogovor
                          select new ViewFirmDogovor
                          {
                              IdDog = d.IdPorachkaMain,
                          }).ToListAsync();
        }
        #endregion

        #region demontaz
        public async Task<IList<ViewFirmiIzpalniteli>> GetFirmiDeMontaz(int faza)
        {
            var firmi = (from f in _dbContext.Firmi
                         where f.Rolq==2 && f.Status == 1
                         select new
                         {
                             idFirma = f.IdFirma,
                             EIK = f.EIK,
                             Ime = f.Ime,
                         });

            var dogovor = (from f in _dbContext.DemDogovors
                           where f.Status == 1 && f.StatusDm < 9
                           select new
                           {
                               idFirma = f.IdFirma,
                               iddog = f.IdFirmaDm,
                               dognom = f.RegIndex,
                               datadognom = f.DataRegN,
                               status_dm = f.StatusDm
                           });

             var data = (from sdv in dogovor
                        from f in firmi
                                .Where(m => m.idFirma == sdv.idFirma)
                                .DefaultIfEmpty()
                        from s3 in _dbContext.NStatusis
                                .Where(s => s.StatusName.Equals("Status_DF") && sdv.status_dm == s.StatusCode && s.Status == 1)
                                .DefaultIfEmpty()
                         from u in _dbContext.DemDgvOlduredis
                                 .Where(s => s.IdFirmaDm == sdv.iddog && s.Status == 1)
                                 .DefaultIfEmpty()
                                 .GroupBy(x => x.IdFirmaDm)
                                 .Select(z => new {
                                     count = z.Count()
                                 })
                         select new ViewFirmiIzpalniteli()
                        {
                            idFirma = f.idFirma,
                            EIK = f.EIK,
                            Ime = f.Ime,
                            IdDog = sdv.iddog,
                            RegIndex = sdv.dognom,
                            DataRegN = sdv.datadognom,
                            StatusDm = sdv.status_dm > 0 ? s3.Text : "Няма",
                            StatusUr = u.count > 0 ? "Има" : "Няма"
                         });

            return await (data).ToListAsync();
        }

        public async Task<ViewFirmDogovor> GetDeMonDogovor(int iddog)
        {
            var dogovor = await (from f in _dbContext.DemDogovors
                                 where f.IdFirmaDm == iddog                                 select new ViewFirmDogovor
                                 {
                                     IdDog = f.IdFirmaDm,
                                     Faza = f.Faza,
                                     IdFirma = f.IdFirma,
                                     RegIndex = f.RegIndex,
                                     DataRegN = f.DataRegN,
                                     NomDgVSudso = f.NomDgVSudso,
                                     NachalnaData = f.NachalnaData,
                                     ObshtSrokGrf = f.ObshtSrokGrf,
                                     ObshtaCenaBezDds = f.ObshtaCenaBezDds,
                                     ObshtaCenaSDds = f.ObshtaCenaSDds,
                                     StatusDm = f.StatusDm,
                                     Status = f.Status
                                 })
                            .FirstOrDefaultAsync();

            if (dogovor != null)
            {
                var uredi = await _dbContext.DemDgvOlduredis
                            .Where(obj => obj.IdFirmaDm ==iddog && obj.Status == 1)
                            .ToListAsync();

                dogovor.olduredi = uredi;

                var firma = await _dbContext.Firmi
                            .Where(obj => obj.IdFirma == dogovor.IdFirma && obj.Status == 1)
                            .FirstOrDefaultAsync();

                dogovor.firma = firma;

                var payments = await _dbContext.DemPayments
                             .Where(obj => obj.IdFirmaDm == dogovor.IdDog)
                             .ToListAsync();

                dogovor.dempayments = payments;

            }
            return dogovor;
        }

        public async Task<IList<ViewFirmDogovor>> GetDeMonDogovoriFirma(int idfirma)
        {
            return await (from f in _dbContext.DemDogovors
                          where f.IdFirma == idfirma && f.StatusDm == 2
                          select new ViewFirmDogovor
                          {
                              IdDog = f.IdFirmaDm,
                              Faza = f.Faza,
                              IdFirma = f.IdFirma,
                              RegIndex = f.RegIndex,
                              DataRegN = f.DataRegN,
                              NomDgVSudso = f.NomDgVSudso,
                              NachalnaData = f.NachalnaData,
                              ObshtSrokGrf = f.ObshtSrokGrf,
                              ObshtaCenaBezDds = f.ObshtaCenaBezDds,
                              ObshtaCenaSDds = f.ObshtaCenaSDds,
                              StatusDm = f.StatusDm,
                              Status = f.Status
                          })
                     .ToListAsync();
        }

        public async Task<int> SetDeMonDogovor(ViewFirmDogovor data)
        {
            var item = new DemDogovor
            {
                IdFirmaDm = data.IdDog,
                Faza = data.Faza,
                IdFirma = data.IdFirma,
                RegIndex = data.RegIndex,
                DataRegN = data.DataRegN,
                NomDgVSudso = data.NomDgVSudso,
                NachalnaData = data.NachalnaData,
                ObshtSrokGrf = data.ObshtSrokGrf,
                ObshtaCenaBezDds = data.ObshtaCenaBezDds,
                ObshtaCenaSDds = data.ObshtaCenaSDds,
                StatusDm = data.StatusDm,
                Status = data.Status
            };

            var firma = data.firma;
            var firmaExists = (firma.IdFirma > 0);
            _dbContext.Entry(firma).State = firmaExists ? EntityState.Modified : EntityState.Added;
            await _dbContext.SaveChangesAsync();

            item.IdFirma = firma.IdFirma;
            var objectExists = (item.IdFirmaDm > 0);
            _dbContext.Entry(item).State = objectExists ? EntityState.Modified : EntityState.Added;
            await _dbContext.SaveChangesAsync();

            //get next sequence value
            using (var dbContextTransaction = _dbContext.Database.BeginTransaction())
            {
                _dbContext.DemDgvOlduredis
                         .RemoveRange(_dbContext.DemDgvOlduredis
                                                .Where(x => x.IdFirmaDm == item.IdFirmaDm));

                data.olduredi.ForEach(x =>
                {
                    x.IdFirmaDm = item.IdFirmaDm;
                    _dbContext.Entry(x).State = EntityState.Added;
                });

                _dbContext.DemPayments
                          .RemoveRange(_dbContext.DemPayments
                                                 .Where(x => x.IdFirmaDm == item.IdFirmaDm));

                data.dempayments.ForEach(x =>
                {
                    x.IdFirmaDm = item.IdFirmaDm;
                    _dbContext.Entry(x).State = EntityState.Added;
                });

                await _dbContext.SaveChangesAsync();
                dbContextTransaction.Commit();
            }

            return item.IdFirmaDm;
        }

        public async Task<IList<ViewFirmaDogovorUredi>> loadDeMonDogovorUredi(int iddogovor)
        {
            return await (from d in _dbContext.DemDgvOlduredis
                          where d.IdFirmaDm == iddogovor && d.Status == 1
                          from n in _dbContext.NNmnObshtis
                          where n.IdKn == d.IdKn && n.KodNmn == "06"
                          select new ViewFirmaDogovorUredi
                          {
                              IdKt = d.IdKn,
                              Broi = d.Broi,
                              Edcena = d.EdCena,
                              Name = n.Text,
                              Total = d.EdCena * d.Broi
                          }).ToListAsync();

        }

        #endregion

    }
}
