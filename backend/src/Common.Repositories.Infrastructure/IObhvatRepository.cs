
using Common.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.Repositories.Infrastructure
{
    public interface IObhvatRepository<TObhvat> where TObhvat : Obhvat
    {
        Task <IList<TObhvat>> GetObhvats(bool includeDeleted = false);
    }
}