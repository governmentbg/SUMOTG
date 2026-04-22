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
    [Route("public")]
    public class PublicController : BaseApiController
    {
        protected readonly IPublicService publicService;
        protected readonly IWebHostEnvironment environment;

        public PublicController(IWebHostEnvironment environment, IPublicService publicService)
        {
            this.environment = environment;
            this.publicService = publicService;
        }

        #region form collecting information
        [HttpPost]
        [Route("setcollectinfo")]
        [AllowAnonymous]
        public async Task<IActionResult> setCollectInfo(CollectInfoDTO item)
        {
            var data = await publicService.setCollectInfo(item);
            return Ok(data);
        }

        #endregion
    }
}
