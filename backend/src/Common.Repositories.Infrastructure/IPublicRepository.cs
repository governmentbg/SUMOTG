using Common.Entities;
using Common.Entities.Demontaz;
using Common.Entities.Fakturi;
using Common.Entities.Montaz;
using Common.Entities.Spravki;
using Common.Entities.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repositories.Infrastructure
{
    public interface IPublicRepository
    {
        #region form collecting information
        Task<int> setCollectInfo(FormCollectingInfo item, int editmode);
        #endregion
    }
}
