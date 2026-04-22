using Common.DTO;
using Common.DTO.Lica;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services.Infrastructure
{
    public interface IFileService
    {
        Task<IList<ListAttachmentsDTO>> GetDocuments(int id, int typedoc);
        Task<DocumentDTO> GetDocument(int id);
        Task AddDocument(string pIdUser, DocumentDTO item);
        Task DelDocument(int id);

    }
}
