using Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repositories.Infrastructure
{
    public interface IFileRepository
    {
        #region documenti
        Task<List<Attachments>> GetDocuments(int id, int typedoc);
        Task<Attachments> GetDocument(int id);
        Task SetDocument(Attachments data);
        Task DelDocument(int Id);
        #endregion

    }
}
