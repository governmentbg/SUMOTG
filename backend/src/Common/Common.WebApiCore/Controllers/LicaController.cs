using Common.DTO;
using Common.DTO.Lica;
using Common.Services.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Novacode;
using System;
using System.IO;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Common.WebApiCore.Controllers
{
    [Route("lica")]
    public class LicaController : BaseApiController
    {
        protected readonly ILicaService licaService;
        protected readonly IWebHostEnvironment environment;

        public LicaController(ILicaService licaService, IWebHostEnvironment environment)
        {
            this.licaService = licaService;
            this.environment = environment;
        }


        #region lica
        [HttpGet]
        [Route("getlice")]
        [AllowAnonymous]
        public async Task<IActionResult> GetLice(int id)
        {
            var data = await licaService.GetLice(id);
            return Ok(data);
        }

        [HttpPost]
        [Route("setlice")]
        [AllowAnonymous]
        public async Task<IActionResult> SetLice(LiceDTO item)
        {
            string iduser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var data = await licaService.SetLice(iduser, item);
            return Ok(data);
        }

        
        [HttpPost]
        [Route("setchlen")]
        [AllowAnonymous]
        public async Task<IActionResult> SetChlen(LiceDTO item)
        {
            string iduser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await licaService.SetChlen(iduser, item);
            return Ok();
        }

        [HttpPost]
        [Route("getpersons")]
        [AllowAnonymous]
        public async Task<IActionResult> GetPersons(FilterDTO filter)
        {
            string iduser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var data = await licaService.GetPersons(filter, iduser);
            return Ok(data);
        }

        [HttpPost]
        [Route("getdogovorpersons")]
        [AllowAnonymous]
        public async Task<IActionResult> GetDogovorPersons(FilterDTO filter)
        {
            string iduser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var data = await licaService.GetDogovorPersons(filter, iduser);
            return Ok(data);
        }


        [HttpGet]
        [Route("getlicedogovor")]
        [AllowAnonymous]
        public async Task<IActionResult> GetLiceDogovor(int id)
        {
            var data = await licaService.GetLiceDogovor(id);
            return Ok(data);
        }

        [HttpPost]
        [Route("setlicedogovor")]
        [AllowAnonymous]
        public async Task<IActionResult> SetLiceDogovor(LiceDogovorDTO item)
        {
            string iduser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var data = await licaService.SetLiceDogovor(iduser, item);
            return Ok(data);
        }

        
        [HttpGet]
        [Route("setlicedogovorstatus")]
        [AllowAnonymous]
        public async Task<IActionResult> SetLiceDogovorStatus(int iddog, int status)
        {
            string iduser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var data = await licaService.SetLiceDogovorStatus(iduser, iddog, status);
            return Ok(data);
        }

        
        [HttpGet]
        [Route("setlicedogovorexpired")]
        [AllowAnonymous]
        public async Task<IActionResult> setLiceDogovorExpired(int iddog)
        {
            string iduser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var data = await licaService.setLiceDogovorExpired(iduser, iddog);
            return Ok(data);
        }

        [HttpGet]
        [Route("changelicetitulqr")]
        [AllowAnonymous]
        public async Task<IActionResult> changeLiceTitulqr(int idlice, int statuslice)
        {
            string iduser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var data = await licaService.changeLiceTitulqr(iduser, idlice, statuslice);
            return Ok(data);
        }

        [HttpPost]
        [Route("addtitulqr")]
        [AllowAnonymous]
        public async Task<IActionResult> AddTitular(int oldidlice, int oldstatus, LiceDTO item)
        {
            string iduser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await licaService.changeLiceTitulqr(iduser, oldidlice, oldstatus);
            var data = await licaService.SetTitulqr(iduser, item.idl, item, true);
            return Ok(data);
        }


        [HttpGet]
        [Route("getlicedogovorstatus")]
        [AllowAnonymous]
        public async Task<IActionResult> GetLiceDogovorStatus(int id)
        {
            var data = await licaService.GetLiceDogovorStatus(id);
            return Ok(data);
        }
        
        [HttpGet]
        [Route("updoposdogovornomer")]
        [AllowAnonymous]
        public async Task<IActionResult> updOposDogovorNomer(string nomer, string data, string otnosno)
        {
            var rez = await licaService.updOposDogovorNomer(nomer, data, otnosno);
            return Ok(rez);
        }

        #endregion


        #region formulqr
        [HttpPost]
        [Route("getlistformulqrs")]
        [AllowAnonymous]
        public async Task<IActionResult> GetListFormulqrs(int pVid, FilterDTO filter)
        {
            string iduser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var data = await licaService.GetListFormulqrs(pVid, filter, iduser);
            return Ok(data);
        }

        
        [HttpGet]
        [Route("getformulqr")]
        [AllowAnonymous]
        public async Task<IActionResult> GetFormulqr(int id)
        {
            var data = await licaService.GetFormulqr(id);
            return Ok(data);
        }

        [HttpPost]
        [Route("addformulqr")]
        public async Task<IActionResult> AddFormulqr(FormulqrDTO item)
        {
            if (item.idformulqr != 0)
            {
                return BadRequest();
            }

            string iduser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await licaService.AddFormulqr(iduser, item);
            return Ok(result);
        }

        [HttpPost]
        [Route("setformulqr")]
        public async Task<IActionResult> SetFormulqr(FormulqrDTO item)
        {

            string iduser = User.FindFirstValue(ClaimTypes.NameIdentifier); 

            var result = await licaService.SetFormulqr(iduser, item);
            return Ok(result);
        }
        #endregion

        #region firma
        [HttpGet]
        [Route("getfirma")]
        [AllowAnonymous]
        public async Task<IActionResult> GetFirma(int id)
        {
            var data = await licaService.GetFirma(id);
            return Ok(data);
        }
        [HttpPost]
        [Route("getfirms")]
        [AllowAnonymous]
        public async Task<IActionResult> GetFirms(FilterDTO filter)
        {
            string iduser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var data = await licaService.GetFirms(filter, iduser);
            return Ok(data);
        }

        [HttpPost]
        [Route("setfirma")]
        [AllowAnonymous]
        public async Task<IActionResult> SetFirma(FirmaDTO item)
        {
            string iduser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var data = await licaService.SetFirma(iduser, item);
            return Ok(data);
        }
        
        [HttpGet]
        [Route("gethistoryformulqr")]
        [AllowAnonymous]
        public async Task<IActionResult> getHistoryFormulqr(int id)
        {
            var data = await licaService.getHistoryFormulqr(id);
            return Ok(data);
        }

        [HttpGet]
        [Route("setformulqrstatus")]
        [AllowAnonymous]
        public async Task<IActionResult> setFormulqrStatus(int idformulqr, int status)
        {
            string iduser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var data = await licaService.setFormulqrStatus(iduser, idformulqr, status);
            return Ok(data);
        }

        
        [HttpGet]
        [Route("checkformulqrunomer")]
        [AllowAnonymous]
        public async Task<IActionResult> checkFormulqrUnomer(string unomer, int faza)
        {
            var data = await licaService.checkFormulqrUnomer(unomer, faza);
            return Ok(data);
        }

        [HttpPost]
        [Route("checkformulqradres")]
        [AllowAnonymous]
        public async Task<IActionResult> checkFormulqrAdres(AdresDTO adres)
        {
            var data = await licaService.checkFormulqrAdres(adres);
            return Ok(data);
        }
        #endregion

        #region dokumenti
        [HttpGet("gendogovorfile")]
        [AllowAnonymous]
        public async Task<IActionResult> GenDogovorFile(int id)
        {

            string wwwPath = this.environment.WebRootPath;

            var item = await licaService.getDogovorData(id);

            //string filePath = @"e:\DogovorIndividualen.docx";
            string filePath; 
            if (item.v_lice == 3)
                filePath = Path.Combine(wwwPath, "templates", "Dogovor-ЮЛ.docx");
            else
                filePath  = Path.Combine(wwwPath, "templates","DogovorIndividualen.docx");
            
            if (!System.IO.File.Exists(filePath))
                return NotFound();


            var persdoc = DocX.Load(filePath);
            persdoc.ReplaceText("/lica_unom/", item.unom);
            persdoc.ReplaceText("/lica_fullname/", item.ime);
            persdoc.ReplaceText("/lica_egn/", item.ident);
            persdoc.ReplaceText("/lica_adres/", !String.IsNullOrEmpty(item.adres) ? item.adres : "");
            persdoc.ReplaceText("/lica_urbezrad/", !String.IsNullOrEmpty(item.txturedi) ? item.txturedi:"");
            persdoc.ReplaceText("/lica_rad/", !String.IsNullOrEmpty(item.txtrad) ? item.txtrad : "");
            persdoc.ReplaceText("/lica_durirad/", !String.IsNullOrEmpty(item.txtolduredi) ? item.txtolduredi : "");            
            persdoc.ReplaceText("/lica_vidimot/", !String.IsNullOrEmpty(item.vidimot) ? item.vidimot : "");
            persdoc.ReplaceText("/lica_regnomer/", !String.IsNullOrEmpty(item.regnomer) ? item.regnomer : "");
            persdoc.ReplaceText("/lica_regdate/", !String.IsNullOrEmpty(item.regdate) ? item.regdate : "");
            persdoc.ReplaceText("/lica_nomlk/", !String.IsNullOrEmpty(item.nomlk) ? item.nomlk : "");
            persdoc.ReplaceText("/lica_datalk/", !String.IsNullOrEmpty(item.datalk) ? item.datalk : "...............");

            persdoc.ReplaceText("/f_ime/", !String.IsNullOrEmpty(item.f_ime) ? item.f_ime : "");
            persdoc.ReplaceText("/f_eik/", !String.IsNullOrEmpty(item.f_eik) ? item.f_eik : "");
            persdoc.ReplaceText("/f_adres/", !String.IsNullOrEmpty(item.f_Adres) ? item.f_Adres : "");


            var guid = Guid.NewGuid();
            filePath = Path.Combine(this.environment.WebRootPath, guid.ToString() + ".docx");
            persdoc.SaveAs(filePath);

            persdoc = DocX.Load(filePath);
            MemoryStream inMemoryCopy = new MemoryStream();
            FileStream fs = new FileStream(filePath, FileMode.Open);
            fs.CopyTo(inMemoryCopy);
            fs.Close();

            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }

            inMemoryCopy.Position = 0;
            return File(inMemoryCopy
                , "application/word"
                , guid.ToString());
        }

        
        [HttpGet("getdogovoraddpages")]
        [AllowAnonymous]
        public async Task<IActionResult> getDogovorAddPages()
        {
            string wwwPath = this.environment.WebRootPath;

            //string filePath = @"e:\DogovorIndividualen.docx";
            string filePath = Path.Combine(wwwPath, "templates", "ДОГОВОР-Лице-СТР 3-6.docx");

            if (!System.IO.File.Exists(filePath))
                return NotFound();

            var persdoc = DocX.Load(filePath);
            var guid = Guid.NewGuid();
            filePath = Path.Combine(this.environment.WebRootPath, guid.ToString() + ".docx");
            persdoc.SaveAs(filePath);

            persdoc = DocX.Load(filePath);
            MemoryStream inMemoryCopy = new MemoryStream();
            FileStream fs = new FileStream(filePath, FileMode.Open);
            fs.CopyTo(inMemoryCopy);
            fs.Close();

            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }

            inMemoryCopy.Position = 0;
            return File(inMemoryCopy
                , "application/word"
                , guid.ToString());
        }
        #endregion

        [HttpPost]
        [Route("getradiatorizaprekodirane")]
        [AllowAnonymous]
        public async Task<IActionResult> getRadiatoriZaPrekodirane(FilterDTO flt)
        {
            var rez = await licaService.getRadiatoriZaPrekodirane(flt);
            return Ok(rez);
        }

        [HttpGet]
        [Route("doprekodiraneradiatori")]
        [AllowAnonymous]
        public async Task<IActionResult> doPrekodiraneRadiatori(int iddog)
        {
            string iduser = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var rez = await licaService.doPrekodiraneRadiatori(iddog, iduser);
            return Ok(rez);
        }

        [HttpGet]
        [Route("getaddress")]
        [AllowAnonymous]
        public async Task<IActionResult> getAddress(int id)
        {
            var rez = await licaService.getAddress(id);
            return Ok(rez);
        }

        [HttpPost]
        [Route("setaddress")]
        [AllowAnonymous]
        public async Task<IActionResult> setAddress(AdresDTO item)
        {
            var rez = await licaService.setAddress(item);
            return Ok(rez);
        }

    }
}
