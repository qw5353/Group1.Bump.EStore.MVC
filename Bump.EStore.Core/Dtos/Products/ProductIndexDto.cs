using Bump.EStore.Infrastructure.Data.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Bump.EStore.Core.Dtos.Products
{
	public class ProductIndexDto
	{
		public int Id { get; set; }
		public int ThirdCategoryId { get; set; }

		public string BrandName { get; set; }


		public string Name { get; set; }

		public string Code { get; set; }

		public int Price { get; set; }

		public string Thumbnail { get; set; }


		public DateTime CreateAt { get; set; }
		public DateTime UpdateTime { get; set; }

		public string ShelfStatus { get; set; }
	}
	public static class ProductIndexDtoExts
	{
		public static ProductIndexDto ToIndexDto(this Product entity)
		{
			return new ProductIndexDto
			{
				Id = entity.Id,
				BrandName = entity.Brand.Name,
				Name = entity.Name,
				Code = entity.Code,
				Price = entity.Price,
				Thumbnail = entity.Thumbnail,
				CreateAt = entity.CreateAt,
				UpdateTime = entity.UpdateTime,
				ShelfStatus = entity.ShelfStatus
			};
		}
	}
}