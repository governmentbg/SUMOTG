using Common.DataAccess.EFCore;
using Common.Entities;
using Common.Entities.Spravki;
using Common.Entities.Views;
using Common.Entities.Views.Spravki;
using Common.Repositories.Infrastructure;
using Common.Services.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Common.Repositories
{
	public class SpravkiRepository : ISpravkiRepository
	{
		private readonly DataContext _dbContext;


		public SpravkiRepository(DataContext context)
		{
			_dbContext = context;
		}


		public async Task<IList<NSpravki>> GetSpravki(int pFaza, bool includeDeleted)
		{
			if (includeDeleted)
				return await _dbContext.Set<NSpravki>()
					.Where(obj => (obj.Faza == pFaza || obj.Faza == 0))
					.ToListAsync();
			else
				return await _dbContext.Set<NSpravki>()
					.Where(obj => (obj.Faza == pFaza || obj.Faza == 0) && obj.Status == 1)
					.ToListAsync();
		}



		public async Task<IList<ViewSpravka1>> GetSpravka1(Filter1 filter)
		{
			string lcsql = "select k.Id as idL, f.ID_Formuliar idformulqr,U_Nom as unom,Ime," +
							"     Tochki1,Tochki2,Tochki3,Tochki4,Tochki5,Tochki6,Tochki7,Total,s1.Text as status" +
							" from lica l" +
							"  inner join lica_formuliar_kolektiv k on k.IdL = l.ID_L AND k.IsTitulqr=1	and k.Status=1" +
							"  inner join lica_formuliar f on l.ID_L = f.Id_L and f.Status = 1" +
							"  inner join n_statusi s1 on k.StatusL = s1.Status_Code AND s1.Status_name = 'Status_L' AND s1.Status = 1";

			lcsql = lcsql +
				" where f.Faza = f.faza";

			if (filter.raionid != null && filter.raionid.Length > 0)
			{
				lcsql = lcsql + " and A_Raion = '" + filter.raionid.Trim() + "'";
			}

			if (filter.ident != null && filter.ident.Length > 0)
			{
				lcsql = lcsql + " and ident like '%" + filter.ident.Trim() + "%'";
			}

			if (filter.name != null && filter.name.Length > 0)
			{
				lcsql = lcsql + " and ime like '%" + filter.name.Trim() + "%'";
			}

			if (filter.unom != null && filter.unom.Length > 0)
			{
				lcsql = lcsql + " and ltrim(rtrim(U_Nom)) = '" + filter.unom.Trim() + "'";
			}

			if (filter.tochki > 0)
			{
				lcsql = lcsql + " and  Total >" + filter.tochki.ToString();
			}

			lcsql = lcsql + " order by f.UNomer";

			var data = _dbContext.ViewSpravka1.FromSqlRaw(lcsql);
			return await (data).ToListAsync();
		}

		public async Task<IList<ViewSpravka2>> GetSpravka2(Filter filter)
		{
			string lcsql = "SELECT 	v.ID_L idl, v.ID_Formuliar idformulqr, v.U_Nom unom, v.Raion, v.IME Ime" +
						   "    , replace([UrIRad],';','\n') txturedi,replace([UrDem],';','\n') txtolduredi" +
						   "    , v.StatL status, v.StatF statusF, f.unomer, v.vidimot, v.adres, v.telefon, v.e_mail " +
						   "	, l.Id idlice, f.comentar " +
						   "   FROM vwOPOS v " +
						   "     inner join lica_formuliar_kolektiv l ON l.IDL = v.ID_L and l.IsTitulqr = 1 AND l.Status = 1" +
						   "     inner join lica_formuliar f ON f.ID_Formuliar = v.ID_Formuliar and f.Status = 1";

			lcsql = lcsql +
				" where f.Faza = " + (filter.faza == 0 ? "f.faza" : filter.faza.ToString());

			if (filter.raionid != null && filter.raionid.Length > 0)
			{
				lcsql = lcsql + " and A_Raion = '" + filter.raionid.Trim() + "'";
			}

			if (filter.tipuredi != null && !filter.tipuredi.Equals("ALL"))
			{
				string tipured = (filter.tipuredi == "RADPEL" || filter.tipuredi == "RADGAZ" ? "RAD" : filter.tipuredi);
				lcsql = lcsql + " and v.VidUr like '%" + tipured.Trim() + "%'";
			}

			if (filter.uredi != null && filter.uredi.Length > 0)
			{
				lcsql = lcsql + " and v.KodUrIRad like '%" + filter.uredi.Trim() + "%'";
			}

			if (filter.olduredi != null && filter.olduredi.Length > 0)
			{
				lcsql = lcsql + " and v.KodUrDem like '%" + filter.olduredi.Trim() + "%'";
			}

			if (filter.statusF > 0)
			{
				lcsql = lcsql + " and f.Status_F = " + filter.statusF.ToString();
			}
			else
			{
				lcsql = lcsql + " and f.Status_F < 9 ";
			}

			if (filter.unomer > 0)
			{
				lcsql = lcsql + " and f.UNomer -(f.Faza* 100000) = " + filter.unomer;
			}

			var data = _dbContext.ViewSpravka2.FromSqlRaw(lcsql);

			return await (data)
					.Select(i => new ViewSpravka2()
					{
						idl = i.idlice,
						idformulqr = i.idformulqr,
						unom = i.unom,
						Raion = i.Raion,
						Ime = i.Ime,
						txturedi = i.txturedi,
						txtolduredi = i.txtolduredi,
						status = i.status,
						statusF = i.statusF,
						unomer = i.unomer,
						vidimot = i.vidimot,
						adres = i.adres,
						telefon = i.telefon,
						e_mail = i.e_mail,
						Comentar = i.Comentar
					})
					.OrderBy(x => x.unomer)
					.ToListAsync();
		}

		public async Task<IList<ViewSpravka2>> GetSpravka2a(Filter filter)
		{
			string lcsql = "SELECT 	v.ID_L idl, v.ID_Formuliar idformulqr, v.U_Nom unom, v.Raion, v.IME Ime" +
						   "    , replace([DUrIRad],';','\n') txturedi,replace([DUrDem],';','\n') txtolduredi" +
						   "    , v.StatL status, v.StatDL statusF, f.unomer, v.vidimot, v.adres, v.telefon" +
						   "	, v.e_mail, isnull(d.Reg_N,'') dognomer, d.Data_reg_N dogdate, isnull(d.Comentar,'') Comentar" +
						   "	, v1.DopSpRegN, v1.DopSpVid, l.Id idlice " +
						   "   FROM vwOPOS v " +
						   "     inner join lica c ON c.ID_L = v.ID_L" +
						   "     inner join lica_formuliar_kolektiv l ON l.IDL = v.ID_L and l.IsTitulqr = 1 AND l.Status = 1" +
						   "     inner join lica_formuliar f ON f.ID_Formuliar = v.ID_Formuliar and f.Status = 1" +
						   "     inner join lica_dogovor d ON d.Id_L = v.ID_L" +
						   "	 inner join vwDopSp v1 ON v1.ID_L = v.ID_L 	";

			if (filter.statusDL > 0)
			{
				lcsql = lcsql + " and d.Status_DL = " + filter.statusDL.ToString();
			}
			else
			{
				lcsql = lcsql + " and d.Status_DL < 9 ";
			}

			lcsql = lcsql +
					" where f.Faza = " + (filter.faza == 0 ? "f.faza" : filter.faza.ToString());

			if (filter.raionid != null && filter.raionid.Length > 0)
			{
				lcsql = lcsql + " and A_Raion = '" + filter.raionid.Trim() + "'";
			}

			if (filter.tipuredi != null && !filter.tipuredi.Equals("ALL"))
			{
				lcsql = lcsql + " and v.DVidUr like '%" + filter.tipuredi.Trim() + "%'";
			}

			if (filter.uredi != null && filter.uredi.Length > 0)
			{
				lcsql = lcsql + " and v.DKodUrIRad like '%" + filter.uredi.Trim() + "%'";
			}

			if (filter.olduredi != null && filter.olduredi.Length > 0)
			{
				lcsql = lcsql + " and v.DKodUrDem like '%" + filter.olduredi.Trim() + "%'";
			}

			if (filter.vid > 0)
			{
				lcsql = lcsql + " and c.v_lice = " + filter.vid.ToString();
			}

			if (filter.unomer > 0)
			{
				lcsql = lcsql + " and f.UNomer -(f.Faza* 100000) = " + filter.unomer;
			}

			if (filter.regnom != null && filter.regnom.Length > 0)
			{
				lcsql = lcsql + " and ltrim(rtrim(d.Reg_N)) like '%" + filter.regnom.Trim() + "%'";
			}

			var data = _dbContext.ViewSpravka2.FromSqlRaw(lcsql);

			return await (data)
					.Select(i => new ViewSpravka2()
					{
						idl = i.idlice,
						idformulqr = i.idformulqr,
						unom = i.unom,
						Raion = i.Raion,
						Ime = i.Ime,
						txturedi = i.txturedi,
						txtolduredi = i.txtolduredi,
						status = i.status,
						statusF = i.statusF,
						unomer = i.unomer,
						vidimot = i.vidimot,
						adres = i.adres,
						telefon = i.telefon,
						e_mail = i.e_mail,
						dognomer = i.dognomer,
						dogdate = i.dogdate,
						Comentar = i.Comentar,
						DopSpRegN = i.DopSpRegN,
						DopSpVid = i.DopSpVid
					})
					.OrderBy(x => x.unomer)
					.ToListAsync();
		}

		public async Task<IList<ViewSpravka4>> GetSpravka4(Filter filter)
		{
			var data = from f in _dbContext.LicaFormuliars
					   where f.Status == 1
					   from l in _dbContext.LicaFormuliarKolektiv
					   where f.IdL == l.IdL && l.IsTitulqr == 1 && l.Status == 1
					   from r in _dbContext.NRaionis
					   where r.Nkod == l.ARaion
					   join d in _dbContext.LicaDogovors on f.IdL equals d.IdL into ps
					   from dr in ps.DefaultIfEmpty()
					   select new
					   {
						   idformulqr = f.IdFormuliar,
						   idl = f.IdL,
						   faza = f.Faza,
						   raionid = l.ARaion,
						   raion = r.Nime,
						   ime = l.Ime,
						   statusF = f.StatusF,
						   unomer = f.UNomer,
						   statusL = l.StatusL,
						   statusDL = dr.StatusDl,
						   idlice = l.Id
					   };

			if (filter.faza > 0)
			{
				data = data.Where(m => m.faza == filter.faza);
			}

			if (filter.raionid != null && filter.raionid.Length > 0)
			{
				data = data.Where(m => m.raionid == filter.raionid);
			}
			if (filter.statusF > 0)
			{
				data = data.Where(m => m.statusF == filter.statusF);
			}
			if (filter.statusL > 0)
			{
				data = data.Where(m => m.statusL == filter.statusL);
			}
			if (filter.statusDL > -1)
			{
				data = data.Where(m => m.statusDL == filter.statusDL);
			}

			var rez = from d in data
					  join v1 in _dbContext.ViewStatusi on d.idl equals v1.IdL into vs
					  from v in vs.DefaultIfEmpty()
					  select new ViewSpravka4
					  {
						  idl = d.idlice,
						  idformulqr = d.idformulqr,
						  raion = d.raion,
						  unom = v.U_nom,
						  Ime = d.ime,
						  statusL = v.StatL,
						  statusF = v.StatF,
						  statusDL = v.StatDL,
						  unomer = d.unomer
					  };
			return await rez.OrderBy(x => x.unomer).ToListAsync();
		}

		public async Task<IList<ViewSpravka5>> GetSpravka5(Filter filter)
		{
			_dbContext.Database.SetCommandTimeout(180);

			var data = from f in _dbContext.LicaFormuliars
					   from l in _dbContext.LicaFormuliarKolektiv
					   where f.IdL == l.IdL && l.IsTitulqr == 1 && l.Status == 1
					   from d in _dbContext.LicaDogovors
					   where f.IdL == d.IdL
					   from u in _dbContext.ViewLicaDogovorUrediVid
					   where u.IdDogL == d.IdDogL
					   from r in _dbContext.NRaionis
					   where r.Nkod == l.ARaion
					   select new
					   {
						   idformulqr = f.IdFormuliar,
						   idl = f.IdL,
						   faza = f.Faza,
						   raionid = l.ARaion,
						   raion = r.Nime,
						   ime = l.Ime,
						   statusU = u.Status_U,
						   unomer = f.UNomer,
						   unom = f.UNom,
						   idured = u.idured,
						   broi = u.Broi,
						   kodured = u.Nkod,
						   tipured = u.Vid,
						   realnum = f.UNomer - ((uint)f.Faza * 100000),
						   iddoglice = u.IdDogL,
						   uredname = u.Nime,
						   statusDL = d.StatusDl,
						   regdog = d.RegN,
						   tipuredime = u.TipUrIme,
						   idlice = l.Id
					   };

			if (filter.faza > 0)
			{
				data = data.Where(m => m.faza == filter.faza);
			}

			if (filter.raionid != null && filter.raionid.Length > 0)
			{
				data = data.Where(m => m.raionid == filter.raionid);
			}

			if (filter.tipuredi != null && !filter.tipuredi.Equals("ALL"))
			{
				data = data.Where(m => m.tipured == filter.tipuredi.Trim());
			}

			if (filter.uredi != null && filter.uredi.Length > 0)
			{
				data = data.Where(m => m.kodured == filter.uredi.Trim());
			}

			if (filter.statusDL > -1)
			{
				data = data.Where(m => m.statusDL == filter.statusDL);
			}

			if (filter.statusU > 0)
			{
				data = data.Where(m => m.statusU == filter.statusU);
			}

			if (filter.unomer > 0)
			{
				data = data.Where(m => m.realnum == filter.unomer);
			}

			var dog = from d in data
					  join p2 in _dbContext.MonPorychkas
						  on new { d.iddoglice, d.idured } equals new { iddoglice = p2.IdDogovorLice, idured = p2.IdUred }
						  into p1
					  from p in p1.DefaultIfEmpty()

					  join pm2 in _dbContext.MonPorychkaMain
						  on p.IdPorachkaMain equals pm2.IdPorachkaMain
						  into pm1
					  from pm in pm1.DefaultIfEmpty()

					  join m2 in _dbContext.MonDogovors
							  on pm.IdDogovorFirma equals m2.IdFirmaMn
						  into m1
					  from m in m1.DefaultIfEmpty()
					  select new
					  {
						  idl = d.idl,
						  idured = d.idured,
						  idporychka = pm.IdPorachkaMain,
					  };

			var rez = from d in data
					  from v in _dbContext.ViewAdres
					  where d.idl == v.ID_L
					  from n in _dbContext.NStatusis
					  where d.statusU == n.StatusCode && n.StatusName == "Status_U"
					  from n1 in _dbContext.NStatusis
					  where d.statusDL == n1.StatusCode && n1.StatusName == "Status_DL"
					  join p2 in dog
							on new { d.idl, d.idured } equals new { p2.idl, p2.idured }
						  into pp
					  from p in pp.DefaultIfEmpty()
					  select new ViewSpravka5
					  {
						  idl = d.idlice,
						  idformulqr = d.idformulqr,
						  raion = d.raion,
						  unom = d.unom,
						  Ime = d.ime,
						  adres = v.Adres,
						  nkod = d.kodured,
						  ured = d.uredname,
						  statusU = n.Text,
						  unomer = d.unomer,
						  broi = d.broi,
						  idporychka = (p.idporychka == null ? 0 : p.idporychka),
						  regdog = (d.regdog == null ? "" : d.regdog),
						  statusDL = n1.Text,
						  tipuredime = d.tipuredime
					  };
			return await rez
						.OrderBy(x => x.unomer)
						.ThenBy(x => x.nkod)
						.ToListAsync();
		}

		public async Task<IList<ViewSpravka6>> GetSpravka6(Filter filter)
		{
			var data = from f in _dbContext.MonDogovors
					   where f.StatusDm == 2
					   from l in _dbContext.Firmi
					   where f.IdFirma == l.IdFirma && l.Rolq == 1 && l.Status == 1
					   from u in _dbContext.MonDgvUredis
					   where u.IdFirmaMn == f.IdFirmaMn
					   from n in _dbContext.NUredi
					   where n.Id == u.IdKn
					   select new
					   {
						   idfirma = l.IdFirma,
						   ime = l.Ime,
						   iddog = f.IdFirmaMn,
						   dogovor = f.RegIndex,
						   idured = u.IdKn,
						   kodured = n.Nkod,
						   imeured = n.Nime,
						   edcena = u.EdCena,
						   broi = u.Broi
					   };


			if (filter.firma > 0)
			{
				data = data.Where(m => m.idfirma == filter.firma);
			}

			if (filter.dogovor > 0)
			{
				data = data.Where(m => m.iddog == filter.dogovor);
			}

			if (filter.uredi != null && filter.uredi.Length > 0)
			{
				data = data.Where(m => m.kodured == filter.uredi.Trim());
			}

			var monuredi = (from d in _dbContext.MonPorychkaMain
							join p in _dbContext.MonPorychkas
							  on d.IdPorachkaMain equals p.IdPorachkaMain
							group new { d, p } by new { d.IdDogovorFirma, p.IdUred }
						   into grp
							select new
							{
								iddog = grp.Key.IdDogovorFirma,
								idured = grp.Key.IdUred,
								oquantity = grp.Sum(t => t.p.Broi),
								rquantity = grp.Sum(t => (t.p.StatusG > 1 || t.p.StatusM > 1 ? t.p.Broi : 0)),
								mquantity = grp.Sum(t => (t.p.StatusM == 1 ? t.p.Broi : 0))
							});
			var x = monuredi.ToList();

			var rez = from d in data
					  join p2 in monuredi
						  on new { d.iddog, d.idured } equals new { iddog = p2.iddog, idured = p2.idured }
						  into p1
					  from r in p1.DefaultIfEmpty()
					  select new ViewSpravka6
					  {
						  idfirma = d.idfirma,
						  ime = d.ime,
						  iddog = d.iddog,
						  dogovor = d.dogovor,
						  kodured = d.kodured,
						  imeured = d.imeured,
						  edcena = d.edcena,
						  tspbroi = d.broi,
						  tsptotal = d.edcena * d.broi,
						  ordbroi = (r.oquantity == null ? 0 : r.oquantity),
						  rembroi = (r.rquantity == null ? 0 : r.rquantity),
						  monbroi = (r.mquantity == null ? 0 : r.mquantity),
						  montotal = (r.mquantity == null ? 0 : r.mquantity * d.edcena),
						  restbroi = (r.mquantity == null ? d.broi : (d.broi - r.mquantity)),
						  resttotal = (r.mquantity == null ? d.broi : (d.broi - r.mquantity)) * d.edcena,
					  };
			return await rez.OrderBy(x => x.ime)
							.ThenBy(n => n.dogovor)
							.ThenBy(n => n.kodured)
							.ToListAsync();
		}

		public async Task<IList<ViewSpravka7>> GetSpravka7(Filter filter)
		{
			var data = (from d in _dbContext.MonDogovors
						where d.StatusDm == 2
						join p in _dbContext.MonDgvUredis
						  on d.IdFirmaMn equals p.IdFirmaMn
						group new { p } by new { p.IdKn } into grp
						select new
						{
							idured = grp.Key.IdKn,
							quantity = grp.Sum(t => t.p.Broi),
							edcena = (double)(grp.Sum(t => t.p.Broi) == 0 ? 0 : grp.Sum(t => t.p.Broi * t.p.EdCena) / grp.Sum(t => t.p.Broi)),
						});

			var monuredi = (from d in _dbContext.MonPorychkaMain
							where d.StatusPM < 9
							join p in _dbContext.MonPorychkas on d.IdPorachkaMain equals p.IdPorachkaMain
							group new { p } by new { p.IdUred } into grp
							select new
							{
								idured = grp.Key.IdUred,
								oquantity = grp.Sum(t => t.p.StatusG <= 1 && t.p.StatusM <= 1 ? t.p.Broi : 0),
								mquantity = grp.Sum(t => t.p.StatusM == 1 ? t.p.Broi : 0)
							});

			var totals = from d in data
						 join p2 in monuredi on d.idured equals p2.idured into p1
						 from r in p1.DefaultIfEmpty()
						 select new ViewSpravka7
						 {
							 idured = d.idured,
							 edcena = d.edcena,
							 tspbroi = d.quantity,
							 tsptotal = d.quantity * d.edcena,
							 ordbroi = r.oquantity == null ? 0 : r.oquantity,
							 monbroi = r.mquantity == null ? 0 : r.mquantity,
							 montotal = r.mquantity == null ? 0 : r.mquantity * d.edcena,
							 restbroi = r.mquantity == null ? d.quantity : d.quantity - r.mquantity,
							 resttotal = r.mquantity == null ? d.quantity : (d.quantity - r.mquantity) * d.edcena,
						 };
			var rez = from d in totals
					  join n in _dbContext.NUredi
						  on d.idured equals n.Id
					  select new ViewSpravka7
					  {
						  kodured = n.Nkod,
						  imeured = n.Nime,
						  edcena = d.edcena,
						  tspbroi = d.tspbroi,
						  tsptotal = d.tsptotal,
						  ordbroi = d.ordbroi,
						  monbroi = d.monbroi,
						  montotal = d.montotal,
						  restbroi = d.restbroi,
						  resttotal = d.resttotal
					  };


			if (filter.uredi != null && filter.uredi.Length > 0)
			{
				rez = rez.Where(m => m.kodured == filter.uredi.Trim());
			}

			return await rez.OrderBy(x => x.kodured).ToListAsync();
		}

		public async Task<IList<ViewSpravka8>> GetSpravka8(Filter filter)
		{

			var uredi = from d in _dbContext.NUredi
						where d.Status == 1
						select new
						{
							idured = d.Id,
							kodured = d.Nkod,
							imeured = d.Nime,
							tipured = d.Vid
						};

			if (filter.tipuredi != null && !filter.tipuredi.Equals("ALL"))
			{
				uredi = uredi.Where(m => m.tipured == filter.tipuredi.Trim());
			}

			if (filter.uredi != null && filter.uredi.Length > 0)
			{
				uredi = uredi.Where(m => m.kodured == filter.uredi.Trim());
			}

			var monuredi = (from p in _dbContext.MonDgvUredis
							join d in _dbContext.MonDogovors on p.IdFirmaMn equals d.IdFirmaMn
							where d.StatusDm == 2
							group p by p.IdKn into newGroup
							select new
							{
								idured = newGroup.Key,
								monbroi = newGroup.Sum(c => c.Broi),
							});

			var lica = from l in _dbContext.LicaFormuliarKolektiv
					   where l.IsTitulqr == 1 && l.Status == 1
					   select new
					   {
						   idl = l.IdL,
						   raionid = l.ARaion
					   };

			if (filter.raionid != null && filter.raionid.Length > 0)
			{
				lica = lica.Where(m => m.raionid == filter.raionid);
			}

			var licauredi = (from d in _dbContext.LicaDogovorUredis
							 where d.StatusU == 1 || d.StatusU == 2 || d.StatusU == 3 || d.StatusU == 5
							 from l in lica
							 where d.IdL == l.idl
							 group d by d.IdKt into newGroup
							 select new
							 {
								 idured = newGroup.Key,
								 dogbroi = newGroup.Sum(x => x.StatusU == 1 ? x.Broi : 0),
								 ordbroi = newGroup.Sum(x => x.StatusU == 2 ? x.Broi : 0),
								 inordbroi = newGroup.Sum(x => x.StatusU == 3 || x.StatusU == 5 ? x.Broi : 0)
							 });

			var rez1 = from d in uredi
					   join l in licauredi on d.idured equals l.idured into lu
					   from ls in lu.DefaultIfEmpty()
					   select new
					   {
						   d.idured,
						   d.kodured,
						   d.imeured,
						   ls.dogbroi,
						   ls.ordbroi,
						   ls.inordbroi,
					   };

			var rez = from d in rez1
					  join m in monuredi on d.idured equals m.idured into mon
					  from jms in mon.DefaultIfEmpty()
					  select new
					  {
						  d.kodured,
						  d.imeured,
						  d.dogbroi,
						  d.ordbroi,
						  d.inordbroi,
						  jms.monbroi,
					  };

			return await rez
					.Select(item => new ViewSpravka8
					{
						kodured = item.kodured,
						imeured = item.imeured,
						dogbroi = (item.dogbroi == null ? 0 : item.dogbroi),
						ordbroi = (item.ordbroi == null ? 0 : item.ordbroi),
						tspbroi = (item.monbroi == null ? 0 : item.monbroi),
						inordbroi = (item.inordbroi == null ? 0 : item.inordbroi)
					})
					.OrderBy(x => x.kodured).ToListAsync();
		}


		public async Task<IList<ViewSpravka5>> GetSpravka9(Filter filter)
		{
			var data = from f in _dbContext.LicaFormuliars
					   from l in _dbContext.LicaFormuliarKolektiv
					   where f.IdL == l.IdL && l.IsTitulqr == 1 && l.Status == 1
					   from r in _dbContext.NRaionis
					   where r.Nkod == l.ARaion
					   from d in _dbContext.LicaDogovors
					   where d.IdL == f.IdL
					   from u in _dbContext.LicaDogovorOldUredis
					   where u.IdL == f.IdL
					   from n in _dbContext.NNmnObshtis
					   where n.IdKn == u.IdKt && n.KodNmn == "06"
					   select new
					   {
						   idformulqr = f.IdFormuliar,
						   idl = f.IdL,
						   faza = f.Faza,
						   raionid = l.ARaion,
						   raion = r.Nime,
						   ime = l.Ime,
						   statusU = u.StatusDU,
						   unomer = f.UNomer,
						   unom = f.UNom,
						   idured = u.IdKt,
						   broi = u.Broi,
						   kodured = n.KodPozicia,
						   tipured = "",
						   realnum = f.UNomer - ((uint)f.Faza * 100000),
						   iddoglice = u.IdDogL,
						   uredname = n.Text,
						   regdog = d.RegN,
						   StatusDl = d.StatusDl,
						   idlice = l.Id
					   };

			if (filter.faza > 0)
			{
				data = data.Where(m => m.faza == filter.faza);
			}

			if (filter.raionid != null && filter.raionid.Length > 0)
			{
				data = data.Where(m => m.raionid == filter.raionid);
			}

			if (filter.olduredi != null && filter.olduredi.Length > 0)
			{
				data = data.Where(m => m.idured == Int16.Parse(filter.olduredi.Trim()));
			}

			if (filter.statusDU > 0)
			{
				data = data.Where(m => m.statusU == filter.statusDU);
			}

			if (filter.unomer > 0)
			{
				data = data.Where(m => m.realnum == filter.unomer);
			}

			if (filter.statusDL > 0)
			{
				data = data.Where(m => m.StatusDl == filter.statusDL);
			}

			var dog = from d in data
					  join p2 in _dbContext.DemPorychkas
						  on new { d.iddoglice, d.idured } equals new { iddoglice = p2.IdDogovorLice, idured = p2.IdUred }
						  into p1
					  from p in p1.DefaultIfEmpty()

						  /*					  join pm2 in _dbContext.DemPorychkaMain
													on p.IdPorachkaMain equals pm2.IdPorachkaMain
													into pm1
												from pm in pm1.DefaultIfEmpty()

												join m2 in _dbContext.DemDogovors
														on pm.IdDogovorFirma equals m2.IdFirmaDm
													into m1
												from m in m1.DefaultIfEmpty()
						  */
					  select new
					  {
						  idl = d.idl,
						  idured = d.idured,
						  idporychka = (p.IdPorachkaMain==null ? 0 : p.IdPorachkaMain),
						  //						  regdog = m.RegIndex
					  };

			var rez = from d in data
					  from v in _dbContext.ViewAdres
					  where d.idl == v.ID_L
					  from n1 in _dbContext.NStatusis
					  where d.StatusDl == n1.StatusCode && n1.StatusName == "Status_DL"
					  from n2 in _dbContext.NStatusis
					  where d.statusU == n2.StatusCode && n2.StatusName == "Status_DU"
					  join p2 in dog
							on new { d.idl, d.idured } equals new { p2.idl, p2.idured }
						  into pp
					  from p in pp.DefaultIfEmpty()
					  select new ViewSpravka5
					  {
						  idl = d.idlice,
						  idformulqr = d.idformulqr,
						  raion = d.raion,
						  unom = d.unom,
						  Ime = d.ime,
						  adres = v.Adres,
						  nkod = d.kodured,
						  ured = d.uredname,
						  statusU = n2.Text,
						  unomer = d.unomer,
						  broi = d.broi,
						  idporychka = p.idporychka,
						  regdog = (d.regdog == null ? "" : d.regdog),
						  statdog = n1.Text,
					  };
			return await rez.OrderBy(x => x.unomer).ThenBy(x => x.nkod).ToListAsync();
		}

		public async Task<IList<ViewSpravka6>> GetSpravka10(Filter filter)
		{
			var data = from f in _dbContext.DemDogovors
					   where f.StatusDm == 2
					   from l in _dbContext.Firmi
					   where f.IdFirma == l.IdFirma && l.Rolq == 2 && l.Status == 1
					   from u in _dbContext.DemDgvOlduredis
					   where u.IdFirmaDm == f.IdFirmaDm
					   from n in _dbContext.NNmnObshtis
					   where n.IdKn == u.IdKn && n.KodNmn == "06"
					   select new
					   {
						   idfirma = l.IdFirma,
						   ime = l.Ime,
						   iddog = f.IdFirmaDm,
						   dogovor = f.RegIndex,
						   idured = u.IdKn,
						   kodured = n.KodPozicia,
						   imeured = n.Text,
						   edcena = u.EdCena,
						   broi = u.Broi
					   };


			if (filter.demfirma > 0)
			{
				data = data.Where(m => m.idfirma == filter.demfirma);
			}

			if (filter.demdogovor > 0)
			{
				data = data.Where(m => m.iddog == filter.demdogovor);
			}

			if (filter.olduredi != null && filter.olduredi.Length > 0)
			{
				data = data.Where(m => m.idured == Int16.Parse(filter.olduredi.Trim()));
			}

			var monuredi = (from d in _dbContext.DemPorychkaMain
							join p in _dbContext.DemPorychkas
							  on d.IdPorachkaMain equals p.IdPorachkaMain
							group new { d, p } by new { d.IdDogovorFirma, p.IdUred }
							into grp
							select new
							{
								iddog = grp.Key.IdDogovorFirma,
								idured = grp.Key.IdUred,
								oquantity = grp.Sum(t => t.p.Broi),
								rquantity = grp.Sum(t => (t.p.StatusG > 1 || t.p.StatusM > 1 ? t.p.Broi : 0)),
								mquantity = grp.Sum(t => (t.p.StatusM == 1 ? t.p.Broi : 0))
							});
			var x = monuredi.ToList();

			var rez = from d in data
					  join p2 in monuredi
						  on new { d.iddog, d.idured } equals new { iddog = p2.iddog, idured = p2.idured }
						  into p1
					  from r in p1.DefaultIfEmpty()
					  select new ViewSpravka6
					  {
						  idfirma = d.idfirma,
						  ime = d.ime,
						  iddog = d.iddog,
						  dogovor = d.dogovor,
						  kodured = d.kodured,
						  imeured = d.imeured,
						  edcena = d.edcena,
						  tspbroi = d.broi,
						  tsptotal = d.edcena * d.broi,
						  ordbroi = (r.oquantity == null ? 0 : r.oquantity),
						  rembroi = (r.rquantity == null ? 0 : r.rquantity),
						  monbroi = (r.mquantity == null ? 0 : r.mquantity),
						  montotal = (r.mquantity == null ? 0 : r.mquantity * d.edcena),
						  restbroi = (r.mquantity == null ? d.broi : (d.broi - r.mquantity)),
						  resttotal = (r.mquantity == null ? d.broi : (d.broi - r.mquantity)) * d.edcena,
					  };
			return await rez.OrderBy(x => x.ime)
							.ThenBy(n => n.dogovor)
							.ThenBy(n => n.kodured)
							.ToListAsync();
		}

		public async Task<IList<ViewSpravka11>> GetSpravka11(Filter filter)
		{
			var data = from p in _dbContext.MonPorychkaMain
					   where p.Status == 1
					   from l in _dbContext.MonPorychkas
					   where p.IdPorachkaMain == l.IdPorachkaMain
					   from d in _dbContext.MonDogovors
					   where p.IdDogovorFirma == d.IdFirmaMn
					   from f in _dbContext.Firmi
					   where f.IdFirma == d.IdFirma
					   from u in _dbContext.LicaDogovors
					   where l.IdDogovorLice == u.IdDogL
					   from fm in _dbContext.LicaFormuliars
					   where fm.IdL == u.IdL
					   from lk in _dbContext.LicaFormuliarKolektiv
					   where fm.IdL == lk.IdL && lk.IsTitulqr == 1 && l.Status == 1
					   select new
					   {
						   porychka = p.IdPorachkaMain,
						   idfirma = f.IdFirma,
						   eik = f.Ime,
						   iddog = d.IdFirmaMn,
						   dogovor = d.RegIndex,
						   unom = fm.UNom,
						   unomer = fm.UNomer - ((uint)fm.Faza * 100000),
						   idured = l.IdUred,
						   broi = l.Broi,
						   datag = l.DoData,
						   otchas = l.OtChas,
						   dochas = l.DoChas,
						   statusg = l.StatusG,
						   note = l.Note,
						   datam = l.MonData,
						   statusm = l.StatusM,
						   note2 = l.Note2,
						   raionid = lk.ARaion,
						   ime = lk.Ime,
						   idl = lk.IdL,
						   model = l.Model,
						   fabrnomer = l.FabrNomer,
						   garkarta = l.GarCard,
						   gardata = l.GarCardData,
						   protnomer = l.ProtNomer,
						   protdata = l.ProtData
					   };

			if (filter.porychkanom > 0)
			{
				data = data.Where(m => m.porychka == filter.porychkanom);
			}

			if (filter.raionid != null && filter.raionid.Length > 0)
			{
				data = data.Where(m => m.raionid == filter.raionid);
			}

			if (filter.firma > 0)
			{
				data = data.Where(m => m.idfirma == filter.firma);
			}

			if (filter.dogovor > 0)
			{
				data = data.Where(m => m.iddog == filter.dogovor);
			}

			if (filter.statusG > 0)
			{
				data = data.Where(m => m.statusg == filter.statusG);
			}

			if (filter.statusM > 0)
			{
				data = data.Where(m => m.statusm == filter.statusM);
			}

			if (filter.grafikdataot > new DateTime(2000, 1, 1) || filter.grafikdatado > new DateTime(2000, 1, 1))
			{
				var grafikdataot = (filter.grafikdataot > new DateTime(2000, 1, 1) ? filter.grafikdataot : new DateTime(2000, 1, 1));
				var grafikdatado = (filter.grafikdatado > new DateTime(2000, 1, 1) ? filter.grafikdatado : new DateTime(2100, 12, 31));

				data = data.Where(m => m.datag >= grafikdataot && m.datag <= grafikdatado);
			}

			if (filter.otchetdataot > new DateTime(2000, 1, 1) || filter.otchetdatado > new DateTime(2000, 1, 1))
			{
				var otchetdataot = (filter.otchetdataot > new DateTime(2000, 1, 1) ? filter.otchetdataot : new DateTime(2000, 1, 1));
				var otchetdatado = (filter.otchetdatado > new DateTime(2000, 1, 1) ? filter.otchetdatado : new DateTime(2100, 12, 31));

				data = data.Where(m => m.datam >= otchetdataot && m.datam <= otchetdatado);
			}

			if (filter.unomer > 0)
			{
				data = data.Where(m => m.unomer == filter.unomer);
			}

			var rez = from d in data
					  from p1 in _dbContext.NUredi
					  where d.idured == p1.Id
					  from p2 in _dbContext.ViewAdres
					  where d.idl == p2.ID_L
					  from n1 in _dbContext.NStatusis
					  where d.statusg == n1.StatusCode && n1.StatusName == "StatusG"
					  from n2 in _dbContext.NStatusis
					  where d.statusm == n2.StatusCode && n2.StatusName == "StatusM"
					  select new ViewSpravka11
					  {
						  porychka = d.porychka,
						  idfirma = d.idfirma,
						  eik = d.eik,
						  iddog = d.iddog,
						  dogovor = d.dogovor,
						  unomer = d.unom,
						  kodured = p1.Nkod,
						  imeured = p1.Nime,
						  broi = d.broi,
						  datag = (d.datag.HasValue ? String.Format("{0:dd.MM.yyyy}", d.datag) : ""),
						  otchas = d.otchas,
						  dochas = d.dochas,
						  statusg = n1.Text,
						  note = d.note,
						  datam = (d.datam.HasValue ? String.Format("{0:dd.MM.yyyy}", d.datam) : ""),
						  statusm = n2.Text,
						  note2 = d.note2,
						  ime = d.ime,
						  adres = p2.Adres,
						  unom = (int)d.unomer,
						  model = d.model,
						  fabrnomer = d.fabrnomer,
						  garkarta = d.garkarta,
						  gardata = d.gardata,
						  protnomer = d.protnomer,
						  protdata = d.protdata

					  };

			return await rez.OrderBy(n => n.porychka)
								.ThenBy(n => n.unom)
								.ThenBy(n => n.kodured)
								.ToListAsync();
		}

		public async Task<IList<ViewSpravka11>> GetSpravka12(Filter filter)
		{
			var data = from p in _dbContext.DemPorychkaMain
					   where p.Status == 1
					   from l in _dbContext.DemPorychkas
					   where p.IdPorachkaMain == l.IdPorachkaMain
					   from d in _dbContext.DemDogovors
					   where p.IdDogovorFirma == d.IdFirmaDm
					   from f in _dbContext.Firmi
					   where f.IdFirma == d.IdFirma
					   from u in _dbContext.LicaDogovors
					   where l.IdDogovorLice == u.IdDogL
					   from fm in _dbContext.LicaFormuliars
					   where fm.IdL == u.IdL
					   from lk in _dbContext.LicaFormuliarKolektiv
					   where fm.IdL == lk.IdL && lk.IsTitulqr == 1 && l.Status == 1
					   select new
					   {
						   porychka = p.IdPorachkaMain,
						   idfirma = f.IdFirma,
						   eik = f.Ime,
						   iddog = d.IdFirmaDm,
						   dogovor = d.RegIndex,
						   unom = fm.UNom,
						   unomer = fm.UNomer - ((uint)fm.Faza * 100000),
						   idured = l.IdUred,
						   broi = l.Broi,
						   datag = l.DoData,
						   statusg = l.StatusG,
						   note = l.Note,
						   datam = l.DemData,
						   statusm = l.StatusM,
						   note2 = l.Note2,
						   raionid = lk.ARaion,
						   ime = lk.Ime,
						   idl = lk.IdL
					   };

			if (filter.porychkanom > 0)
			{
				data = data.Where(m => m.porychka == filter.porychkanom);
			}

			if (filter.raionid != null && filter.raionid.Length > 0)
			{
				data = data.Where(m => m.raionid == filter.raionid);
			}

			if (filter.demfirma > 0)
			{
				data = data.Where(m => m.idfirma == filter.demfirma);
			}

			if (filter.demdogovor > 0)
			{
				data = data.Where(m => m.iddog == filter.demdogovor);
			}

			if (filter.statusG > 0)
			{
				data = data.Where(m => m.statusg == filter.statusG);
			}

			if (filter.statusM > 0)
			{
				data = data.Where(m => m.statusm == filter.statusM);
			}

			if (filter.grafikdataot > new DateTime(2000, 1, 1) || filter.grafikdatado > new DateTime(2000, 1, 1))
			{
				var grafikdataot = (filter.grafikdataot > new DateTime(2000, 1, 1) ? filter.grafikdataot : new DateTime(2000, 1, 1));
				var grafikdatado = (filter.grafikdatado > new DateTime(2000, 1, 1) ? filter.grafikdatado : new DateTime(2100, 12, 31));

				data = data.Where(m => m.datag >= grafikdataot && m.datag <= grafikdatado);
			}

			if (filter.otchetdataot > new DateTime(2000, 1, 1) || filter.otchetdatado > new DateTime(2000, 1, 1))
			{
				var otchetdataot = (filter.otchetdataot > new DateTime(2000, 1, 1) ? filter.otchetdataot : new DateTime(2000, 1, 1));
				var otchetdatado = (filter.otchetdatado > new DateTime(2000, 1, 1) ? filter.otchetdatado : new DateTime(2100, 12, 31));

				data = data.Where(m => m.datam >= otchetdataot && m.datam <= otchetdatado);
			}

			if (filter.unomer > 0)
			{
				data = data.Where(m => m.unomer == filter.unomer);
			}

			var rez = from d in data
					  from p1 in _dbContext.NNmnObshtis
					  where p1.IdKn == d.idured && p1.KodNmn == "06"
					  from p2 in _dbContext.ViewAdres
					  where d.idl == p2.ID_L
					  from n1 in _dbContext.NStatusis
					  where d.statusg == n1.StatusCode && n1.StatusName == "StatusGD"
					  from n2 in _dbContext.NStatusis
					  where d.statusm == n2.StatusCode && n2.StatusName == "StatusMD"
					  select new ViewSpravka11
					  {
						  porychka = d.porychka,
						  idfirma = d.idfirma,
						  eik = d.eik,
						  iddog = d.iddog,
						  dogovor = d.dogovor,
						  unomer = d.unom,
						  kodured = p1.KodPozicia,
						  imeured = p1.Text,
						  broi = d.broi,
						  datag = (d.datag.HasValue ? String.Format("{0:dd.MM.yyyy}", d.datag) : ""),
						  otchas = "",
						  dochas = "",
						  statusg = n1.Text,
						  note = d.note,
						  datam = (d.datam.HasValue ? String.Format("{0:dd.MM.yyyy}", d.datam) : ""),
						  statusm = n2.Text,
						  note2 = d.note2,
						  ime = d.ime,
						  adres = p2.Adres,
						  unom = (int)d.unomer

					  };

			return await rez.OrderBy(n => n.porychka)
								.ThenBy(n => n.unom)
								.ThenBy(n => n.kodured)
								.ToListAsync();
		}

		public async Task<IList<ViewSpravka13>> GetSpravka13(Filter filter)
		{

			var uredi = from d in _dbContext.NUredi
						where d.Status == 1
						select new
						{
							idured = d.Id,
							kodured = d.Nkod,
							imeured = d.Nime,
							tipured = d.Vid
						};

			if (filter.tipuredi != null && !filter.tipuredi.Equals("ALL"))
			{
				uredi = uredi.Where(m => m.tipured == filter.tipuredi.Trim());
			}



			var lica = from l in _dbContext.LicaFormuliarKolektiv
					   where l.IsTitulqr == 1 && l.Status == 1
					   select new
					   {
						   idl = l.IdL,
						   raionid = l.ARaion
					   };

			if (filter.raionid != null && filter.raionid.Length > 0)
			{
				lica = lica.Where(m => m.raionid == filter.raionid);
			}

			var licauredi = (from d in _dbContext.LicaDogovorUredis
							 where d.StatusU > 0
							 from l in lica
							 where d.IdL == l.idl
							 group d by d.IdKt into newGroup
							 select new
							 {
								 idured = newGroup.Key,
								 l_dogbroi = newGroup.Sum(x => x.StatusU == 1 ? x.Broi : 0),
								 l_ordbroi = newGroup.Sum(x => x.StatusU == 2 ? x.Broi : 0),
								 l_inordbroi = newGroup.Sum(x => x.StatusU == 3 ? x.Broi : 0),
								 l_otkazani = newGroup.Sum(x => x.StatusU == 6 || x.StatusU == 7 ? x.Broi : 0)
							 });

			var poruredi = (from p in _dbContext.MonPorychkaMain
							where p.StatusPM < 9
							from d in _dbContext.MonPorychkas
							where p.IdPorachkaMain == d.IdPorachkaMain
							from ld in _dbContext.LicaDogovors
							where ld.IdDogL == d.IdDogovorLice
							from l in lica
							where l.idl == ld.IdL
							group d by d.IdUred into newGroup
							select new
							{
								idured = newGroup.Key,
								p_ingrafik = newGroup.Sum(x => x.StatusG > 0 ? x.Broi : 0),
								p_inotchet = newGroup.Sum(x => x.StatusM > 0 ? x.Broi : 0),
								p_montirani = newGroup.Sum(x => x.StatusM == 1 ? x.Broi : 0),
								p_otkazani = newGroup.Sum(x => x.StatusG == 4 || x.StatusM == 4 ? x.Broi : 0),
								p_izklucheni = newGroup.Sum(x => x.StatusG == 2 || x.StatusG == 3 || x.StatusG == 5 ||
																 x.StatusM == 2 || x.StatusM == 3 || x.StatusM == 5
															? x.Broi : 0)
							});

			var rez1 = from d in uredi
					   join l in licauredi on d.idured equals l.idured into lu
					   from ls in lu.DefaultIfEmpty()
					   select new
					   {
						   d.idured,
						   d.kodured,
						   d.imeured,
						   ls.l_dogbroi,
						   ls.l_ordbroi,
						   ls.l_inordbroi,
						   ls.l_otkazani,

					   };

			var rez = from d in rez1
					  join m in poruredi on d.idured equals m.idured into mon
					  from jms in mon.DefaultIfEmpty()
					  select new
					  {
						  d.kodured,
						  d.imeured,
						  d.l_dogbroi,
						  d.l_ordbroi,
						  d.l_inordbroi,
						  d.l_otkazani,
						  jms.p_ingrafik,
						  jms.p_inotchet,
						  jms.p_montirani,
						  jms.p_otkazani,
						  jms.p_izklucheni
					  };

			return await rez
					.Select(item => new ViewSpravka13
					{
						kodured = item.kodured,
						imeured = item.imeured,
						l_dogbroi = (item.l_dogbroi == null ? 0 : item.l_dogbroi),
						l_ordbroi = (item.l_ordbroi == null ? 0 : item.l_ordbroi),
						l_inordbroi = (item.l_inordbroi == null ? 0 : item.l_inordbroi),
						p_ingrafik = (item.p_ingrafik == null ? 0 : item.p_ingrafik),
						p_inotchet = (item.p_inotchet == null ? 0 : item.p_inotchet),
						p_montirani = (item.p_montirani == null ? 0 : item.p_montirani),
						l_otkazani = (item.l_otkazani == null ? 0 : item.l_otkazani),
						p_otkazani = (item.p_otkazani == null ? 0 : item.p_otkazani),
						p_izklucheni = (item.p_izklucheni == null ? 0 : item.p_izklucheni),
					})
					.OrderBy(x => x.kodured).ToListAsync();
		}

		public async Task<IList<ViewSpravka14>> GetSpravka14(Filter filter)
		{
			var lica = (from f in _dbContext.LicaFormuliars
						from l in _dbContext.LicaFormuliarKolektiv
						where f.IdL == l.IdL && l.IsTitulqr == 1 && l.Status == 1
						from d in _dbContext.LicaDogovors
						where f.IdL == d.IdL
						from a in _dbContext.ViewAdres
						where f.IdL == a.ID_L
						from n1 in _dbContext.NRaionis
						where n1.Nkod == l.ARaion
						select new
						{
							idl = l.IdL,
							idformulqr = f.IdFormuliar,
							raionid = l.ARaion,
							unomer = f.UNomer - ((uint)f.Faza * 100000),
							iddogovorlice = d.IdDogL,
							dogovor = d.RegN,
							dogdata = (d.DataRegN.HasValue ? String.Format("{0:dd.MM.yyyy}", d.DataRegN) : ""),
							unom = f.UNom,
							ime = l.Ime,
							adres = a.Adres,
							raion = n1.Nime,
							statusDl = d.StatusDl,
							idlice = l.Id
						});

			if (filter.raionid != null && filter.raionid.Length > 0)
			{
				lica = lica.Where(m => m.raionid == filter.raionid);
			}

			if (filter.unomer > 0)
			{
				lica = lica.Where(m => m.unomer == filter.unomer);
			}


			var rez = (from l in lica
					   from m in _dbContext.vwSpravka14
					   where l.iddogovorlice == m.IdDogovorLice
					   from p in _dbContext.MonPorychkaMain
					   where m.IdPorachkaMain == p.IdPorachkaMain
					   from f in _dbContext.Firmi
					   where p.IdFirma == f.IdFirma
					   from fd in _dbContext.MonDogovors
					   where p.IdDogovorFirma == fd.IdFirmaMn
					   from n in _dbContext.NStatusis
					   where n.StatusCode == l.statusDl && n.StatusName == "Status_DL"
					   select new
					   {
						   idl = l.idl,
						   idformulqr = l.idformulqr,
						   dognomer = l.dogovor,
						   dogdate = l.dogdata,
						   unom = l.unom,
						   ime = l.ime,
						   raion = l.raion,
						   adres = l.adres,
						   txturedi = m.txturedi,
						   statusM = m.txtstatus,
						   dataM = m.txtmondata,
						   porychkaM = m.IdPorachkaMain,
						   izpalnitel = f.Ime,
						   izpdogovor = fd.RegIndex,
						   txtolduredi = m.txtdemuredi,
						   statusD = m.txtdemstatus,
						   dataD = m.txtdemdata,
						   porychkaD = m.porychkaD,
						   idfirma = p.IdFirma,
						   IdDogovorFirma = p.IdDogovorFirma,
						   unomer = l.unomer,
						   statusDl = n.Text,
						   txtkamina = m.txtkamina,
						   idlice = l.idlice
					   });

			if (filter.porychkanom > 0)
			{
				rez = rez.Where(m => m.porychkaM == filter.porychkanom);
			}

			if (filter.demporychkanom > 0)
			{
				rez = rez.Where(m => m.porychkaD == filter.demporychkanom);
			}

			if (filter.firma > 0)
			{
				rez = rez.Where(m => m.idfirma == filter.firma);
			}

			if (filter.dogovor > 0)
			{
				rez = rez.Where(m => m.IdDogovorFirma == filter.dogovor);
			}

			return await rez
						 .Select(l => new ViewSpravka14
						 {
							 idl = l.idlice,
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
							 porychkaM = l.porychkaM,
							 izpalnitel = l.izpalnitel,
							 izpdogovor = l.izpdogovor,
							 txtolduredi = l.txtolduredi,
							 statusD = l.statusD,
							 dataD = l.dataD,
							 porychkaD = l.porychkaD,
							 unomer = l.unomer,
							 statusDl = l.statusDl,
							 txtkamina = l.txtkamina
						 })
						  .OrderBy(x => x.unomer)
						  .ToListAsync();
		}

		public async Task<IList<ViewSpravka15>> GetSpravka15(Filter filter)
		{
			var rez = (from f in _dbContext.LicaFormuliars
					   from l in _dbContext.LicaFormuliarKolektiv
					   where f.IdL == l.IdL && l.IsTitulqr == 1 && l.Status == 1
					   from d in _dbContext.LicaDogovors
					   where f.IdL == d.IdL
					   from n1 in _dbContext.NRaionis
					   where n1.Nkod == l.ARaion
					   from ds in _dbContext.LicaDopSporazumeniq
					   where d.IdL == ds.IdL
					   from n2 in _dbContext.NNmnObshtis
					   where n2.IdKn == ds.IdDopSp
					   from n3 in _dbContext.NStatusis
					   where n3.StatusCode == d.StatusDl && n3.StatusName == "Status_DL"
					   select new
					   {
						   idl = l.IdL,
						   idformulqr = f.IdFormuliar,
						   raionid = l.ARaion,
						   unomer = f.UNomer - ((uint)f.Faza * 100000),
						   iddogovorlice = d.IdDogL,
						   dogovor = d.RegN + "/" + (d.DataRegN.HasValue ? String.Format("{0:dd.MM.yyyy}", d.DataRegN) : ""),
						   unom = f.UNom,
						   raion = n1.Nime,
						   statusDl = n3.Text,
						   dopspor = ds.RegNomer,
						   viddopspor = n2.Text,
						   komentar = ds.Komentar,
						   dogregnom = d.RegN,
						   IdDopSp = ds.IdDopSp,
						   koga = (ds.Koga.HasValue ? String.Format("{0:dd.MM.yyyy}", ds.Koga) : ""),
						   idlice = l.Id
					   });

			if (filter.raionid != null && filter.raionid.Length > 0)
			{
				rez = rez.Where(m => m.raionid == filter.raionid);
			}

			if (filter.unomer > 0)
			{
				rez = rez.Where(m => m.unomer == filter.unomer);
			}

			if (filter.regnom != null && filter.regnom.Length > 0)
			{
				rez = rez.Where(m => m.dogregnom == filter.regnom);
			}

			if (filter.dpregnom != null && filter.dpregnom.Length > 0)
			{
				rez = rez.Where(m => m.dopspor.Contains(filter.dpregnom));
			}

			if (filter.viddpspor > 0)
			{
				rez = rez.Where(m => m.IdDopSp == filter.viddpspor);
			}

			return await rez
						 .Select(l => new ViewSpravka15
						 {
							 idl = l.idlice,
							 idformulqr = l.idformulqr,
							 unom = l.unom,
							 raion = l.raion,
							 dogovor = l.dogovor,
							 statusDl = l.statusDl,
							 dopspor = l.dopspor,
							 viddopspor = l.viddopspor,
							 komentar = l.komentar,
							 unomer = (int)l.unomer,
							 koga = l.koga
						 })
						  .OrderBy(x => x.unomer)
						  .ToListAsync();
		}

		public async Task<IList<ViewSpravka20>> GetSpravka20(Filter filter)
		{
			var data = from d in _dbContext.LicaFormuliarKolektiv
					   where d.IsTitulqr == 1 && d.Status == 1
					   from d1 in _dbContext.LicaFormuliarKolektiv
					   where d.IdL == d1.IdL && d1.IsTitulqr == 0 && d1.Status == 0 && d1.TypeLice < 2
					   from f in _dbContext.LicaFormuliars
					   where f.IdL == d.IdL
					   from s in _dbContext.NStatusis
					   where d1.StatusL == s.StatusCode && s.StatusName == "Status_L"
					   from n in _dbContext.NRaionis
					   where n.Nkod == d1.ARaion
					   select new
					   {
						   raionid = n.Nkod,
						   raion = n.Nime,
						   unom = f.UNom,
						   ime = d1.Ime,
						   status = s.Text,
						   ime2 = d.Ime,
						   faza = f.Faza,
						   unomer = f.UNomer
					   };

			if (filter.faza > 0)
			{
				data = data.Where(m => m.faza == filter.faza);
			}

			if (filter.raionid != null && filter.raionid.Length > 0)
			{
				data = data.Where(m => m.raionid == filter.raionid.Trim());
			}

			return await data
						.Select(item => new ViewSpravka20
						{
							raion = item.raion,
							unom = item.unom,
							ime = item.ime,
							status = item.status,
							ime2 = item.ime2,
							unomer = item.unomer
						})
						.OrderBy(x => x.unomer).ToListAsync();

		}


		public async Task<IList<ViewSpravka21>> GetSpravka21(Filter filter)
		{
			int faza = filter.faza;

			var lica = from p in _dbContext.LicaFormuliars
					   where p.Faza == (faza == 0 ? p.Faza : faza) && p.Status == 1
					   from l in _dbContext.LicaFormuliarKolektiv
					   where l.IdL == p.IdL && l.IsTitulqr == 1 && l.Status == 1
					   select new { idl = l.IdL, raion = l.ARaion };


			var cntform = from l in lica
						  from p in _dbContext.LicaFormuliars
						  where l.idl == p.IdL
						  group p by l.raion into g
						  select new { raion = g.Key, formulqri = g.Count() };

			var cntdog = from l in lica
						 from d in _dbContext.LicaDogovors
						 where d.IdL == l.idl && d.StatusDl == 2
						 group l by l.raion into g
						 select new { raion = g.Key, dogovori = g.Count() };

			var cntdoguredi = from l in lica
							  from d in _dbContext.LicaDogovors
							  where d.IdL == l.idl && d.StatusDl == 2
							  from u in _dbContext.LicaDogovorUredis
							  where d.IdDogL == u.IdDogL && u.StatusU < 6
							  from n in _dbContext.NUredi
							  where n.Id == u.IdKt && n.Vid != "RAD"
							  group u by l.raion into g
							  select new { raion = g.Key, doguredi = g.Sum(x => x.Broi) };

			var cntnonuredi = from p in lica
							  from d in _dbContext.LicaDogovorUredis
							  where d.IdL == p.idl && d.StatusU < 6
							  from n in _dbContext.NUredi
							  where n.Id == d.IdKt
							  group d by new { p.raion, n.Vid } into g
							  select new {
								  raion = g.Key.raion,
								  vid   = g.Key.Vid,
								  monuredipel = g.Sum(x => x.StatusU == 5 && g.Key.Vid == "PEL" ? x.Broi : 0),
								  monuredigaz = g.Sum(x => x.StatusU == 5 && g.Key.Vid == "GAZ" ? x.Broi : 0),
								  monurediklm = g.Sum(x => x.StatusU == 5 && g.Key.Vid == "KLM" ? x.Broi : 0),
								  monurrad    = g.Sum(x => x.StatusU == 5 && g.Key.Vid == "RAD" ? x.Broi : 0),
							  };

			var monurediquery = from p in _dbContext.LicaDogovorUredis
								join n in _dbContext.NUredi on p.IdKt equals n.Id
								where p.StatusU == 5
								group new { p.IdL, n.Vid } by new { p.IdL, n.Vid } into g
								select g.Key;

			var cntdomakinstva = from p in lica
							  from d in monurediquery
							  where d.IdL == p.idl
							  group d by new { p.raion, d.Vid } into g
							  select new
							  {
								  raion = g.Key.raion,
								  vid = g.Key.Vid,
								  monuredipeld = g.Select(x => x.IdL)
													.Where(x =>g.Key.Vid == "PEL")
													.Count(),

								  monuredigazd = g.Select(x => x.IdL)
													.Where(x => g.Key.Vid == "GAZ")
													.Count(),

								  monurediklmd = g.Select(x =>  x.IdL)
													.Where(x => g.Key.Vid == "KLM")
													.Count(),
							  };

			var raioni = _dbContext.NRaionis
							.Where(x => x.Status == 1)
							.Select(x => new ViewSpravka21
							{
								nkod = x.Nkod,
								raion = x.Nime,
								formulqri = 0,
								dogovori = 0,
								doguredi = 0,
								monurpel = 0,
								monurgaz = 0,
								monurklm = 0,
								monurrad = 0,
								monurpeld = 0,
								monurgazd = 0,
								monurklmd = 0,
							})
							.ToList();

			raioni.ForEach(x =>
			{
				var f = cntform.FirstOrDefault(a => a.raion == x.nkod);
				x.formulqri = (f != null ? f.formulqri : 0);

				var d = cntdog.FirstOrDefault(a => a.raion == x.nkod);
				x.dogovori = (d != null ? d.dogovori : 0);

				var u = cntdoguredi.FirstOrDefault(a => a.raion == x.nkod);
				x.doguredi = (u != null ? u.doguredi : 0);

				var p1 = cntnonuredi.FirstOrDefault(a => a.raion == x.nkod && a.vid == "PEL");
				x.monurpel = (p1 != null ? p1.monuredipel : 0);

				var p2 = cntnonuredi.FirstOrDefault(a => a.raion == x.nkod && a.vid == "GAZ");
				x.monurgaz = (p2 != null ? p2.monuredigaz : 0);

				var p3 = cntnonuredi.FirstOrDefault(a => a.raion == x.nkod && a.vid == "KLM");
				x.monurklm = (p3 != null ? p3.monurediklm : 0);

				var p4 = cntnonuredi.FirstOrDefault(a => a.raion == x.nkod && a.vid == "RAD");
				x.monurrad = (p4 != null ? p4.monurrad : 0);

				var p1d = cntdomakinstva.FirstOrDefault(a => a.raion == x.nkod && a.vid == "PEL");
				x.monurpeld = (p1d != null ? p1d.monuredipeld : 0);

				var p2d = cntdomakinstva.FirstOrDefault(a => a.raion == x.nkod && a.vid == "GAZ");
				x.monurgazd = (p2d != null ? p2d.monuredigazd : 0);

				var p3d = cntdomakinstva.FirstOrDefault(a => a.raion == x.nkod && a.vid == "KLM");
				x.monurklmd = (p3d != null ? p3d.monurediklmd : 0);

				x.monuredi = x.monurpel + x.monurgaz + x.monurklm;
				x.monuredid = x.monurpeld + x.monurgazd + x.monurklmd;
			});

			return raioni.OrderBy(z => z.nkod).ToList();

		}

		public async Task<IList<ViewSpravka5>> GetSpravka23(Filter filter)
		{
			string lcsql = "exec spravka5a 1," + 
							filter.faza + ',' + 
							"\'"+filter.raionid + "\'," +
							"\'" + filter.tipuredi + "\'," +
							"\'" + filter.uredi + "\'," +
							filter.statusDL + ',' +
							filter.statusU + ',' +
							filter.unomer;
			var data = _dbContext.ViewSpravka5.FromSqlRaw(lcsql)
						.ToList<ViewSpravka5>();

			return data;
		}

		public async Task<IList<ViewSpravka24>> GetSpravka24()
		{
			string lcsql = "exec spravka24";

			_dbContext.Database.SetCommandTimeout(180);

			var data = _dbContext.ViewSpravka24.FromSqlRaw(lcsql)
						.ToList<ViewSpravka24>();

			return data;
		}

		public async Task<IList<ViewSpravka25>> GetSpravka25(Filter filter)
		{
			string lcsql = "exec spravka25 '"+filter.raionid + "','"+filter.adres+"'";

			_dbContext.Database.SetCommandTimeout(180);

			var data = _dbContext.ViewSpravka25.FromSqlRaw(lcsql)
						.ToList<ViewSpravka25>();

			return data;
		}

		public async Task<IList<ViewOposPortret>> GetOposPortret(Filter filter)
		{
			string lcsql = "exec createOposPortret " + 
								filter.faza + ',' + 
								filter.unomer + ',' +
								filter.vidformulqr.ToString() + ',' +
								filter.vidportret.ToString();

			var data = _dbContext.ViewOposPortret.FromSqlRaw(lcsql)
						.ToList<ViewOposPortret>();

			return data;
		}

		public async Task<IList<ViewSpravka50>> GetSpravka50(Filter filter)
		{
			string lcsql = "exec spravka50 " + filter.firma + ',' + filter.limit;
			var data = _dbContext.ViewSpravka50.FromSqlRaw(lcsql)
						.ToList<ViewSpravka50>();

			return data;

		}

		public async Task<IList<ViewSpravka51>> GetSpravka51(Filter filter)
		{
			string lcsql = "exec spravka51 '" + filter.tipuredi + "','" + filter.uredi + "'";
			var data = _dbContext.ViewSpravka51.FromSqlRaw(lcsql)
						.ToList<ViewSpravka51>();

			return data;

		}

		public async Task<IList<ViewSpravka52>> GetSpravka52()
		{
			string lcsql = "exec spravka52";
			var data = _dbContext.ViewSpravka52.FromSqlRaw(lcsql)
						.ToList<ViewSpravka52>();

			return data;
		}

		public async Task<IList<ViewSpravka53>> GetSpravka53()
		{
			string lcsql = "exec spravka53";
			var data = _dbContext.ViewSpravka53.FromSqlRaw(lcsql)
						.ToList<ViewSpravka53>();

			return data;
		}
		public async Task<IList<ViewSpravka54>> GetSpravka54()
		{
			string lcsql = "exec spravka54";
			var data = _dbContext.ViewSpravka54.FromSqlRaw(lcsql)
						.ToList<ViewSpravka54>();

			return data;
		}
		public async Task<IList<ViewSpravka55>> GetSpravka55(int type)
		{
			string lcsql = "exec spravka55 " + type;
			var data = _dbContext.ViewSpravka55.FromSqlRaw(lcsql)
						.ToList<ViewSpravka55>();

			return data;
		}

		public async Task<IList<ViewSpravka55>> GetSpravka56()
		{
			string lcsql = "exec spravka56";
			var data = _dbContext.ViewSpravka55.FromSqlRaw(lcsql)
						.ToList<ViewSpravka55>();

			return data;
		}

		public async Task<IList<ViewSpravka60>> GetSpravka60(Filter1 filter)
		{
			var data = from p in _dbContext.Profilaktika
		//			   where p.Status_PF > 0
					   from m in _dbContext.MonPorychkaMain
					   where p.IdPorachkaMain == m.IdPorachkaMain
					   from df in _dbContext.MonDogovors
					   where m.IdDogovorFirma == df.IdFirmaMn
					   from fm in _dbContext.Firmi
					   where df.IdFirma == fm.IdFirma
					   from d in _dbContext.LicaFormuliarKolektiv
					   where d.IdL == p.IdL && d.IsTitulqr == 1 && d.Status == 1
					   from f in _dbContext.LicaFormuliars
					   where f.IdL == p.IdL
					   from s in _dbContext.NStatusis
					   where p.Status_PF == s.StatusCode && s.StatusName == "Status_PF"
					   from n in _dbContext.NRaionis
					   where n.Nkod == d.ARaion
					   from a in _dbContext.ViewAdres
					   where a.ID_L == d.IdL
					   from u in _dbContext.NUredi
					   where u.Id == p.IdUred
					   select new
					   {
						   firma = m.IdFirma,
						   raionid = n.Nkod,
						   raion = n.Nime,
						   unom = f.UNom,
						   ured = u.Nime,
						   ime = d.Ime,
						   adres = a.Adres,
						   period = p.Period,
						   pnomer = p.PNomer,
						   data = p.Data,
						   otchdata = p.OtchetData,
						   status = s.Text,
						   unomer = f.UNomer - ((uint)f.Faza * 100000),
						   statusPF = p.Status_PF,
						   idporychka = p.IdPorachkaMain,
						   note = p.Note,
						   iddogovor = m.IdDogovorFirma,
						   dogfirma = df.RegIndex,
						   namefirma = fm.Ime
					   };

			if (filter.unomer > 0)
			{
				data = data.Where(m => m.unomer == filter.unomer);
			}
			else
			{
				if (filter.raionid != null && filter.raionid.Length > 0)
				{
					data = data.Where(m => m.raionid == filter.raionid.Trim());
				}

				if (filter.firma > 0)
				{
					data = data.Where(m => m.firma == filter.firma);
				}

				if (filter.dogovor > 0)
				{
					data = data.Where(m => m.iddogovor == filter.dogovor);
				}

				if (filter.porychkanom > 0)
				{
					data = data.Where(m => m.idporychka == filter.porychkanom);
				}

				filter.otdata = (filter.otdata > new DateTime(2000, 1, 1) ? filter.otdata : new DateTime(2000, 1, 1));
				filter.dodata = (filter.dodata > new DateTime(2000, 1, 1) ? filter.dodata : new DateTime(2100, 12, 31));

				if (filter.otdata > new DateTime(2000, 1, 1))
				{
					data = data.Where(m => m.data > filter.otdata && m.data < filter.dodata);
				}

				if (filter.statusPF > -1)
				{
					data = data.Where(m => m.statusPF == filter.statusPF);
				}

			}

			return await data
						.Select(i => new ViewSpravka60
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
							note = i.note,
							dogfirma = i.dogfirma,
							namefirma = i.namefirma
						})
						.OrderBy(x => x.data)
						.ThenBy(x => x.status)
						.ToListAsync();
		}
		public async Task<IList<ViewSpravka60>> GetSpravka61(Filter1 filter)
		{
			int days = -15;
			var data = from p in _dbContext.Profilaktika
					   where p.Data < DateTime.Now.AddDays(days) &&  p.Status_PF== filter.statusPF
					   from m in _dbContext.MonPorychkaMain
					   where p.IdPorachkaMain == m.IdPorachkaMain
					   from df in _dbContext.MonDogovors
					   where m.IdDogovorFirma == df.IdFirmaMn
					   from fm in _dbContext.Firmi
					   where df.IdFirma == fm.IdFirma
					   from d in _dbContext.LicaFormuliarKolektiv
					   where d.IdL == p.IdL && d.IsTitulqr == 1 && d.Status == 1
					   from f in _dbContext.LicaFormuliars
					   where f.IdL == p.IdL
					   from s in _dbContext.NStatusis
					   where p.Status_PF == s.StatusCode && s.StatusName == "Status_PF"
					   from n in _dbContext.NRaionis
					   where n.Nkod == d.ARaion
					   from a in _dbContext.ViewAdres
					   where a.ID_L == d.IdL
					   from u in _dbContext.NUredi
					   where u.Id == p.IdUred
					   select new
					   {
						   firma = m.IdFirma,
						   raionid = n.Nkod,
						   raion = n.Nime,
						   unom = f.UNom,
						   ured = u.Nime,
						   ime = d.Ime,
						   adres = a.Adres,
						   period = p.Period,
						   pnomer = p.PNomer,
						   data = p.Data,
						   otchdata = p.OtchetData,
						   status = s.Text,
						   unomer = f.UNomer - ((uint)f.Faza * 100000),
						   statusPF = p.Status_PF,
						   idporychka = p.IdPorachkaMain,
						   iddogovor = m.IdDogovorFirma,
						   dogfirma = df.RegIndex,
						   namefirma = fm.Ime
					   };

			if (filter.unomer > 0)
			{
				data = data.Where(m => m.unomer == filter.unomer);
			}
			else
			{
				if (filter.raionid != null && filter.raionid.Length > 0)
				{
					data = data.Where(m => m.raionid == filter.raionid.Trim());
				}

				if (filter.firma > 0)
				{
					data = data.Where(m => m.firma == filter.firma);
				}

				if (filter.dogovor > 0)
				{
					data = data.Where(m => m.iddogovor == filter.dogovor);
				}

				if (filter.porychkanom > 0)
				{
					data = data.Where(m => m.idporychka == filter.porychkanom);
				}

				filter.otdata = (filter.otdata > new DateTime(2000, 1, 1) ? filter.otdata : new DateTime(2000, 1, 1));
				filter.dodata = (filter.dodata > new DateTime(2000, 1, 1) ? filter.dodata : new DateTime(2100, 12, 31));

				if (filter.otdata > new DateTime(2000, 1, 1))
				{
					data = data.Where(m => m.data > filter.otdata && m.data < filter.dodata);
				}

			}

			return await data
						.Select(i => new ViewSpravka60
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
						})
						.OrderBy(x => x.data)
						.ThenBy(x => x.status)
						.ToListAsync();
		}

		public async Task<IList<ViewSpravka70>> GetSpravka70(int tip, Filter1 filter)
		{
			var data = from p in _dbContext.MonPorychkas
						where p.StatusM == 1 && p.MonData != null
					   from m in _dbContext.MonPorychkaMain
					   where p.IdPorachkaMain == m.IdPorachkaMain
					   from df in _dbContext.MonDogovors
					   where m.IdDogovorFirma == df.IdFirmaMn
					   from d in _dbContext.LicaDogovors
						where p.IdDogovorLice == d.IdDogL
						from k in _dbContext.LicaFormuliarKolektiv
						where d.IdL == k.IdL && k.IsTitulqr == 1 && k.Status == 1
						from f in _dbContext.LicaFormuliars
						where f.IdL == d.IdL
						from n in _dbContext.NRaionis
						where n.Nkod == k.ARaion
						from a in _dbContext.ViewAdres
						where a.ID_L == d.IdL
						from u in _dbContext.NUredi
						where u.Id == p.IdUred
						select new
						{
							raionid = n.Nkod,
							raion = n.Nime,
							unom = f.UNom,
							ured = u.Nime,
							ime = k.Ime,
							adres = a.Adres,
							srok = d.SrokSobstvenost,
							data = ((DateTime)p.MonData).AddMonths(d.SrokSobstvenost),
							unomer = f.UNomer - ((uint)f.Faza * 100000),
							idporychka = p.IdPorachkaBody,
							kodured = u.Nkod, 
							dogfirma = df.RegIndex
						};

			if (filter.unomer > 0)
			{
				data = data.Where(m => m.unomer == filter.unomer);
			}
			else
			{
				if (tip == 0) 
					data = data.Where(m => m.data >= filter.otdata && m.data <= filter.dodata );
				else
					data = data.Where(m => m.data > filter.otdata && m.data <= filter.dodata);

				if (filter.raionid != null && filter.raionid.Length > 0)
				{
					data = data.Where(m => m.raionid == filter.raionid.Trim());
				}

				if (filter.uredi != null && filter.uredi.Length > 0)
				{
					data = data.Where(m => m.kodured == filter.uredi);
				}

			}

			return await data
				.Select(i => new ViewSpravka70
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
				})
				.OrderBy(x => x.data)
				.ToListAsync();
		}

		public async Task<IList<ViewSpravka78>> GetSpravka72(int tip, Filter1 filter)
		{
			var data = from p in _dbContext.MonPorychkas
					   where p.StatusM == 1 && p.MonData != null
					   from m in _dbContext.MonPorychkaMain
					   where p.IdPorachkaMain == m.IdPorachkaMain
					   from df in _dbContext.MonDogovors
					   where m.IdDogovorFirma == df.IdFirmaMn
					   from d in _dbContext.LicaDogovors
					   where p.IdDogovorLice == d.IdDogL && (d.StatusDl == 2 || d.StatusDl == 3) && d.isexpired == 0
					   from k in _dbContext.LicaFormuliarKolektiv
					   where d.IdL == k.IdL && k.IsTitulqr == 1 && k.Status == 1
					   from f in _dbContext.LicaFormuliars
					   where f.IdL == d.IdL
					   from n in _dbContext.NRaionis
					   where n.Nkod == k.ARaion
					   from a in _dbContext.ViewAdres
					   where a.ID_L == d.IdL
					   select new
					   {
						   raionid = n.Nkod,
						   raion = n.Nime,
						   unom = f.UNom,
						   ime = k.Ime,
						   adres = a.Adres,
						   dogovor = d.RegN,
						   srok = d.SrokSobstvenost,
						   data = ((DateTime)(p.MonData.HasValue ? p.MonData : new DateTime(2000, 1, 1)))
										.AddMonths(d.SrokSobstvenost),
						   unomer = f.UNomer - ((uint)f.Faza * 100000),
						   iddogovor = d.IdDogL,
						   dogfirma = df.RegIndex
					   };

			if (filter.unomer > 0)
			{
				try
				{
					data = data.Where(m => m.unomer == filter.unomer);
				}
				catch (FormatException e)
				{
				}
			}
			else
			{
				if (tip == 0)
					data = data.Where(m => m.data >= filter.otdata && m.data <= filter.dodata);
				else
					data = data.Where(m => m.data > filter.otdata && m.data <= filter.dodata);

				if (filter.raionid != null && filter.raionid.Length > 0)
				{
					data = data.Where(m => m.raionid == filter.raionid.Trim());
				}
			}

			return await data
				.Distinct()
				.Select(i => new ViewSpravka78
				{
					raion = i.raion,
					unom = i.unom,
					ime = i.ime,
					adres = i.adres,
					dogovor = i.dogovor,
					srok = i.srok,
					data = i.data,
					iddogovor = i.iddogovor,
					dogfirma = i.dogfirma
				})
				.OrderBy(x => x.data)
				.ToListAsync();
		}

		public async Task<IList<ViewSpravka78>> GetSpravka78(Filter1 filter)
		{
			var d1 = (filter.otdata < new DateTime(2000, 1, 1) ? new DateTime(2000, 1, 1) : filter.otdata);
			var d2 = (filter.dodata < new DateTime(2000, 1, 1) ? new DateTime(2100, 12, 31) : filter.dodata);

			var data = from p in _dbContext.MonPorychkas
					   where p.StatusM == 1
					   from d in _dbContext.LicaDogovors
					   from m in _dbContext.MonPorychkaMain
					   where p.IdPorachkaMain == m.IdPorachkaMain
					   from df in _dbContext.MonDogovors
					   where m.IdDogovorFirma == df.IdFirmaMn
					   where p.IdDogovorLice == d.IdDogL && (d.StatusDl == 2 || d.StatusDl == 3) && d.isexpired ==0
					   from k in _dbContext.LicaFormuliarKolektiv
					   where d.IdL == k.IdL && k.IsTitulqr == 1 && k.Status == 1
					   from f in _dbContext.LicaFormuliars
					   where f.IdL == d.IdL
					   from n in _dbContext.NRaionis
					   where n.Nkod == k.ARaion
					   from a in _dbContext.ViewAdres
					   where a.ID_L == d.IdL
					   select new
					   {
						   raionid = n.Nkod,
						   raion = n.Nime,
						   unom = f.UNom,
						   ime = k.Ime,
						   adres = a.Adres,
						   dogovor = d.RegN,
						   srok = d.SrokSobstvenost,
						   data = ((DateTime)(p.MonData.HasValue ? p.MonData : new DateTime(2000, 1, 1)))
										.AddMonths(d.SrokSobstvenost),
						   unomer = f.UNomer - ((uint)f.Faza * 100000),
						   iddogovor = d.IdDogL,
						   dogfirma = df.RegIndex
					   };

			if (filter.unomer > 0)
			{
				try
				{
					data = data.Where(m => m.unomer == filter.unomer);
				}
				catch (FormatException e)
				{
				}
			}
			else
			{
				data = data.Where(m => m.data >= d1 && m.data <= d2);

				if (filter.raionid != null && filter.raionid.Length > 0)
				{
					data = data.Where(m => m.raionid == filter.raionid.Trim());
				}
			}

			return await data
				.Distinct()
				.Select(i => new ViewSpravka78
				{
					raion = i.raion,
					unom = i.unom,
					ime = i.ime,
					adres = i.adres,
					dogovor = i.dogovor,
					srok = i.srok,
					data = i.data,
					iddogovor = i.iddogovor,
					dogfirma = i.dogfirma
				})
				.OrderBy(x => x.data)
				.ToListAsync();
		}

		public async Task<int> setPorychkaStatus(int idporychka, int status)
		{

			var f = _dbContext.MonPorychkas
						  .SingleOrDefault(x => x.IdPorachkaBody == idporychka);
			if (f != null)
			{
				f.StatusM = (short) status;
				_dbContext.Entry(f).State = EntityState.Modified;
				await _dbContext.SaveChangesAsync();
			}
			return 0; 
		}

		public async Task<int> setPorychkaUnSign(int idporychka)
		{

			var f = _dbContext.MonPorychkas
						  .SingleOrDefault(x => x.IdPorachkaBody == idporychka);
			if (f != null)
			{
				f.unsigned = 1;

				_dbContext.Entry(f).State = EntityState.Modified;
				await _dbContext.SaveChangesAsync();
			}
			return 0;
		}


	}
}
