/*
* Copyright (c) Akveo 2019. All Rights Reserved.
* Licensed under the Single Application / Multi Application License.
* See LICENSE_SINGLE_APP / LICENSE_MULTI_APP in the ‘docs’ folder for license information on type of purchased license.
*/

using Common.DataAccess.EFCore;
using Common.Entities;
using Common.Repositories.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Common.Entities.Views;

namespace Common.Repositories
{
    public class UserRepository : BaseDeletableRepository<User, DataContext>, IUserRepository<User>
    {

        public UserRepository(DataContext context) : base(context)
        {
        }

        public override async Task<User> Edit(User obj)
        {
            if (!_dbContext.Users.Any(u => u.Id != obj.Id && u.Email == obj.Email && !u.IsDeleted))
            {

                var objectExists = await Exists(obj);
                if (!objectExists) { 
                    _dbContext.Entry(obj).State = EntityState.Added;
                     await _dbContext.SaveChangesAsync();
                } else
                {
                    string password = (from c in _dbContext.Users
                                        where c.Id == obj.Id
                                        select c.Password)
                                        .SingleOrDefault();

                    obj.Password = password;

                    _dbContext.Entry(obj).State = EntityState.Modified;
                    await _dbContext.SaveChangesAsync();
                }
                return obj;
            }
            else
                return null;
        }

    
        public async Task<User> GetByLogin(string login, bool includeDeleted = false)
        {
            return await GetEntities(includeDeleted)
                .Where(obj => obj.Login == login && !obj.IsDeleted && obj.status == 1)
                .Include(u => u.UserRoles)
                .ThenInclude(x => x.Role)
                .Include(u => u.UserObhvat)
                .ThenInclude(x => x.Obhvat)
                .Include(u => u.Settings)
                .FirstOrDefaultAsync();
        }

        public async Task<User> GetByEmail(string email, bool includeDeleted = false)
        {
            return await GetEntities(includeDeleted)
                .Where(obj => obj.Email == email && !obj.IsDeleted && obj.status == 1)
                .Include(u => u.UserRoles)
                .ThenInclude(x => x.Role)
                .Include(u => u.UserObhvat)
                .ThenInclude(x => x.Obhvat)
                .Include(u => u.Settings)
                .FirstOrDefaultAsync();
        }

        public async Task<IList<User>> GetUsers (bool includeDeleted)
        {
            return await GetEntities(includeDeleted)
                            .Where(u => !u.IsDeleted)
                            .Include(u => u.UserRoles)
                            .ThenInclude(x => x.Role)
                            .Include(u => u.UserObhvat)
                            .ThenInclude(x => x.Obhvat)
                            .Include(u => u.Settings)
                            .ToListAsync();
        }

      
        public async Task<ViewUser> Get(int id, bool includeDeleted)
        {
           var data =  (from u in _dbContext.Users.Where(x => x.Id == id)
                        from r in _dbContext.UserRoles
                                        .Where(x => x.UserId == id)
                                        .DefaultIfEmpty()
                        from s in _dbContext.UserObhvat
                                        .Where(x => x.UserId == id)
                                        .DefaultIfEmpty()
                        select new ViewUser
                        {
                            Id  = u.Id,
                            Login = u.Login,
                            Email = u.Email,
                            RoleId = r.RoleId,
                            ScopeId = s.ObhvatId,
                            RaionId = s.RaionId,
                            Status = u.status,
                            Password = u.Password,
                            Telefon = u.Telefon
                        }).FirstOrDefaultAsync();
            return await data;
        }

        public async Task<IList<ViewDashboard>> GetDashboard(int faza)
        {
            var cntform = from p in _dbContext.LicaFormuliars
                              where p.Faza == (faza==0 ? p.Faza : faza) && p.Status == 1      
                          from l in _dbContext.LicaFormuliarKolektiv
                              where l.IdL == p.IdL && l.IsTitulqr == 1 && l.Status == 1
                          group p by l.ARaion into g
                          select new { raion = g.Key, formulqri = g.Count()};

            var cntdog = from p in _dbContext.LicaFormuliars
                         where p.Faza == (faza == 0 ? p.Faza : faza) && p.Status == 1
                         from d in _dbContext.LicaDogovors
                            where d.IdL == p.IdL && d.StatusDl == 2
                          from l in _dbContext.LicaFormuliarKolektiv
                            where l.IdL == p.IdL && l.IsTitulqr == 1 && l.Status == 1
                         group p by l.ARaion into g
                          select new { raion = g.Key, dogovori = g.Count() };

            var cntpor = from p in _dbContext.LicaFormuliars
                         where p.Faza == (faza == 0 ? p.Faza : faza) && p.Status == 1
                         from l in _dbContext.LicaFormuliarKolektiv
                         where l.IdL == p.IdL && l.IsTitulqr == 1 && l.Status == 1
                         from d in _dbContext.LicaDogovorUredis
                         where d.IdL == p.IdL && d.StatusU == 5
                         from n in _dbContext.NUredi
                         where n.Id == d.IdKt && n.Vid != "RAD"
                         group d by l.ARaion into g
                         select new { raion = g.Key, uredi = g.Sum(x => x.Broi) };

            var raioni = _dbContext.NRaionis
                            .Where(x => x.Status == 1)
                            .Select(x=> new ViewDashboard
                            {
                                nkod = x.Nkod,
                                raion = x.Nime,
                                formulqri = 0,
                                dogovori = 0,
                                uredi = 0
                            })
                            .ToList();

            raioni.ForEach(x =>
            {
                var f = cntform.FirstOrDefault(a => a.raion == x.nkod);
                x.formulqri = (f != null ? f.formulqri : 0);

                var d = cntdog.FirstOrDefault(a => a.raion == x.nkod);
                x.dogovori = (d != null ? d.dogovori : 0);

                var p = cntpor.FirstOrDefault(a => a.raion == x.nkod);
                x.uredi = (p != null ? p.uredi : 0);

            });

            return raioni.OrderBy(z=>z.nkod).ToList();

        }
    }
}