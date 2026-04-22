/*
* Copyright (c) Akveo 2019. All Rights Reserved.
* Licensed under the Single Application / Multi Application License.
* See LICENSE_SINGLE_APP / LICENSE_MULTI_APP in the ‘docs’ folder for license information on type of purchased license.
*/

using Common.DTO;
using Common.Entities;
using Common.Repositories.Infrastructure;
using Common.Services.Infrastructure;
using Common.Utils;
using System.Threading.Tasks;

namespace Common.Services
{
    public class SettingsService : BaseService, ISettingsService
    {
        protected readonly ISettingsRepository settingsRepository;

        public SettingsService(ISettingsRepository settingsRepository) : base()
        {
            this.settingsRepository = settingsRepository;
        }

        public async Task<SettingsDTO> Edit(SettingsDTO dto)
        {
            var settings = dto.MapTo<Settings>();
            await settingsRepository.Edit(settings);
            return settings.MapTo<SettingsDTO>();
        }

        public async Task<SettingsDTO> GetById(int id)
        {
            var user = await settingsRepository.Get(id);
            return user.MapTo<SettingsDTO>();
        }
    }
}
