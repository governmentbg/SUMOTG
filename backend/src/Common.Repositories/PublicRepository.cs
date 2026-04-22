using Common.DataAccess.EFCore;
using Common.Entities;
using Common.Entities.Demontaz;
using Common.Entities.Fakturi;
using Common.Entities.Montaz;
using Common.Entities.Spravki;
using Common.Entities.Views;
using Common.Repositories.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Repositories
{
    public class PublicRepository : IPublicRepository
    {
        private readonly DataContext _dbContext;

        public PublicRepository(DataContext context)
        {
            _dbContext = context;
        }

        #region form collecting information  
        public async Task<int> setCollectInfo(FormCollectingInfo item, int editmode)
        {
            string lcsql = "exec checkCollectingInformation '"
                                    + item.e_mail.Trim()+"',"+
                                    "'" + item.ARaion + "'" + ',' +
                                    (String.IsNullOrEmpty(item.Nm) ? "''" : "'" + item.Nm + "'") + ',' +
                                    (String.IsNullOrEmpty(item.Jk) ? "''" : "'" + item.Jk + "'") + ',' +
                                    (String.IsNullOrEmpty(item.Ul) ? "''" : "'" + item.Ul + "'") + ',' +
                                    (String.IsNullOrEmpty(item.Nomer) ? "''" : "'" + item.Nomer + "'") + ',' +
                                    (String.IsNullOrEmpty(item.Blok) ? "''" : "'" + item.Blok + "'") + ',' +
                                    (String.IsNullOrEmpty(item.Vh) ? "''" : "'" + item.Vh + "'") + ',' +
                                    (String.IsNullOrEmpty(item.Etaj) ? "''" : "'" + item.Etaj + "'") + ',' +
                                    (String.IsNullOrEmpty(item.Ap) ? "''" : "'" + item.Ap + "'") + ',' +
                                    editmode.ToString();

            var r = _dbContext.ViewResult
                            .FromSqlRaw(lcsql)
                            .ToList()
                            .AsQueryable()
                            .FirstOrDefault();

            if (r.result == 0)
            {
                item.status = 0;
                item.descript = "";
                item.CreatedOn = DateTime.Now;

                _dbContext.FormCollectingInfo.Add(item);
                await _dbContext.SaveChangesAsync();

                lcsql = "exec setCollectingInformation "
                                      + item.Id.ToString();

                var data = _dbContext.ViewResult
                                .FromSqlRaw(lcsql)
                                .ToList()
                                .AsQueryable()
                                .FirstOrDefault();

                return item.Id;
            } else
            {
                return r.result;
            }
        }

        #endregion


    }
}
