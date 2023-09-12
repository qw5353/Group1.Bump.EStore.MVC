using Bump.EStore.Infrastructure.Criteria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bump.EStore.Core.Dtos.Products
{
	public class ProductCriteriaDto
	{
		public string Name { get; set; }

		public string Code { get; set; }

		public int? FirstCategoryId { get; set; }

		public int? SecondCategoryId { get; set; }

		public int? ThirdCategoryId { get; set; }

		public int? BrandId { get; set; }

		public int? MinPrice { get; set; }

		public int? MaxPrice { get; set; }
	}
	public static class ProductCriteriaCriteriaDtoExts
	{
		public static ProductCriteria ToProductCriteria(this ProductCriteriaDto dto)
		{
			return new ProductCriteria
			{
				Name = dto.Name,	
				Code = dto.Code,
				FirstCategoryId = dto.FirstCategoryId,
				SecondCategoryId = dto.SecondCategoryId,
				ThirdCategoryId = dto.ThirdCategoryId,	
				BrandId = dto.BrandId,
				MinPrice = dto.MinPrice,
				MaxPrice = dto.MaxPrice
			};
		}
	}
}
