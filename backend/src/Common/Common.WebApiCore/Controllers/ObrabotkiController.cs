using Common.DTO;
using Common.DTO.Obrabotki;
using Common.Services.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Common.WebApiCore.Controllers
{
    [Route("obrabotki")]
    public class ObrabotkiController : BaseApiController
    {
        protected readonly IObrabotkiService obrabotkiService;
        protected readonly IWebHostEnvironment environment;

        public ObrabotkiController(IWebHostEnvironment environment, IObrabotkiService obrabotkiService)
        {
            this.environment = environment;
            this.obrabotkiService = obrabotkiService;
        }

        #region porychki montazj
        [HttpGet]
        [Route("getmonorder")]
        [AllowAnonymous]
        public async Task<IActionResult> GetMonOrder(int id)
        {
            var data = await obrabotkiService.GetMonOrder(id);
            return Ok(data);
        }

        [HttpGet]
        [Route("getdogovorfirmauredi")]
        [AllowAnonymous]
        public async Task<IActionResult> getDogovorFirmaUredi(int iddogovorfirma)
        {
            var data = await obrabotkiService.getDogovorFirmaUredi(iddogovorfirma);
            return Ok(data);
        }


        [HttpGet]
        [Route("getdogovorfirmaraioni")]
        [AllowAnonymous]
        public async Task<IActionResult> getDogovorFirmaRaioni(int iddogovorfirma)
        {
            var data = await obrabotkiService.getDogovorFirmaRaioni(iddogovorfirma);
            return Ok(data);
        }

        [HttpGet]
        [Route("getpersonswithdoguredi")]
        [AllowAnonymous]
        public async Task<IActionResult> getPersonsWihtDogUredi(int iddogovorfirma, string raion, int faza)
        {
            var data = await obrabotkiService.getPersonsWihtDogUredi(iddogovorfirma, raion, faza);
            return Ok(data);
        }

        [HttpGet]
        [Route("getpersonuredi")]
        [AllowAnonymous]
        public async Task<IActionResult> getPersonUredi(int iddogovorfirma, int idlice)
        {
            var data = await obrabotkiService.getPersonUredi(iddogovorfirma, idlice);
            return Ok(data);
        }

        [HttpPost]
        [Route("setmonorder")]
        [AllowAnonymous]
        public async Task<IActionResult> setMonOrder(OrderDTO item)
        {
            string iduser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var data = await obrabotkiService.setMonOrder(iduser, item);
            return Ok(data);
        }


        [HttpPost]
        [Route("setmonuredidogovor")]
        [AllowAnonymous]
        public async Task<IActionResult> setMonUrediDogovor(List<UrediDogovorDTO> items)
        {
            string iduser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var data = await obrabotkiService.SetMonUrediDogovor(iduser, items);
            return Ok(data);
        }


        [HttpGet]
        [Route("getmonlistorders")]
        [AllowAnonymous]
        public async Task<IActionResult> getMonListOrders(int faza)
        {
            var data = await obrabotkiService.getMonListOrders(faza);
            return Ok(data);
        }

        [HttpGet]
        [Route("delmonuredidogovor")]
        [AllowAnonymous]
        public async Task<IActionResult> delMonUrediDogovor(int idporychkamain, int idlicedogovor)
        {
            int data = await obrabotkiService.DelMonUrediDogovor(idporychkamain, idlicedogovor);
            return Ok(data);
        }

        [HttpGet]
        [Route("delmonorder")]
        [AllowAnonymous]
        public async Task<IActionResult> DelMonOrder(int idporychkamain)
        {
            var data = await obrabotkiService.DelMonOrder(idporychkamain);
            return Ok(data);
        }

        [HttpGet]
        [Route("getmonorderswithoutdemporychka")]
        [AllowAnonymous]
        public async Task<IActionResult> getMonOrdersWithoutDemPorychka()
        {
            var data = await obrabotkiService.getMonOrdersWithoutDemPorychka();
            return Ok(data);
        }


        [HttpGet]
        [Route("candeletemonorder")]
        [AllowAnonymous]
        public async Task<IActionResult> canDeleteMonOrder(int idporychkamain)
        {
            var data = await obrabotkiService.canDeleteMonOrder(idporychkamain);
            return Ok(data);
        }
        #endregion


        #region demontazj
        [HttpGet]
        [Route("getdemonorder")]
        [AllowAnonymous]
        public async Task<IActionResult> GetDemonOrder(int id)
        {
            var data = await obrabotkiService.GetDemonOrder(id);
            return Ok(data);
        }

        [HttpGet]
        [Route("getdemondogovorfirmauredi")]
        [AllowAnonymous]
        public async Task<IActionResult> getDemonDogovorFirmaUredi(int iddogovorfirma)
        {
            var data = await obrabotkiService.getDemonDogovorFirmaUredi(iddogovorfirma);
            return Ok(data);
        }


        [HttpGet]
        [Route("getdemondogovorfirmaraioni")]
        [AllowAnonymous]
        public async Task<IActionResult> getDemonDogovorFirmaRaioni(int iddogovorfirma)
        {
            var data = await obrabotkiService.getDogovorFirmaRaioni(iddogovorfirma);
            return Ok(data);
        }

        [HttpGet]
        [Route("getdemonpersonswithdoguredi")]
        [AllowAnonymous]
        public async Task<IActionResult> getDemonPersonsWihtDogUredi(int iddogovorfirma, string raion, int faza)
        {
            var data = await obrabotkiService.getDemonPersonsWihtDogUredi(iddogovorfirma, raion, faza);
            return Ok(data);
        }

        [HttpGet]
        [Route("getdemonpersonuredi")]
        [AllowAnonymous]
        public async Task<IActionResult> getDemonPersonUredi(int iddogovorfirma, int idlice)
        {
            var data = await obrabotkiService.getDemonPersonUredi(iddogovorfirma, idlice);
            return Ok(data);
        }

        [HttpPost]
        [Route("setdemonorder")]
        [AllowAnonymous]
        public async Task<IActionResult> setDemonOrder(OrderDTO item)
        {
            string iduser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var data = await obrabotkiService.setDemonOrder(iduser, item);
            return Ok(data);
        }


        [HttpPost]
        [Route("setdemonuredidogovor")]
        [AllowAnonymous]
        public async Task<IActionResult> setDemonUrediDogovor(List<UrediDogovorDTO> items)
        {
            string iduser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var data = await obrabotkiService.SetDemonUrediDogovor(iduser, items);
            return Ok(data);
        }


        [HttpGet]
        [Route("getdemonlistorders")]
        [AllowAnonymous]
        public async Task<IActionResult> getDemonListOrders(int faza)
        {
            var data = await obrabotkiService.getDemonListOrders(faza);
            return Ok(data);
        }

        [HttpGet]
        [Route("deldemonuredidogovor")]
        [AllowAnonymous]
        public async Task<IActionResult> delDemonUrediDogovor(int idporychkamain, int idlicedogovor)
        {
            int data = await obrabotkiService.DelDemonUrediDogovor(idporychkamain, idlicedogovor);
            return Ok(data);
        }

        [HttpGet]
        [Route("deldemonorder")]
        [AllowAnonymous]
        public async Task<IActionResult> DelDemonOrder(int idporychkamain)
        {
            var data = await obrabotkiService.DelDemonOrder(idporychkamain);
            return Ok(data);
        }

        [HttpGet]
        [Route("getdemonuredifrommonporychka")]
        [AllowAnonymous]
        public async Task<IActionResult> getDemonUrediFromMonPorychka(int iddogovorfirma, int idmonporychka)
        {
            var data = await obrabotkiService.getDemonUrediFromMonPorychka(iddogovorfirma, idmonporychka);
            return Ok(data);
        }

        [HttpGet]
        [Route("setdemonotcheturedi")]
        [AllowAnonymous]
        public async Task<IActionResult> setDemonOtchetUredi(string opos, string dogovor, string data)
        {
            var rez = await obrabotkiService.setDemonOtchetUredi(opos, dogovor, data);
            return Ok(rez);
        }
        #endregion


        #region fakturi
        [HttpGet]
        [Route("getmonlistfakturi")]
        [AllowAnonymous]
        public async Task<IActionResult> getMonListFakturi(int vid)
        {
            var data = await obrabotkiService.getMonListFakturi(vid);
            return Ok(data);
        }

        [HttpGet]
        [Route("getfaktura")]
        [AllowAnonymous]
        public async Task<IActionResult> GetFaktura(int idfaktura)
        {
            var data = await obrabotkiService.GetFaktura(idfaktura);
            return Ok(data);
        }

        [HttpPost]
        [Route("setfaktura")]
        [AllowAnonymous]
        public async Task<IActionResult> SetFaktura(FakturaDTO item)
        {
            string iduser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var data = await obrabotkiService.SetFaktura(iduser, item);
            return Ok(data);
        }


        [HttpGet]
        [Route("delfaktura")]
        [AllowAnonymous]
        public async Task<IActionResult> DelFaktura(int idfaktura)
        {
            var data = await obrabotkiService.DelFaktura(idfaktura);
            return Ok(data);
        }


        [HttpGet("getdocuments")]
        [AllowAnonymous]
        public async Task<IActionResult> GetDocuments(int id, int typedoc)
        {
            var data = await obrabotkiService.GetDocuments(id, typedoc);
            return Ok(data);
        }

        [HttpGet("delfile")]
        [AllowAnonymous]
        public async Task<IActionResult> Delfile(int id)
        {
            DocumentDTO data = await obrabotkiService.GetDocument(id);
            string savedFileName = data.savedfilename;

            string wwwPath = this.environment.WebRootPath;
            string filePathName = Path.Combine(wwwPath, "dokumenti", savedFileName);
            if (System.IO.File.Exists(filePathName))
            {
                try
                {
                    System.IO.File.Delete(filePathName);
                }
                catch (Exception ex)
                {
                }
            }
            await obrabotkiService.DelDocument(id);
            return Ok();
        }

        [HttpPost]
        [Route("addfile")]
        [AllowAnonymous]
        public IActionResult AddFile([FromBody] FileToUpload file)
        {
            string wwwPath = this.environment.WebRootPath;
            string savedFileName = Guid.NewGuid().ToString();
            string filePathName = Path.Combine(wwwPath, "dokumenti", savedFileName);

            if (file.FileAsBase64.Contains(","))
            {
                file.FileAsBase64 = file.FileAsBase64.Substring(file.FileAsBase64.IndexOf(",") + 1);
            }

            file.FileAsByteArray = Convert.FromBase64String(file.FileAsBase64);
            using (var fs = new FileStream(filePathName, FileMode.CreateNew))
            {
                fs.Write(file.FileAsByteArray, 0, file.FileAsByteArray.Length);
            }

            var item = new DocumentDTO
            {
                doctype = file.DocType,
                iddog = file.IdDog,
                text = file.Description,
                filename = file.FileName,
                savedfilename = savedFileName,
                status = 1
            };

            string iduser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            this.obrabotkiService.AddDocument(iduser, item);
            return Ok();
        }


        [HttpGet("getfile")]
        [AllowAnonymous]
        public async Task<IActionResult> DownloadFile(int id)
        {
            string wwwPath = this.environment.WebRootPath;

            DocumentDTO data = await obrabotkiService.GetDocument(id);
            string savedFileName = data.savedfilename;
            string filePath = Path.Combine(wwwPath, "dokumenti", savedFileName);

            if (!System.IO.File.Exists(filePath))
                return NotFound();

            MemoryStream inMemoryCopy = new MemoryStream();
            FileStream fs = new FileStream(filePath, FileMode.Open);
            fs.CopyTo(inMemoryCopy);
            fs.Close();

            inMemoryCopy.Position = 0;
            return File(inMemoryCopy
                , "application/text"
                , savedFileName);
        }
        #endregion



        #region profilaktika
        [HttpPost("getproforder")]
        [AllowAnonymous]
        public async Task<IActionResult> getProfOrder(Filter1DTO filter)
        {
            var data = await obrabotkiService.getProfOrder(filter);
            return Ok(data);
        }

        [HttpGet("setmonprofilaktika")]
        [AllowAnonymous]
        public async Task<IActionResult> setMonProfilaktika(int id, string otchdata, string note, int status_pf, int idprofilaktika)
        {
            var data = await obrabotkiService.setMonProfilaktika(id, otchdata, note, status_pf, idprofilaktika);
            return Ok(data);
        }

        [HttpGet("getproforderbyid")]
        [AllowAnonymous]
        public async Task<IActionResult> getProfOrderById(int idprofilaktika)
        {
            var data = await obrabotkiService.getProfOrderById(idprofilaktika);
            return Ok(data);
        }

        [HttpGet("getprofilaktikanextid")]
        [AllowAnonymous]
        public async Task<IActionResult> getProfilaktikaNextId()
        {
            var data = await obrabotkiService.getProfilaktikaNextId();
            return Ok(data);
        }
        #endregion
    }
}
