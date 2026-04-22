/*
* Copyright (c) Akveo 2019. All Rights Reserved.
* Licensed under the Single Application / Multi Application License.
* See LICENSE_SINGLE_APP / LICENSE_MULTI_APP in the ‘docs’ folder for license information on type of purchased license.
*/

using Common.DTO;
using Common.DTO.Users;
using Common.Entities;
using Common.Repositories.Infrastructure;
using Common.Services.Infrastructure;
using Common.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Services
{
    public class UserService<TUser> : BaseService,
                                    IUserService where TUser : User,
                                    new()
    {
        protected readonly IUserRepository<TUser> userRepository;
        protected readonly IUserPhotoRepository userPhotoRepository;
        protected readonly IRoleRepository<Role> roleRepository;
        protected readonly IObhvatRepository<Obhvat> obhvatRepository;
        protected readonly IUserRoleRepository<UserRole> userRoleRepository;
        protected readonly IUserScopeRepository<UserObhvat> userScopeRepository;

        public UserService(
            IUserRepository<TUser> userRepository,
            IUserPhotoRepository userPhotoRepository,
            IRoleRepository<Role> roleRepository,
            IObhvatRepository<Obhvat> obhvatRepository,
            IUserRoleRepository<UserRole> userRoleRepository,
            IUserScopeRepository<UserObhvat> userScopeRepository
        ) : base()

        {
            this.userRepository = userRepository;
            this.userPhotoRepository = userPhotoRepository;
            this.roleRepository = roleRepository;
            this.obhvatRepository = obhvatRepository;
            this.userRoleRepository = userRoleRepository;
            this.userScopeRepository = userScopeRepository;
        }

        public async Task<bool> Delete(int id)
        {
            await userRepository.Delete(id);
            return true;
        }

        public async Task<UserDTO> Edit(UserDTO dto)
        {
            var user = dto.MapTo<TUser>();
            var data = await userRepository.Edit(user);

            if (data != null)
            {
                if (dto.roleid > 0)
                {
                    await userRoleRepository.Delete(data.Id);
                    UserRole role = new UserRole();
                    role.UserId = data.Id;
                    role.RoleId = dto.roleid;

                    await userRoleRepository.Add(role);
                }
                if (dto.scopeid > 0)
                {
                    await userScopeRepository.Delete(data.Id);
                    UserObhvat scope = new UserObhvat();
                    scope.UserId = data.Id;
                    scope.ObhvatId = dto.scopeid;
                    scope.RaionId = dto.raionid;
                    await userScopeRepository.Add(scope);
                }

                return user.MapTo<UserDTO>();
            }
            else
                return null;
        }
        public async Task<byte[]> GetUserPhoto(int userId)
        {
            var photoContent = await userPhotoRepository.Get(userId);
            return photoContent?.Image;
        }

        public async Task<UserDTO> GetById(int id, bool includeDeleted = false)
        {
            var user = await userRepository.Get(id, includeDeleted);
            return new UserDTO()
            {
                Id = user.Id,
                login = user.Login,
                email = user.Email,
                roleid = user.RoleId == null ? 0 : (int)user.RoleId,
                scopeid = user.ScopeId == null ? 0: (int)user.ScopeId,
                raionid = user.RaionId == null ? "0" : user.RaionId,
                status = user.Status,
                password = user.Password,
                telefon = user.Telefon
            };
        }

        public async Task<UserDTO> GetByLogin(string login, bool includeDeleted = false)
        {
            var user = await userRepository.GetByLogin(login, includeDeleted);
            return user.MapTo<UserDTO>();
        }

        public async Task<IList<UserDTO>> GetUsers(bool includeDeleted = false)
        {
            var user = await userRepository.GetUsers(includeDeleted);
            return user.Select(i => new UserDTO
            {
                Id = i.Id,
                telefon = i.Telefon,
                login = i.Login,
                email = i.Email,
                role = i.UserRoles
                            .Where(s=>s.UserId == i.Id)
                            .Select(x=> x.Role.Name)
                            .FirstOrDefault(),
                roleid = i.UserRoles.Select(x => x.RoleId).FirstOrDefault(),
                scopeid = i.UserObhvat.Select(x => x.ObhvatId).FirstOrDefault(),
                raionid = i.UserObhvat.Select(x => x.RaionId).FirstOrDefault(),
                status = i.status
            }).ToList();
        }

        public async Task<IList<RoleDTO>> GetRoles(bool includeDeleted = false)
        {
            var user = await roleRepository.GetRoles(includeDeleted);
            return user.Select(i => new RoleDTO
            {
                Id = i.Id,
                Name = i.Name,
            }).ToList();
        }
        public async Task<IList<ObhvatDTO>> GetObhvats(bool includeDeleted = false)
        {
            var user = await obhvatRepository.GetObhvats(includeDeleted);
            return user.Select(i => new ObhvatDTO
            {
                Id = i.Id,
                Name = i.Name,
            }).ToList();
        }

        public async Task<IList<DashboardDTO>> GetDashboard(int faza)
        {
            var data = await userRepository.GetDashboard(faza);
            return data.Select(i => new DashboardDTO
            {
                nkod = i.nkod,
                raion = i.raion,
                formulqri = i.formulqri,
                dogovori = i.dogovori,
                uredi = i.uredi
            }).ToList();
        }
    }
}