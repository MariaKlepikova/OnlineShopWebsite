using Website.Domain.Entities;

namespace Website.Domain.Repositories.Abstract
{
	public interface IServiceItemsRepository
	{
		IQueryable<ServiceItem> GetServiceItems(); /*выбрать все услуги*/
		ServiceItem GetServiceItemById(Guid id); /*выбрать услугу по идентификатору*/
		void SaveServiceItems(ServiceItem entity); /*обновить/создать новую услугу*/
		void DeleteServiceItems(Guid id); /*удалить услугу*/
	}
}
