using Common.DataAccess.EFCore;
using Common.Entities;
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
    public class LicaRepository : ILicaRepository
    {
        private readonly DataContext _dbContext;

        public LicaRepository(DataContext context)
        {
            _dbContext = context;
        }


        #region lica
        public async Task<ViewLica> GetLice(int id)
        {
            return await (from k in _dbContext.LicaFormuliarKolektiv
							where k.Id == id
						  from l in _dbContext.Licas
							where k.IdL == l.IdL
						  from f in _dbContext.LicaFormuliars
							where f.IdL == l.IdL
						  select new ViewLica() {
							 IdL = k.IdL,
							 VLice = l.VLice,
							 VIdent = k.VIdent,
							 IdLice = k.Id,
							 Ident = k.Ident,
							 Ime = k.Ime,
							 NLk = k.NLk,
							 DataIzdavane = k.DataIzdavane,
							 ARaion = k.ARaion,
							 Nm = k.Nm,
							 Kv = k.Kv,
							 Jk = k.Jk,
							 Ul = k.Ul,
							 Nomer = k.Nomer,
							 Blok = k.Blok,
							 Vh = k.Vh,
							 Etaj = k.Etaj,
							 Ap = k.Ap,
							 EMail = k.EMail,
							 Tel = k.Tel,
							 Pk = k.Pk,
							 StatusL = k.StatusL,
							 Status = l.Status,
							 Tochki1 = l.Tochki1,
							 Tochki2 = l.Tochki2,
							 Tochki3 = l.Tochki3,
							 Tochki4 = l.Tochki4,
							 Tochki5 = l.Tochki5,
							 Tochki6 = l.Tochki6,
							 Tochki7 = l.Tochki7,
							 Total = l.Total,
							 Zona = k.Zona,
							 Faza = l.Faza,
							 Koga = k.Koga,
							 User = k.User,
							 V7 = k.V7,
							 nV8 = k.nV8,
							 typeLice = k.TypeLice,
							 Unom = f.UNom
						 }) 
						.FirstOrDefaultAsync();
        }

		public async Task<int> SetLice(Lica data)
        {
			var objectExists = (data.IdL>0);
			_dbContext.Entry(data).State = objectExists ? EntityState.Modified : EntityState.Added;

			await _dbContext.SaveChangesAsync();
			return data.IdL;
		}

		public async Task<IList<ViewPersons>> GetDogovorPersons(Filter filter, string iduser)
		{

			var lica = (from f in _dbContext.ViewOpos
						from l in _dbContext.Licas
							.Where(m => m.IdL == f.ID_L)
						from r in _dbContext.LicaFormuliars
							.Where(m => m.IdL == l.IdL && m.StatusF == 2)
						from k in _dbContext.LicaFormuliarKolektiv
						  .Where(m => m.IdL == l.IdL && m.IsTitulqr == 1 && m.Status == 1)
						from n in _dbContext.NRaionis
							.Where(n => n.Nkod == k.ARaion && n.Status == 1)
						select new
						{
							idl = l.IdL,
							unom = f.U_nom,
							ident = k.Ident,
							ime = k.Ime,
							statusL = f.StatL,
							idformulqr = f.ID_Formuliar,
							statusF = f.StatF,
							statusDL = f.StatDL,
							bal = l.Total,
							VLice = l.VLice,
							raion = k.ARaion,
							unomer = f.UNomer,
							faza = l.Faza,
							adres = f.Adres,
							dvidur = f.DVidUr,
							dkodurirad = f.DKodUrIRad,
							telefon = f.Telefon,
							realnum = f.UNomer - ((uint)f.Faza * 100000),
							idlice = k.Id
						});


			if (filter.unomer > 0)
			{
				lica = lica.Where(m => m.realnum == filter.unomer);
			}
			if (filter.raionid != null && filter.raionid.Length > 0)
			{
				lica = lica.Where(m => m.raion == filter.raionid);
			}

			if (filter.faza > 0)
			{
				lica = lica.Where(m => m.faza == filter.faza);
			}

			if (filter.adres != null && filter.adres.Length > 0)
			{
				lica = lica.Where(m => m.adres.IndexOf(filter.adres) > -1);
			}

			if (filter.tipuredi != null && filter.tipuredi.Length > 0 && !filter.tipuredi.Equals("ALL") )
			{
				lica = lica.Where(m => m.dvidur.IndexOf(filter.tipuredi) > -1);
			}

			if (filter.uredi != null && filter.uredi.Length > 0)
			{
				lica = lica.Where(m => m.dkodurirad.IndexOf(filter.uredi) > -1);
			}

			var data = (from l in lica
						from d in _dbContext.LicaDogovors
							   .Where(m => m.IdL == l.idl)
							   .DefaultIfEmpty()
						from s4 in _dbContext.NNmnObshtis
								.Where(s => s.KodNmn.Equals("01") && s.IdKn == l.VLice && s.Status == 1)
								.DefaultIfEmpty()
						select new ViewPersons()
						{
							idl = l.idl,
							unom = l.unom,
							ident = l.ident,
							ime = l.ime,
							statusL = l.statusL,
							idformulqr = l.idformulqr,
							statusF = l.statusF,
							statusDL = l.statusDL,
							iddogovor = d == null ? 0 : d.IdDogL,
							typeLice = s4.Text,
							bal = l.bal,
							unomer = l.unomer,
							raion = l.raion,
							dognomer = d == null ? "" : d.RegN,
							dogdate = d == null ? "" : (d.DataRegN.HasValue ? String.Format("{0:dd.MM.yyyy}", d.DataRegN) : ""),
							telefon = l.telefon,
							adres = l.adres,
							idlice = l.idlice
						});


			return await (data).OrderBy(x => x.unomer).ToListAsync();
		}

		public async Task<IList<ViewPersons>> GetPersons(Filter filter, string iduser)
		{
			var raion = (from u in _dbContext.UserObhvat
						 where u.UserId == int.Parse(iduser)
						 select new
						 {
							 obhvatid = u.ObhvatId,
							 raionid = u.RaionId
						 }).FirstOrDefault();

			var lica = (from l in _dbContext.Licas
							.Where(m => m.VLice < 3)
						from k in _dbContext.LicaFormuliarKolektiv
							.Where(m => m.IdL == l.IdL && m.Status == 1)
						from f in _dbContext.LicaFormuliars
							.Where(m => m.IdL == l.IdL && m.Status == 1)
						select new {
							idl = l.IdL,
							faza = l.Faza,
							ident = k.Ident, 
							ime = k.Ime,
							TypeLice = k.TypeLice,
							bal = l.Total,
							raion = k.ARaion,
							unomer = f.UNomer,
							realnum = f.UNomer - ((uint)f.Faza * 100000),
							idlice = k.Id
						});

			if (filter.faza > 0)
			{
				lica = lica.Where(m => m.faza == filter.faza);
			}

			if (filter.unomer > 0)
			{
				lica = lica.Where(m => m.realnum == filter.unomer);
			}

			if (!raion.raionid.Equals("00") && raion.obhvatid == 1)
			{
				lica = lica.Where(m => m.raion == raion.raionid);
			} else
            {
				if (filter.raionid != null && filter.raionid.Length > 0)
				{
					lica = lica.Where(m => m.raion == filter.raionid);
				}
			}

			var data = (from k in lica
						from v in _dbContext.ViewOpos
							.Where(m => m.ID_L  == k.idl)
						from d in _dbContext.LicaDogovors
							.Where(m => m.IdL == k.idl)
						from s4 in _dbContext.NNmnObshtis
							.Where(s => s.KodNmn.Equals("01") && k.TypeLice == s.IdKn && s.Status == 1)
							.DefaultIfEmpty()
						select new ViewPersons()
						{
							idl = k.idl,
							unom = v.U_nom,
							ident = k.ident,
							ime = k.ime,
							statusL = v.StatL != null ? v.StatL : "",
							idformulqr = v.ID_Formuliar,
							statusF = v.StatF != null ? v.StatF : "Няма",
							iddogovor = d == null ? 0 : d.IdDogL,
							statusDL = v.StatDL != null ? v.StatDL : "Няма",
							typeLice = s4.Text != null ? s4.Text : "",
							bal = k.bal,
							unomer = v.UNomer,
							raion = k.raion,
							adres = v.Adres,
							idlice = k.idlice
						});

			return await (data).OrderBy(x => x.unomer).ToListAsync();
		}

		public int GetLiceDogovorNomer(int idlice)
		{
			var data = (from d in _dbContext.LicaDogovors
							.Where(m => m.IdL == idlice)
							select d.IdDogL)
							.SingleOrDefault();

			return data;
		}

		public async Task <int> GetLiceDogovorStatus(int idlice)
		{
			int data = (from d in _dbContext.LicaDogovors
						where d.IdL == idlice
						select d.StatusDl)
						.SingleOrDefault();

			return data ;
		}

		public async Task <ViewLiceDogovor> GetLiceDogovor(int id)
        {
			var data = await (from d in _dbContext.LicaDogovors
								.Where(m => m.IdL == id)
							from l in _dbContext.Licas
								.Where (x => x.IdL == d.IdL)
							   select new ViewLiceDogovor()
								{
									iddog = d.IdDogL,
									idl = d.IdL,
									regnom = d == null ? "" : d.RegN,
									regnomdata = d == null ? null : d.DataRegN,
									status_DL = d == null ? (short)0 : d.StatusDl,
									status = d == null ? (short)0 : d.Status,
									Comentar = d == null ? "" : d.Comentar,
									BrDopSp = d == null ? "" : d.BrDopSp,
									vid = l.VLice,
									SrokDogovor = d.SrokDogovor,
									SrokSobstvenost = d.SrokSobstvenost
								})
							 .FirstOrDefaultAsync();
			

			if (data != null)
			{
				var uredi = await _dbContext.LicaDogovorUredis
							.Where(obj => obj.IdL == id && obj.Status == 1)
							.Select (item => new ViewDogovorUredi
                            {
								IdL = item.IdL,
								IdKt = item.IdKt,
								Broi = item.Broi,
								Status = item.Status,
								StatusU = item.StatusU
                            })
							.ToListAsync();

				data.uredi = uredi;

				var olduredi = await _dbContext.LicaDogovorOldUredis
							.Where(obj => obj.IdL == id && obj.Status == 1)
							.Select(item => new ViewDogovorUredi
							{
								IdL = item.IdL,
								IdKt = item.IdKt,
								Broi = item.Broi,
								Status = item.Status,
								StatusU = item.StatusDU
							})
							.ToListAsync();

				data.olduredi = olduredi;

				var arhuredi = await _dbContext.LicaDogovorUredisArhiv
							.Where(obj => obj.IdL == id && obj.Status == 1)
							.Select(item => new ViewDogovorUredi
							{
								IdL = item.IdL,
								IdKt = item.IdKt,
								Broi = item.Broi,
								Status = item.Status,
								StatusU = item.StatusU
							})
							.ToListAsync();

				data.arhuredi = arhuredi;

				var dopsp = await _dbContext.LicaDopSporazumeniq
							.Where(obj => obj.IdL == id )
							.Select(item => new LicaDopSporazumeniq
							{
								IdL = item.IdL,
								IdDopSp = item.IdDopSp,
								RegNomer = item.RegNomer,
								Komentar = item.Komentar
							})
							.ToListAsync();

				data.dopsp = dopsp;

			}
			else {
				data = new ViewLiceDogovor();
				data.iddog = 0;
				data.idl = id;
				data.regnom = "";
				data.regnomdata = null;
				data.status_DL = (short)0;
				data.status = (short)0;

				var uredi = await _dbContext.LicaFormuliarUredis
							.Where(obj => obj.IdL == id && obj.Status == 1)
							.Select(item => new ViewDogovorUredi
							{
								IdL = item.IdL,
								IdKt = item.IdKt,
								Broi = item.Broi,
								Status = item.Status,
								StatusU = item.StatusU
							})
							.ToListAsync();

				data.uredi = uredi;

				var olduredi = await _dbContext.LicaFormuliarOldUredis
							.Where(obj => obj.IdL == id && obj.Status == 1)
							.Select(item => new ViewDogovorUredi
							{
								IdL = item.IdL,
								IdKt = item.IdKt,
								Broi = item.Broi,
								Status = item.Status,
								StatusU = item.StatusU
							})
							.ToListAsync();

				data.olduredi = olduredi;

				var arhuredi = await _dbContext.LicaDogovorUredisArhiv
							.Where(obj => obj.IdL == id && obj.Status == 1)
							.Select(item => new ViewDogovorUredi
							{
								IdL = item.IdL,
								IdKt = item.IdKt,
								Broi = item.Broi,
								Status = item.Status,
								StatusU = item.StatusU
							})
							.ToListAsync();

				data.arhuredi = arhuredi;
			}

			return data;
		}

		public async Task<int> SetLiceDogovor(string iduser, LicaDogovor data)
        {
			var objectExists = (data.IdDogL > 0);
			_dbContext.Entry(data).State = objectExists ? EntityState.Modified : EntityState.Added;

			var unom = (from d in _dbContext.LicaFormuliars
								.Where(m => m.IdL == data.IdL)
						select d.UNom)
								.SingleOrDefault();

			var odititem = new OditLog
			{
				Koga = DateTime.Now,
				User = iduser,
				Kod = 6,
				Text = "Регистрация на договор " + unom,
			};
			_dbContext.Entry(odititem).State = EntityState.Added;

			await _dbContext.SaveChangesAsync();
			return data.IdDogL;

		}

		public async Task<int> SetLiceDogovorStatus(string iduser, int iddog, int status)
        {
			_dbContext.LicaDogovors
					.Where (c => c.IdDogL == iddog)
					.ToList()
					.ForEach(a => {
						a.StatusDl = (short) status;
						a.Status = (short)(status == 9 ? 0: 1);
					});

			await _dbContext.SaveChangesAsync();

			if (status > 7) {
				_dbContext.LicaDogovorUredis
									.Where(x => x.IdDogL == iddog)
									.ToList()
									.ForEach(a => {
										a.StatusU = 9;
										a.Status = 0;
									});
				await _dbContext.SaveChangesAsync();

				_dbContext.LicaDogovorOldUredis
									.Where(x => x.IdDogL == iddog)
									.ToList()
									.ForEach(a => {
										a.StatusDU = 9;
										a.Status = 0;
									});
				await _dbContext.SaveChangesAsync();
			}
			return iddog;
		}

		public async Task<int> SetLiceStatus(string iduser, int idlice, int status)
		{
			short stat = (short) (status == 9 ? 0 : 1);
			var data = new Lica { IdL = idlice, Status = stat};
			_dbContext.Licas
					.Attach(data)
					.Property(x => x.Status).IsModified = true;

			await _dbContext.SaveChangesAsync();

			if (status == 9)
			{
				_dbContext.LicaFormuliarKolektiv
									.Where(x => x.IdL == data.IdL)
									.ToList()
									.ForEach(a => {
										a.Status  = 0;
										a.StatusL = (short)status;
									});
				await _dbContext.SaveChangesAsync();
			}
			return data.IdL;
		}

		public async Task<int> changeLiceTitulqr(string iduser, int idlice, int statuslice)
        {
			var f = _dbContext.LicaFormuliars
						.Where (x=> x.IdL == idlice)
						.FirstOrDefault();

			var data = _dbContext.LicaFormuliarKolektiv.Find(idlice);

			data.Status = 0;
			data.IsTitulqr = 0;
			data.StatusL = (short)statuslice;
			data.User = iduser;
			data.Koga = DateTime.Now;
			_dbContext.Entry(data).State = EntityState.Modified;

			var odititem = new OditLog
			{
				Koga = DateTime.Now,
				User = iduser,
				Kod = 3,
				Text = "Промяна на статус лице: " + f.UNom,
			};
			_dbContext.Entry(odititem).State = EntityState.Added;

			await _dbContext.SaveChangesAsync();
			return data.IdL;
		}

		public async Task<int> updOposDogovorNomer(string nomer, string data, string otnosno)
        {
			DateTime datanom;

			if (otnosno != null)
			{
				String s1 = (otnosno.Trim().Length > 8 ? otnosno.Trim().Substring(0, 8) : "");
				String s2 = (otnosno.Trim().Length > 10 ? otnosno.Trim().Substring(0, 10) : "");

				if (!(s1.Equals("СО ОПОС_") || s2.Equals("2 СО ОПОС_")))
				{
					return -2;              //greshen fornat nomer OPOS
				}
			} else
            {
				return -2;              //greshen fornat nomer OPOS
			}

			try {
				datanom = DateTime.ParseExact(data, "dd.MM.yyyy", CultureInfo.InvariantCulture);
			} catch (Exception e)
			{
				return -2;				//greshen format na data
			}

			var f = _dbContext.LicaFormuliars
					.Where(x =>  x.UNom == otnosno && x.Status==1 )
					.FirstOrDefault();

			if (f != null)
			{
				var d = _dbContext.LicaDogovors
										.Where(x => x.IdL == f.IdL && x.Status == 1)
										.FirstOrDefault();
				if (d != null) {
					try
					{
						d.RegN = (d.RegN == null ? "" : d.RegN);
						if (d.RegN.Length == 0)
						{
							d.RegN = nomer;
							d.DataRegN = datanom;
							d.StatusDl = (d.StatusDl < 2 ? (short) 2: d.StatusDl);

							_dbContext.Entry(d).State = EntityState.Modified;
							await _dbContext.SaveChangesAsync();

							_dbContext.LicaDogovorUredis
									.Where(x => x.IdDogL == d.IdDogL)
									.ToList()
									.ForEach(a => {
										a.StatusU = (a.StatusU < 2 ? (short) 2 : a.StatusU);
									});
							await _dbContext.SaveChangesAsync();

							_dbContext.LicaDogovorOldUredis
									.Where(x => x.IdDogL == d.IdDogL)
									.ToList()
									.ForEach(a => {
										a.StatusDU = (a.StatusDU < 2 ? (short)2 : a.StatusDU);
									});
							await _dbContext.SaveChangesAsync();

						}
						else if (d.RegN.Equals(nomer))
						{
							d.DataRegN = DateTime.ParseExact(data, "dd.MM.yyyy", CultureInfo.InvariantCulture);
							d.StatusDl = (d.StatusDl < 2 ? (short)2 : d.StatusDl);

							_dbContext.Entry(d).State = EntityState.Modified;
							await _dbContext.SaveChangesAsync();

							_dbContext.LicaDogovorUredis
									.Where(x => x.IdDogL == d.IdDogL)
									.ToList()
									.ForEach(a => {
										a.StatusU = (a.StatusU < 2 ? (short)2 : a.StatusU);
									});
							await _dbContext.SaveChangesAsync();

							_dbContext.LicaDogovorOldUredis
									.Where(x => x.IdDogL == d.IdDogL)
									.ToList()
									.ForEach(a => {
										a.StatusDU = (a.StatusDU < 2 ? (short)2 : a.StatusDU);
									});
							await _dbContext.SaveChangesAsync();
						}
						else
							return -4;		// ralichno nomera
					}
					catch (Exception e) {
						return -2;			//greshen format
					}
				} else
					return -3;              //lipswa dogowor
			}
			else
				return -1;                  //lipswa OPOS

			return 0;
		}

		public async Task<int> setLiceDogovorExpired(string iduser, int iddog)
        {
			var d = _dbContext.LicaDogovors
						.Where(x => x.IdDogL == iddog)
						.FirstOrDefault();
			if (d != null)
			{
				d.isexpired = 1;
				d.Koga = DateTime.Now;
				d.User = iduser;

				_dbContext.Entry(d).State = EntityState.Modified;
				await _dbContext.SaveChangesAsync();
			}
			return iddog;
		}

		#endregion

		#region firma
		public async Task<IList<ViewFirms>> GetFirms(Filter filter, string iduser)
        {
			var raion = (from u in _dbContext.UserObhvat
						 where u.UserId == int.Parse(iduser)
						 select new
						 {
							 obhvatid = u.ObhvatId,
							 raionid = u.RaionId
						 }).FirstOrDefault();


			var firm = (from l in _dbContext.Licas
								.Where(m => m.VLice == 3)
						from f in _dbContext.LicaFormuliars
							.Where(m => m.IdL == l.IdL && m.Status == 1)
						from k in _dbContext.LicaFormuliarKolektiv
							   .Where(m => m.IdL == l.IdL && m.IsTitulqr == 1)
						from fm in _dbContext.LicaFormuliarFirma
							   .Where(m => m.IdL == l.IdL)
						from d in _dbContext.LicaDogovors
							   .Where(m => m.IdL == l.IdL)
							   .DefaultIfEmpty()
						select new 
						{	
							faza = l.Faza,
							idl = l.IdL,
							idfirma = fm.Id,
							ident = fm.Ident,
							ime = fm.Ime,
							iddogovor = d == null ? 0 : d.IdDogL,
							raion = k.ARaion
						});

			if (filter.faza > 0)
			{
				firm = firm.Where(m => m.faza == filter.faza);
			}

			if (!raion.raionid.Equals("00") && raion.obhvatid == 1)
			{
				firm = firm.Where(m => m.raion == raion.raionid);
			}
			else
			{
				if (filter.raionid != null && filter.raionid.Length > 0)
				{
					firm = firm.Where(m => m.raion == filter.raionid);
				}
			}

			var data = (from f in firm
						from v in _dbContext.ViewOpos
							.Where(s => s.ID_L == f.idl)
						select new ViewFirms()
						{
							idfirma = f.idfirma,
							unom = v.U_nom,
							ident = f.ident,
							ime = f.ime,
							statusL = v.StatL != null ? v.StatL : "",
							idformulqr = v.ID_Formuliar,
							statusF = v.StatF != null ? v.StatF : "Няма",
							iddogovor = f.iddogovor,
							statusDL = v.StatDL != null ? v.StatDL : "Няма",
							unomer = v.UNomer,
							raion = f.raion
						});

			return await (data).OrderBy(x => x.unomer).ToListAsync();
		}

		public async Task<LicaFormuliarFirma> GetFirma(int id)
        {
			return await _dbContext.LicaFormuliarFirma 
					.Where(obj => obj.Id == id)
					.FirstOrDefaultAsync();
		}
		public async Task<int> SetFirma(LicaFormuliarFirma data)
        {
			var objectExists = (data.Id > 0);
			_dbContext.Entry(data).State = objectExists ? EntityState.Modified : EntityState.Added;

			await _dbContext.SaveChangesAsync();
			return data.IdL;
		}
		#endregion

		#region formulqr
		public async Task<ViewFormulqr> GetFormulqr(int id)
        {
			var data = await (
				from f in _dbContext.LicaFormuliars
					where f.IdFormuliar == id
				join d in _dbContext.LicaDogovors on f.IdL equals d.IdL into leftJ
				from r in leftJ.DefaultIfEmpty()
				select new ViewFormulqr()
                {
                    IdFormulqr = f.IdFormuliar,
					uNom = f.UNom,
					Faza = f.Faza,
					regdate = f.RegDate,
					IdL = f.IdL,
					nv9 = f.nV9,
					nv10= f.nV10,
					v11 = f.V11,
					v12 = f.V12,
					v13 = f.V13,
					v14 = f.V14,
					v15 = f.V15,
					v16 = f.V16,
					v17 = f.V17,
					nv18 = f.nV18,
					nv19 = f.nV19,
					v20 = f.V20,
					v211 = f.V211,
					v212 = f.V212,
					v213 = f.V213,
					v22 = f.V22,
					v23 = f.V23,
					v24 = f.V24,
					v25 = f.V25,
					v26 = f.V26,
					v27 = f.V27,
					v28 = f.V28,
					nv29 = f.nV29,
					v30 = f.V30,
					v31 = f.V31,
					v32 = f.V32,
					v33 = f.V33,
					v34 = f.V34,
					v35 = f.V35,
					v36 = f.V36,
					v37 = f.V37,
					v38 = f.V38,
					v391 = f.V391,
					v392 = f.V392,
					v401 = f.V401,
					v402 = f.V402,
					v41 = f.V41,
					v421 = f.V421,
					v422 = f.V422,
					v423 = f.V423,
					status = f.Status,
					statusF = f.StatusF,
					uNomer = f.UNomer,
					statusDL = (r.StatusDl == null ? (short)0 : r.StatusDl),
					comentar = f.comentar
				})
                .FirstOrDefaultAsync();

			if (data != null)
			{
				var lice = await (from l in _dbContext.Licas
									.Where(obj => obj.IdL == data.IdL && obj.Status == 1)
								  from k in _dbContext.LicaFormuliarKolektiv
								    .Where(m => m.IdL == l.IdL && m.IsTitulqr == 1 && m.Status == 1)
								  select new ViewLica () {
									  IdL = l.IdL,
									  VLice = l.VLice,
									  IdLice = k.Id,
									  VIdent = k.VIdent,
									  Ident = k.Ident,
									  Ime = k.Ime,
									  NLk = k.NLk,
									  DataIzdavane = k.DataIzdavane,
									  ARaion = k.ARaion,
									  Nm = k.Nm,
									  Kv = k.Kv,
									  Jk = k.Jk,
									  Ul = k.Ul,
									  Nomer = k.Nomer,
									  Blok = k.Blok,
									  Vh = k.Vh,
									  Etaj = k.Etaj,
									  Ap = k.Ap,
									  EMail = k.EMail,
									  Tel = k.Tel,
									  Pk = k.Pk,
									  StatusL = k.StatusL,
									  Status = l.Status,
									  Tochki1 = l.Tochki1,
									  Tochki2 = l.Tochki2,
									  Tochki3 = l.Tochki3,
									  Tochki4 = l.Tochki4,
									  Tochki5 = l.Tochki5,
									  Tochki6 = l.Tochki6,
									  Tochki7 = l.Tochki7,
									  Total = l.Total,
									  Zona = k.Zona,
									  Faza = l.Faza,
									  Koga = k.Koga,
									  User = k.User,
									  V7 = k.V7,
									  nV8 = k.nV8,
								  })
								  .FirstOrDefaultAsync();

				data.lice = lice;

				var firma = await _dbContext.LicaFormuliarFirma
							.Where(obj => obj.IdL == data.IdL && obj.Status == 1)
							.FirstOrDefaultAsync();

				data.firma = firma;

				var uredi = await _dbContext.LicaFormuliarUredis
							.Where(obj => obj.IdL == data.IdL && obj.Status == 1)
							.ToListAsync();

				data.uredi = uredi;

				var olduredi = await _dbContext.LicaFormuliarOldUredis
							.Where(obj => obj.IdL == data.IdL && obj.Status == 1)
							.ToListAsync();

				data.olduredi = olduredi;

				data.dokumenti = await GetDocuments(data.IdL);

				var systav = await _dbContext.LicaFormuliarKolektiv
						.Where(obj => obj.IdL == data.IdL && obj.Status == 1 && obj.IsTitulqr==0)
						.ToListAsync();

				data.systav = systav;

			}
			return data;
        }

		public async Task<int> AddFormulqr(
			Lica lice,
			LicaFormuliar formulqr,
			LicaFormuliarKolektiv titular,
			LicaFormuliarFirma firma,
			List<LicaFormuliarOldUredi> olduredi,
			List<LicaFormuliarUredi> uredi,
			List<LicaFormuliarKolektiv> systav,
			List<LicaDokumenti> dokumenti
		)
        {
			int id = 0;

			int unomer = 0;
			//get next sequence value
			using (var dbContextTransaction = _dbContext.Database.BeginTransaction())
			{
				var seq = _dbContext.Sequnces.Where(x => x.seqname == "FORM").FirstOrDefault();
				seq.seqval = seq.seqval + 1;
				_dbContext.Sequnces.Update(seq);
				dbContextTransaction.Commit();

				//generare formulqr unom
				unomer = seq.seqval;
			}

			using (var transaction = _dbContext.Database.BeginTransaction())
			{
				try
				{
					lice.Faza = formulqr.Faza;
					_dbContext.Entry(lice).State =EntityState.Added;
					await _dbContext.SaveChangesAsync();
					id = lice.IdL;

					//lice_formulqr_kolektiv - titulqr
					titular.IdL = id;
					await SetKolektiv(titular);

					//lice_formulqr_firma
					if (lice.VLice == 3)
					{
						firma.IdL = id;
						firma.Faza = formulqr.Faza;
						await SetFirma(firma);
					}

					//lice_fomulqr
					formulqr.IdL = id;
					int idformulqr =  await SetFormulqr(formulqr, lice.VLice, unomer);

					//lice_fomulqr_olduredi
					await DelOldUredi(id);
					foreach (LicaFormuliarOldUredi item in olduredi)
					{
						item.IdL = id;
						item.IdFormuliar = idformulqr;
						await SetOldUredi(item);
					}

					//lice_fomulqr_uredi
					await DelUredi(id);
					foreach (LicaFormuliarUredi item in uredi)
					{
						item.IdL = id;
						item.IdFormuliar = idformulqr;
						await SetUredi(item);
					}

					//lice_fomulqr_dokumenti
					await DelDocuments(id);
					foreach (LicaDokumenti item in dokumenti)
					{
						item.IdL = id;
						await SetDocument(item);
					}

					//lice_fomulqr_kolektiv
					await DelKolektiv(id);
					foreach (LicaFormuliarKolektiv item in systav)
					{
						item.IdL = id;
						await SetKolektiv(item);
					}

					transaction.Commit();
				}
				catch (Exception ex)
				{
					transaction.Rollback();
					throw ex;
				}
			}

			return id;
		}


		public async Task<int> SetFormulqr(LicaFormuliar item, int vid, int unomer)
		{
			var objectExists = (item.IdFormuliar>0);

			if (objectExists)
				_dbContext.LicaFormuliars.Update(item);
			else {
				string preffix = (item.Faza == 1 ? "" : item.Faza.ToString().Trim() + " ") + "СО ОПОС_";
				string suffix  = "";

				if (vid == 2) {
					suffix = "К";
				}
				else if (vid ==3)
                {
					suffix = "Ф";
				}

				item.UNom = preffix+unomer.ToString().Trim()+suffix;
				item.UNomer = item.Faza * 100000 + unomer;

				//add formulqr
				_dbContext.LicaFormuliars.Add(item);
			}

			var odititem = new OditLog
			{
				Koga = DateTime.Now,
				User = item.User,
				Kod = (objectExists ? 5:4),
				Text = (objectExists ? "Редакция" : "Регистрация") +
					   " на формуляр " + item.UNom,
			};

			_dbContext.Entry(odititem).State = EntityState.Added;

			await _dbContext.SaveChangesAsync();
			return item.IdFormuliar;
		}

		public async Task<IList<ViewListFormulqr>> GetListFormulqrs(int pVid, Filter filter, string iduser)
		{
			var formulqr = (from f in _dbContext.LicaFormuliars
							where f.Status == 1
							from s3 in _dbContext.NStatusis
							where s3.StatusName.Equals("Status_F") && f.StatusF == s3.StatusCode && s3.Status == 1
							select new
							{
								IdFormuliar = f.IdFormuliar,
								IdL = f.IdL,
								unom = f.UNom,
								status_f = f.StatusF,
								stattxt_f = f.StatusF > 0 ? s3.Text : "Няма",
								unomer = f.UNomer,
								faza = f.Faza,
								realnum = f.UNomer - ((uint)f.Faza * 100000)
							});

			var lica = (from f in formulqr
						from l in _dbContext.Licas
							.Where(m => m.IdL == f.IdL)
						from k in _dbContext.LicaFormuliarKolektiv
						  .Where(m => m.IdL == l.IdL && m.IsTitulqr == 1 && m.Status == 1)
						from n in _dbContext.NRaionis
							.Where(n => n.Nkod == k.ARaion && n.Status == 1)
						where l.VLice == pVid && l.Status == 1
						from s3 in _dbContext.NStatusis
						where s3.StatusName.Equals("Status_L") && k.StatusL == s3.StatusCode && s3.Status == 1
						select new 
						{
							IdL = l.IdL,
							IdLice = k.Id,
							raion = n.Nime,
							ident = k.Ident,
							name = k.Ime,
							telefon = k.Tel,
							status_L = k.StatusL,
							araion = k.ARaion,
							faza = l.Faza,
							stattxt_l = k.StatusL > 0 ? s3.Text : "Няма",
						});
	
			if (filter.unomer > 0)
            {
				formulqr = formulqr.Where(m => m.realnum == filter.unomer);
			}

			if (filter.faza > 0)
			{
				formulqr = formulqr.Where(m => m.faza == filter.faza);
			}

			if (filter.raionid != null && filter.raionid.Length > 0)
			{
				lica = lica.Where(m => m.araion == filter.raionid);
			}

			var firma = (from f in formulqr
						 join m in _dbContext.LicaFormuliarFirma
								on f.IdL equals m.IdL
						 where m.Status == 1
						 select new
						 {
							 idl = m.IdL,
							 idfirma = m.Id,
							 firma = m.Ime,
							 bulstat = m.Ident
						 });

			var dogovor = (from f in formulqr
						   from d in _dbContext.LicaDogovors
								where f.IdL == d.IdL && d.Status == 1
						   from s3 in _dbContext.NStatusis
								where s3.StatusName.Equals("Status_DL") && d.StatusDl == s3.StatusCode && s3.Status == 1
						   select new
						   {
							   idl = d.IdL,
							   iddogovor  = d.IdDogL,
							   status_dl  = d.StatusDl,
							   stattxt_dl = d.StatusDl > 0 ? s3.Text : "Няма"
						   });

			var data = (from f in formulqr
						from l in lica
								.Where(m => m.IdL == f.IdL)
						from sfv in firma
								.Where(m => m.idl == f.IdL)
								.DefaultIfEmpty()
						from sdv in dogovor
								.Where(m => m.idl == f.IdL)
								.DefaultIfEmpty()
						select new ViewListFormulqr()
						{
							IdFormulqr = f.IdFormuliar,
							idl = l.IdLice,
							unom = f.unom,
							raion = l.raion,
							ident = l.ident,
							name = l.name,
							telefon = l.telefon,
							idfirma = sfv.idfirma != null ? sfv.idfirma : 0,
							firma = sfv.firma != null ? sfv.firma : string.Empty,
							bulstat = sfv.bulstat != null ? sfv.bulstat : string.Empty,
							status_L = l.status_L,
							status_f = f.status_f,
							stattxt_f = f.stattxt_f,
							stattxt_l = l.stattxt_l,
							iddog = sdv.iddogovor != null ? sdv.iddogovor : 0,
							status_dl = sdv.status_dl != null ? sdv.status_dl : 0,
							stattxt_dl = sdv.stattxt_dl ,
							unomer = f.unomer
						});

			return await (data).OrderBy(x => x.unomer).ToListAsync();
		}

		public async Task<IList<ViewPersons>> getHistoryFormulqr(int id)
        {

			var data = (from f in _dbContext.LicaFormuliars
							   .Where(m => m.IdFormuliar == id && m.Status == 1)
						from k in _dbContext.LicaFormuliarKolektiv
							   .Where(m => m.IdL == f.IdL && m.Status == 0)
						from s1 in _dbContext.NStatusis
								.Where(s => s.StatusName.Equals("Status_L") && k.StatusL == s.StatusCode && s.Status == 1)
								.DefaultIfEmpty()
						from s4 in _dbContext.NNmnObshtis
								.Where(s => s.KodNmn.Equals("01") && s.IdKn == k.TypeLice && s.Status == 1)
								.DefaultIfEmpty()
						select new ViewPersons()
						{
							idl = k.IdL,
							unom = "",
							ident = k.Ident,
							ime = k.Ime,
							statusL = s1.Text != null ? s1.Text : "",
							idformulqr = f.IdFormuliar,
							statusF = "",
							iddogovor = 0,
							statusDL = "",
							typeLice = s4.Text,
							bal = 0,
							unomer = 0,
							raion = k.ARaion,
							dognomer = "",
							dogdate = (k.Koga == null ? null : k.Koga.Value.ToString("dd.MM.yyyy")),
							koga = (k.Koga == null ? null : k.Koga)
						});


			return await (data).OrderBy(x=>x.koga).ThenBy(x=>x.ime).ToListAsync();
		}

		public async Task<int> setFormulqrStatus(string iduser, int idformulqr, int status)
		{
			var f = _dbContext.LicaFormuliars.Find(idformulqr);

			f.StatusF = (short) status;
			f.User = iduser;
			f.Koga = DateTime.Now;

			int idlice = f.IdL;
			if (status == 9)
			{
				using (var transaction = _dbContext.Database.BeginTransaction())
				{
					try
					{
						f.Status = 0;
						_dbContext.Entry(f).State = EntityState.Modified;

						var lice = _dbContext.Licas.Find(idlice);
						if (lice != null)
						{
							lice.Status = 0;
							lice.User = iduser;
							lice.Koga = DateTime.Now;

							_dbContext.Entry(lice).State = EntityState.Modified;
						}

						var formuredi = _dbContext.LicaFormuliarUredis
												.Where(x => x.IdL == idlice)
												.ToList();
						formuredi.ForEach(a =>
						{
							a.Status = 0;
							a.StatusU = 9;
							_dbContext.Entry(a).State = EntityState.Modified;
						});

						var formolduredi = _dbContext.LicaFormuliarOldUredis
													.Where(x => x.IdL == idlice)
													.ToList();
						formolduredi.ForEach(a =>
						{
							a.Status = 0;
							a.StatusU = 9;
							_dbContext.Entry(a).State = EntityState.Modified;
						});

						var pers = _dbContext.LicaFormuliarKolektiv
										.Where(x => x.IdL == idlice)
										.SingleOrDefault();
						if (pers != null)
						{
							pers.Status = 0;
							pers.StatusL = 9;
							pers.User = iduser;
							pers.Koga = DateTime.Now;

							_dbContext.Entry(pers).State = EntityState.Modified;
						}

						var dog = _dbContext.LicaDogovors
											.Where(x => x.IdL == idlice)
											.SingleOrDefault();
						if (dog != null)
						{
							dog.Status = 0;
							dog.StatusDl = 9;
							dog.User = iduser;
							dog.Koga = DateTime.Now;

							_dbContext.Entry(dog).State = EntityState.Modified;
						}

						var doguredi = _dbContext.LicaDogovorUredis
												.Where(x => x.IdL == idlice)
												.ToList();
						doguredi.ForEach(a =>
						{
							a.Status = 0;
							a.StatusU = 9;
							_dbContext.Entry(a).State = EntityState.Modified;
						});

						var dogolduredi = _dbContext.LicaDogovorOldUredis
												.Where(x => x.IdL == idlice)
												.ToList();
						dogolduredi.ForEach(a =>
						{
							a.Status = 0;
							a.StatusDU = 9;
							_dbContext.Entry(a).State = EntityState.Modified;
						});

						var dok = _dbContext.LicaDokumentis
											.Where(x => x.IdL == idlice)
											.ToList();
						dok.ForEach(a =>
						{
							a.Status = 0;
							a.User = iduser;
							a.Koga = DateTime.Now;

							_dbContext.Entry(a).State = EntityState.Modified;
						});

						var firma = _dbContext.LicaFormuliarFirma.Find(idlice);
						if (firma != null)
						{
							firma.Status = 0;
							firma.StatusL = 9;
							firma.StatusF = 9;
							firma.User = iduser;
							firma.Koga = DateTime.Now;

							_dbContext.Entry(firma).State = EntityState.Modified;
						}

						var kolektiv = _dbContext.LicaFormuliarKolektiv
												.Where(x => x.IdL == idlice)
												.ToList();
						kolektiv.ForEach(a =>
						{
							a.Status = 0;
							a.StatusL = 9;
							_dbContext.Entry(a).State = EntityState.Modified;
						});

						var odititem = new OditLog
						{
							Koga = DateTime.Now,
							User = iduser,
							Kod = 10,
							Text = "Изтриване(Анулиране) на " + f.UNom,
						};
						_dbContext.Entry(odititem).State = EntityState.Added;

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
			else
			{
				_dbContext.Entry(f).State = EntityState.Modified;
				await _dbContext.SaveChangesAsync();
			}

			return f.IdFormuliar;
		}

		public async Task<int> checkFormulqrUnomer(string unomer, int faza)
        {
			var data = (from d in _dbContext.LicaFormuliars
							.Where(m => m.UNom == unomer && m.Faza == faza && m.Status==1)
						select d.IdFormuliar)
							.SingleOrDefault();

			return data;
		}

		public async Task<int> checkFormulqrAdres(Address adres)
		{
			string lcsql = "exec checkAddress " +
							adres.id.ToString() + ',' +
							"'" + adres.raionid + "'" + ',' +
							(String.IsNullOrEmpty(adres.nm)?"''": "'"+adres.nm+"'") + ',' +
							(String.IsNullOrEmpty(adres.jk) ? "''" : "'" + adres.jk + "'") + ',' +
							(String.IsNullOrEmpty(adres.ul) ? "''" : "'" + adres.ul + "'") + ',' +
							(String.IsNullOrEmpty(adres.nomer) ? "''" : "'" + adres.nomer + "'") + ',' +
							(String.IsNullOrEmpty(adres.blok) ? "''" : "'" + adres.blok + "'") + ',' +
							(String.IsNullOrEmpty(adres.vh) ? "''" : "'" + adres.vh + "'") + ',' +
							(String.IsNullOrEmpty(adres.etaj) ? "''" : "'" + adres.etaj + "'") + ',' +
							(String.IsNullOrEmpty(adres.ap) ? "''" : "'" + adres.ap + "'");

			var data = _dbContext.ViewResult
							.FromSqlRaw(lcsql)
							.ToList()
							.AsQueryable()
							.FirstOrDefault();

			return data.result;
		}

		#endregion

		#region uredi
		public async Task<List<LicaFormuliarUredi>> GetUredi(int id)
		{
			return await _dbContext.LicaFormuliarUredis
					.Where(obj => obj.IdL == id && obj.Status == 1)
					.ToListAsync();
		}
		public async Task SetUredi(LicaFormuliarUredi data)
		{
			_dbContext.Entry(data).State = EntityState.Added;
			await _dbContext.SaveChangesAsync();
		}

		public async Task DelUredi(int liceId)
		{
			_dbContext.LicaFormuliarUredis
					 .RemoveRange(_dbContext.LicaFormuliarUredis
											.Where(x => x.IdL == liceId));
			await _dbContext.SaveChangesAsync();
		}

		public async Task DelDogovorUredi(int dogovorId)
		{
			_dbContext.LicaDogovorUredis
					 .RemoveRange(_dbContext.LicaDogovorUredis
											.Where(x => x.IdDogL == dogovorId));
			await _dbContext.SaveChangesAsync();
		}

		public async Task SetDogovorUredi(LicaDogovorUredi data)
		{
			_dbContext.Entry(data).State = EntityState.Added;
			await _dbContext.SaveChangesAsync();
		}

		public async Task SetDogovorUrediArhiv(int pIdDog, List<LicaDogovorUredi> data)
		{
			var ids = data.Select(x => x.IdKt).ToList();

			var missinguredi = from s in _dbContext.LicaDogovorUredis
							   where s.IdDogL == pIdDog && !ids.Contains(s.IdKt )
							   select s;

			using (var transaction = _dbContext.Database.BeginTransaction())
			{
				try
				{
					missinguredi.ToList().ForEach(a => {
						LicaDogovorUrediArhiv l = new LicaDogovorUrediArhiv
						{
							IdDogL = a.IdDogL,
							IdL = a.IdL,
							IdKt = a.IdKt,
							Broi = a.Broi,
							StatusU = 4,
							Status = a.Status,
							User = a.User ,
							Koga = a.Koga,
							Porychani = a.Porychani
						};

						_dbContext.Entry(l).State = EntityState.Added;
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


		#endregion

		#region olduredi
		public async Task<List<LicaFormuliarOldUredi>> GetOldUredi(int id)
		{
			return await _dbContext.LicaFormuliarOldUredis
					.Where(obj => obj.IdL == id && obj.Status == 1)
					.ToListAsync();
		}
		public async Task SetOldUredi(LicaFormuliarOldUredi data)
		{
			_dbContext.Entry(data).State = EntityState.Added;
			await _dbContext.SaveChangesAsync();
		}

		public async Task DelOldUredi(int liceId)
		{
			_dbContext.LicaFormuliarOldUredis
					 .RemoveRange(_dbContext.LicaFormuliarOldUredis
											.Where(x => x.IdL == liceId));
			await _dbContext.SaveChangesAsync();
		}

		public async Task DelDogovorOldUredi(int dogovorId)
		{
			_dbContext.LicaDogovorOldUredis
					 .RemoveRange(_dbContext.LicaDogovorOldUredis
											.Where(x => x.IdDogL == dogovorId));
			await _dbContext.SaveChangesAsync();
		}

		public async Task SetDogovorOldUredi(LicaDogovorOldUredi data)
        {
			_dbContext.Entry(data).State = EntityState.Added;
			await _dbContext.SaveChangesAsync();
		}

		#endregion

		#region documenti
		public async Task<List<LicaDokumenti>> GetDocuments(int id)
        {
			var data = (from d in _dbContext.LicaDokumentis
								.Where (obj => obj.IdL == id && obj.Status == 1)
						from n in _dbContext.NNmnObshtis
								.Where (x => x.IdKn == d.DocType)
						select new LicaDokumenti()
						{
							IdL = d.IdL,
							IdDok = d.IdDok,
							DocType = d.DocType,
							DocDescription = d.DocDescription,
							FileName = d.FileName,
							Status = d.Status,
						});
					
			return await data.ToListAsync();
		}

		public async Task<LicaDokumenti> GetDocument(int id)
		{
			var data = (from d in _dbContext.LicaDokumentis
								.Where(obj => obj.IdDok == id)
						select new LicaDokumenti()
						{
							IdL = d.IdL,
							IdDok = d.IdDok,
							FileName = d.FileName,
							SavedFileName = d.SavedFileName,
							Status = d.Status,
						});

			return await data.FirstOrDefaultAsync();
		}

		public async Task SetDocument(LicaDokumenti data)
        {
			_dbContext.Entry(data).State = EntityState.Added;
			_dbContext.SaveChanges();
		}


		public async Task DelDocuments(int liceId)
		{
			_dbContext.LicaDokumentis
					 .RemoveRange(_dbContext.LicaDokumentis
											.Where(x => x.IdL == liceId));
			await _dbContext.SaveChangesAsync();
		}

		#endregion


		#region kolektiv
		public async Task<List<LicaFormuliarKolektiv>> GetKolektiv(int id)
        {
			return await _dbContext.LicaFormuliarKolektiv
					.Where(obj => obj.IdL == id && obj.Status == 1 && obj.IsTitulqr == 0 && obj.TypeLice > 1)
					.ToListAsync();
		}
		public async Task<int> SetKolektiv(LicaFormuliarKolektiv data)
        {
			_dbContext.LicaFormuliarKolektiv.Add(data);
			await _dbContext.SaveChangesAsync();
			return data.Id;
		}

		public async Task<int> UpdKolektiv(LicaFormuliarKolektiv data)
		{
			_dbContext.LicaFormuliarKolektiv.Update(data);
			await _dbContext.SaveChangesAsync();
			return data.Id;
		}

		public async Task DelKolektiv(int liceId)
		{
			_dbContext.LicaFormuliarKolektiv
					 .RemoveRange(_dbContext.LicaFormuliarKolektiv
											.Where(x => x.IdL == liceId && x.IsTitulqr==0 && x.TypeLice > 1));
			await _dbContext.SaveChangesAsync();
		}
		#endregion

		#region dop. sporazumeniq
		public async Task DelDogovorDopSp(int IdLice)
        {
			_dbContext.LicaDopSporazumeniq
					 .RemoveRange(_dbContext.LicaDopSporazumeniq
											.Where(x => x.IdL == IdLice));
			await _dbContext.SaveChangesAsync();
		}
		public async Task SetDogovorDopSp(LicaDopSporazumeniq data)
        {
			_dbContext.Entry(data).State = EntityState.Added;
			await _dbContext.SaveChangesAsync();
		}
		#endregion

		public async Task<ViewDogovorPrint> getDogovorData(int id)
		{
			string lcsql = "SELECT l.ident, v.U_nom unom, v.ime, v.adres,"+
						" DUrBezRad txturedi, DRad txtrad, DUrDem txtolduredi, vidimot, d.Reg_N regnomer," +
						" CONVERT(varchar, d.Data_reg_N, 104) regdate, l.N_LK nomlk," +
						" isnull(CONVERT(varchar, l.Data_izdavane, 104), '...........') datalk," +
						" f.f_ime, f.f_eik, f.f_Adres,a.v_lice" +
					" FROM[dbo].[vwOPOS] v" +
						" inner join lica a ON v.ID_L = a.ID_L and a.Status = 1" +
						" inner join lica_formuliar_kolektiv l ON v.ID_L = l.IDL and l.isTitulqr = 1 and l.Status = 1" +
						" inner join lica_dogovor d ON v.ID_L = d.ID_L and d.Status = 1" +
						" left join vwAdresLicaFirmi f on d.Id_L = f.ID_L";

			lcsql = lcsql +
					" WHERE v.ID_L = " + id.ToString();

			var data = _dbContext.ViewDogovorPrint.FromSqlRaw(lcsql);

			return await data
					.Select(i => new ViewDogovorPrint
					{
						unom = i.unom,
						ident = i.ident,
						ime = i.ime,
						txturedi = i.txturedi,
						txtrad = i.txtrad,
						txtolduredi = i.txtolduredi,
						adres = i.adres,
						vidimot = i.vidimot,
						regnomer = i.regnomer,
						regdate = i.regdate,
						nomlk = i.nomlk,
						datalk = i.datalk,
						f_eik = i.f_eik,
						f_ime = i.f_ime,
						f_Adres = i.f_Adres,
						v_lice = i.v_lice
					}).FirstOrDefaultAsync() ;
		}

		public async Task<IList<ViewRadiatoriZaPrekodirane>> getRadiatoriZaPrekodirane(Filter filter)
		{
			var lcsql = "SELECT x.IdL, x.iddogovorlice, fk.ime, fk.ident, a.vidimot, fk.A_Raion, a.adres"+
						"			, fk.e_mail email, fk.tel as telefon, x.uredname, f.U_nom as unom, f.unomer" +
						"			, x.Vid vidured, r.NIME as raion, s1.Text as txtStatusDL" +
						"	FROM" +
						"		(SELECT ldu.Id_L as IdL, ldu.ID_DOG_L as iddogovorlice, 0 as idured" +
						"				, STRING_AGG(u.nime + ' - ' + convert(varchar, ldu.broi) + ' бр.', '; ')" +
						"						WITHIN GROUP(ORDER BY  u.nkod) AS uredname" +
						"				, MAX(IIF(u.id > 30, '', u.Vid)) Vid" +
						"			FROM lica_dogovor_uredi ldu" +
						"				INNER JOIN(SELECT Id_L, COUNT(*) cntAll" +
						"								FROM lica_dogovor_uredi" +
						"								WHERE Status_U <= 2" +
						"								  AND Id_KT between 32 AND 49" +
						"								GROUP BY Id_L) x" +
						"						ON ldu.Id_L = x.ID_L" +
						"				INNER JOIN n_uredi u ON ldu.Id_KT = u.Id" +
						"			GROUP BY ldu.Id_L, ldu.ID_DOG_L) x" +
						"		INNER JOIN lica_dogovor ld ON x.IdL = ld.Id_L and ld.Status_DL < 6" +
						"		INNER JOIN lica_formuliar f ON x.IdL = f.Id_L" +
						"		INNER JOIN lica_formuliar_kolektiv fk ON x.IdL = fk.IdL and fk.IsTitulqr = 1 and fk.StatusL < 3" +
						"		INNER JOIN n_raioni r ON fk.A_Raion = r.NKOD" +
						"		INNER JOIN vwAdres a ON x.IdL = a.ID_L" +
						"		INNER JOIN n_statusi s1 ON ld.status_dl = s1.status_code and s1.status_name = 'Status_DL'" +
						"	WHERE f.Status = 1";

			if (filter.unomer > 0)
			{
				lcsql = lcsql + " and f.UNomer -(f.Faza* 100000) = " + filter.unomer;
			}
			else
			{
				if (filter.raionid != null && filter.raionid.Length > 0)
				{
					lcsql = lcsql + " and fk.A_Raion = '" + filter.raionid.Trim() + "'";
				}

				if (filter.tipuredi != null && !filter.tipuredi.Equals("ALL"))
				{
					string tipured = (filter.tipuredi == "RADPEL" || filter.tipuredi == "RADGAZ" ? "RAD" : filter.tipuredi);
					lcsql = lcsql + " and x.Vid like '%" + tipured.Trim() + "%'";
				}

				if (filter.statusDL > 0)
				{
					lcsql = lcsql + " and ld.Status_DL = '" + filter.statusDL.ToString() + "'";
				}

			}


			var data = _dbContext.ViewRadiatoriZaPrekodirane.FromSqlRaw(lcsql);

			return await data
				.Select(i => new ViewRadiatoriZaPrekodirane
				{
					iddogovorlice = i.iddogovorlice,
					IdL = i.IdL,
					ident = i.ident,
					ime = i.ime,
					vidimot = i.vidimot,
					A_raion = i.A_raion,
					adres = i.adres,
					email = i.email,
					telefon = i.telefon,
					uredname = i.uredname,
					unom = i.unom,
					unomer = i.unomer,
					vidured = i.vidured,
					raion = i.raion,
					txtStatusDL = i.txtStatusDL
				})
				.OrderBy(x=>x.unom)
				.ToListAsync();
		}

		public async Task<int> doPrekodiraneRadiatori(int iddog, string iduser)
        {
			string lcsql = "exec prekodiraneRadiatori " 
							+ iddog.ToString() 
							+ ",\'" + iduser + "\'";

			var data = _dbContext.ViewResult
							.FromSqlRaw(lcsql)
							.ToList()
							.AsQueryable()
							.FirstOrDefault();

			return data.result;
		}

		public async Task<Address> getAddress(int id)
        {
			return await (from k in _dbContext.LicaFormuliarKolektiv
						  where k.IdL == id
						  from f in _dbContext.LicaFormuliars
						  where f.IdL == k.IdL
						  select new Address()
						  {
							  id = k.Id,
							  raionid = k.ARaion,
							  nm = k.Nm,
							  kv = k.Kv,
							  jk = k.Jk,
							  ul = k.Ul,
							  nomer = k.Nomer,
							  blok = k.Blok,
							  vh = k.Vh,
							  etaj = k.Etaj,
							  ap = k.Ap,
							  opos = f.UNom
						  })
						.FirstOrDefaultAsync();
		}
		public async Task<int> setAddress(Address adres)
        {
			var f = _dbContext.LicaFormuliarKolektiv.Find(adres.id);

			if (f.Status == 1)
			{
				using (var transaction = _dbContext.Database.BeginTransaction())
				{
					try
					{
						f.ARaion = adres.raionid;
						f.Nm = adres.nm;
						f.Kv = adres.kv;
						f.Jk = adres.jk;
						f.Ul = adres.ul;
						f.Nomer = adres.nomer;
						f.Blok = adres.blok;
						f.Vh = adres.vh;
						f.Etaj = adres.etaj;
						f.Ap = adres.ap;

						_dbContext.Entry(f).State = EntityState.Modified;

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

			return 0;
		}

	}
}
