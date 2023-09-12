using Bump.EStore.Infrastructure.Data.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Bump.EStore.Core.Dtos.Products
{
	public class ProductCreateDto
	{
		public int Id { get; set; }

		public int ThirdCategoryId { get; set; }

		public int BrandId{ get; set; }

		public int DealerId { get; set; }

		public string Name { get; set; }

		public string Code { get; set; }

		public int Price { get; set; }
		
		public string ShortDescription { get; set; }

		public string Description { get; set; }	

		public string Thumbnail { get; set; }

		public DateTime CreateAt { get; set; }
		public DateTime UpdateTime { get; set; }

		public string ShelfStatus { get; set; }
	}
	public static class ProductCreateDtoExts
	{
		public static Product ToCreateEntity(this ProductCreateDto dto)
		{
			return new Product
			{
				Id = dto.Id,
				ThirdCategoryId = dto.ThirdCategoryId,
				Brand = new Brand { Id = dto.BrandId },
				Name = dto.Name,
				Code = dto.Code,
				Price = dto.Price,
				ShortDescription = dto.ShortDescription,
				Description= dto.Description,
				Thumbnail = dto.Thumbnail,
				CreateAt = dto.CreateAt,
				UpdateTime = dto.UpdateTime,
				ShelfStatus = dto.ShelfStatus
			};
		}
	}

}