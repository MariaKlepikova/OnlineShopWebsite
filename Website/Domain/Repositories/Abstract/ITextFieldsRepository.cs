using Website.Domain.Entities;

namespace Website.Domain.Repositories.Abstract
{
	public interface ITextFieldsRepository
	{
		IQueryable<TextField> GetTextFields(); /*сделать выборку всех текстовых полей*/
		TextField GetTextFieldById(Guid id); /*выбрать текстовое поле по идентификатору*/
		TextField GetTextFieldByCodeWord(string codeWord); /*выбрать текстовое поле по кодовому слову*/
		void SaveTextField(TextField entity); /*сохранить изменения в бд*/
		void DeleteTextField(Guid id); /*удалить текстовое поле*/
	}
}
