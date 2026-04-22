using Common.DTO;
using Common.Entities;
using Common.Repositories.Infrastructure;
using Common.Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Services
{
    public class PublicService : BaseService, IPublicService
    {
        protected readonly IPublicRepository publicRepository;

        public PublicService(IPublicRepository publicRepository) : base()
        {
            this.publicRepository = publicRepository;
        }

        #region form collecting information

        public async Task<int> setCollectInfo(CollectInfoDTO item)
        {
            //dobawqne na formulqra
            var data = new FormCollectingInfo
            {
                Ime = item.ime,
                Prezime = item.prezime,
                Familiq  = item.familiq,
                ARaion = item.raionid,
                Nm = item.nm,
                Jk = item.jk,
                Ul = item.ul,
                Nomer = item.nomer,
                Blok = item.blok,
                Vh = item.vh,
                Etaj = item.etaj,
                Ap = item.ap,
                Pk = item.pk,
                e_mail = item.email,
                tel = item.tel,
                v1 = item.v1,
                v101 = item.v101,
                v2 = item.v2,
                v201 = item.v201

            };

            return await publicRepository.setCollectInfo(data, item.editmode);
        }

        #endregion

    }
}
