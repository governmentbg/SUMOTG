/*
* Copyright (c) Akveo 2019. All Rights Reserved.
* Licensed under the Single Application / Multi Application License.
* See LICENSE_SINGLE_APP / LICENSE_MULTI_APP in the ‘docs’ folder for license information on type of purchased license.
*/

using Common.DTO;
using Common.Entities;
using Common.Services.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Novacode;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System;
using System.IO;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace Common.WebApiCore.Controllers
{
    [Route("users")]
    public class UsersController : BaseApiController
    {
        protected readonly UserManager<User> userManager;
        protected readonly IUserService userService;
        protected readonly JwtManager jwtManager;
        protected readonly IAuthenticationService authService;
        protected readonly IWebHostEnvironment environment;

        public UsersController(
            IUserService userService
            , JwtManager jwtManager
            , IAuthenticationService authService
            , UserManager<User> userManager
            , IWebHostEnvironment environment)
        {
            this.userManager = userManager;
            this.userService = userService;
            this.jwtManager = jwtManager;
            this.authService = authService;
            this.environment = environment;
        }

        [HttpGet]
        [Route("getusers")]
        [AllowAnonymous]

        public async Task<IActionResult> GetUsers()
        {
            var user = await userService.GetUsers();
            return Ok(user);
        }

        [HttpGet]
        [Route("{id:int}")]
        [AllowAnonymous]
        //        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await userService.GetById(id);
            return Ok(user);
        }

        [HttpGet]
        [Route("current")]
        public async Task<IActionResult> GetCurrent()
        {
            var currentUserId = User.GetUserId();
            if (currentUserId > 0)
            {
                var user = await userService.GetById(currentUserId);
                return Ok(user);
            }

            return Unauthorized();
        }

        [HttpPost]
        [Route("")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> Create(UserDTO userDto)
        {
            if (userDto.Id != 0)
            {
                return BadRequest();
            }

            var result = await userService.Edit(userDto);
            
            if (result != null) { 
                return Ok(result);
            }
            else
                return BadRequest();

        }

        [HttpPut]
        [Route("update")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> Edit(UserDTO userDto)
        {
            var result = await userService.Edit(userDto);

            if (result != null)
            {
                return Ok(result);
            }
            else
                return BadRequest();
        }

        [HttpPut]
        [Route("current")]
        public async Task<IActionResult> EditCurrent(UserDTO userDto)
        {
            var currentUserId = User.GetUserId();
            if (currentUserId != userDto.Id)
            {
                return BadRequest();
            }
            await userService.Edit(userDto);

            var newToken = await authService.GenerateToken(currentUserId);

            return Ok(newToken);
        }

        [HttpDelete]
        [Route("deluser/{id:int}")]
        [AllowAnonymous]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await userService.Delete(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("{userId:int}/photo")]
        [AllowAnonymous]
        public async Task<IActionResult> UserPhoto(int userId, string token)
        {
           var user = jwtManager.GetPrincipal(token);
           if (user == null || !user.Identity.IsAuthenticated)
           {
               return Unauthorized();
           }

            var photoContent = await userService.GetUserPhoto(userId);
            
            if (photoContent == null)
            {
                return NoContent();
            }

            return File(photoContent, contentType: "image/png");
        }

        [HttpGet]
        [Route("getroles")]
        [AllowAnonymous]

        public async Task<IActionResult> GetRoles()
        {
            var roles = await userService.GetRoles();
            return Ok(roles);
        }

        [HttpGet]
        [Route("getobhvats")]
        [AllowAnonymous]
        public async Task<IActionResult> GetObhvats()
        {
            var obhvs = await userService.GetObhvats();
            return Ok(obhvs);
        }

        [HttpPut]
        [Route("changepass/{userId:int}")]
        [AllowAnonymous]
        public async Task<IActionResult> ChangePassword(int UserId, ChangePasswordDTO changePasswordDto)
        {
            if (changePasswordDto == null ||
                string.IsNullOrEmpty(changePasswordDto.ConfirmPassword) ||
                string.IsNullOrEmpty(changePasswordDto.Password) ||
                changePasswordDto.Password != changePasswordDto.ConfirmPassword
             )
            {
                return BadRequest();
            }

            int iduser = UserId;
            if (iduser == 0)
            {
                iduser = Int16.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            } 

            var user = await userManager.FindByIdAsync(iduser.ToString());
            var result = await userManager.ChangePasswordAsync(user, null, changePasswordDto.Password);
            if (result.Succeeded)
            {
                return Ok(true);
            }

            return BadRequest();
        }

        
        [HttpGet]
        [Route("getdashboard")]
        [AllowAnonymous]
        public async Task<IActionResult> GetDashboard(int faza)
        {
            var data = await userService.GetDashboard(faza);
            return Ok(data);
        }

 
        [HttpGet]
        [Route("downloadfile")]
        [AllowAnonymous]
        public async Task<IActionResult> downloadFile([FromQuery]  string file)
        {
            string wwwPath = this.environment.WebRootPath;
            string filePath = Path.Combine(wwwPath, "templates", file);

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
    }
}