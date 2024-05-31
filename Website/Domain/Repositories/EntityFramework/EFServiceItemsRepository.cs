using Website.Domain.Entities;
using Website.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Website.Domain.Repositories.EntityFramework
{
    public class EFServiceItemsRepository : IServiceItemsRepository
	{
		private readonly AppDbContext _context;
		public EFServiceItemsRepository(AppDbContext appDbContext)
		{
			_context = appDbContext;
		}

		public IQueryable<ServiceItem> GetServiceItems()
		{
			return _context.ServiceItems;
		}

		public ServiceItem GetServiceItemById(Guid id)
		{
			return _context.ServiceItems.FirstOrDefault(x => x.Id == id)!;
		}

		public void SaveServiceItems(ServiceItem entity)
		{
			if (entity.Id == default)
				_context.Entry(entity).State = EntityState.Added;
			else
				_context.Entry(entity).State = EntityState.Modified;

			_context.SaveChanges();
		}

		public void DeleteServiceItems(Guid id)
		{
			_context.ServiceItems.Remove(new ServiceItem() { Id = id });
			_context.SaveChanges();
		}
	}
}
