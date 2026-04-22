using System;
using System.IO;
using System.Security.Claims;
using System.Threading.Tasks;
using Common.DTO;
using Common.Services.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;


namespace Common.WebApiCore.Controllers
{
    [Route("uploadfile")]
    public class FileUploadController : BaseApiController
    {
         protected readonly IWebHostEnvironment environment;
        protected readonly IFileService fileService;

        public FileUploadController(IWebHostEnvironment environment, IFileService fileService)
        {
            this.environment = environment;
            this.fileService = fileService;
        }

        [HttpGet("getdocuments")]
        [AllowAnonymous]
        public async Task<IActionResult> GetDocuments(int id, int typedoc)
        {
            var data = await fileService.GetDocuments(id, typedoc);
            return Ok(data);
        }

        [HttpGet("delfile")]
        [AllowAnonymous]
        public async Task<IActionResult> Delfile(int id)
        {
            DocumentDTO data = await fileService.GetDocument(id);
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
            await fileService.DelDocument(id);
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
            this.fileService.AddDocument(iduser, item );
            return Ok();
        }


        [HttpGet("getfile")]
        [AllowAnonymous]
        public async Task<IActionResult> DownloadFile(int id)
        {
            string wwwPath = this.environment.WebRootPath;

            DocumentDTO data = await fileService.GetDocument(id);
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

        [HttpPost]
        [Route("putfile")]
        [AllowAnonymous]
        public IActionResult PutFile([FromBody] FileToUpload file)
        {
            string wwwPath = this.environment.WebRootPath;
            string savedFileName = file.FileName;
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
            return Ok();
        }
    }

}
