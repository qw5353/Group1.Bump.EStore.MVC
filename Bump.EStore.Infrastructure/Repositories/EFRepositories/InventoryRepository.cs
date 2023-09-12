using Bump.EStore.Infrastructure.Data.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Bump.EStore.Infrastructure.Repositories.Interfaces;

namespace Bump.EStore.Infrastructure.Repositories.EFRepositories
{
	public class InventoryRepository : RepositoryBase<Product>, IInventoryRepository
	{
		public InventoryRepository() : base()
		{

		}

		public IEnumerable<Product> Search()
		{
			return _db.Products
				.AsNoTracking()
				.Include(p => p.ProductStyles)
				.ToList();
		}

		public ProductStyle GetStyleById(int id)
		{
			return _db.ProductStyles
				.Include(ps => ps.Product)
				.AsNoTracking()
				.SingleOrDefault(ps => ps.Id == id);
		}

		public int Update(ProductStyle entity)
		{
			var productStyleInDb = _db.ProductStyles.Find(entity.Id);

			if (productStyleInDb is null)
			{
				return 0;
			}

			_db.Entry(productStyleInDb).State = EntityState.Modified;
			
			productStyleInDb.Inventory = entity.Inventory;
			productStyleInDb.MinimumStock = entity.MinimumStock;

			return _db.SaveChanges();
		}
	}
}
