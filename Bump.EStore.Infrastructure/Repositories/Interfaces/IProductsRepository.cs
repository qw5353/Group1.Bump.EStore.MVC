using Bump.EStore.Infrastructure.Criteria;
using Bump.EStore.Infrastructure.Data.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Bump.EStore.Infrastructure.Repositories.Interfaces
{
	public interface IProductsRepository
	{
		IEnumerable<Product> Search(int pageNumber, int rowsPerPage, ProductCriteria criteria);
		int Count(ProductCriteria dto);
		bool Create(Product product);

		bool UpdateShelfStatus(int id,string shelfSatatus);

		Product GetProductEdits(int? id);

		bool Edit(Product product);
	}
}
 
