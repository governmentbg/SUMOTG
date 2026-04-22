using Common.DTO;
using Common.DTO.Lica;
using Common.Entities;
using Common.Entities.Views;
using Common.Repositories.Infrastructure;
using Common.Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Services
{
	public class LicaService : BaseService, ILicaService
	{
		protected readonly ILicaRepository licaRepository;
		protected readonly IOditRepository oditRepository;

		public LicaService(ILicaRepository licaRepository, IOditRepository oditRepository) : base()
		{
			this.licaRepository = licaRepository;
			this.oditRepository = oditRepository;
		}

		#region firma
		public async Task<IList<FirmsDTO>> GetFirms(FilterDTO filter, string iduser)
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
				adres = filter.adres
			};

			var data = await licaRepository.GetFirms(flt, iduser);
			return data.Select(i => new FirmsDTO
			{
				idfirma = i.idfirma,
				unom = i.unom,
				raion = i.raion,
				ident = i.ident,
				ime = i.ime,
				statusL = i.statusL,
				idformulqr = i.idformulqr,
				statusF = i.statusF,
				iddogovor = i.iddogovor,
				statusDL = i.statusDL,
			}).ToList();
		}

		public async Task<FirmaDTO> GetFirma(int id)
		{
			LicaFormuliarFirma data = await licaRepository.GetFirma(id);
			if (data != null)
				return convertFirmaToFirmaDTO(data);
			else
				return new FirmaDTO();
		}

		public async Task<int> SetFirma(string pIdUser, FirmaDTO item)
		{
			LicaFormuliarFirma data = convertFirmaDTOtoFirma(pIdUser, item);
			return await licaRepository.SetFirma(data);
		}

		#endregion

		#region lica
		public async Task<LiceDTO> GetLice(int id)
		{
			ViewLica data = await licaRepository.GetLice(id);
			if (data != null)
				return convertLice2LiceDTO(data);
			else
				return new LiceDTO();
		}

		public async Task<int> SetLice(string pIdUser, LiceDTO item)
		{
			bool isNew = (item.idlice == 0);
			item.total = (short)(item.tochki1 +
								item.tochki2 +
								item.tochki3 +
								item.tochki4 +
								item.tochki5 +
								item.tochki6 +
								item.tochki7);

			Lica data = new Lica
			{
				IdL = item.idl,
				VLice = item.vidLice,
				Status = item.status,
				Tochki1 = item.tochki1,
				Tochki2 = item.tochki2,
				Tochki3 = item.tochki3,
				Tochki4 = item.tochki4,
				Tochki5 = item.tochki5,
				Tochki6 = item.tochki6,
				Tochki7 = item.tochki7,
				Total = item.total,
				Faza = item.faza,
				Koga = DateTime.Now,
				User = pIdUser,
			};

			int id = await licaRepository.SetLice(data);
			await SetTitulqr(pIdUser, id, item, isNew);
			return id;
		}


		public async Task<IList<PersonsDTO>> GetPersons(FilterDTO filter, string iduser)
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
				adres = filter.adres
			};

			var item = await licaRepository.GetPersons(flt, iduser);
			return item.Select(i => new PersonsDTO
			{
				idl = i.idl,
				unom = i.unom,
				raion = i.raion,
				ident = i.ident,
				ime = i.ime,
				statusL = i.statusL,
				idformulqr = i.idformulqr,
				statusF = i.statusF,
				iddogovor = i.iddogovor,
				statusDL = i.statusDL,
				typelice = i.typeLice,
				bal = i.bal,
				adres = i.adres,
				idlice = i.idlice
			}).ToList();
		}

		public async Task<IList<PersonsDTO>> GetDogovorPersons(FilterDTO filter, string iduser)
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
				adres = filter.adres
			};

			var item = await licaRepository.GetDogovorPersons(flt, iduser);
			return item.Select(i => new PersonsDTO
			{
				idl = i.idl,
				unom = i.unom,
				raion = i.raion,
				ident = i.ident,
				ime = i.ime,
				statusL = i.statusL,
				idformulqr = i.idformulqr,
				statusF = i.statusF,
				iddogovor = i.iddogovor,
				statusDL = i.statusDL,
				typelice = i.typeLice,
				bal = i.bal,
				dognomer = i.dognomer,
				dogdate = i.dogdate,
				telefon = i.telefon,
				adres = i.adres,
				idlice = i.idlice
			}).ToList();
		}

		public async Task<LiceDogovorDTO> GetLiceDogovor(int id)
        {
			var item = await licaRepository.GetLiceDogovor(id);
			if (item != null)
				return new LiceDogovorDTO
				{
					iddog = item.iddog,
					idl = item.idl,
					faza = item.faza,
					regnom = item.regnom,
					regnomdata = item.regnomdata,
					uredi = convertDogovorUrediToUrediDTO(item.uredi),
					olduredi = convertDogovorUrediToUrediDTO(item.olduredi),
					arhuredi = convertDogovorUrediToUrediDTO(item.arhuredi),
					dopsp = convertDogovorDopSpToDopSpDTO(item.dopsp),
					status_DL = item.status_DL,
					status = item.status,
					comentar= item.Comentar,
					brdopsp = item.BrDopSp,
					vid = item.vid,
					SrokDogovor = item.SrokDogovor,
					SrokSobstvenost = item.SrokSobstvenost
				};
			else
				return new LiceDogovorDTO();
		}

		public async Task<int> SetLiceDogovor(string iduser, LiceDogovorDTO item)
		{
			//item.olduredi.ForEach(x => { x.statusU = item.status_DL;});
			//item.uredi.ForEach(x => { x.statusU = item.status_DL; });

			if (item.status_DL==9)
            {
				item.olduredi.ForEach(x => { x.status = 0; });
				item.uredi.ForEach(x => { x.status = 0; });
			}

			LicaDogovor data = new LicaDogovor
			{
				IdDogL = item.iddog,
				IdL = item.idl,
				Faza = item.faza,
				RegN = item.regnom,
				DataRegN = item.regnomdata,
				StatusDl = item.status_DL,
				User = iduser,
				Koga = DateTime.Now,
				Status = (short)(item.status_DL == 9 ? 0 :item.status),
				Comentar = item.comentar,
				BrDopSp = item.brdopsp,
				SrokDogovor = item.SrokDogovor,
				SrokSobstvenost = item.SrokSobstvenost
			};
			int id = await licaRepository.SetLiceDogovor(iduser, data);

			if (id > 0)
			{
				//dobawqne na old uredi
				await SetDogovorOldUredi(iduser, item.idl, id, item.olduredi);

				//dobawqne na uredi
				await SetDogovorUredi(iduser, item.idl, id, item.uredi);

				//dobawqne na dop. sporazumeniq
				await SetDogovorDopSp(iduser, item.idl, id, item.dopsp);
			}

			return id;
		}

		public async Task<int> SetLiceDogovorStatus(string iduser, int id, int status)
        {
			int iddog = await licaRepository.SetLiceDogovorStatus(iduser, id,status);
			return iddog;
		}

		public async Task<int> changeLiceTitulqr(string iduser, int idlice, int statuslice)
        {
			int id = await licaRepository.changeLiceTitulqr(iduser, idlice, statuslice);
			return id;

		}

		public async Task<int> setLiceDogovorExpired(string iduser, int iddog)
        {
			int id = await licaRepository.setLiceDogovorExpired(iduser, iddog);
			return id;
		}

		#endregion

		#region uredi
		public async Task<IList<UrediDTO>> GetUred(int id)
		{
			var data = await licaRepository.GetUredi(id);
			return convertUrediToUrediDTO(data);
		}

		public async Task SetUredi(string pIdUser, int pIdFormulqr, int pIdLice, List<UrediDTO> items)
		{
			await licaRepository.DelUredi(pIdLice);

			foreach (UrediDTO item in items) {
				if (item.id != null && Int16.Parse(item.id) > 0) {
					item.idL = pIdLice;
					item.idFormuliar = pIdFormulqr;
					LicaFormuliarUredi data = convertUrediDTOtoUredi(pIdUser, item);
					await licaRepository.SetUredi(data);
				}
			}
		}

		public async Task SetDogovorUredi(string pIdUser, int pIdLice, int pIdDog, List<UrediDTO> items)
		{
			if (items != null)
			{
				List<LicaDogovorUredi> newuredi = items.Select(data => new LicaDogovorUredi
				{
					IdDogL = pIdDog,
					IdKt = Int16.Parse(data.id)
				}).ToList();

				await licaRepository.SetDogovorUrediArhiv(pIdDog, newuredi);
			}
	
			await licaRepository.DelDogovorUredi(pIdDog);

			foreach (UrediDTO item in items)
			{
				if (item.id != null && Int16.Parse(item.id) > 0)
				{
					LicaDogovorUredi data = new LicaDogovorUredi
					{
						IdDogL = pIdDog,
						IdL = pIdLice,
						IdKt = Int16.Parse(item.id),
						Broi = item.broi,
						StatusU = Int16.Parse(item.statusU),
						Status = item.status,
						Koga = DateTime.Now,
						User = pIdUser
					};

					await licaRepository.SetDogovorUredi(data);
				}
			}
		}

		public async Task SetDogovorDopSp(string pIdUser, int pIdLice, int pIdDog, List<DopSpDTO> items)
		{
			await licaRepository.DelDogovorDopSp(pIdLice);

			foreach (DopSpDTO item in items)
			{
				if (item.id != null && Int16.Parse(item.id) > 0)
				{
					LicaDopSporazumeniq data = new LicaDopSporazumeniq
					{
						IdL = pIdLice,
						IdDopSp = Int16.Parse(item.id),
						RegNomer = item.regnomer,
						Komentar = item.komentar,
						User = pIdUser,
						Koga = DateTime.Now
					};

					await licaRepository.SetDogovorDopSp(data);
				}
			}
		}

		public async Task<int> updOposDogovorNomer(string nomer, string data, string otnosno)
        {
			return await licaRepository.updOposDogovorNomer(nomer, data, otnosno);
		}

		#endregion

		#region olduredi
		public async Task<IList<UrediDTO>> GetOldUred(int id)
		{
			var data = await licaRepository.GetOldUredi(id);
			return convertOldUrediToUrediDTO(data);
		}

		public async Task SetOldUredi(string pIdUser, int pIdFormulqr, int pIdLice, List<UrediDTO> items)
		{
			await licaRepository.DelOldUredi(pIdLice);

			foreach (UrediDTO item in items)
			{
				if (item.id != null && Int16.Parse(item.id) > 0)
				{
					item.idL = pIdLice;
					item.idFormuliar = pIdFormulqr;
					LicaFormuliarOldUredi data = convertUrediDTOtoOldUredi(pIdUser, item);
					await licaRepository.SetOldUredi(data);
				}
			}
		}

		public async Task SetDogovorOldUredi(string pIdUser, int pIdLice, int pIdDog, List<UrediDTO> items)
		{
			await licaRepository.DelDogovorOldUredi(pIdDog);

			foreach (UrediDTO item in items)
			{
				if (item.id != null && Int16.Parse(item.id) > 0)
				{
					LicaDogovorOldUredi data = new LicaDogovorOldUredi
					{
						IdDogL = pIdDog,
						IdL = pIdLice,
						IdKt = Int16.Parse(item.id),
						Broi = item.broi,
						StatusDU = (item.id=="22" ? (short)5 : Int16.Parse(item.statusU)),
						Status = item.status,
						Koga = DateTime.Now,
						User = pIdUser
					};

					await licaRepository.SetDogovorOldUredi(data);
				}
			}
		}
		#endregion

		#region systav
		public async Task<IList<LiceDTO>> GetKolektiv(int id)
		{
			var data = await licaRepository.GetKolektiv(id);
			return convertLicaKolektiv2LiceDTO(data);
		}

		public async Task SetKolektiv(string pIdUser, int pIdLice, List<LiceDTO> items)
        {
			await licaRepository.DelKolektiv(pIdLice);

			foreach (LiceDTO item in items)
			{
				if (item.ident.Length > 0)
				{
					item.idl = pIdLice;
					item.idlice = 0;

					LicaFormuliarKolektiv data = convertLiceDTO2LiceKolektiv(pIdUser, item);
					await licaRepository.SetKolektiv(data);
				}
			}
		}

		public async Task SetChlen(string pIdUser, LiceDTO item)
		{
			LicaFormuliarKolektiv data = convertLiceDTO2LiceKolektiv(pIdUser, item);
			await licaRepository.UpdKolektiv(data);
		}

		public async Task<int> SetTitulqr(string pIdUser, int pIdL, LiceDTO items, bool isNew)
		{
			LicaFormuliarKolektiv data = new LicaFormuliarKolektiv
			{
				IdL = pIdL,
				Id  = items.idlice,
				VIdent = items.vidIdent,
				Ident = items.ident,
				Ime = items.ime,
				NLk = items.nomLk,
				DataIzdavane = items.dataIzdavane,
				ARaion = items.admRaion,
				Nm = items.nasMqsto,
				Kv = items.kvartal,
				Jk = items.jk,
				Ul = items.ulica,
				Nomer = items.nomer,
				Blok = items.blok,
				Vh = items.vhod,
				Etaj = items.etaj,
				Ap = items.apart,
				EMail = items.email,
				Tel = items.telefon,
				Pk = items.postKode,
				StatusL = items.statusL,
				Status = 1,
				Koga = DateTime.Now,
				User = pIdUser,
				nV8 = items.nv8,
				TypeLice = items.typeLice,
				IsTitulqr = 1
			};

			if (isNew)
				return await licaRepository.SetKolektiv(data);
			else
				return await licaRepository.UpdKolektiv(data);
		}

		#endregion

		#region formulqr
		public async Task<IList<ListFormulqrDTO>> GetListFormulqrs(int pVid, FilterDTO filter, string iduser)
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
				adres = filter.adres
			};

			var item = await licaRepository.GetListFormulqrs(pVid, flt, iduser);

			return item.Select(i => new ListFormulqrDTO
				{
					IdFormulqr = i.IdFormulqr,
					unom = i.unom,
					raion = i.raion,
					idl = i.idl,
					name = i.name,
					ident = i.ident,
					telefon = i.telefon,
					idfirma = i.idfirma,
					firma = i.firma,
					bulstat = i.bulstat,
					bal = i.bal,
					status_L = i.status_L,
					status_f = i.status_f,
					iddog = i.iddog,
					status_dl = i.status_dl,
					stattxt_dl = i.stattxt_dl,
					stattxt_f = i.stattxt_f,
					stattxt_l = i.stattxt_l,
					unomer = i.unomer
			}).ToList();
		}
		
		public async Task<FormulqrDTO> GetFormulqr(int id)
        {
			var item = await licaRepository.GetFormulqr(id);
			if (item != null)
			{
				return new FormulqrDTO
				{
					idformulqr = item.IdFormulqr,
					unom = item.uNom,
					faza = item.Faza,
					regdate = item.regdate,
					lice = convertLice2LiceDTO(item.lice),
					firma = convertFirmaToFirmaDTO(item.firma),
					uredi = convertUrediToUrediDTO(item.uredi),
					olduredi = convertOldUrediToUrediDTO(item.olduredi),
					dokumenti = convertDocsToDocsDTO(item.dokumenti),
					systav = convertLicaKolektiv2LiceDTO(item.systav),
					nv9 = item.nv9,
					nv10 = item.nv10,
					v11 = item.v11,
					v12 = item.v12,
					v13 = item.v13,
					v14 = item.v14,
					v15 = item.v15,
					v16 = item.v16,
					v17 = item.v17,
					nv19 = item.nv19,
					v20 = item.v20,
					v211 = item.v211,
					v212 = item.v212,
					v213 = item.v213,
					v22 = item.v22,
					v23 = item.v23,
					v24 = item.v24,
					v25 = item.v25,
					v26 = item.v26,
					v27 = item.v27,
					v28 = item.v28,
					nv29 = item.nv29,
					v30 = item.v30,
					v31 = item.v31,
					v32 = item.v32,
					v33 = item.v33,
					v34 = item.v34,
					v35 = item.v35,
					v36 = item.v36,
					v37 = item.v37,
					v38 = item.v38,
					v391 = item.v391,
					v392 = item.v392,
					v401 = item.v401,
					v402 = item.v402,
					v41 = item.v41,
					v421 = item.v421,
					v422 = item.v422,
					v423 = item.v423,
					status = item.status,
					statusF = item.statusF,
					unomer = item.uNomer,
					statusDL = item.statusDL,
					comentar = item.comentar
				};
			}
			else
				return new FormulqrDTO();
		}

		public async Task<int> AddFormulqr(string pIdUser, FormulqrDTO item)
		{
			//kalkulirane na bala
			if (item.lice.vidLice != 3)
			{
				short v16 = (short)(item.v16 == 1 ? 1 : 0);
				short v17 = (short)(item.v17 == 1 ? 1 : 0);
				short v32 = (short)(item.v32);
				short v34 = (short)(item.v34 == 1 ? 1 : 0);
				short v35 = (short)(item.v35 == 1 ? 1 : 0);
				short v36 = (short)(item.v36 == 1 ? 1 : 0);
				short v37 = (short)(item.v37 == 1 ? 1 : 0);
				short v38 = (short)(item.v38 == 1 ? 1 : 0);

				//p4
				item.lice.tochki4 = (short)(v16 + v17);
				//p5
				if (v34 + v35 + v36 == 3)
					item.lice.tochki5 = 6;
				else
				if (v34 + v35 + v36 == 2)
				{
					item.lice.tochki5 = 4;
				}
				//p6
				item.lice.tochki6 = (short)(v32 > 0 && v32 < 5 ? v32 : 0);
				//p7
				if (v37 == 1 && v38 == 0)
				{
					item.lice.tochki7 = 2;
				}
				else if (v38 == 1)
				{
					item.lice.tochki7 = 3;
				}
				else
				{
					item.lice.tochki7 = 0;
				}
			}

			item.lice.total = (short)(item.lice.tochki1 +
								item.lice.tochki2 +
								item.lice.tochki3 +
								item.lice.tochki4 +
								item.lice.tochki5 +
								item.lice.tochki6 +
								item.lice.tochki7);

			//podgotowka na obektite za zapis w bazata 
			Lica lice = new Lica
			{
				IdL = item.lice.idl,
				VLice = item.lice.vidLice,
				Status = item.lice.status,
				Tochki1 = item.lice.tochki1,
				Tochki2 = item.lice.tochki2,
				Tochki3 = item.lice.tochki3,
				Tochki4 = item.lice.tochki4,
				Tochki5 = item.lice.tochki5,
				Tochki6 = item.lice.tochki6,
				Tochki7 = item.lice.tochki7,
				Total = item.lice.total,
				Faza = item.lice.faza,
				Koga = DateTime.Now,
				User = pIdUser,
			};

			LicaFormuliarKolektiv titulqr = new LicaFormuliarKolektiv
			{
				IdL = 0,
				Id = 0,
				VIdent = item.lice.vidIdent,
				Ident = item.lice.ident,
				Ime = item.lice.ime,
				NLk = item.lice.nomLk,
				DataIzdavane = item.lice.dataIzdavane,
				ARaion = item.lice.admRaion,
				Nm = item.lice.nasMqsto,
				Kv = item.lice.kvartal,
				Jk = item.lice.jk,
				Ul = item.lice.ulica,
				Nomer = item.lice.nomer,
				Blok = item.lice.blok,
				Vh = item.lice.vhod,
				Etaj = item.lice.etaj,
				Ap = item.lice.apart,
				EMail = item.lice.email,
				Tel = item.lice.telefon,
				Pk = item.lice.postKode,
				StatusL = item.lice.statusL,
				Status = 1,
				Koga = DateTime.Now,
				User = pIdUser,
				nV8 = item.lice.nv8,
				TypeLice = item.lice.typeLice,
				IsTitulqr = 1
			};

			//dobawqne na firma, samo ako e za firma
			LicaFormuliarFirma firma = convertFirmaDTOtoFirma(pIdUser, item.firma);

			//dobawqne na starite uredi
			List<LicaFormuliarOldUredi> olduredi = convertUrediDTOtoOldUredis(pIdUser, item.olduredi);

			//dobawqne na uredi
			List<LicaFormuliarUredi> uredi = convertUrediDTOtoUredis(pIdUser, item.uredi);

			//dobawqne na dokumenti
			List<LicaDokumenti> documents = convertDocsDTOtoDocs(pIdUser, item.dokumenti);

			//dobawqne na systav
			List<LicaFormuliarKolektiv> systav = convertLiceDTO2LiceKolektiv(pIdUser, item.systav);

			//dobawqne na formulqra
			var formulaqr = new LicaFormuliar
			{
				IdFormuliar = item.idformulqr,
				UNom = item.unom,
				Faza = item.faza,
				IdL = 0,
				nV9 = item.nv9,
				nV10 = item.nv10,
				V11 = (short)item.v11,
				V12 = (short)item.v12,
				V13 = item.v13,
				V14 = item.v14,
				V15 = item.v15,
				V16 = (short)item.v16,
				V17 = (short)item.v17,
				nV19 = item.nv19,
				V20 = (short)item.v20,
				V211 = item.v211,
				V212 = item.v212,
				V213 = item.v213,
				V22 = (short)item.v22,
				V23 = (short)item.v23,
				V24 = (short)item.v24,
				V25 = (short)item.v25,
				V26 = (short)item.v26,
				V27 = (short)item.v27,
				V28 = (short)item.v28,
				nV29 = item.nv29,
				V30 = (short)item.v30,
				V31 = (short)item.v31,
				V32 = (short)item.v32,
				V33 = (short)item.v33,
				V34 = (short)item.v34,
				V35 = (short)item.v35,
				V36 = (short)item.v36,
				V37 = (short)item.v37,
				V38 = (short)item.v38,
				V391 = item.v391,
				V392 = item.v392,
				V401 = item.v401,
				V402 = item.v402,
				V41 = item.v41,
				V421 = item.v421,
				V422 = item.v422,
				V423 = item.v423,
				Status = item.status,
				StatusF = item.statusF,
				Koga = DateTime.Now,
				User = pIdUser,
				UNomer = item.unomer

			};

			var result = await licaRepository.AddFormulqr(lice, formulaqr, titulqr, firma, olduredi, uredi, systav,  documents);
			return result;
		}

		public async Task<int> SetFormulqr(string pIdUser, FormulqrDTO item)
        {
			//kalkulirane na bala
			if (item.lice.vidLice != 3)
			{
				short v16 = (short)(item.v16 == 1 ? 1 : 0);
				short v17 = (short)(item.v17 == 1 ? 1 : 0);
				short v32 = (short)(item.v32);
				short v34 = (short)(item.v34 == 1 ? 1 : 0);
				short v35 = (short)(item.v35 == 1 ? 1 : 0);
				short v36 = (short)(item.v36 == 1 ? 1 : 0);
				short v37 = (short)(item.v37 == 1 ? 1 : 0);
				short v38 = (short)(item.v38 == 1 ? 1 : 0);

				//p4
				item.lice.tochki4 = (short)(v16 + v17);
				//p5
				if (v34 + v35 + v36 == 3)
					item.lice.tochki5 = 6;
				else
				if (v34 + v35 + v36 == 2)
				{
					item.lice.tochki5 = 4;
				}
				//p6
				item.lice.tochki6 = (short)(v32 > 0 && v32 < 5 ? v32 : 0);
                //p7
                if (v37==1 && v38==0)
                {
					item.lice.tochki7 = 2;
				} else if (v38 == 1) { 
					item.lice.tochki7 = 3;
				} else
                {
					item.lice.tochki7 = 0;
				}
			}

			//dobawqne na osnovniq zapis
			if (item.statusF == 9) {
				item.lice.status = 0;
				item.lice.statusL = 9;
			}
			int id = await SetLice(pIdUser, item.lice);

			//dobawqne na firma, samo ako e za firma
			if (item.lice.vidLice==3) { 
				item.firma.idl = id;
				int idfirma = await SetFirma(pIdUser, item.firma);
			}

			//dobawqne na starite uredi
			await SetOldUredi(pIdUser, item.idformulqr, id, item.olduredi);

			//dobawqne na uredi
			await SetUredi(pIdUser, item.idformulqr, id, item.uredi);

			//dobawqne na dokumenti
			await SetDocuments (pIdUser, id, item.dokumenti);

			//dobawqne na systav
			await SetKolektiv(pIdUser, id, item.systav);

			//dobawqne na formulqra
			var data = new LicaFormuliar
			{
				IdFormuliar = item.idformulqr,
				UNom = item.unom,
				Faza = item.faza,
				IdL = id,
				nV9 = item.nv9,
				nV10 = item.nv10,
				V11 = (short)item.v11,
				V12 = (short)item.v12,
				V13 = item.v13,
				V14 = item.v14,
				V15 = item.v15,
				V16 = (short)item.v16,
				V17 = (short)item.v17,
				nV19 = item.nv19,
				V20 = (short)item.v20,
				V211 = item.v211,
				V212 = item.v212,
				V213 = item.v213,
				V22 = (short)item.v22,
				V23 = (short)item.v23,
				V24 = (short)item.v24,
				V25 = (short)item.v25,
				V26 = (short)item.v26,
				V27 = (short)item.v27,
				V28 = (short)item.v28,
				nV29 = item.nv29,
				V30 = (short)item.v30,
				V31 = (short)item.v31,
				V32 = (short)item.v32,
				V33 = (short)item.v33,
				V34 = (short)item.v34,
				V35 = (short)item.v35,
				V36 = (short)item.v36,
				V37 = (short)item.v37,
				V38 = (short)item.v38,
				V391 = item.v391,
				V392 = item.v392,
				V401 = item.v401,
				V402 = item.v402,
				V41 = item.v41,
				V421 = item.v421,
				V422 = item.v422,
				V423 = item.v423,
				Status = (item.statusF == 9 ? (short)0 :item.status),
				StatusF = item.statusF,
				Koga = DateTime.Now,
				User = pIdUser,
				UNomer = item.unomer,
				comentar = item.comentar
			};

			var result = await licaRepository.SetFormulqr(data, item.lice.vidLice, item.unomer);

            var v = await licaRepository.GetLiceDogovorStatus(id);
            if (v != 2) {
				int iddog = GetLiceDogovorNomer(id);
				if (item.statusF == 2) {
					//syzdawane na dogowor
					if (iddog == 0) { 
						LicaDogovor dgv = new LicaDogovor() {
							IdDogL = 0,
							IdL = item.lice.idl,
							Faza = item.faza,
							RegN = "",
							DataRegN = null,
							StatusDl = 1,
							User = pIdUser,
							Koga = DateTime.Now,
							Status = 1
						};

						iddog = await licaRepository.SetLiceDogovor(pIdUser, dgv);
					}

					if (iddog > 0)
					{
						await SetDogovorOldUredi(pIdUser, id, iddog, item.olduredi);

						//dobawqne na uredi
						await SetDogovorUredi(pIdUser, id, iddog, item.uredi);
					}
				} else {
					await licaRepository.SetLiceDogovorStatus(pIdUser, iddog, item.statusF);
				}
			}
			return result;
		}

		public int GetLiceDogovorNomer(int id)
		{
			return licaRepository.GetLiceDogovorNomer(id);
		}

		public Task<int> GetLiceDogovorStatus(int id)
		{
			return licaRepository.GetLiceDogovorStatus(id);
		}

		public async Task<IList<PersonsDTO>> getHistoryFormulqr(int id)
        {
			var items = await licaRepository.getHistoryFormulqr(id);
			return items.Select (i => new PersonsDTO
			{
				idl = i.idl,
				unom = i.unom,
				raion = i.raion,
				ident = i.ident,
				ime = i.ime,
				statusL = i.statusL,
				idformulqr = i.idformulqr,
				statusF = i.statusF,
				iddogovor = i.iddogovor,
				statusDL = i.statusDL,
				typelice = i.typeLice,
				bal = i.bal,
				dogdate = i.dogdate
			}).ToList();
		}

		public async Task<int> setFormulqrStatus(string iduser, int idformulqr, int status)
		{
			int id = await licaRepository.setFormulqrStatus(iduser, idformulqr, status);
			return id;
		}

		public async Task<int> checkFormulqrUnomer(string unomer, int faza)
        {
			int id = await licaRepository.checkFormulqrUnomer(unomer, faza);
			return id;
		}

		public async Task<int> checkFormulqrAdres(AdresDTO adres)
        {
			var adr = new Address
			{
				id = adres.id,
				raionid = adres.raionid,
				nm =  adres.nm,
				jk = adres.jk,
				ul = adres.ul,
				nomer = adres.nomer,
				blok = adres.blok,
				vh = adres.vh,
				etaj = adres.etaj,
				ap = adres.ap
			};

			int id = await licaRepository.checkFormulqrAdres(adr);
			return id;

		}

		#endregion

		#region documenti
		public async Task SetDocuments(string pIdUser, int pIdLice, List<ListDocumentsDTO> items)
		{
			await licaRepository.DelDocuments(pIdLice);

			foreach (ListDocumentsDTO item in items)
			{
				if (item.id != null && Int16.Parse(item.id) > 0)
				{
					item.idL = pIdLice;
					LicaDokumenti data = convertDocsDTOtoDocs(pIdUser, item);
					await licaRepository.SetDocument(data);
				}
			}

		}
		#endregion


		#region printdoc        
		public async Task<DogovorPrintDTO> getDogovorData(int id)
		{
			var item = await licaRepository.getDogovorData(id);
			if (item != null)
				return new DogovorPrintDTO
				{
					unom = item.unom,
					ident = item.ident,
					ime = item.ime,
					txturedi = item.txturedi,
					txtrad = item.txtrad,
					txtolduredi = item.txtolduredi,
					adres = item.adres,
					vidimot = item.vidimot,
					regnomer = item.regnomer,
					regdate = item.regdate,
					nomlk = item.nomlk,
					datalk = item.datalk,
					f_eik = item.f_eik,
					f_ime = item.f_ime,
					f_Adres = item.f_Adres,
					v_lice = item.v_lice
				};
			else
				return new DogovorPrintDTO();
		}
		#endregion

		public async Task<IList<ViewRadiatoriZaPrekodiraneDTO>> getRadiatoriZaPrekodirane(FilterDTO filter)
        {
			var flt = new Filter
			{
				raionid = filter.raionid,
				tipuredi = filter.tipuredi,
				unomer = filter.unomer,
				statusDL = filter.statusDL
			};

			var items = await licaRepository.getRadiatoriZaPrekodirane(flt);
			return items.Select(i => new ViewRadiatoriZaPrekodiraneDTO
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
				}).ToList();
		}

		public async Task<int> doPrekodiraneRadiatori(int iddog, string iduser)
        {
			return await licaRepository.doPrekodiraneRadiatori(iddog,iduser);
		}


		public async Task<AdresDTO> getAddress(int id)
        {
			var item = await licaRepository.getAddress(id);
			return new AdresDTO
			{
					id = item.id,
					raionid = item.raionid,
					nm = item.nm,
					kv = item.kv,
					jk = item.jk,
					ul = item.ul,
					nomer = item.nomer,
					blok = item.blok,
					vh = item.vh,
					etaj = item.etaj,
					ap = item.ap,
					opos = item.opos
				};
		}

		public async Task<int> setAddress(AdresDTO adres)
        {
			var adr = new Address
			{
				id = adres.id,
				raionid = adres.raionid,
				nm = adres.nm,
				jk = adres.jk,
				ul = adres.ul,
				nomer = adres.nomer,
				blok = adres.blok,
				vh = adres.vh,
				etaj = adres.etaj,
				ap = adres.ap
			};

			return await licaRepository.setAddress(adr);
		}

        #region private methods
        private List<DopSpDTO> convertDogovorDopSpToDopSpDTO(List<LicaDopSporazumeniq> data)
		{
			return data.Select(item => new DopSpDTO
			{
				idL = item.IdL,
				id = item.IdDopSp.ToString(),
				regnomer = item.RegNomer,
				komentar = item.Komentar
			}).ToList();
		}

		private List<UrediDTO> convertDogovorUrediToUrediDTO(List<ViewDogovorUredi> data)
		{
			return data.Select(item => new UrediDTO
			{
				idL = item.IdL,
				id = item.IdKt.ToString(),
				broi = item.Broi,
				statusU = item.StatusU.ToString(),
				status = item.Status
			}).ToList();
		}

		private LiceDTO convertLice2LiceDTO(ViewLica data)
        {
			return new LiceDTO
			{
				idl = data.IdL,
				vidLice = data.VLice,
				idlice = data.IdLice,
				vidIdent = data.VIdent,
				ident = data.Ident,
				ime = data.Ime,
				nomLk = data.NLk,
				dataIzdavane = data.DataIzdavane,
				admRaion = data.ARaion,
				nasMqsto = data.Nm,
				kvartal = data.Kv,
				jk = data.Jk,
				ulica = data.Ul,
				nomer = data.Nomer,
				blok = data.Blok,
				vhod = data.Vh,
				etaj = data.Etaj,
				apart = data.Ap,
				email = data.EMail,
				telefon = data.Tel,
				postKode = data.Pk,
				statusL = data.StatusL,
				status = data.Status,
				tochki1 = data.Tochki1,
				tochki2 = data.Tochki2,
				tochki3 = data.Tochki3,
				tochki4 = data.Tochki4,
				tochki5 = data.Tochki5,
				tochki6 = data.Tochki6,
				tochki7 = data.Tochki7,
				total = (data.Total),
				zona = data.Zona,
				faza = data.Faza,
				v7 = data.V7,
				nv8 = data.nV8,
				typeLice = data.typeLice,
				unom = data.Unom
			};
		}

		private FirmaDTO convertFirmaToFirmaDTO(LicaFormuliarFirma data)
		{
			if (data != null) {
				return new FirmaDTO
				{
					idfirma = data.Id,
					idl = data.IdL,
					vidFirma = data.VidFirma,
					tipFirma = data.TipFirma,
					ident = data.Ident,
					ime = data.Ime,
					kodKID = data.KodKID,
					admRaion = data.ARaion,
					nasMqsto = data.Nm,
					kvartal = data.Kv,
					jk = data.Jk,
					ulica = data.Ul,
					nomer = data.Nomer,
					blok = data.Blok,
					vhod = data.Vh,
					etaj = data.Etaj,
					apart = data.Ap,
					email = data.EMail,
					telefon = data.Tel,
					postKode = data.Pk,
					statusL = data.StatusL,
					statusF = data.StatusF,
					status = data.Status,
					faza = data.Faza
				};
			} else
				return new FirmaDTO();		
		}

		private LicaFormuliarFirma convertFirmaDTOtoFirma(string pIdUser, FirmaDTO data)
		{
			return new LicaFormuliarFirma
			{
				Id = data.idfirma,
				IdL = data.idl,
				VidFirma = data.vidFirma,
				TipFirma = data.tipFirma,
				Ident = data.ident,
				Ime = data.ime,
				KodKID = data.kodKID,
				ARaion = data.admRaion,
				Nm = data.nasMqsto,
				Kv = data.kvartal,
				Jk = data.jk,
				Ul = data.ulica,
				Nomer = data.nomer,
				Blok = data.blok,
				Vh = data.vhod,
				Etaj = data.etaj,
				Ap = data.apart,
				EMail = data.email,
				Tel = data.telefon,
				Pk = data.postKode,
				StatusL = data.statusL,
				StatusF = data.statusF,
				Status = data.status,
				Faza = data.faza,
				Koga = DateTime.Now,
				User = pIdUser
			};
		}

		private List<LicaFormuliarUredi> convertUrediDTOtoUredis(string pIdUser, List<UrediDTO> items)
		{
			return items
				.Where(x => Int16.Parse(x.id) > 0)
				.Select (item => new LicaFormuliarUredi
					{
						IdUredF = item.idUredF,
						IdFormuliar = item.idFormuliar,
						IdL = item.idL,
						IdKt = Int16.Parse(item.id),
						Broi = item.broi,
						StatusU = Int16.Parse(item.statusU),
						Status = item.status,
						Koga = DateTime.Now,
						User = pIdUser
					}).ToList();
		}

		private LicaFormuliarUredi convertUrediDTOtoUredi(string pIdUser, UrediDTO item)
        {
			return new LicaFormuliarUredi 
			{
				IdUredF = item.idUredF,
				IdFormuliar = item.idFormuliar,
				IdL = item.idL,
				IdKt = Int16.Parse(item.id),
				Broi = item.broi,
				StatusU = Int16.Parse(item.statusU),
				Status = item.status,
				Koga = DateTime.Now,
				User = pIdUser
			};
		}

		private List<UrediDTO> convertUrediToUrediDTO(List<LicaFormuliarUredi> data)
		{
			return data.Select(item =>  new UrediDTO
			{
				idUredF = item.IdUredF,
				idFormuliar = item.IdFormuliar,
				idL = item.IdL,
				id = item.IdKt.ToString(),
				broi = item.Broi,
				statusU = item.StatusU.ToString(),
				status = item.Status
			}).ToList();
		}

		private List<LicaDokumenti> convertDocsDTOtoDocs(string pIdUser, List <ListDocumentsDTO> items)
		{
			return items
				.Where (x => x.id != null)
				.Select(item => new LicaDokumenti
			{
				IdDok = 0,
				IdL = item.idL,
				DocType = Int16.Parse(item.id),
				DocDescription = item.description,
				FileName = item.filename,
				Status = item.status,
				Koga = DateTime.Now,
				User = pIdUser
			}).ToList();
		}


		private LicaDokumenti convertDocsDTOtoDocs(string pIdUser, ListDocumentsDTO item)
		{
			return new LicaDokumenti
			{
				IdDok = 0,
				IdL = item.idL,
				DocType = Int16.Parse(item.id),
				DocDescription = item.description,
				FileName = item.filename,
				Status = item.status,
				Koga = DateTime.Now,
				User = pIdUser
			};
		}

		private List<ListDocumentsDTO> convertDocsToDocsDTO(List<LicaDokumenti> data)
		{
			return data.Select(item => new ListDocumentsDTO
			{
				iddoc = item.IdDok,
				idL = item.IdL,
				id = item.DocType.ToString(),
				description = item.DocDescription,
				filename = item.FileName,
				status = item.Status
			}).ToList();
		}

		private List<LiceDTO> convertLicaKolektiv2LiceDTO(List<LicaFormuliarKolektiv> data)
		{
			return  data.Select(item => new LiceDTO
			{
				idl = item.IdL,
				idlice = item.Id,
				vidIdent = item.VIdent,
				ident = item.Ident,
				ime = item.Ime,
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
				email = item.EMail,
				telefon = item.Tel,
				postKode = item.Pk,
				statusL = item.StatusL,
				status = item.Status,
				typeLice = item.TypeLice
			}).ToList();
		}

		private List<LicaFormuliarKolektiv> convertLiceDTO2LiceKolektiv(string pIdUser, List<LiceDTO> items)
		{
			return items.Select(data => new LicaFormuliarKolektiv
			{
				IdL = data.idl,
				Id = data.idlice,
				VIdent = data.vidIdent,
				Ident = data.ident,
				Ime = data.ime,
				ARaion = data.admRaion,
				Nm = data.nasMqsto,
				Kv = data.kvartal,
				Jk = data.jk,
				Ul = data.ulica,
				Nomer = data.nomer,
				Blok = data.blok,
				Vh = data.vhod,
				Etaj = data.etaj,
				Ap = data.apart,
				EMail = data.email,
				Tel = data.telefon,
				Pk = data.postKode,
				StatusL = data.statusL,
				Status = data.status,
				Koga = DateTime.Now,
				User = pIdUser,
				TypeLice = data.typeLice,
				IsTitulqr = 0
			}).ToList();
		}

		private LicaFormuliarKolektiv convertLiceDTO2LiceKolektiv(string pIdUser, LiceDTO data)
		{
			return new LicaFormuliarKolektiv
			{
				IdL = data.idl,
				Id = data.idlice,
				VIdent = data.vidIdent,
				Ident = data.ident,
				Ime = data.ime,
				ARaion = data.admRaion,
				Nm = data.nasMqsto,
				Kv = data.kvartal,
				Jk = data.jk,
				Ul = data.ulica,
				Nomer = data.nomer,
				Blok = data.blok,
				Vh = data.vhod,
				Etaj = data.etaj,
				Ap = data.apart,
				EMail = data.email,
				Tel = data.telefon,
				Pk = data.postKode,
				StatusL = data.statusL,
				Status = data.status,
				Koga = DateTime.Now,
				User = pIdUser,
				TypeLice =data.typeLice,
				IsTitulqr = 0
			};
		}

		private List<LicaFormuliarOldUredi> convertUrediDTOtoOldUredis(string pIdUser, List<UrediDTO> items)
		{
			return items
				.Where(x => Int16.Parse(x.id) > 0)
				.Select(item => new LicaFormuliarOldUredi
			{
				IdUredF = item.idUredF,
				IdFormuliar = item.idFormuliar,
				IdL = item.idL,
				IdKt = Int16.Parse(item.id),
				Broi = item.broi,
				StatusU = Int16.Parse(item.statusU),
				Status = item.status,
				Koga = DateTime.Now,
				User = pIdUser
			}).ToList();
		}

		private LicaFormuliarOldUredi convertUrediDTOtoOldUredi(string pIdUser, UrediDTO item)
		{
			return new LicaFormuliarOldUredi
			{
				IdUredF = item.idUredF,
				IdFormuliar = item.idFormuliar,
				IdL = item.idL,
				IdKt = Int16.Parse(item.id),
				Broi = item.broi,
				StatusU = Int16.Parse(item.statusU),
				Status = item.status,
				Koga = DateTime.Now,
				User = pIdUser
			};
		}

		private List<UrediDTO> convertOldUrediToUrediDTO(List<LicaFormuliarOldUredi> data)
		{
			return data.Select(item => new UrediDTO
			{
				idUredF = item.IdUredF,
				idFormuliar = item.IdFormuliar,
				idL = item.IdL,
				id = item.IdKt.ToString(),
				broi = item.Broi,
				statusU = item.StatusU.ToString(),
				status = item.Status
			}).ToList();
		}

        #endregion
    }
}
