using Bump.EStore.Core.Dtos;
using Bump.EStore.Core.Dtos.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Web;

namespace Bump.EStore.MVC.ViewModels.Products
{
	public class ProductIndexVM
	{
		public int Id { get; set; }
		public int ThirdCategoryId { get; set; }

		[Display(Name="品牌")]
		public string BrandName { get; set; }


		[Display(Name = "商品名稱")]
		public string Name { get; set; }

		[Display(Name = "商品編號")]
		public string Code { get; set; }

		[Display(Name = "商品價格")]
		public int Price { get; set; }

		public string Thumbnail { get; set; }

		[Display(Name = "創立時間")]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]

		public DateTime CreateAt { get; set; }
		[Display(Name = "異動時間")]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
		public DateTime UpdateTime { get; set; }

		[Display(Name = "上架狀態")]
		public string ShelfStatus { get; set; }
	}
	public static class ProductIndexVMExts
	{
		public static ProductIndexVM ToIndexVM(this ProductIndexDto dto)
		{
			return new ProductIndexVM
			{
				Id = dto.Id,
				BrandName = dto.BrandName,
				Name = dto.Name,
				Code = dto.Code,
				Price = dto.Price,
				Thumbnail = dto.Thumbnail,
				CreateAt = dto.CreateAt,
				UpdateTime = dto.UpdateTime,
				ShelfStatus = dto.ShelfStatus
			};
		}
	}
}