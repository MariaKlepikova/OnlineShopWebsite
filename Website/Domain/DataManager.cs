using Website.Domain.Repositories.Abstract;

namespace Website.Domain
{
	//Класс, чтобы было удобнее управлять текстовыми полями и услугами.
	//Вместо  того, чтобы по отдельности передавать каждый репозиторий для управления услугами,
	//например, в контроллер, будем передавать класс DataManager и через его св-ва будем управлять д-ями
	public class DataManager
	{
		public ITextFieldsRepository TextFields { get; set; }
		public IServiceItemsRepository ServiceItems { get; set; }

		public DataManager(ITextFieldsRepository textFieldsRepository, IServiceItemsRepository serviceItemsRepository) 
		{
			TextFields = textFieldsRepository;
			ServiceItems = serviceItemsRepository;
		}


	}
}
