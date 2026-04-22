using Common.DTO.Firmi;
using Common.Services.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Common.WebApiCore.Controllers
{
    [Route("firmi")]
    public class FirmController : BaseApiController
    {
        protected readonly IFirmService firmService;

        public FirmController(IFirmService firmService)
        {
            this.firmService = firmService;
        }


        [HttpGet]
        [Route("getfirmi")]
        [AllowAnonymous]
        public async Task<IActionResult> GetFirmi(int faza, int rolq)
        {
            var data = await firmService.GetFirmi(faza, rolq);
            return Ok(data);
        }

        [HttpGet]
        [Route("getfirma")]
        [AllowAnonymous]
        public async Task<IActionResult> GetFirma(string eik)
        {
            var data = await firmService.GetFirma(eik);
            return Ok(data);
        }

        #region montaz
        [HttpGet]
        [Route("getfirmimontaz")]
        [AllowAnonymous]
        public async Task<IActionResult> GetFirmiMontaz(int pFaza)
        {
            var data = await firmService.GetFirmiMontaz(pFaza);
            return Ok(data);
        }

        [HttpGet]
        [Route("getmondogovor")]
        [AllowAnonymous]
        public async Task<IActionResult> GetMonDogovor(int iddog)
        {
            var data = await firmService.GetMonDogovor(iddog);
            return Ok(data);
        }

        [HttpPost]
        [Route("setmondogovor")]
        [AllowAnonymous]
        public async Task<IActionResult> SetMonDogovor(FirmaDogovorDTO item)
        {
            string iduser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var data = await firmService.SetMonDogovor(iduser, item);
            return Ok(data);
        }

        [HttpGet]
        [Route("getmondogovorifirma")]
        [AllowAnonymous]
        public async Task<IActionResult> GetMonDogovoriFirma(int idfirma)
        {
            var data = await firmService.GetMonDogovoriFirma(idfirma);
            return Ok(data);
        }

        [HttpGet]
        [Route("loadmongogovoruredi")]
        [AllowAnonymous]
        public async Task<IActionResult> loadMonDogovorUredi(int idgogovor)
        {
            var data = await firmService.loadMonDogovorUredi(idgogovor);
            return Ok(data);
        }


        [HttpGet]
        [Route("loadmondogovorporychki")]
        [AllowAnonymous]
        public async Task<IActionResult> loadMonDogovorPorychki(int iddogovor)
        {
            var data = await firmService.loadMonDogovorPorychki(iddogovor);
            return Ok(data);
        }
        #endregion

        #region demontaz
        [HttpGet]
        [Route("getfirmidemontaz")]
        [AllowAnonymous]
        public async Task<IActionResult> GetFirmiDeMontaz(int pFaza)
        {
            var data = await firmService.GetFirmiDeMontaz(pFaza);
            return Ok(data);
        }

        [HttpGet]
        [Route("getdemdogovor")]
        [AllowAnonymous]
        public async Task<IActionResult> GetDeMonDogovor(int iddog)
        {
            var data = await firmService.GetDeMonDogovor(iddog);
            return Ok(data);
        }

        [HttpPost]
        [Route("setdemdogovor")]
        [AllowAnonymous]
        public async Task<IActionResult> SetDeMonDogovor(FirmaDogovorDTO item)
        {
            string iduser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var data = await firmService.SetDeMonDogovor(iduser, item);
            return Ok(data);
        }

        [HttpGet]
        [Route("getdemondogovorifirma")]
        [AllowAnonymous]
        public async Task<IActionResult> GetDeMonDogovoriFirma(int idfirma)
        {
            var data = await firmService.GetDeMonDogovoriFirma(idfirma);
            return Ok(data);
        }

        [HttpGet]
        [Route("loaddemongogovoruredi")]
        [AllowAnonymous]
        public async Task<IActionResult> loadDeMonDogovorUredi(int idgogovor)
        {
            var data = await firmService.loadDeMonDogovorUredi(idgogovor);
            return Ok(data);
        }

        #endregion


    }
}
