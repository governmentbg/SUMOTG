/*
* Copyright (c) Akveo 2019. All Rights Reserved.
* Licensed under the Single Application / Multi Application License.
* See LICENSE_SINGLE_APP / LICENSE_MULTI_APP in the ‘docs’ folder for license information on type of purchased license.
*/

using Common.Services;
using Common.Services.Infrastructure;
using Common.DataAccess.EFCore;
using Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Common.Repositories;
using Common.Repositories.Infrastructure;
using Microsoft.AspNetCore.Identity;

namespace Common.DIContainerCore
{
    public static class ContainerExtension
    {
        public static void Initialize(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped<IDataBaseInitializer, DataBaseInitializer>();
            services.AddTransient<ISettingsService, SettingsService>();
            services.AddTransient<ISettingsRepository, SettingsRepository>();
            services.AddTransient<IUserPhotoRepository, UserPhotoRepository>();
            services.AddTransient<IUserService, UserService<User>>();
            services.AddTransient<IUserRepository<User>, UserRepository>();
            services.AddTransient<IIdentityUserRepository<User>, IdentityUserRepository>();
            services.AddTransient<IRoleRepository<Role>, RoleRepository>();
            services.AddTransient<IUserRoleRepository<UserRole>, UserRoleRepository>();
            services.AddTransient<IUserClaimRepository<UserClaim>, UserClaimRepository>();

            services.AddTransient<INomenclatureService, NomenclatureService>();
            services.AddTransient<INomenclatureRepository, NomenclatureRepository>();

            services.AddTransient<ISpravkiService, SpravkiService>();
            services.AddTransient<ISpravkiRepository, SpravkiRepository>();

            services.AddTransient<IObhvatRepository<Obhvat>, ObhvatRepository>();
            services.AddTransient<IUserScopeRepository<UserObhvat>, UserScopeRepository>();

            services.AddTransient<ILicaService, LicaService>();
            services.AddTransient<ILicaRepository, LicaRepository>();

            services.AddTransient<IFirmService, FirmService>();
            services.AddTransient<IFirmRepository, FirmRepository>();

            services.AddTransient<IObrabotkiService, ObrabotkiService>();
            services.AddTransient<IObrabotkiRepository, ObrabotkiRepository>();

            services.AddTransient<IFileService, FileService>();
            services.AddTransient<IFileRepository, FileRepository>();

            services.AddTransient<IPublicService, PublicService>();
            services.AddTransient<IPublicRepository, PublicRepository>();

            services.AddTransient<IOditRepository, OditRepository>();
        }
    }
}
