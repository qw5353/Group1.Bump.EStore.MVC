using Bump.EStore.Core.Dtos.Inventories;
using Bump.EStore.Infrastructure.Data.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bump.EStore.Core.Dtos.Products
{
	public class ProductEditDto
	{
		public int Id { get; set; }

		public int ThirdCategoryId { get; set; }

		public string Thumbnail { get; set; }

		public string Name { get; set; }

		public string ShortDescription { get; set; }

		public string Description { get; set; }

		public int BrandId { get; set; }

		public int Price { get; set; }
		public IEnumerable<ProductStyle> ProductStyles { get; set; }
	}
	public static class ProductEditDtoExts
	{
		public static ProductEditDto ToEditDto(this Product entity)
		{
			return new ProductEditDto
			{
				Id = entity.Id,
				ThirdCategoryId = entity.ThirdCategoryId,
				Thumbnail = entity.Thumbnail,
				Name = entity.Name,
				ShortDescription = entity.ShortDescription,
				Description = entity.Description,
				BrandId = entity.BrandId,
				Price = entity.Price,
				ProductStyles = entity.ProductStyles,
			};
		}
		public static Product ToEditEntity(this ProductEditDto dto)
		{
			return new Product
			{
				Id = dto.Id,
				ThirdCategoryId = dto.ThirdCategoryId,
				Thumbnail = dto.Thumbnail,
				Name = dto.Name,
				ShortDescription = dto.ShortDescription,
				Description = dto.Description,
				BrandId = dto.BrandId,
				Price = dto.Price,
				//ProductStyles = dto.ProductStyles.ToList(),
			};
		}
	}
}
