using Common.DTO;
using Common.DTO.Obrabotki;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services.Infrastructure
{
    public interface IPublicService
    {
        #region form collecting information      
        Task<int> setCollectInfo(CollectInfoDTO item);
        #endregion
    }
}
