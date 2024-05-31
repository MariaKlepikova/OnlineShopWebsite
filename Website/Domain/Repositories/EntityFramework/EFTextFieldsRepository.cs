using Microsoft.EntityFrameworkCore;
using Website.Domain.Entities;
using Website.Domain.Repositories.Abstract;

namespace Website.Domain.Repositories.EntityFramework
{
    public class EFTextFieldsRepository : ITextFieldsRepository
	{
		private readonly AppDbContext _context;
		public EFTextFieldsRepository(AppDbContext context)
		{
			_context = context;
		}

		public IQueryable<TextField> GetTextFields()
		{
			return _context.TextField;
		}

		public TextField GetTextFieldById(Guid id) 
		{
			return _context.TextField.FirstOrDefault(x => x.Id == id)!;
		}

		public TextField GetTextFieldByCodeWord(string codeWord)
		{
			return _context.TextField.FirstOrDefault(x => x.CodeWord == codeWord)!;
		}

		//Если идентификатор = значению по умолчанию, то предполагается, что создана новая запись на сайте
		//и идентификатора для нее еще нет => объект помечается как добавленный (Added)

		//Если идентификатор уже есть, значит данный объект есть в бд, но у него изменились значения св-в

		public void SaveTextField(TextField entity) 
		{
			if (entity.Id == default)
				_context.Entry(entity).State = EntityState.Added;
			else
				_context.Entry(entity).State = EntityState.Modified;

			_context.SaveChanges();
		}

		public void DeleteTextField(Guid id) 
		{
			_context.TextField.Remove(new TextField () { Id = id });
			_context.SaveChanges();
		}
	}
}
