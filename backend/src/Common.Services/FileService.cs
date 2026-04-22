using Common.DTO;
using Common.DTO.Lica;
using Common.Entities;
using Common.Repositories.Infrastructure;
using Common.Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services
{
    public class FileService : IFileService
	{
		protected readonly IFileRepository fileRepository;

		public FileService(IFileRepository fileRepository) : base()
		{
			this.fileRepository = fileRepository;
		}


		#region documenti
		public async Task<IList<ListAttachmentsDTO>> GetDocuments(int id, int typedoc)
		{
			var data = await fileRepository.GetDocuments(id, typedoc);

			return data.Select(i => new ListAttachmentsDTO
			{
				id = i.Id,
				iddog = i.IdDog,
				description = i.DocDescription,
				filename = i.FileName
			}).ToList();

		}

		public async Task<DocumentDTO> GetDocument(int id)
		{
			Attachments data = await fileRepository.GetDocument(id);

			if (data != null)
				return new DocumentDTO
				{
					doctype = data.DocType,
					id = data.Id,
					iddog = data.IdDog,
					filename = data.FileName,
					savedfilename = data.SavedFileName
				};
			else
				return new DocumentDTO();
		}

		public async Task AddDocument(string pIdUser, DocumentDTO item)
		{
			Attachments data = convertDocsDTOtoDocs(pIdUser, item);
			await fileRepository.SetDocument(data);
		}

		public async Task DelDocument(int id)
		{
			await fileRepository.DelDocument(id);
		}
		#endregion

		private Attachments convertDocsDTOtoDocs(string pIdUser, DocumentDTO item)
		{
			return new Attachments
			{
				IdDog = item.iddog,
				Id = item.id,
				DocType = item.doctype,
				DocDescription = item.text,
				FileName = item.filename,
				Koga = DateTime.Now,
				User = pIdUser,
				Status = item.status,
				SavedFileName = item.savedfilename,
			};
		}
		private List<DocumentDTO> convertDocsToDocsDTO(List<Attachments> data)
		{
			return data.Select(item => new DocumentDTO
			{
				iddog = item.IdDog,
				doctype = item.DocType,
				id = item.Id,
				text = item.DocDescription,
				filename = item.FileName,
				status = item.Status,
				savedfilename = item.SavedFileName,
			}).ToList();
		}
	}
}
