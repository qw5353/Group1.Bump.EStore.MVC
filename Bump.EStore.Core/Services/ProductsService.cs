using Bump.EStore.Core.Dtos;
using Bump.EStore.Core.Dtos.Products;
using Bump.EStore.Infrastructure.Infra;
using Bump.EStore.Infrastructure.Repositories.DapperRepositories;
using Bump.EStore.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bump.EStore.Core.Services
{
	public class ProductsService
	{
		private IProductsRepository _repo;
		public ProductsService()
		{
			_repo = new ProductRepository();
		}
		public ProductsService(IProductsRepository repo)
		{
			_repo = repo;
		}
		public IEnumerable<ProductIndexDto> Search(ProductCriteriaDto dto, int pageNumber, int rowsPerPage)
		{
			return _repo
					.Search(pageNumber, rowsPerPage, dto.ToProductCriteria())
					.Select(ef => ef.ToIndexDto())
					.ToList();
		}
		public int Count(ProductCriteriaDto dto) => _repo.Count(dto.ToProductCriteria());
		public bool Create(ProductCreateDto dto)
		{
			return _repo
					.Create(dto.ToCreateEntity());
		}
		public Result UpdateShelfStatus(int id, string shelfStatus)
		{
			bool result = _repo.UpdateShelfStatus(id, shelfStatus);


			return result == false ? Result.Fail("更新失敗") : Result.Success();

		}
		
		public ProductEditDto GetProductEdits(int? id) 
		{
			return _repo
					.GetProductEdits(id)
					.ToEditDto();
		}

		public bool Edit(ProductEditDto dto)
		{
			return _repo
				.Edit(dto.ToEditEntity());
		}
	}
}
