/*
* Copyright (c) Akveo 2019. All Rights Reserved.
* Licensed under the Single Application / Multi Application License.
* See LICENSE_SINGLE_APP / LICENSE_MULTI_APP in the ‘docs’ folder for license information on type of purchased license.
*/

using Common.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.Repositories.Infrastructure
{
    public interface IRoleRepository<TRole> where TRole : Role
    {
        Task Delete(int id);
        Task<TRole> Get(int id);
        Task<TRole> Get(string name);
        Task<TRole> Edit(TRole role);

        Task<IList<TRole>> GetRoles(bool includeDeleted = false);
    }
}