using Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repositories.Infrastructure
{
    public interface IUserScopeRepository<TUserScope> where TUserScope : UserObhvat
    {
        Task<TUserScope> Add(TUserScope userScope);
        Task<TUserScope> Get(int userId, int scopeId);
        Task Delete(int userId);
    }
}
