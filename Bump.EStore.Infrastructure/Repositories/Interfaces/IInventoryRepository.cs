using Bump.EStore.Infrastructure.Data.EFModels;
using System.Collections.Generic;

namespace Bump.EStore.Infrastructure.Repositories.Interfaces
{
	public interface IInventoryRepository
	{
		ProductStyle GetStyleById(int id);
		IEnumerable<Product> Search();
		int Update(ProductStyle entity);
	}
}