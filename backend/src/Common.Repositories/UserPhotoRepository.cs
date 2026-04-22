/*
* Copyright (c) Akveo 2019. All Rights Reserved.
* Licensed under the Single Application / Multi Application License.
* See LICENSE_SINGLE_APP / LICENSE_MULTI_APP in the ‘docs’ folder for license information on type of purchased license.
*/

using Common.DataAccess.EFCore;
using Common.Entities;
using Common.Repositories.Infrastructure;
using Common.Services.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Repositories
{
    public class UserPhotoRepository : BaseRepository<UserPhoto, DataContext>, IUserPhotoRepository
    {
        public UserPhotoRepository(DataContext context) : base(context)
        {
        }

        public override async Task<bool> Exists(UserPhoto obj)
        {
            return await _dbContext.UserPhotos.Where(x => x.Id == obj.Id).AsNoTracking().CountAsync() > 0;
        }

        public override async Task<UserPhoto> Get(int id)
        {
            return await _dbContext.UserPhotos.Where(obj => obj.Id == id).AsNoTracking().FirstOrDefaultAsync();
        }
    }
}
