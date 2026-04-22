using Common.DataAccess.EFCore;
using Common.Entities;
using Common.Entities.Views;
using Common.Repositories.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;


namespace Common.Repositories
{
    public class FileRepository: IFileRepository
    {
		private readonly DataContext _dbContext;

		public FileRepository(DataContext context)
		{
			_dbContext = context;
		}

		#region documenti
		public async Task<List<Attachments>> GetDocuments(int id, int typedoc)
		{
			var data = (from d in _dbContext.Attachments
								.Where(obj => obj.IdDog == id && obj.Status == 1 && obj.DocType == typedoc)
						select new Attachments()
						{
							Id = d.Id,
							IdDog = d.IdDog,
							DocType = d.DocType,
							DocDescription = d.DocDescription,
							FileName = d.FileName
						});

			return await data.ToListAsync();
		}

		public async Task<Attachments> GetDocument(int id)
		{
			var data = (from d in _dbContext.Attachments
								.Where(obj => obj.Id == id)
						select new Attachments()
						{
							Id = d.Id,
							IdDog = d.IdDog,
							DocType = d.DocType,
							DocDescription = d.DocDescription,
							FileName = d.FileName,
							SavedFileName = d.SavedFileName,
						});

			return await data.FirstOrDefaultAsync();
		}

		public async Task SetDocument(Attachments data)
		{
			_dbContext.Entry(data).State = EntityState.Added;
			_dbContext.SaveChanges();
		}


		public async Task DelDocument(int Id)
		{
			var item = _dbContext.Attachments.Where(x => x.Id == Id).First();

			_dbContext.Attachments.Remove(item);
			await _dbContext.SaveChangesAsync();
		}

		#endregion
	}
}
