using Bump.EStore.Core.Dtos.Products;
using Bump.EStore.Infrastructure.Data.EFModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bump.EStore.MVC.ViewModels.Products
{
	public class ProductCreateVM
	{
		public int Id { get; set; }

		public string Code { get; set; }

		[Required(ErrorMessage = "分類尚未選擇完成")]
		public int ThirdCategoryId { get; set; }

		[Display(Name = "商品圖片")]
		//[Required(ErrorMessage = "{0} 未上傳")]
		public string Thumbnail { get; set; }

		[Display(Name = "商品名稱")]
		[Required(ErrorMessage = "{0} 必填")]
		[StringLength(100)]
		public string Name { get; set; }

		[Display(Name = "商品簡介")]
		[Required(ErrorMessage = "{0} 必填")]
		[AllowHtml]
		public string ShortDescription { get; set; }

		[Display(Name = "商品描述")]
		[Required(ErrorMessage = "{0} 必填")]
		[AllowHtml]
		public string Description { get; set; }

		[Display(Name = "品牌")]
		[Required(ErrorMessage = "{0} 必填")]
		public int BrandId { get; set; }

		[Display(Name = "是否上架")]
		public bool ShelfStatus { get; set; }

		[Display(Name = "金額")]
		[Required(ErrorMessage = "{0} 必填")]
		[Range(0, 10000000, ErrorMessage = "金額異常請重新輸入")]
		public int Price { get; set; }
		public IEnumerable<ProductStyle> ProductStyles { get; set; }
	}
	public static class ProductCreateVMExts
	{
		public static Product ToEntity(this ProductCreateVM vm)
		{
			return new Product
			{
				Id = vm.Id,
				Code = vm.Code,
				ThirdCategoryId = vm.ThirdCategoryId,
				Thumbnail = vm.Thumbnail,
				Name = vm.Name,
				ShortDescription = vm.ShortDescription,
				Description = vm.Description,
				BrandId = vm.BrandId,
				ShelfStatus = vm.ShelfStatus ? "上架中" : "已下架",
				Price = vm.Price,
				//ProductStyles = vm.ProductStyles.ToList(),
			};
		}
	}
}