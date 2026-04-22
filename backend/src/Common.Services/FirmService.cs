using Common.DTO;
using Common.DTO.Firmi;
using Common.Entities;
using Common.Entities.Views;
using Common.Repositories.Infrastructure;
using Common.Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Common.Services
{
    public class FirmService : BaseService, IFirmService
    {
        protected readonly IFirmRepository firmRepository;

        public FirmService(IFirmRepository firmRepository) : base()
        {
            this.firmRepository = firmRepository;
        }

		public async Task<IList<IzpylnitelDTO>> GetFirmi(int faza, int rolq)
        {
			var data = await firmRepository.GetFirmi(faza, rolq);
			return data.Select(item => convertFirmaToIzpylnitelDTO(item)).ToList(); 
		}

		public async Task<IzpylnitelDTO> GetFirma(string eik)
        {
			var item = await firmRepository.GetFirma(eik);
			if (item != null)
			{
				return convertFirmaToIzpylnitelDTO(item);
			}
			else
				return new IzpylnitelDTO();
		}


		#region montaz
		public async Task<IList<FirmaIzpalnitelDTO>> GetFirmiMontaz(int faza)
        {
            var data = await firmRepository.GetFirmiMontaz(faza);
            return data.Select(i => new FirmaIzpalnitelDTO
            {
                idfirma = i.idFirma,
                eik = i.EIK,
                ime = i.Ime,
                iddog = i.IdDog,
                regnomer = i.RegIndex,
                dataregnom = i.DataRegN,
                statusdm = i.StatusDm,
                statusur = i.StatusUr
            }).ToList();
        }

        public async Task <FirmaDogovorDTO> GetMonDogovor(int iddog)
        {
			var item = await firmRepository.GetMonDogovor(iddog);
			if (item != null)
			{
				var data = new FirmaDogovorDTO
				{
					iddog = item.IdDog,
					faza = item.Faza,
					regnom = item.RegIndex,
					regnomdata = item.DataRegN,
					nomdgsudso = item.NomDgVSudso,
					nachalnadata = item.NachalnaData,
					srokgrafic = item.ObshtSrokGrf,
					cenabezdds = item.ObshtaCenaBezDds,
					cenadds = item.ObshtaCenaSDds,
					status_DM = item.StatusDm,
					status = item.Status,
					uredi = convertMonDgvUrediToFirmaUrediDTO(item.uredi),
					firma =  convertFirmaToIzpylnitelDTO(item.firma),
					raioni = convertMonRaionToFirmaRaioniDTO(item.raioni),
					payments = convertMonPaymentToFirmaPaymentDTO(item.payments),
				};

				return data;
			}
			else
				return new FirmaDogovorDTO();
		}

		public async Task<IList<FirmaDogovorDTO>> GetMonDogovoriFirma(int idfirma)
        {
			var data = await firmRepository.GetMonDogovoriFirma(idfirma);
			return data.Select(item => new FirmaDogovorDTO
			{
				iddog = item.IdDog,
				faza = item.Faza,
				regnom = item.RegIndex,
				regnomdata = item.DataRegN,
				nomdgsudso = item.NomDgVSudso,
				nachalnadata = item.NachalnaData,
				srokgrafic = item.ObshtSrokGrf,
				cenabezdds = item.ObshtaCenaBezDds,
				cenadds = item.ObshtaCenaSDds,
				status_DM = item.StatusDm,
				status = item.Status,
			}).ToList();
		}


		public async Task<int> SetMonDogovor(string pIdUser, FirmaDogovorDTO item)
		{
			var f = convertIzpylnitelDTOtoFirmi(pIdUser, item.firma);
			var u = convertFirmaUrediDTO2MonDgvUredi(pIdUser, item.iddog, item.uredi);
			var r = convertFirmaRaioniDTO2MonRaion(pIdUser, item.iddog, item.raioni);
			var p = convertFirmaPaymentDTO2MonPayment(pIdUser, item.iddog, item.payments);

			var data = new ViewFirmDogovor
			{
				IdDog = item.iddog,
				IdFirma = item.firma.idfirma,
				Faza = item.faza,
				RegIndex = item.regnom,
				DataRegN = item.regnomdata,
				NomDgVSudso = item.nomdgsudso,
				NachalnaData = item.nachalnadata,
				ObshtSrokGrf = item.srokgrafic,
				ObshtaCenaBezDds = item.cenabezdds,
				ObshtaCenaSDds = item.cenadds,
				StatusDm = item.status_DM,
				Status = item.status,
				firma = f,
				uredi = u,
				raioni = r,
				payments = p,
			};

			return await firmRepository.SetMonDogovor(data);
		}

		public async Task<IList<FirmaUrediDTO>> loadMonDogovorUredi(int iddogovor)
        {
			var u = await firmRepository.loadMonDogovorUredi(iddogovor);
			return u.Select(item => new FirmaUrediDTO
			{
				idured = item.IdKt.ToString(),
				name = item.Name,
				edcena = item.Edcena,
				broi = item.Broi,
				total = item.Total,
				status = item.Status
			})
			.OrderBy(x=>x.idured) 
			.ToList();
		}

		public async Task<IList<FirmaDogovorDTO>> loadMonDogovorPorychki(int iddogovor)
        {
			var data = await firmRepository.loadMonDogovorPorychki(iddogovor);
			return data.Select(item => new FirmaDogovorDTO
			{
				iddog = item.IdDog
			}).ToList();
		}

		#endregion

		#region demontaz
		public async Task<IList<FirmaIzpalnitelDTO>> GetFirmiDeMontaz(int faza)
        {
            var data = await firmRepository.GetFirmiDeMontaz(faza);
            return data.Select(i => new FirmaIzpalnitelDTO
            {
                idfirma = i.idFirma,
                eik = i.EIK,
                ime = i.Ime,
                iddog = i.IdDog,
                regnomer = i.RegIndex,
                dataregnom = i.DataRegN,
                statusdm =  i.StatusDm,
                statusur = i.StatusUr
            }).ToList();
        }

		public async Task<FirmaDogovorDTO> GetDeMonDogovor(int iddog)
		{
			var item = await firmRepository.GetDeMonDogovor(iddog);
			if (item != null)
			{
				var data = new FirmaDogovorDTO
				{
					iddog = item.IdDog,
					faza = item.Faza,
					regnom = item.RegIndex,
					regnomdata = item.DataRegN,
					nomdgsudso = item.NomDgVSudso,
					nachalnadata = item.NachalnaData,
					srokgrafic = item.ObshtSrokGrf,
					cenabezdds = item.ObshtaCenaBezDds,
					cenadds = item.ObshtaCenaSDds,
					status_DM = item.StatusDm,
					status = item.Status,
					uredi = convertDeMonDgvUrediToFirmaUrediDTO(item.olduredi),
					firma = convertFirmaToIzpylnitelDTO(item.firma),
					payments = convertDeMonPaymentsToFirmaPaymenDTO(item.dempayments)
				};

				return data;
			}
			else {
				return new FirmaDogovorDTO();
			}
		}

		public async Task<IList<FirmaDogovorDTO>> GetDeMonDogovoriFirma(int idfirma)
		{
			var data = await firmRepository.GetDeMonDogovoriFirma(idfirma);
			return data.Select(item => new FirmaDogovorDTO
			{
				iddog = item.IdDog,
				faza = item.Faza,
				regnom = item.RegIndex,
				regnomdata = item.DataRegN,
				nomdgsudso = item.NomDgVSudso,
				nachalnadata = item.NachalnaData,
				srokgrafic = item.ObshtSrokGrf,
				cenabezdds = item.ObshtaCenaBezDds,
				cenadds = item.ObshtaCenaSDds,
				status_DM = item.StatusDm,
				status = item.Status,
			}).ToList();
		}

		public async Task<int> SetDeMonDogovor(string pIdUser, FirmaDogovorDTO item)
		{
			var f = convertIzpylnitelDTOtoFirmi(pIdUser, item.firma);
			var u = convertFirmaUrediDTO2DemDgvUredi(pIdUser, item.iddog, item.uredi);
			var p = convertFirmaPaymentsDTO2DemPayments(pIdUser, item.iddog, item.payments);

			var data = new ViewFirmDogovor
			{
				IdDog = item.iddog,
				IdFirma = item.firma.idfirma,
				Faza = item.faza,
				RegIndex = item.regnom,
				DataRegN = item.regnomdata,
				NomDgVSudso = item.nomdgsudso,
				NachalnaData = item.nachalnadata,
				ObshtSrokGrf = item.srokgrafic,
				ObshtaCenaBezDds = item.cenabezdds,
				ObshtaCenaSDds = item.cenadds,
				StatusDm = item.status_DM,
				Status = (short)(item.status == 9 ? 0 : item.status),
				firma = f,
				olduredi = u,
				dempayments = p,
			};

			return await firmRepository.SetDeMonDogovor(data);
		}

		public async Task<IList<FirmaUrediDTO>> loadDeMonDogovorUredi(int iddogovor)
		{
			var u = await firmRepository.loadDeMonDogovorUredi(iddogovor);
			return u.Select(item => new FirmaUrediDTO
			{
				idured = item.IdKt.ToString(),
				name = item.Name,
				edcena = item.Edcena,
				broi = item.Broi,
				total = item.Total,
				status = item.Status
			})
			.OrderBy(x => x.idured)
			.ToList();
		}

		#endregion


		private Firmi convertIzpylnitelDTOtoFirmi(string pIdUser, IzpylnitelDTO data)
		{
			return new Firmi
			{
				IdFirma = data.idfirma,
				Faza = data.faza,
				Rolq = data.rolq,
				EIK = data.eik,
				Ime = data.ime,
				Manager = data.manager,
				MName = data.mname,
				Adres = data.adres,
				EMail = data.email,
				Tel = data.telefon,
				Pk = data.postKode,
				StatusDm = data.statusDM,
				Status = data.status,
				Koga = DateTime.Now,
				User = pIdUser
			};
		}

		#region new convert montazj metods
		private List<MonDgvUredi> convertFirmaUrediDTO2MonDgvUredi(string pIdUser, int iddog, List<FirmaUrediDTO> data)
		{
			return data
				.Where (x=> x.idured != null && Int32.Parse(x.idured)>0)
				.Select(item => new MonDgvUredi
						{
							IdFirmaMn = iddog,
							IdKn = Int16.Parse(item.idured),
							Model = item.model,
							EdCena = item.edcena,
							Broi = item.broi,
							StatusDs = item.statusU,
							Status = item.status,
							Koga = DateTime.Now,
							User = pIdUser,
							Garancia = item.garancia,
							Profilaktika = item.profilaktika
						})
				.ToList();
		}

		private List<MonPayments> convertFirmaPaymentDTO2MonPayment(string pIdUser, int iddog, List<FirmaPaymentDTO> data)
		{
			return data
				.Where(x => x.id != null && Int32.Parse(x.id) > 0)
				.Select(item => new MonPayments
				{
					IdFirmaMn = iddog,
					IdPay = Int32.Parse(item.id),
					SumaBezDds = item.sumabezdds,
					SumaSDds = item.sumasdds
				})
				.ToList();
		}

		private List<MonRajoni> convertFirmaRaioniDTO2MonRaion(string pIdUser, int iddog, List<FirmaRaioniDTO> data)
		{
			return data
				.Where (x => x.nkod != null && x.nkod.Length > 0)
				.Select(item => new MonRajoni
					{
						IdFirmaMn = iddog,
						Nkod = item.nkod,
						Status = 1,
						Faza = 0
					})
				.ToList();
		}

		private IzpylnitelDTO convertFirmaToIzpylnitelDTO(Firmi data)
		{
			if (data != null)
			{
				return new IzpylnitelDTO
				{
					idfirma = data.IdFirma,
					faza = data.Faza,
					rolq = data.Rolq,
					eik = data.EIK,
					ime = data.Ime,
					manager = data.Manager,
					mname = data.MName,
					adres = data.Adres,
					email = data.EMail,
					telefon = data.Tel,
					postKode = data.Pk,
					statusDM = data.StatusDm,
					status = data.Status,
				};
			}
			else
				return new IzpylnitelDTO();
		}


		private List<FirmaUrediDTO> convertMonDgvUrediToFirmaUrediDTO(List<MonDgvUredi> data)
		{
			return data.Select(item => new FirmaUrediDTO
			{
				iddog = (int) item.IdFirmaMn,
				idured = item.IdKn.ToString(),
				model = item.Model,
				edcena = item.EdCena,
				broi = item.Broi,
				total = item.EdCena * item.Broi,
				statusU = item.StatusDs,
				status = item.Status,
				garancia= item.Garancia,
				profilaktika = item.Profilaktika
			}).ToList();
		}

		private List<FirmaPaymentDTO> convertMonPaymentToFirmaPaymentDTO(List<MonPayments> data)
		{
			return data.Select(item => new FirmaPaymentDTO
			{
				idfirmamn = (int)item.IdFirmaMn,
				id = item.IdPay.ToString(),
				sumabezdds = item.SumaBezDds,
				sumasdds = item.SumaSDds
			}).ToList();
		}

		private List<FirmaRaioniDTO> convertMonRaionToFirmaRaioniDTO(List<MonRajoni> data)
		{
			return data.Select(item => new FirmaRaioniDTO
			{
				iddog = (int)item.IdFirmaMn,
				id = item.IdRec,
				nkod = item.Nkod,
				status = item.Status
			}).ToList();
		}

		#endregion

		#region private demontazj

		private List<DemPayments> convertFirmaPaymentsDTO2DemPayments(string pIdUser, int iddog, List<FirmaPaymentDTO> data)
		{
			return data
					.Where (x=> x.id != null)
					.Select(item => new DemPayments
						{
							IdFirmaDm = iddog,
							IdPay = Int32.Parse(item.id),
							SumaBezDds = item.sumabezdds,
							SumaSDds = item.sumasdds
						})
					.ToList();
		}

		private List<DemDgvOlduredi> convertFirmaUrediDTO2DemDgvUredi(string pIdUser, int iddog, List<FirmaUrediDTO> data)
		{
			return data
				.Select (item => new DemDgvOlduredi
						{
							IdFirmaDm = iddog,
							IdKn = Int16.Parse(item.idured),
							EdCena = item.edcena,
							Broi = item.broi,
							StatusDs = item.statusU,
							Status = item.status,
							Koga = DateTime.Now,
							User = pIdUser
						})
				.ToList();
		}

		private List<FirmaUrediDTO> convertDeMonDgvUrediToFirmaUrediDTO(List<DemDgvOlduredi> data)
		{
			return data.Select(item => new FirmaUrediDTO
			{

				iddog = (int)item.IdFirmaDm,
				idured = item.IdKn.ToString(),
				edcena = item.EdCena,
				broi = item.Broi,
				total = item.EdCena * item.Broi,
				statusU = item.StatusDs,
				status = item.Status
			}).ToList();
		}
		
		private List<FirmaPaymentDTO> convertDeMonPaymentsToFirmaPaymenDTO(List<DemPayments> data)
		{
			return data.Select(item => new FirmaPaymentDTO
			{
				idfirmamn = (int)item.IdFirmaDm,
				id = item.IdPay.ToString(),
				sumabezdds = item.SumaBezDds,
				sumasdds = item.SumaSDds
			}).ToList();
		}

        #endregion
    }
}
