using Common.DTO;
using Common.DTO.Nomenclature;
using Common.Services.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Common.WebApiCore.Controllers
{
    [Route("nomenclatures")]
    public class NomenclaturesController : BaseApiController
    {
        protected readonly INomenclatureService nomenclatureService;

        public NomenclaturesController(INomenclatureService nomenclatureService)
        {
            this.nomenclatureService = nomenclatureService;
        }

        [HttpGet]
        [Route("getnomenclatures")]
        [AllowAnonymous]
        public async Task<IActionResult> GetNomenclatures(int pFaza)
        {
            var data = await nomenclatureService.GetNomenclatures(pFaza);
            return Ok(data);
        }

#region nomobshti

        [HttpGet]
        [Route("getnomobshti")]
        [AllowAnonymous]
        public async Task<IActionResult> GetNomObshti(string pKod, int pFaza, bool includeDeleted = false)
        {
            var data = await nomenclatureService.GetNomObshti(pKod, pFaza, includeDeleted);
            return Ok(data);
        }

        [HttpGet]
        [Route("getrownomobshti")]
        [AllowAnonymous]
        public async Task<IActionResult> GetRowFormNomObshti(int id)
        {
            var data = await nomenclatureService.GetRowFormNomObshti(id);
            return Ok(data);
        }

        [HttpPost]
        [Route("addrownomobshti")]
        [AllowAnonymous]
        public async Task<IActionResult> AddRowFormNomObshti(NomObshtiDTO item)
        {
            var data = await nomenclatureService.AddRowFormNomObshti(item);
            return Ok(data);
        }

        [HttpPost]
        [Route("setrownomobshti")]
        [AllowAnonymous]
        public async Task<IActionResult> SetRowFormNomObshti(NomObshtiDTO item)
        {
            var data = await nomenclatureService.SetRowFormNomObshti(item);
            return Ok(data);
        }

        [HttpGet]
        [Route("delrownomobshti")]
        [AllowAnonymous]
        public async Task<IActionResult> DelRowFormNomObshti(int id)
        {
            var data = await nomenclatureService.DelRowFormNomObshti(id);
            return Ok(data);
        }
        #endregion nomobshti


        #region nomjk

        //n_jk
        [HttpGet]
        [Route("getnomjk")]
        [AllowAnonymous]
        public async Task<IActionResult> getNomenJk(int pFaza, bool includeDeleted = false)
        {
            var data = await nomenclatureService.getNomenJk(pFaza, includeDeleted);
            return Ok(data);
        }

        [HttpGet]
        [Route("getrownomjk")]
        [AllowAnonymous]
        public async Task<IActionResult> getRowNomenJk(string pKod)
        {
            var data = await nomenclatureService.getRowNomenJk(pKod);
            return Ok(data);
        }

      
        [HttpPost]
        [Route("setrownomjk")]
        [AllowAnonymous]
        public async Task<IActionResult> SetRowNomenJk(NomJkDTO item)
        {
            var data = await nomenclatureService.SetRowNomenJk(item);
            return Ok(data);
        }

        [HttpPost]
        [Route("addrownomjk")]
        [AllowAnonymous]
        public async Task<IActionResult> AddRowNomenJk(NomJkDTO item)
        {
            var data = await nomenclatureService.AddRowNomenJk(item);
            return Ok(data);
        }

        [HttpGet]
        [Route("delrownomjk")]
        [AllowAnonymous]
        public async Task<IActionResult> DelRowNomenJk(string id)
        {
            var data = await nomenclatureService.DelRowNomenJk(id);
            return Ok(data);
        }
        
        [HttpGet]
        [Route("getmaxkodjk")]
        [Produces("application/json")]
        [AllowAnonymous]
        public async Task<IActionResult> getMaxKodJk()
        {
            var data = await nomenclatureService.getMaxKodJk();
            return Ok(data);
        }
        #endregion nomjk


        #region n_kmetstva
        //n_kmetstva
        [HttpGet]
        [Route("getnomkmetstva")]
        [AllowAnonymous]
        public async Task<IActionResult> getNomenKmetstva(int pFaza, bool includeDeleted = false) {
            var data = await nomenclatureService.getNomenKmetstva(pFaza, includeDeleted);
            return Ok(data);
        }


        [HttpGet]
        [Route("getrownomkmetstva")]
        [AllowAnonymous]
        public async Task<IActionResult> getRowNomenKmetstva(string pKod) {
            var data = await nomenclatureService.getRowNomenKmetstva(pKod);
            return Ok(data);
        }

        [HttpPost]
        [Route("setnomkmetstva")]
        [AllowAnonymous]
        public async Task<IActionResult> SetRowNomenKmetstva(NomKmetstvoDTO item)
        {
            var data = await nomenclatureService.SetRowNomenKmetstva(item);
            return Ok(data);
        }

        [HttpPost]
        [Route("addnomkmetstva")]
        [AllowAnonymous]
        public async Task<IActionResult> AddRowNomenKmetstva(NomKmetstvoDTO item)
        {
            var data = await nomenclatureService.AddRowNomenKmetstva(item);
            return Ok(data);
        }

        [HttpGet]
        [Route("delnomkmetstva")]
        [AllowAnonymous]
        public async Task<IActionResult> DelRowNomenKmetstva(string id)
        {
            var data = await nomenclatureService.DelRowNomenKmetstva(id);
            return Ok(data);
        }

        #endregion n_kmetstva


        #region n_ulici
        [HttpGet]
        [Route("getnomulici")]
        [AllowAnonymous]
        public async Task<IActionResult> getNomenUlici(int pFaza, bool includeDeleted = false)
        {
            var data = await nomenclatureService.getNomenUlici(pFaza, includeDeleted);
            return Ok(data);
        }


        [HttpGet]
        [Route("getrownomulici")]
        [AllowAnonymous]
        public async Task<IActionResult> getRowNomenUlici(string pKod)
        {
            var data = await nomenclatureService.getRowNomenUlici(pKod);
            return Ok(data);
        }

        [HttpPost]
        [Route("setrownomulici")]
        [AllowAnonymous]
        public async Task<IActionResult> SetRowNomenUlici(NomUlicaDTO item)
        {
            var data = await nomenclatureService.SetRowNomenUlici(item);
            return Ok(data);
        }

        [HttpPost]
        [Route("addrownomulici")]
        [AllowAnonymous]
        public async Task<IActionResult> AddRowNomenUlici(NomUlicaDTO item)
        {
            var data = await nomenclatureService.AddRowNomenUlici(item);
            return Ok(data);
        }

        [HttpGet]
        [Route("delrownomulici")]
        [AllowAnonymous]
        public async Task<IActionResult> DelRowNomenUlici(string id)
        {
            var data = await nomenclatureService.DelRowNomenUlici(id);
            return Ok(data);
        }
  
        [HttpGet]
        [Route("getulicipernsmqsto")]
        [AllowAnonymous]
        public async Task<IActionResult> getUliciPerNsMqsto(string nkod)
        {
            var data = await nomenclatureService.getUliciPerNsMqsto(nkod);
            return Ok(data);
        }

        
        [HttpGet]
        [Route("getmaxkodulici")]
        [Produces("application/json")]
        [AllowAnonymous]
        public async Task<IActionResult> getMaxKodUlici()
        {
            var data = await nomenclatureService.getMaxKodUlici();
            return Ok(data);
        }


        #endregion n_ulici


        #region n_nasmesta
        [HttpGet]
        [Route("getnomnsmesta")]
        [AllowAnonymous]
        public async Task<IActionResult> getNomenNsMesta(int pFaza, bool includeDeleted = false)
        {
            var data = await nomenclatureService.getNomenNsMesta(pFaza, includeDeleted);
            return Ok(data);
        }


        [HttpGet]
        [Route("getrownomnsmesta")]
        [AllowAnonymous]
        public async Task<IActionResult> getRowNomenNsMesta(string pKod)
        {
            var data = await nomenclatureService.getRowNomenNsMesta(pKod);
            return Ok(data);
        }

        [HttpPost]
        [Route("setrownomnsmesta")]
        [AllowAnonymous]
        public async Task<IActionResult> SetRowNomenNsMesta(NomNsMqstoDTO item)
        {
            var data = await nomenclatureService.SetRowNomenNsMesta(item);
            return Ok(data);
        }

        [HttpPost]
        [Route("addrownomnsmesta")]
        [AllowAnonymous]
        public async Task<IActionResult> AddRowNomenNsMesta(NomNsMqstoDTO item)
        {
            var data = await nomenclatureService.AddRowNomenNsMesta(item);
            return Ok(data);
        }

        [HttpGet]
        [Route("delrownomnsmesta")]
        [AllowAnonymous]
        public async Task<IActionResult> DelRowNomenNsMesta(string id)
        {
            var data = await nomenclatureService.DelRowNomenNsMesta(id);
            return Ok(data);
        }

        [HttpGet]
        [Route("getnomnsmestabyraion")]
        [AllowAnonymous]
        public async Task<IActionResult> getNomenNsMestaByRaion(string pRaion)
        {
            var data = await nomenclatureService.getNomenNsMestaByRaion(pRaion);
            return Ok(data);
        }

        #endregion n_nasmesta


        #region n_raioni
        [HttpGet]
        [Route("getnomraioni")]
        [AllowAnonymous]
        public async Task<IActionResult> getNomenRaioni(int pFaza, bool includeDeleted = false)
        {
            var data = await nomenclatureService.getNomenRaioni(pFaza, includeDeleted);
            return Ok(data);
        }


        [HttpGet]
        [Route("getrownomraioni")]
        [AllowAnonymous]
        public async Task<IActionResult> getRowNomenRaioni(string pKod)
        {
            var data = await nomenclatureService.getRowNomenRaioni(pKod);
            return Ok(data);
        }

        [HttpPost]
        [Route("setrownomraioni")]
        [AllowAnonymous]
        public async Task<IActionResult> SetRowNomenRaioni(NomRaionDTO item)
        {
            var data = await nomenclatureService.SetRowNomenRaioni(item);
            return Ok(data);
        }

        [HttpPost]
        [Route("addrownomraioni")]
        [AllowAnonymous]
        public async Task<IActionResult> AddRowNomenRaioni(NomRaionDTO item)
        {
            var data = await nomenclatureService.AddRowNomenRaioni(item);
            return Ok(data);
        }

        [HttpGet]
        [Route("delrownomraioni")]
        [AllowAnonymous]
        public async Task<IActionResult> DelRowNomenRaioni(string id)
        {
            var data = await nomenclatureService.DelRowNomenRaioni(id);
            return Ok(data);
        }

        #endregion n_raioni


        #region n_uredi
        [HttpGet]
        [Route("getnomuredi")]
        [AllowAnonymous]
        public async Task<IActionResult> getNomenUredi(int pFaza, bool includeDeleted = false)
        {
            var data = await nomenclatureService.getNomenUredi(pFaza, includeDeleted);
            return Ok(data);
        }

        [HttpGet]
        [Route("getrownomuredi")]
        [AllowAnonymous]
        public async Task<IActionResult> getRowNomenUredi(int id)
        {
            var data = await nomenclatureService.getRowNomenUredi(id);
            return Ok(data);
        }

        [HttpPost]
        [Route("setrownomuredi")]
        [AllowAnonymous]
        public async Task<IActionResult> SetRowNomenUredi(NomUrediDTO item)
        {
            var data = await nomenclatureService.SetRowNomenUredi(item);
            return Ok(data);
        }

        [HttpPost]
        [Route("addrownomuredi")]
        [AllowAnonymous]
        public async Task<IActionResult> AddRowNomenUredi(NomUrediDTO item)
        {
            var data = await nomenclatureService.AddRowNomenUredi(item);
            return Ok(data);
        }

        [HttpGet]
        [Route("delrownomuredi")]
        [AllowAnonymous]
        public async Task<IActionResult> DelRowNomenUredi(int id)
        {
            var data = await nomenclatureService.DelRowNomenUredi(id);
            return Ok(data);
        }

        [HttpGet]
        [Route("getnomkolektivuredi")]
        [AllowAnonymous]
        public async Task<IActionResult> getKolektivNomenUredi(int pFaza)
        {
            var data = await nomenclatureService.getKolektivNomenUredi(pFaza);
            return Ok(data);
        }

        #endregion n_uredi

        #region statusi     
        [HttpGet]
        [Route("getnomstatusi")]
        [AllowAnonymous]
        public async Task<IActionResult> GetNomStatusi(string type)
        {
            var data = await nomenclatureService.GetNomStatusi(type);
            return Ok(data);
        }

        #endregion

        #region nkid     
        [HttpGet]
        [Route("getnomkid")]
        [AllowAnonymous]
        public async Task<IActionResult> GetNomKID()
        {
            var data = await nomenclatureService.GetNomKid();
            return Ok(data);
        }

        #endregion

        #region extra adresi
        [HttpGet]
        [Route("getallextraaddresses")]
        [AllowAnonymous]
        public async Task<IActionResult> getAllExtraAddresses()
        {
            var data = await nomenclatureService.getAllExtraAddresses();
            return Ok(data);
        }

        [HttpGet]
        [Route("delextraaddress")]
        [AllowAnonymous]
        public async Task<IActionResult> delExtraAddress(int id)
        {
            var data = await nomenclatureService.delExtraAddress(id);
            return Ok(data);
        }

        [HttpPost]
        [Route("addrowextraaddress")]
        [AllowAnonymous]
        public async Task<IActionResult> addRowExtraAddress(ExtraAddrDTO item)
        {
            var data = await nomenclatureService.addRowExtraAddress(item);
            return Ok(data);
        }

        [HttpPost]
        [Route("setrowextraaddress")]
        [AllowAnonymous]
        public async Task<IActionResult> setRowExtraAddress(ExtraAddrDTO item)
        {
            var data = await nomenclatureService.setRowExtraAddress(item);
            return Ok(data);
        }

        [HttpGet]
        [Route("getrowextraaddress")]
        [AllowAnonymous]
        public async Task<IActionResult> getRowExtraAddress(int id)
        {
            var data = await nomenclatureService.getRowExtraAddress(id);
            return Ok(data);
        }
        #endregion


        #region n_uredi_budget
        [HttpGet]
        [Route("getallnomenuredibudget")]
        [AllowAnonymous]
        public async Task<IActionResult> getAllNomenUrediBudget(int pFaza,bool includeDeleted)
        {
            var data = await nomenclatureService.getAllNomenUrediBudget(pFaza,includeDeleted);
            return Ok(data);
        }

        [HttpGet]
        [Route("getrownomenbudgeturedi")]
        [AllowAnonymous]
        public async Task<IActionResult> getRowNomenBudgetUredi(int id)
        {
            var data = await nomenclatureService.getRowNomenBudgetUredi(id);
            return Ok(data);
        }


        [HttpPost]
        [Route("setrownomenbudgeturedi")]
        [AllowAnonymous]
        public async Task<IActionResult> setRowNomenBudgetUredi(NomUredBudgetDTO item) {
            var data = await nomenclatureService.setRowNomenBudgetUredi(item);
            return Ok(data);
        }
        #endregion
    }
}
