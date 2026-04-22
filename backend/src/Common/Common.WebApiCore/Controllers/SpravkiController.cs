using Common.DTO;
using Common.DTO.Spravki;
using Common.Services.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Novacode;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Common.WebApiCore.Controllers
{
    [Route("spravki")]
    public class SpravkiController : BaseApiController
    {

        protected readonly ISpravkiService spravkiService;
        protected readonly IHostingEnvironment _hostingEnvironment;

        public SpravkiController(ISpravkiService spravkiService)
        {
            this.spravkiService = spravkiService;
        }


        [HttpGet]
        [Route("getspravki")]
        [AllowAnonymous]
        public async Task<IActionResult> GetSpravki(int pFaza)
        {
            var data = await spravkiService.GetSpravki(pFaza);
            return Ok(data);
        }

        [HttpPost]
        [Route("getspravka1")]
        [AllowAnonymous]
        public async Task<IActionResult> GetSpravka1(Filter1DTO filter)
        {
            var data = await spravkiService.GetSpravka1(filter);
            return Ok(data);
        }

        [HttpPost]
        [Route("getspravka2")]
        [AllowAnonymous]
        public async Task<IActionResult> GetSpravka2(int type, FilterDTO filter)
        {
            var data = await spravkiService.GetSpravka2(type, filter);
            return Ok(data);
        }

        [HttpPost]
        [Route("getspravka4")]
        [AllowAnonymous]
        public async Task<IActionResult> GetSpravka4(FilterDTO filter)
        {
            var data = await spravkiService.GetSpravka4(filter);
            return Ok(data);
        }

        [HttpPost]
        [Route("getspravka5")]
        [AllowAnonymous]
        public async Task<IActionResult> GetSpravka5(FilterDTO filter)
        {
            var data = await spravkiService.GetSpravka5(filter);
            return Ok(data);
        }

        [HttpPost]
        [Route("getspravka6")]
        [AllowAnonymous]
        public async Task<IActionResult> GetSpravka6(FilterDTO filter)
        {
            var data = await spravkiService.GetSpravka6(filter);
            return Ok(data);
        }

        [HttpPost]
        [Route("getspravka7")]
        [AllowAnonymous]
        public async Task<IActionResult> GetSpravka7(FilterDTO filter)
        {
            var data = await spravkiService.GetSpravka7(filter);
            return Ok(data);
        }

        [HttpPost]
        [Route("getspravka8")]
        [AllowAnonymous]
        public async Task<IActionResult> GetSpravka8(FilterDTO filter)
        {
            var data = await spravkiService.GetSpravka8(filter);
            return Ok(data);
        }

        [HttpPost]
        [Route("getspravka9")]
        [AllowAnonymous]
        public async Task<IActionResult> GetSpravka9(FilterDTO filter)
        {
            var data = await spravkiService.GetSpravka9(filter);
            return Ok(data);
        }

        [HttpPost]
        [Route("getspravka10")]
        [AllowAnonymous]
        public async Task<IActionResult> GetSpravka10(FilterDTO filter)
        {
            var data = await spravkiService.GetSpravka10(filter);
            return Ok(data);
        }

        [HttpPost]
        [Route("getspravka11")]
        [AllowAnonymous]
        public async Task<IActionResult> GetSpravka11(FilterDTO filter)
        {
            var data = await spravkiService.GetSpravka11(filter);
            return Ok(data);
        }

        [HttpPost]
        [Route("getspravka12")]
        [AllowAnonymous]
        public async Task<IActionResult> GetSpravka12(FilterDTO filter)
        {
            var data = await spravkiService.GetSpravka12(filter);
            return Ok(data);
        }

        [HttpPost]
        [Route("getspravka13")]
        [AllowAnonymous]
        public async Task<IActionResult> GetSpravka13(FilterDTO filter)
        {
            var data = await spravkiService.GetSpravka13(filter);
            return Ok(data);
        }

        [HttpPost]
        [Route("getspravka14")]
        [AllowAnonymous]
        public async Task<IActionResult> GetSpravka14(FilterDTO filter)
        {
            var data = await spravkiService.GetSpravka14(filter);
            return Ok(data);
        }

        [HttpPost]
        [Route("getspravka15")]
        [AllowAnonymous]
        public async Task<IActionResult> GetSpravka15(FilterDTO filter)
        {
            var data = await spravkiService.GetSpravka15(filter);
            return Ok(data);
        }

        [HttpPost]
        [Route("getspravka23")]
        [AllowAnonymous]
        public async Task<IActionResult> GetSpravka23(FilterDTO filter)
        {
            var data = await spravkiService.GetSpravka23(filter);
            return Ok(data);
        }

        [HttpGet]
        [Route("getspravka24")]
        [AllowAnonymous]
        public async Task<IActionResult> GetSpravka24()
        {
            var data = await spravkiService.GetSpravka24();
            return Ok(data);
        }

        [HttpPost]
        [Route("getspravka20")]
        [AllowAnonymous]
        public async Task<IActionResult> GetSpravka20(FilterDTO filter)
        {
            var data = await spravkiService.GetSpravka20(filter);
            return Ok(data);
        }

        [HttpPost]
        [Route("getspravka21")]
        [AllowAnonymous]
        public async Task<IActionResult> GetSpravka21(FilterDTO filter)
        {
            var data = await spravkiService.GetSpravka21(filter);
            return Ok(data);
        }


        [HttpPost]
        [Route("getspravka25")]
        [AllowAnonymous]
        public async Task<IActionResult> GetSpravka25(FilterDTO filter)
        {
            var data = await spravkiService.GetSpravka25(filter);
            return Ok(data);
        }

        [HttpPost]
        [Route("getoposportret")]
        [AllowAnonymous]
        public async Task<IActionResult> GetOposPortret(FilterDTO filter)
        {
            var data = await spravkiService.GetOposPortret(filter);
            return Ok(data);
        }


        [HttpPost]
        [Route("getspravka50")]
        [AllowAnonymous]
        public async Task<IActionResult> GetSpravka50(FilterDTO filter)
        {
            var data = await spravkiService.GetSpravka50(filter);
            return Ok(data);
        }

        [HttpPost]
        [Route("getspravka51")]
        [AllowAnonymous]
        public async Task<IActionResult> GetSpravka51(FilterDTO filter)
        {
            var data = await spravkiService.GetSpravka51(filter);
            return Ok(data);
        }

        [HttpGet]
        [Route("getspravka52")]
        [AllowAnonymous]
        public async Task<IActionResult> GetSpravka52()
        {
            var data = await spravkiService.GetSpravka52();
            return Ok(data);
        }

        [HttpGet]
        [Route("getspravka53")]
        [AllowAnonymous]
        public async Task<IActionResult> GetSpravka53()
        {
            var data = await spravkiService.GetSpravka53();
            return Ok(data);
        }

        [HttpGet]
        [Route("getspravka54")]
        [AllowAnonymous]
        public async Task<IActionResult> GetSpravka54()
        {
            var data = await spravkiService.GetSpravka54();
            return Ok(data);
        }

        [HttpGet]
        [Route("getspravka55")]
        [AllowAnonymous]
        public async Task<IActionResult> GetSpravka55(int type)
        {
            var data = await spravkiService.GetSpravka55(type);
            return Ok(data);
        }

        [HttpGet]
        [Route("getspravka56")]
        [AllowAnonymous]
        public async Task<IActionResult> GetSpravka56()
        {
            var data = await spravkiService.GetSpravka56();
            return Ok(data);
        }

        [HttpPost]
        [Route("getspravka60")]
        [AllowAnonymous]
        public async Task<IActionResult> GetSpravka60(Filter1DTO filter)
        {
            var data = await spravkiService.GetSpravka60(filter);
            return Ok(data);
        }

        [HttpPost]
        [Route("getspravka61")]
        [AllowAnonymous]
        public async Task<IActionResult> GetSpravka61(Filter1DTO filter)
        {
            var data = await spravkiService.GetSpravka61(filter);
            return Ok(data);
        }

        [HttpPost]
        [Route("getspravka70")]
        [AllowAnonymous]
        public async Task<IActionResult> GetSpravka70(int tip,Filter1DTO filter)
        {
            var data = await spravkiService.GetSpravka70(tip,filter);
            return Ok(data);
        }

        [HttpPost]
        [Route("getspravka72")]
        [AllowAnonymous]
        public async Task<IActionResult> GetSpravka72(int tip, Filter1DTO filter)
        {
            var data = await spravkiService.GetSpravka72(tip, filter);
            return Ok(data);
        }

        [HttpPost]
        [Route("getspravka78")]
        [AllowAnonymous]
        public async Task<IActionResult> GetSpravka78(Filter1DTO filter)
        {
            var data = await spravkiService.GetSpravka78(filter);
            return Ok(data);
        }

        [HttpPost]
        [Route("getspravka79")]
        [AllowAnonymous]
        public async Task<IActionResult> GetSpravka79(Filter1DTO filter)
        {
            var data = await spravkiService.GetSpravka79(filter);
            return Ok(data);
        }

        [HttpGet]
        [Route("setporychkastatus")]
        [AllowAnonymous]
        public async Task<IActionResult> setPorychkaStatus(int idporychka, int status)
        {
            await spravkiService.setPorychkaStatus(idporychka, status);
            return Ok();
        }

        [HttpGet]
        [Route("setporychkaunsign")]
        [AllowAnonymous]
        public async Task<IActionResult> setPorychkaUnSign(int idporychka)
        {
            await spravkiService.setPorychkaUnSign(idporychka);
            return Ok();
        }
    }
}
