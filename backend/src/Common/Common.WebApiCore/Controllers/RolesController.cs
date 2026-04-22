/*
* Copyright (c) Akveo 2019. All Rights Reserved.
* Licensed under the Single Application / Multi Application License.
* See LICENSE_SINGLE_APP / LICENSE_MULTI_APP in the ‘docs’ folder for license information on type of purchased license.
*/

using Common.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace Common.WebApiCore.Controllers
{
    [Route("users/{id:int}/roles")]
    [Authorize(Policy = "AdminOnly")]
    public class RolesController : BaseApiController
    {
        public IConfiguration configuration { get; }

        protected readonly IRoleService roleService;

        public RolesController(IRoleService roleService, IConfiguration Config)
        {
            this.roleService = roleService;
            this.configuration = Config;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Assign(int id, RoleDTO role)
        {
            var result = await roleService.AssignToRole(id, role.Name);
            if (result.Succeeded)
                return Ok();

            return BadRequest(new { message = result.Errors.FirstOrDefault()?.Description });
        }

        [HttpDelete]
        [Route("")]
        public async Task<IActionResult> Unassign(int id, RoleDTO role)
        {
            var result = await roleService.UnassignRole(id, role.Name);
            if (result.Succeeded)
                return Ok();

            return BadRequest(new { message = result.Errors.FirstOrDefault()?.Description });
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetRoles(int id)
        {
            var result = await roleService.GetRoles(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("getconnection")]
        [AllowAnonymous]
        public async Task<IActionResult> GetConnection()
        {
            string result = this.configuration.GetConnectionString ("DefaultConnection");
            return Ok(result);
        }

    }
}