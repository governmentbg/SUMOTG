using Common.DataAccess.EFCore;
using Common.Entities;
using Common.Entities.Demontaz;
using Common.Entities.Fakturi;
using Common.Entities.Montaz;
using Common.Entities.Spravki;
using Common.Entities.Views;
using Common.Repositories.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Repositories
{
    public class ObrabotkiRepository : IObrabotkiRepository
    {
        private readonly DataContext _dbContext;

        public ObrabotkiRepository(DataContext context)
        {
            _dbContext = context;
        }

        #region montazj
        public async Task<IList<ViewListOrder>> getMonListOrders(int faza)
        {
            var data = (from p in _dbContext.MonPorychkaMain
                        where p.StatusPM < 9
                        from f in _dbContext.Firmi
                        where f.IdFirma == p.IdFirma
                        from d in _dbContext.MonDogovors
                        where p.IdDogovorFirma == d.IdFirmaMn
                        from s in _dbContext.NStatusis
                        where p.StatusPM == s.StatusCode && s.StatusName == "Status_DPM"
                        select new ViewListOrder
                        {
                            idporychka = p.IdPorachkaMain,
                            nomer = p.Nomer,
                            faza = p.Faza,
                            data = p.Data,
                            idfirma = p.IdFirma,
                            eik = f.EIK,
                            ime = f.Ime,
                            email = f.EMail,
                            telefon = f.Tel,
                            dogovor = d.RegIndex + '/' +
                                       (d.DataRegN.HasValue ? d.DataRegN.Value.ToString("dd.MM.yyyy") : ""),
                            statusPM = s.Text,
                            status = p.Status,
                            note = p.Note,
                            spm = p.StatusPM
                        });

            return await data.OrderBy(x=>x.idporychka).ToListAsync();
        }

        public Task<ViewOrder> GetMonOrder(int id)
        {
            var dogovor = (from f in _dbContext.MonPorychkaMain
                           where f.IdPorachkaMain == id
                           select new ViewOrder
                           {
                               idporychkamain = f.IdPorachkaMain,
                               faza = f.Faza,
                               nomer = f.Nomer,
                               data = f.Data,
                               idfirma = f.IdFirma,
                               iddogovorfirma = f.IdDogovorFirma,
                               raion = f.ARaion,
                               status = f.Status,
                               startData = f.StartData,
                               endData = f.EndData,
                               status_pm = f.StatusPM,
                               note = f.Note
                           })
                           .FirstOrDefault();

            if (dogovor != null)
            {
                var porychki = (from p in _dbContext.MonPorychkas
                                where p.IdPorachkaMain == id && p.Status == 1
                                from d in _dbContext.LicaDogovors
                                where d.IdDogL == p.IdDogovorLice
                                from l in _dbContext.ViewOpos
                                where l.ID_L == d.IdL
                                from k in _dbContext.LicaFormuliarKolektiv
                                where k.IdL == l.ID_L && k.IsTitulqr == 1
                                from f in _dbContext.LicaFormuliars
                                where l.ID_L == f.IdL && f.Status == 1
                                from s1 in _dbContext.NNmnObshtis
                                where s1.IdKn == f.nV9 && s1.Status == 1
                                from u in _dbContext.NUredi
                                where u.Id == p.IdUred && u.Status == 1
                                from n in _dbContext.NRaionis
                                where n.Nkod == k.ARaion
                                select new ViewMonOrderItem
                                {
                                    idporychkabody = p.IdPorachkaBody,
                                    idl = d.IdL,
                                    iddogovorlice = p.IdDogovorLice,
                                    unom = f.UNom,
                                    idured = p.IdUred,
                                    model = p.Model == null ? "" : p.Model,
                                    broi = p.Broi,
                                    dodata = p.DoData,
                                    otchas = p.OtChas == null ? "" : p.OtChas,
                                    dochas = p.DoChas == null ? "" : p.DoChas,
                                    note = p.Note == null ? "" : p.Note,
                                    mondata = p.MonData,
                                    protnomer = p.ProtNomer == null ? "" : p.ProtNomer,
                                    protdata = p.ProtData,
                                    fabrnomer = p.FabrNomer == null ? "" : p.FabrNomer,
                                    garkarta = p.GarCard == null ? "" : p.GarCard,
                                    gardata = p.GarCardData,
                                    note2 = p.Note2 == null ? "" : p.Note2,
                                    statusG = p.StatusG,
                                    statusM = p.StatusM,
                                    status = p.Status,
                                    uredname = u.Nime,
                                    ident = k.Ident,
                                    ime = k.Ime,
                                    vidimot = s1.Text,
                                    adres = l.Adres,
                                    email = k.EMail,
                                    telefon = k.Tel,
                                    Snimka = p.Snimka == null ? " " : p.Snimka,
                                    unomer = l.UNomer,
                                    vidured = u.Vid,
                                    raion = n.Nime,
                                    note3 = d.Comentar
                                })
                                .OrderBy(x => x.unomer).ThenBy(x=>x.idured)
                                .ToList();

                dogovor.porychkaitems = porychki;
            }
            else
                dogovor = new ViewOrder();

            return Task.FromResult(dogovor);
        }

        public async Task<IList<ViewUrediOrder>> getDogovorFirmaUredi(int iddogovorfirma)
        {
            var uredi = (from f in _dbContext.MonPorychkaMain
                         where f.IdDogovorFirma == iddogovorfirma
                         from s in _dbContext.MonPorychkas
                         where s.IdPorachkaMain == f.IdPorachkaMain
                                && s.StatusG < 2
                                && s.StatusM < 2
                         group s by new {s.IdUred } into grp
                         select new
                         {
                             grp.Key.IdUred,
                             Broi = grp.Sum(x => x.Broi)
                         });
            
            var data = (from f in _dbContext.MonDgvUredis
                        where f.IdFirmaMn == iddogovorfirma
                        from s in _dbContext.NUredi
                        where s.Id == f.IdKn
                        join u in uredi on f.IdKn equals u.IdUred into gj
                        from mu in gj.DefaultIfEmpty()
                        select new ViewUrediOrder
                        {
                            idspdost = f.IdSpDost,
                            id = f.IdKn,
                            name = s.Nime,
                            edcena = f.EdCena,
                            broi = f.Broi,
                            maxbroi = f.Broi - (mu.Broi == null ? 0 : mu.Broi),
                            broiporychani = (mu.Broi == null ? 0 : mu.Broi),
                            vidured = s.Vid
                        });
            return await data.OrderBy(x=>x.id).ToListAsync();
        }

        public async Task<IList<MonRajoni>> getDogovorFirmaRaioni(int iddogovorfirma)
        {
            var data = (from f in _dbContext.MonRajonis
                        where f.IdFirmaMn == iddogovorfirma
                        select new MonRajoni
                        {
                            Nkod = f.Nkod
                        });
            return await data.OrderBy(x=>x.Nkod).ToListAsync();
        }

        public async Task<IList<ViewPersUrediOrder>> getPersonsWihtDogUredi(int iddogovorfirma, string raion, int faza)
        {
            var lcsql = "SELECT x.IdL, x.iddogovorlice, x.idured, 0 as broi,fk.ime, fk.ident, a.vidimot, a.adres "+
                        "       , fk.e_mail email, fk.tel as telefon, x.uredname, f.U_nom as unom, f.unomer, '' vidured" +
                        "       , r.NIME as raion, ld.Comentar note3 " +
                      "  FROM "+
                      "  (SELECT ldu.Id_L as IdL, ldu.ID_DOG_L as iddogovorlice, 0 as idured " +
                      "          , STRING_AGG(u.nime + ' - ' + convert(varchar, ldu.broi) + ' бр.', '; ') " +
                      "                  WITHIN GROUP(ORDER BY  u.nkod) AS uredname " +
                      "    FROM lica_dogovor_uredi ldu " +
                      "         INNER JOIN(SELECT Id_L, COUNT(*) cntAll " +
                      "                        FROM lica_dogovor_uredi " +
                      "                        WHERE Status_U = 2 " +
                      "                           AND Broi -Porychani > 0" +
                      "                        GROUP BY Id_L) x " +
                      "                 ON ldu.Id_L = x.ID_L " +
                      "         INNER JOIN(SELECT Id_L, COUNT(*) cntTz " +
                      "                        FROM lica_dogovor_uredi " +
                      "                        WHERE Id_KT IN(SELECT mdu.ID_kn " +
                      "                                            FROM mon_dgv_uredi mdu " +
                      "                                            WHERE mdu.IdFirmaMn = "+ iddogovorfirma.ToString()+") " +
                      "                           AND Status_U = 2 " +
                      "                           AND Broi -Porychani > 0"+
                      "                        GROUP BY Id_L) y " +
                      "                ON ldu.Id_L = y.ID_L " +
                      "        INNER JOIN n_uredi u ON ldu.Id_KT = u.Id " +
                      "    WHERE ldu.Id_KT IN(SELECT mdu.ID_kn " +
                      "                            FROM mon_dgv_uredi mdu " +
                      "                            WHERE mdu.IdFirmaMn = " + iddogovorfirma.ToString() + ") " +
                      "        AND ldu.Status_U = 2 " +
                      "        AND ldu.Broi - ldu.Porychani > 0" +
                      "        AND cntAll = cntTz " +
                      "    GROUP BY ldu.Id_L, ldu.ID_DOG_L) x " +
                      "    INNER JOIN lica_dogovor ld ON x.IdL = ld.Id_L " +
                      "    INNER JOIN lica_formuliar f ON x.IdL = f.Id_L " +
                      "    INNER JOIN lica_formuliar_kolektiv fk ON x.IdL = fk.IdL and fk.IsTitulqr=1 and fk.StatusL < 3" +
                      "    INNER JOIN n_raioni r ON fk.A_Raion = r.NKOD " +
                      "    INNER JOIN vwAdres a ON x.IdL=a.ID_L " +
                      " ORDER BY f.UNomer";

            var data = _dbContext.ViewPersUrediOrder.FromSqlRaw(lcsql);
            return await (data).ToListAsync();
        }

        public async Task<IList<ViewPersUrediOrder>> getPersonUredi(int iddogovorfirma, int idlice)
        {
            var data = await (from f in _dbContext.LicaDogovorUredis
                              where f.IdL == idlice 
                                    && f.StatusU == 2 
                                    && (f.Broi - f.Porychani > 0)
                              from u in _dbContext.MonDgvUredis
                              where u.IdFirmaMn == iddogovorfirma && u.IdKn == f.IdKt
                              from d in _dbContext.LicaDogovors
                              where d.IdDogL == f.IdDogL && d.StatusDl == 2
                              from l in _dbContext.ViewAdres
                              where l.ID_L == d.IdL
                              from k in _dbContext.LicaFormuliarKolektiv
                              where k.IdL == l.ID_L && k.IsTitulqr == 1 && k.StatusL < 3 && k.Status == 1
                              from s in _dbContext.NUredi
                              where s.Id == f.IdKt
                              from n in _dbContext.NRaionis
                              where n.Nkod == k.ARaion
                              select new ViewPersUrediOrder
                              {
                                  iddogovorlice = f.IdDogL,
                                  idured = f.IdKt,
                                  broi = f.Broi - f.Porychani,
                                  IdL = d.IdL,
                                  ident = k.Ident,
                                  ime = k.Ime,
                                  adres = l.Adres,
                                  vidimot = l.vidimot,
                                  email = k.EMail,
                                  telefon = k.Tel,
                                  unom = l.U_nom,
                                  uredname = s.Nime,
                                  unomer = l.UNomer,
                                  vidured = s.Vid,
                                  raion = n.Nime,
                                  note3 = d.Comentar
                              }).OrderBy(x => x.unomer).ToListAsync();

            return data;
        }

        public async Task<IList<ViewMonOrderItem>> getPersonsDogovorUredi(int id)
        {
            var porychki = (from p in _dbContext.MonPorychkas
                            where p.IdPorachkaMain == id && p.Status == 1
                            from u in _dbContext.LicaDogovorUredis
                            where u.IdDogL == p.IdDogovorLice
                            select new ViewMonOrderItem
                            {
                                idured = u.IdUredDg,
                                broi = p.Broi,
                            });

            return await porychki.ToListAsync();
        }

        public async Task<int> setMonOrder(MonPorychkaMain item)
        {
            var objectExists = (item.IdPorachkaMain > 0);

            if (objectExists)
                _dbContext.MonPorychkaMain.Update(item);
            else
                _dbContext.MonPorychkaMain.Add(item);

            var odititem = new OditLog
            {
                Koga = DateTime.Now,
                User = item.User,
                Kod = 8,
                Text = "Редакция на поръчка за монтаж: " + item.IdPorachkaMain.ToString(),
            };
            _dbContext.Entry(odititem).State = EntityState.Added;

            await _dbContext.SaveChangesAsync();
            return item.IdPorachkaMain;
        }

        public async Task SetPorychkaBody(int IdPorachkaMain, List<MonPorychka> data)
        {
            //get next sequence value
            using (var dbContextTransaction = _dbContext.Database.BeginTransaction())
            {
                DelPorychkaBody(IdPorachkaMain);

                data.ForEach(x =>
                {
                    _dbContext.Entry(x).State = EntityState.Added;
                });

                await _dbContext.SaveChangesAsync();
                dbContextTransaction.Commit();
            }
        }

        public async Task DelPorychkaBody(int idPorychkaMain)
        {
 
            var porychka = _dbContext.MonPorychkas
                            .Where(x => x.IdPorachkaMain == idPorychkaMain)
                            .ToList();

            porychka.ForEach(c =>
            {
                //update statusa i broq porychani lica dogovor uredi 
                if (c.StatusG == 0 && c.StatusM == 0)
                {
                    var f = _dbContext.LicaDogovorUredis
                                 .SingleOrDefault(x => x.IdDogL == c.IdDogovorLice && x.IdKt == c.IdUred);
                    if (f != null)
                    {
                        f.StatusU = 2;
                        f.Porychani = (f.Porychani - c.Broi > 0 ? f.Porychani - c.Broi : 0);

                        _dbContext.Entry(f).State = EntityState.Modified;

                    }
                }

                //iztrivame zaqveniq ured 
                _dbContext.MonPorychkas.Attach(c);
                _dbContext.MonPorychkas.Remove(c);
            });
        }

        public async Task SetLiceDogovorUredi(LicaDogovorUredi item)
        {
            var rec = _dbContext.LicaDogovorUredis
                                .FirstOrDefault(x => x.IdDogL == item.IdDogL && x.IdKt == item.IdKt);

            if (rec != null)
            {
                rec.StatusU = item.StatusU;
                rec.Koga = item.Koga;
                rec.User = item.User;
                rec.Porychani = rec.Porychani + item.Porychani;

                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task SetMonUrediDogovor(MonDgvUredi item)
        {
            var rec = _dbContext.MonDgvUredis
                              .FirstOrDefault(x => x.IdSpDost == item.IdSpDost);

            rec.Koga = item.Koga;
            rec.User = item.User;

            await _dbContext.SaveChangesAsync();
        }

        public async Task DelMonUrediDogovor(int idporychkamain, int idlicedogovor)
        {
            int iddogovor = (from c in _dbContext.MonPorychkaMain
                             where c.IdPorachkaMain == idporychkamain
                             select c.IdDogovorFirma)
                             .SingleOrDefault();

            var porychka = _dbContext.MonPorychkas
                                .Where(x => x.IdPorachkaMain == idporychkamain && x.IdDogovorLice == idlicedogovor)
                                .ToList();

            porychka.ForEach(c =>
            {
                using (var transaction = _dbContext.Database.BeginTransaction())
                {
                    try
                    {
                        //update statusa i broq porychani lica dogovor uredi 
                        var f = _dbContext.LicaDogovorUredis
                                 .SingleOrDefault(x => x.IdDogL == idlicedogovor && x.IdKt == c.IdUred);

                        if ( f != null) { 
                            f.StatusU = 2;
                            f.Porychani = (f.Porychani - c.Broi > 0 ? f.Porychani - c.Broi : 0);

                            _dbContext.Entry(f).State = EntityState.Modified;
                        }

                        //iztrivame zaqveniq ured 
                        _dbContext.MonPorychkas.Attach(c);
                        _dbContext.MonPorychkas.Remove(c);

                        _dbContext.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine("Error occurred.");
                    }
                }
            });
        }

        public async Task UpdPorychkaBodyGrafik(int iddog, MonPorychka item)
        {
            //update statusa na uredite w porychkata
            var f = _dbContext.MonPorychkas
                         .SingleOrDefault(x => x.IdPorachkaBody == item.IdPorachkaBody);
            f.StatusG = item.StatusG;
            f.DoData = (item.DoData.HasValue ? ((DateTime)item.DoData).Date : null);
            f.OtChas = item.OtChas;
            f.DoChas = item.DoChas;
            f.Note = item.Note;
            f.User = item.User;
            f.Koga = item.Koga;

            _dbContext.Entry(f).State = EntityState.Modified;

            if (item.StatusG > 1)
            {
                //update statusa i broq porychani lica dogovor uredi 
                var l = _dbContext.LicaDogovorUredis
                             .SingleOrDefault(x => x.IdDogL == f.IdDogovorLice && x.IdKt == f.IdUred);
                if (l != null)
                {

                    if (item.StatusG == 2)
                        l.StatusU = 7;
                    else if (item.StatusG == 4)
                        l.StatusU = 6;
                    else
                        l.StatusU = 2;

                    l.Porychani = (l.Porychani - f.Broi > 0 ? l.Porychani - f.Broi : 0);

                    _dbContext.Entry(l).State = EntityState.Modified;
                }
            }
            _dbContext.SaveChanges();
        }
        public async Task UpdPorychkaBodyOtchet(int iddog, MonPorychka item)
        {
            //update statusa na uredite w porychkata
            var f = _dbContext.MonPorychkas
                         .SingleOrDefault(x => x.IdPorachkaBody == item.IdPorachkaBody && x.StatusG <= 1);
            if (f != null) { 
                f.StatusM = item.StatusM;
                f.MonData = (item.MonData.HasValue ? ((DateTime)item.MonData).Date : null);
                f.FabrNomer = item.FabrNomer;
                f.GarCard = item.GarCard;
                f.GarCardData = (item.GarCardData.HasValue ? ((DateTime)item.GarCardData).Date : null); 
                f.ProtNomer = item.ProtNomer;
                f.ProtData = (item.ProtData.HasValue ? ((DateTime)item.ProtData).Date : null); 
                f.Snimka = item.Snimka;
                f.Note2 = item.Note2;
                f.Model = item.Model;
                f.User = item.User;
                f.Koga = item.Koga;

                using (var transaction = _dbContext.Database.BeginTransaction())
                {
                    try
                    {
                        _dbContext.Entry(f).State = EntityState.Modified;

                        //update statusa i broq porychani lica dogovor uredi 
                        var l = _dbContext.LicaDogovorUredis
                                        .SingleOrDefault(x => x.IdDogL == f.IdDogovorLice && x.IdKt == f.IdUred);
                        if ( l != null) { 
                            if (item.StatusM == 1) { 
                                l.StatusU = 5;
                            } else
                            {
                                if (item.StatusM == 2)
                                    l.StatusU = 7;
                                else if (item.StatusM == 4)
                                    l.StatusU = 6;
                                else
                                    l.StatusU = 2;

                                l.Porychani = (l.Porychani - f.Broi > 0 ? l.Porychani - f.Broi : 0);
                            }
                            _dbContext.Entry(l).State = EntityState.Modified;
                        }
                        _dbContext.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine("Error occurred.");
                    }
                }
            }
        }

        public async Task DelМonOrder(int idporychkamain)
        {
            //update status na porychkata
            var d = _dbContext.MonPorychkaMain
                         .SingleOrDefault(x => x.IdPorachkaMain == idporychkamain);
            d.StatusPM = 9;
            _dbContext.Entry(d).State = EntityState.Modified;

            await DelPorychkaBody(idporychkamain);
            _dbContext.SaveChanges();
        }

        public async Task<IList<ViewListOrder>> getMonOrdersWithoutDemPorychka()
        {

            var data = (from p in _dbContext.MonPorychkaMain
   // това е съгласувано с КЕВ              where p.StatusPM == 1
                        from f in _dbContext.Firmi
                        where f.IdFirma == p.IdFirma
                        join e2 in _dbContext.DemPorychkaMain 
                                on p.IdPorachkaMain equals e2.IdMonPorachka
                             into jrs
                        from jrResult in jrs.DefaultIfEmpty()
                        select new ViewListOrder
                        {
                            idporychka = p.IdPorachkaMain,
                            nomer = p.Nomer,
                            faza = p.Faza,
                            data = p.Data,
                            idfirma = p.IdFirma,
                            eik = f.EIK,
                            ime = f.Ime,
                            email = f.EMail,
                            telefon = f.Tel,
                            dogovor = "",
                            statusPM = "",
                            status = p.Status,
                            note = p.Note,
                            spm = (jrResult.IdMonPorachka == null || jrResult.StatusDM==9  ? 0 : jrResult.IdMonPorachka),
                        });

            return await data
                .OrderBy(x => x.idporychka).ToListAsync();
        }

        public async Task<int> canDeleteMonOrder(int idporychkamain)
        {
            var data = (from d in _dbContext.MonPorychkas
                            .Where(m => m.IdPorachkaMain == idporychkamain && (m.StatusG > 0 || m.StatusM >0))
                        select d.IdPorachkaBody);

            return data.Count();

        }
        #endregion

        #region demontazj
        public async Task<IList<ViewListOrder>> getDemonListOrders(int faza)
        {
            var data = (from p in _dbContext.DemPorychkaMain
                        where p.StatusDM < 9
                        from f in _dbContext.Firmi
                        where f.IdFirma == p.IdFirma
                        from d in _dbContext.DemDogovors
                        where p.IdDogovorFirma == d.IdFirmaDm
                        from s in _dbContext.NStatusis
                        where p.StatusDM == s.StatusCode && s.StatusName == "Status_DP"
                        select new ViewListOrder
                        {
                            idporychka = p.IdPorachkaMain,
                            nomer = p.Nomer,
                            faza = p.Faza,
                            data = p.Data,
                            idfirma = p.IdFirma,
                            eik = f.EIK,
                            ime = f.Ime,
                            email = f.EMail,
                            telefon = f.Tel,
                            dogovor = d.RegIndex + '/' +
                                       (d.DataRegN.HasValue ? d.DataRegN.Value.ToString("dd.MM.yyyy") : ""),
                            statusPM = s.Text,
                            status = p.Status,
                            note = p.Note
                        });

            return await data.OrderBy(x=>x.idporychka).ToListAsync();
        }

        public Task<ViewOrder> GetDemonOrder(int id)
        {
            var dogovor = (from f in _dbContext.DemPorychkaMain
                           where f.IdPorachkaMain == id
                           select new ViewOrder
                           {
                               idporychkamain = f.IdPorachkaMain,
                               faza = f.Faza,
                               nomer = f.Nomer,
                               data = f.Data,
                               idfirma = f.IdFirma,
                               iddogovorfirma = f.IdDogovorFirma,
                               raion = f.ARaion,
                               status = f.Status,
                               startData = f.StartData,
                               endData = f.EndData,
                               status_pm = f.StatusDM,
                               note = f.Note,
                               idmonporychka = f.IdMonPorachka
                           })
                           .FirstOrDefault();

            if (dogovor != null)
            {
                var porychki = (from p in _dbContext.DemPorychkas
                                where p.IdPorachkaMain == id && p.Status == 1
                                from d in _dbContext.LicaDogovors
                                where d.IdDogL == p.IdDogovorLice
                                from l in _dbContext.ViewOpos
                                where l.ID_L == d.IdL
                                from k in _dbContext.LicaFormuliarKolektiv
                                where k.IdL == l.ID_L && k.IsTitulqr == 1
                                from f in _dbContext.LicaFormuliars
                                where l.ID_L == f.IdL && f.Status == 1
                                from s1 in _dbContext.NNmnObshtis
                                where s1.IdKn == f.nV9
                                from u in _dbContext.NNmnObshtis
                                where u.IdKn == p.IdUred
                                from n in _dbContext.NRaionis
                                where n.Nkod == k.ARaion
                                select new ViewMonOrderItem
                                {
                                    idporychkabody = p.IdPorachkaBody,
                                    idl = d.IdL,
                                    iddogovorlice = p.IdDogovorLice,
                                    unom = f.UNom,
                                    idured = p.IdUred,
                                    broi = p.Broi,
                                    dodata = p.DoData,
                                    otchas = p.OtChas == null ? "" : p.OtChas,
                                    dochas = p.DoChas == null ? "" : p.DoChas,
                                    note = p.Note == null ? "" : p.Note,
                                    statusG = p.StatusG,
                                    statusM = p.StatusM,
                                    status = p.Status,
                                    note2 = p.Note2 == null ? "" : p.Note2,
                                    mondata = p.DemData,
                                    uredname = u.Text,
                                    ident = k.Ident,
                                    ime = k.Ime,
                                    vidimot = s1.Text,
                                    adres = l.Adres,
                                    email = k.EMail,
                                    telefon = k.Tel,
                                    Snimka = p.Snimka == null ? " " : p.Snimka,
                                    unomer = l.UNomer,
                                    vidured = "",
                                    raion = n.Nime
                                })
                                .OrderBy(x => x.unomer)
                                .ToList();

                dogovor.porychkaitems = porychki;
            }
            else
                dogovor = new ViewOrder();

            return Task.FromResult(dogovor);
        }

        public async Task<IList<ViewUrediOrder>> getDemonDogovorFirmaUredi(int iddogovorfirma)
        {
            var uredi = (from f in _dbContext.DemPorychkaMain
                         where f.IdDogovorFirma == iddogovorfirma
                         from s in _dbContext.DemPorychkas
                         where s.IdPorachkaMain == f.IdPorachkaMain 
                                && s.StatusG < 2
                                && s.StatusM < 2
                         group s by new { s.IdUred } into grp
                         select new
                         {
                             grp.Key.IdUred,
                             Broi = grp.Sum(x => x.Broi)
                         });

            var data = (from f in _dbContext.DemDgvOlduredis
                        where f.IdFirmaDm == iddogovorfirma
                        from s in _dbContext.NNmnObshtis
                        where s.IdKn == f.IdKn
                        join u in uredi on f.IdKn equals u.IdUred into gj
                        from mu in gj.DefaultIfEmpty()
                        select new ViewUrediOrder
                        {
                            idspdost = f.IdSpDm,
                            id = f.IdKn,
                            name = s.Text,
                            edcena = f.EdCena,
                            broi = f.Broi,
                            maxbroi = f.Broi - (mu.Broi == null ? 0 : mu.Broi),
                            broiporychani = (mu.Broi == null ? 0 : mu.Broi),
                            vidured = ""
                        });

            return await data.OrderBy(x => x.id).ToListAsync();
        }

        public async Task<IList<MonRajoni>> getDemonDogovorFirmaRaioni(int iddogovorfirma)
        {
            var data = (from f in _dbContext.MonRajonis
                        where f.IdFirmaMn == iddogovorfirma
                        select new MonRajoni
                        {
                            Nkod = f.Nkod
                        });
            return await data.OrderBy(x=> x.Nkod).ToListAsync();
        }

        public async Task<IList<ViewPersUrediOrder>> getDemonPersonsWihtDogUredi(int iddogovorfirma, string raion, int faza)
        {
            var lcsql = "SELECT x.IdL, x.iddogovorlice, x.idured, 0 as broi,fk.ime, fk.ident, a.vidimot, a.adres " +
                       "       , fk.e_mail email, fk.tel as telefon, x.uredname, f.U_nom as unom, f.unomer, '' vidured" +
                       "       , r.NIME as raion, ld.Comentar note3  " +
                     "  FROM " +
                     "  (SELECT ldu.Id_L as IdL, ldu.ID_DOG_L as iddogovorlice, 0 as idured " +
                     "          , STRING_AGG (u.Text+' - '+convert(varchar,ldu.broi)+' бр.' , '; ')  " +
                     "                  WITHIN GROUP (ORDER BY  u.id_kn) AS uredname " +
                     "    FROM lica_dogovor_olduredi ldu " +
                     "         INNER JOIN(SELECT Id_L, COUNT(*) cntAll " +
                     "                        FROM lica_dogovor_olduredi " +
                     "                        WHERE Status_DU = 2 AND Id_Kt != 22" +
                     "                        GROUP BY Id_L) x " +
                     "                 ON ldu.Id_L = x.ID_L " +
                     "         INNER JOIN(SELECT Id_L, COUNT(*) cntTz " +
                     "                        FROM lica_dogovor_olduredi " +
                     "                        WHERE Id_KT IN(SELECT mdu.ID_kn " +
                     "                                            FROM dem_dgv_olduredi mdu " +
                     "                                            WHERE mdu.Id_firma_dm = " + iddogovorfirma.ToString() + ") " +
                     "                           AND Status_DU = 2 " +
                     "                        GROUP BY Id_L) y " +
                     "                ON ldu.Id_L = y.ID_L " +
                     "        INNER JOIN n_nmn_obshti u ON ldu.Id_KT=u.id_kn " +
                     "    WHERE ldu.Id_KT IN(SELECT mdu.ID_kn " +
                     "                            FROM dem_dgv_olduredi mdu " +
                     "                            WHERE mdu.Id_firma_dm = " + iddogovorfirma.ToString() + ") " +
                     "        AND ldu.Status_DU = 2 " +
                     "        AND cntAll = cntTz " +
                     "    GROUP BY ldu.Id_L, ldu.ID_DOG_L) x " +
                     "    INNER JOIN lica_dogovor ld ON x.IdL = ld.Id_L " +
                     "    INNER JOIN lica_formuliar f ON x.IdL = f.Id_L " +
                     "    INNER JOIN lica_formuliar_kolektiv fk ON x.IdL = fk.IdL and fk.IsTitulqr=1 and fk.StatusL < 3" +
                     "    INNER JOIN n_raioni r ON fk.A_Raion = r.NKOD " +
                     "    INNER JOIN vwAdres a ON x.IdL=a.ID_L " +
                    " ORDER BY f.UNomer";

            var data = _dbContext.ViewPersUrediOrder.FromSqlRaw(lcsql);
            return await (data).ToListAsync();


        }

        public async Task<IList<ViewPersUrediOrder>> getDemonPersonUredi(int iddogovorfirma, int idlice)
        {
            var data = await (from f in _dbContext.LicaDogovorOldUredis
                              where f.IdL == idlice && f.StatusDU < 3
                              from u in _dbContext.DemDgvOlduredis
                              where u.IdFirmaDm == iddogovorfirma && u.IdKn == f.IdKt
                              from d in _dbContext.LicaDogovors
                              where d.IdDogL == f.IdDogL && d.StatusDl == 2
                              from l in _dbContext.ViewAdres
                              where l.ID_L == d.IdL
                              from k in _dbContext.LicaFormuliarKolektiv
                              where k.IdL == l.ID_L && k.IsTitulqr == 1 && k.StatusL < 3 && k.Status == 1
                              from s in _dbContext.NNmnObshtis
                              where s.IdKn == f.IdKt
                              from n in _dbContext.NRaionis
                              where n.Nkod == k.ARaion
                              select new ViewPersUrediOrder
                              {
                                  iddogovorlice = f.IdDogL,
                                  idured = f.IdKt,
                                  broi = f.Broi,
                                  IdL = d.IdL,
                                  ident = k.Ident,
                                  ime = k.Ime,
                                  adres = l.Adres,
                                  vidimot = l.vidimot,
                                  email = k.EMail,
                                  telefon = k.Tel,
                                  unom = l.U_nom,
                                  uredname = s.Text,
                                  unomer = l.UNomer,
                                  vidured = "",
                                  raion = n.Nime
                              }).OrderBy(x => x.unomer).ToListAsync();

            return data;
        }

        public async Task<IList<ViewMonOrderItem>> getDemonPersonsDogovorUredi(int id)
        {
            var porychki = (from p in _dbContext.DemPorychkas
                            where p.IdPorachkaMain == id && p.Status == 1
                            from u in _dbContext.LicaDogovorOldUredis
                            where u.IdDogL == p.IdDogovorLice
                            select new ViewMonOrderItem
                            {
                                idured = u.IdOldurediDgl,
                                broi = p.Broi,
                            });

            return await porychki.ToListAsync();
        }

        public async Task<int> setDemonOrder(DemPorychkaMain item)
        {
            var objectExists = (item.IdPorachkaMain > 0);

            if (objectExists)
                _dbContext.DemPorychkaMain.Update(item);
            else
                _dbContext.DemPorychkaMain.Add(item);

            var odititem = new OditLog
            {
                Koga = DateTime.Now,
                User = item.User,
                Kod = 9,
                Text = "Редакция на поръчка за демонтаж: " + item.IdPorachkaMain.ToString(),
            };
            _dbContext.Entry(odititem).State = EntityState.Added;

            await _dbContext.SaveChangesAsync();
            return item.IdPorachkaMain;
        }

        public async Task SetDemonPorychkaBody(int IdPorachkaMain, List<DemPorychka> data)
        {
            //get next sequence value
            using (var dbContextTransaction = _dbContext.Database.BeginTransaction())
            {
                DelDemonPorychkaBody(IdPorachkaMain);

                data.ForEach(x =>
                {
                    _dbContext.Entry(x).State = EntityState.Added;
                });

                await _dbContext.SaveChangesAsync();
                dbContextTransaction.Commit();
            }
        }

        public async Task DelDemonPorychkaBody(int idPorychkaMain)
        {
            var porychka = _dbContext.DemPorychkas
                                     .Where(x => x.IdPorachkaMain == idPorychkaMain)
                                     .ToList();

            porychka.ForEach(c =>
            {
                //update statusa i broq porychani lica dogovor uredi 
                if (c.StatusG == 0 && c.StatusM == 0)
                {
                    //update statusa i broq porychani lica dogovor uredi 
                    var f = _dbContext.LicaDogovorOldUredis
                                 .SingleOrDefault(x => x.IdDogL == c.IdDogovorLice && x.IdKt == c.IdUred);

                    if (f != null)
                    {
                        f.StatusDU = 2;
                        _dbContext.Entry(f).State = EntityState.Modified;
                    }
                }

                //iztrivame zaqveniq ured 
                _dbContext.DemPorychkas.Attach(c);
                _dbContext.DemPorychkas.Remove(c);
            });
        }

        public async Task SetLiceDogovorOldUredi(LicaDogovorOldUredi item)
        {
            var rec = _dbContext.LicaDogovorOldUredis
                                .FirstOrDefault(x => x.IdDogL == item.IdDogL && x.IdKt == item.IdKt);

            rec.StatusDU = item.StatusDU;
            rec.Koga = item.Koga;
            rec.User = item.User;

            await _dbContext.SaveChangesAsync();
        }

        public async Task SetDemonUrediDogovor(DemDgvOlduredi item)
        {
            var rec = _dbContext.DemDgvOlduredis
                              .FirstOrDefault(x => x.IdSpDm == item.IdSpDm);

            rec.Koga = item.Koga;
            rec.User = item.User;

            await _dbContext.SaveChangesAsync();
        }

        public async Task DelDemonUrediDogovor(int idporychkamain, int idlicedogovor)
        {
            int iddogovor = (from c in _dbContext.DemPorychkaMain
                             where c.IdPorachkaMain == idporychkamain
                             select c.IdDogovorFirma)
                             .SingleOrDefault();

            var porychka = _dbContext.DemPorychkas
                                .Where(x => x.IdPorachkaMain == idporychkamain && x.IdDogovorLice == idlicedogovor)
                                .ToList();

            porychka.ForEach(c =>
            {
                //update statusa i broq porychani lica dogovor uredi 
                var f = _dbContext.LicaDogovorOldUredis
                             .SingleOrDefault(x => x.IdDogL == idlicedogovor && x.IdKt == c.IdUred);
                f.StatusDU = 2;
                _dbContext.Entry(f).State = EntityState.Modified;

                //iztrivame zaqveniq ured 
                _dbContext.DemPorychkas.Attach(c);
                _dbContext.DemPorychkas.Remove(c);
            });

            await _dbContext.SaveChangesAsync();

        }

        public async Task UpdDemPorychkaBodyGrafik(int iddog, DemPorychka item)
        {
            //update statusa na uredite w porychkata
            var f = _dbContext.DemPorychkas
                         .SingleOrDefault(x => x.IdPorachkaBody == item.IdPorachkaBody);
            f.StatusG = item.StatusG;
            f.DoData = (item.DoData.HasValue ? ((DateTime) item.DoData).Date : null);
            f.OtChas = item.OtChas;
            f.DoChas = item.DoChas;
            f.Note = item.Note;
            f.User = item.User;
            f.Koga = item.Koga;

            _dbContext.Entry(f).State = EntityState.Modified;

            if (item.StatusG > 1)
            {
                //update statusa i broq porychani lica dogovor uredi 
                var l = _dbContext.LicaDogovorOldUredis
                             .SingleOrDefault(x => x.IdDogL == f.IdDogovorLice && x.IdKt == f.IdUred);

                if (item.StatusG == 2)
                    l.StatusDU = 2;
                else if (item.StatusG == 3)
                    l.StatusDU = 6;
                else if (item.StatusG == 4)
                    l.StatusDU = 2;

                _dbContext.Entry(l).State = EntityState.Modified;
            }

            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdDemPorychkaBodyOtchet(int iddog, DemPorychka item)
        {
            //update statusa na uredite w porychkata
            var f = _dbContext.DemPorychkas
                         .SingleOrDefault(x => x.IdPorachkaBody == item.IdPorachkaBody && x.StatusG <= 1);

            if (f != null) { 
                f.StatusM = item.StatusM;
                f.DemData = item.DemData;
                f.Snimka = item.Snimka;
                f.Note2 = item.Note2;
                f.User = item.User;
                f.Koga = item.Koga;

                using (var transaction = _dbContext.Database.BeginTransaction())
                {
                    try
                    {
                        _dbContext.Entry(f).State = EntityState.Modified;

                        //update statusa i broq porychani lica dogovor uredi 
                        var l = _dbContext.LicaDogovorOldUredis
                                        .SingleOrDefault(x => x.IdDogL == f.IdDogovorLice && x.IdKt == f.IdUred);

                        if (item.StatusM == 1)
                            l.StatusDU = 5;
                        else if (item.StatusM == 2)
                            l.StatusDU = 2;
                        else if (item.StatusM == 3)
                            l.StatusDU = 6;
                        else if (item.StatusM == 4)
                            l.StatusDU = 2;

                        _dbContext.Entry(l).State = EntityState.Modified;

                        await _dbContext.SaveChangesAsync();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine("Error occurred.");
                    }
                }
            }
        }
        public async Task DelDemonOrder(int idporychkamain)
        {
            //update status na porychkata
            var d = _dbContext.DemPorychkaMain
                         .SingleOrDefault(x => x.IdPorachkaMain == idporychkamain);
            d.StatusDM = 9;
            d.Status = 0;
            _dbContext.Entry(d).State = EntityState.Modified;
            _dbContext.SaveChanges();

            await DelDemonPorychkaBody(idporychkamain);
        }

        public async Task<IList<ViewPersUrediOrder>> getDemonUrediFromMonPorychka(int iddogovorfirma, int idmonporychka)
        {
            var firmadoguredi = (from u in _dbContext.DemDgvOlduredis
                                 where u.IdFirmaDm == iddogovorfirma
                                 select u.IdKn)
                                .ToList();

            var licadog = (from m in _dbContext.MonPorychkas
                            where m.IdPorachkaMain == idmonporychka
                            select new
                            {
                               iddogovorlice = m.IdDogovorLice
                            })
                            .Distinct()
                            .ToList();

            var uredi = (from m in licadog
                         from f in _dbContext.LicaDogovorOldUredis
                         where f.IdDogL == m.iddogovorlice
                            && f.IdKt != 22
                            && f.StatusDU == 2
                         from n in _dbContext.NNmnObshtis
                         where n.IdKn == f.IdKt
                            && n.KodNmn == "06"
                         select new
                         {
                             idl = f.IdL,
                             iddogovorlice = f.IdDogL,
                             idured = f.IdKt,
                             broi = f.Broi,
                             name = n.Text + " -" + f.Broi.ToString() + " бр."
                         })
                         .OrderBy(x => x.iddogovorlice)
                         .ToList();

            var opos = uredi
                        .OrderBy(x => x.idured)
                        .GroupBy(x => new { x.idl, x.iddogovorlice })
                        .Select(f => new
                        {
                            idl = f.Key.idl,
                            iddogovorlice = f.Key.iddogovorlice,
                            name = f.Select(si => si.name)
                        })
                       .ToList()
                       .Select(x => new {
                           idl = x.idl,
                           iddogovorlice = x.iddogovorlice,
                           uredi = string.Join("; ", x.name)
                       })
                       .ToList();

            for (int i = opos.Count() - 1; i >= 0; i--)
            {
                var licedoguredi = (from f in uredi
                                    where f.idl == opos[i].idl
                                    select f.idured)
                                    .ToList();

                var c = licedoguredi
                    .Where(i => firmadoguredi.Contains(i))
                    .ToList();

                if (c.Count() != licedoguredi.Count())
                {
                    opos.Remove(opos[i]);
                }

            };

            var data = (from f in opos
                        from l in _dbContext.ViewAdres
                        where l.ID_L == f.idl
                        from k in _dbContext.LicaFormuliarKolektiv
                        where k.IdL == f.idl && k.IsTitulqr == 1 && k.StatusL < 3 && k.Status == 1
                        select new ViewPersUrediOrder
                        {
                            iddogovorlice = f.iddogovorlice,
                            IdL = ((int)(l.ID_L.HasValue ? l.ID_L : 0)),
                            ident = k.Ident,
                            ime = k.Ime,
                            adres = (l != null ? l.Adres : ""),
                            vidimot = l.vidimot,
                            email = k.EMail,
                            telefon = k.Tel,
                            unom = (l != null ? l.U_nom : ""),
                            unomer = (l != null ? l.UNomer : 0),
                            uredname = f.uredi
                        });

            return data.OrderBy(x => x.unomer).ToList();
        }

        public async Task<int> setDemonOtchetUredi(string opos, string dogovor, string data)
        {
            var f = _dbContext.LicaFormuliars
                        .Where(x => x.UNom == opos && x.Status==1)
                        .FirstOrDefault();

            if (f == null)
            {
                return -1;
            } else { 
                var d = _dbContext.LicaDogovors
                            .Where(x => x.IdL == f.IdL && x.Status == 1)
                            .FirstOrDefault();
                if (d == null)
                {
                    return -2;
                }
                else if (d.StatusDl == 6 || d.StatusDl == 9)
                {
                    return -4;
                } else { 
                    String dognomer = d.RegN + '/' +
                                       (d.DataRegN.HasValue ? d.DataRegN.Value.ToString("dd.MM.yyyy") : "");
// premahnato test-1                   if (dognomer.Equals(dogovor))
                    {
                        var p = _dbContext.DemPorychkas
                                    .Where(x => x.IdDogovorLice == d.IdDogL && x.StatusM != 4)
                                    .FirstOrDefault();
                        if (p == null)
                        {
                            return -3;
                        } 
                        else { 
                            using (var transaction = _dbContext.Database.BeginTransaction())
                            {
                                try
                                {
                                    //update statusa  w porychkata 
                                    _dbContext.DemPorychkas
                                            .Where(x => x.IdDogovorLice == d.IdDogL && x.StatusM != 4)
                                            .ToList()
                                            .ForEach(x => {
                                                x.StatusM = 1;
                                                x.DemData = DateTime.ParseExact(data, "dd.MM.yyyy", CultureInfo.InvariantCulture);
                                            });

                                    _dbContext.Entry(p).State = EntityState.Modified;

                                    //update statusa  lica dogovor uredi 
                                    _dbContext.LicaDogovorOldUredis
                                            .Where(x => x.IdDogL == p.IdDogovorLice && x.Status < 6)
                                            .ToList()
                                            .ForEach(x => {
                                                x.StatusDU = (short)5;
                                            });

                                    await _dbContext.SaveChangesAsync();
                                    transaction.Commit();
                                }
                                catch (Exception ex)
                                {
                                    transaction.Rollback();
                                    Console.WriteLine("Error occurred.");
                                }
                            }
                        }
                    }
                    //else
                    //{
                    //    return -2;
                    //}
                }
            }
            return 0;
        }
        #endregion

        #region fakturi
        public async Task<IList<ViewListFakturi>> getMonListFakturi(int vid)
        {
            var data = (from p in _dbContext.FacturiMain
                        where p.VidFirma == vid && p.Status == 1
                        from f in _dbContext.Firmi
                        where f.IdFirma == p.IdFirma
                        select new ViewListFakturi
                        {
                            idfaktura = p.IdFactura,
                            faknomer = p.FacNomer,
                            fakdata = (p.FacData.HasValue ? p.FacData.Value.ToString("dd.MM.yyyy") : ""),
                            idfirma = p.IdFirma,
                            eik = f.EIK,
                            ime = f.Ime,
                            total = p.Total
                        });

            return await data.ToListAsync();
        }

        public async Task<ViewFaktura> GetFaktura(int idfaktura)
        {
            var faktura = (from p in _dbContext.FacturiMain
                           where p.IdFactura == idfaktura
                           select new ViewFaktura
                           {
                               idfactura = p.IdFactura,
                               vidfirma = p.VidFirma,
                               facnomer = p.FacNomer,
                               facdata = p.FacData,
                               idfirma = p.IdFirma,
                               iddogovorfirma = p.idDogovorFirma,
                               suma = p.Suma,
                               dds = p.DDS,
                               total = p.Total,
                               broifiles = p.BroiFiles,
                               status = p.Status,
                               vidpayment = p.VidPayment,
                               forperiod = p.ForPeriod
                           })
                        .FirstOrDefault();


            if (faktura != null)
            {
                var items = (from p in _dbContext.FacturiRows
                             where p.IdFactura == idfaktura
                             select new ViewFakturaItems
                             {
                                 idfaktura = p.IdFactura,
                                 idured = p.IdKn,
                                 broi = p.Broi,
                                 edcena = p.EdCena,
                                 total = p.EdCena* p.Broi
                             })
                            .ToList();
                faktura.fakturaitems = items;
            }
            else
                faktura = new ViewFaktura();

            return await Task.FromResult(faktura);
        }

        public async Task<int> SetFaktura(FacturiMain item)
        {
            var objectExists = (item.IdFactura > 0);

            if (objectExists)
                _dbContext.FacturiMain.Update(item);
            else
                _dbContext.FacturiMain.Add(item);

            await _dbContext.SaveChangesAsync();
            return item.IdFactura;
        }

        public async Task SetFakturaBody(FacturiRows data)
        {
            _dbContext.Entry(data).State = EntityState.Added;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DelFakturaBody(int idFactura)
        {
            _dbContext.FacturiRows
                     .RemoveRange(_dbContext.FacturiRows
                                            .Where(x => x.IdFactura == idFactura));
            await _dbContext.SaveChangesAsync();
        }

        public async Task<int> DelFaktura(int idFactura)
        {
            //update status na porychkata
            var d = _dbContext.FacturiMain
                         .SingleOrDefault(x => x.IdFactura == idFactura);
            d.Status = 0;
            _dbContext.Entry(d).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return d.IdFactura;
        }

        public async Task<List<FacturiDokumenti>> GetDocuments(int id, int typedoc)
        {
            var data = (from d in _dbContext.FacturiDokumenti
                                .Where(obj => obj.IdFactura == id && obj.Status == 1 && obj.DocType == typedoc)
                        select new FacturiDokumenti()
                        {
                            IdDok = d.IdDok,
                            IdFactura = d.IdFactura,
                            DocType = d.DocType,
                            DocDescription = d.DocDescription,
                            FileName = d.FileName
                        });

            return await data.ToListAsync();
        }

        public async Task<FacturiDokumenti> GetDocument(int id)
        {
            var data = (from d in _dbContext.FacturiDokumenti
                                .Where(obj => obj.IdDok == id)
                        select new FacturiDokumenti()
                        {
                            IdDok = d.IdDok,
                            IdFactura = d.IdFactura,
                            DocType = d.DocType,
                            DocDescription = d.DocDescription,
                            FileName = d.FileName,
                            SavedFileName = d.SavedFileName,
                        });

            return await data.FirstOrDefaultAsync();
        }

        public async Task SetDocument(FacturiDokumenti data)
        {
            _dbContext.Entry(data).State = EntityState.Added;
            _dbContext.SaveChanges();
        }


        public async Task DelDocument(int Id)
        {
            var item = _dbContext.FacturiDokumenti.Where(x => x.IdDok == Id).First();

            _dbContext.FacturiDokumenti.Remove(item);
            await _dbContext.SaveChangesAsync();
        }

        #endregion

        #region profilaktika
        public async Task<IList<ProfOrderItem>> getProfOrder(Filter1 filter)
        {
            var prof = (from p in _dbContext.Profilaktika
                        from m in _dbContext.MonPorychkaMain
                        where p.IdPorachkaMain == m.IdPorachkaMain
                        select new 
                        {
                            idfirma = m.IdFirma,
                            iddog = m.IdDogovorFirma,
                            Status_PF = p.Status_PF,
                            id = p.Id,
                            idporychkamain = m.IdPorachkaMain
                        });

            if (filter.firma > 0)
            {
                prof = prof.Where(m => m.idfirma == filter.firma);
            }

            if (filter.dogovor > 0)
            {
                prof = prof.Where(m => m.iddog == filter.dogovor);
            }

            if (filter.porychkanom > 0)
            {
                prof = prof.Where(m => m.idporychkamain == filter.porychkanom);
            }

            if (filter.statusPF > -1)
            {
                prof = prof.Where(m => m.Status_PF == filter.statusPF);
            }


            var data = (from p0 in prof
                        from p in _dbContext.Profilaktika
                        where p.Id == p0.id
                        from fd in _dbContext.MonDogovors
                        where p0.iddog == fd.IdFirmaMn
                        from fm in _dbContext.Firmi
                        where p0.idfirma == fm.IdFirma
                        from l in _dbContext.LicaDogovors
                        where l.IdDogL == p.IdDogovorLice
                        from f in _dbContext.LicaFormuliars
                        where l.IdL == f.IdL
                        from k in _dbContext.LicaFormuliarKolektiv
                        where k.IdL == l.IdL && k.IsTitulqr == 1 && k.StatusL < 3 && k.Status == 1
                        from u in _dbContext.NUredi
                        where p.IdUred == u.Id
                        from s in _dbContext.NStatusis
                        where p.Status_PF == s.StatusCode && s.StatusName == "Status_PF"
                        from a in _dbContext.ViewAdres
                        where l.IdL == a.ID_L
                        select new ProfOrderItem
                        {
                            id = p.Id,
                            idporychkamain = p.IdPorachkaMain,
                            idporychka = p.Id,
                            unom = f.UNom,
                            idured = p.IdUred,
                            nkod = u.Nkod,
                            nomer = p.PNomer,
                            ured = u.Nime,
                            broi = p.Broi,
                            ime = k.Ime,
                            adres = a.Adres,
                            plandata = p.Data,
                            otchdata = p.OtchetData,
                            status_pf = p.Status_PF,
                            model = p.Model,
                            note = p.Note,
                            status_pfstr = s.Text,
                            unomer = f.UNomer,
                            idprofilaktika = p.idprofilaktika,
                            dogfirma = fd.RegIndex,
                            namefirma = fm.Ime
                        });


            return data.OrderBy(x => x.unomer).ToList();
        }

        public async Task<int> setMonProfilaktika(int id, string otchdata, string note, int status_pf, int idprofilaktika)
        {
            var f = _dbContext.Profilaktika
                         .Where(x => x.Id == id)
                         .SingleOrDefault();
            if (f == null)
            {
                return -1;
            }
            else
            {
                if (otchdata != null)
                {
                    f.OtchetData = DateTime.ParseExact(otchdata, "dd.MM.yyyy", CultureInfo.InvariantCulture);
                }
                f.Status_PF = status_pf;
                f.Note = note;
                f.idprofilaktika = idprofilaktika;

                _dbContext.Entry(f).State = EntityState.Modified;

                await _dbContext.SaveChangesAsync();
                return 0;
            }
        }

        public async Task<IList<ProfOrderItem>> getProfOrderById(int idprofilaktika)
        {
            var prof = (from p in _dbContext.Profilaktika
                        where p.idprofilaktika == idprofilaktika
                        from m in _dbContext.MonPorychkaMain
                        where p.IdPorachkaMain == m.IdPorachkaMain
                        select new
                        {
                            idfirma = m.IdFirma,
                            iddog = m.IdDogovorFirma,
                            Status_PF = p.Status_PF,
                            id = p.Id,
                            idporychkamain = m.IdPorachkaMain
                        });

            var data = (from p0 in prof
                        from p in _dbContext.Profilaktika
                        where p.Id == p0.id
                        from l in _dbContext.LicaDogovors
                        where l.IdDogL == p.IdDogovorLice
                        from f in _dbContext.LicaFormuliars
                        where l.IdL == f.IdL
                        from k in _dbContext.LicaFormuliarKolektiv
                        where k.IdL == l.IdL && k.IsTitulqr == 1 && k.StatusL < 3 && k.Status == 1
                        from u in _dbContext.NUredi
                        where p.IdUred == u.Id
                        from s in _dbContext.NStatusis
                        where p.Status_PF == s.StatusCode && s.StatusName == "Status_PF"
                        from a in _dbContext.ViewAdres
                        where l.IdL == a.ID_L
                        select new ProfOrderItem
                        {
                            id = p.Id,
                            idporychkamain = p.IdPorachkaMain,
                            idporychka = p.Id,
                            unom = f.UNom,
                            idured = p.IdUred,
                            nkod = u.Nkod,
                            nomer = p.PNomer,
                            ured = u.Nime,
                            broi = p.Broi,
                            ime = k.Ime,
                            adres = a.Adres,
                            plandata = p.Data,
                            otchdata = p.OtchetData,
                            status_pf = p.Status_PF,
                            model = p.Model,
                            note = p.Note,
                            status_pfstr = s.Text,
                            unomer = f.UNomer
                        });


            return data.OrderBy(x => x.unomer).ToList();
        }

        public async Task<int> getProfilaktikaNextId()
        {
            int maxId = Convert.ToInt32(_dbContext.Profilaktika.AsEnumerable()
                        .Max(row => row.idprofilaktika));

            return maxId + 1;
        }
        #endregion

    }
}
