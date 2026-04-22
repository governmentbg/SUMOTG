
using Common.DTO;
using Common.DTO.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.Services.Infrastructure
{
    public interface IUserService
    {
        
        Task<IList<UserDTO>> GetUsers(bool includeDeleted = false);
        Task<UserDTO> GetById(int id, bool includeDeleted = false);
        Task<UserDTO> GetByLogin(string login, bool includeDeleted = false);
        Task<bool> Delete(int id);
        Task<UserDTO> Edit(UserDTO dto);
        Task<byte[]> GetUserPhoto(int userId);
        Task<IList<RoleDTO>> GetRoles(bool includeDeleted = false);
        Task<IList<ObhvatDTO>> GetObhvats(bool includeDeleted = false);
        Task<IList<DashboardDTO>> GetDashboard(int faza);
    }
}