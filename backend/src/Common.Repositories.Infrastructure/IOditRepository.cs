using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repositories.Infrastructure
{
    public interface IOditRepository
    {
        #region oditlog
//        Task<IList<ViewOditLog>> GetOditLog(DateTime from, DateTime To, string iduser);
        Task<int> AddRow(int id, string text,string iduser);
        Task<int> DeleteRows(DateTime from, DateTime To);
        #endregion
    }
}
