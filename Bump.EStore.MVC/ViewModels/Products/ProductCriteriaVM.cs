using Bump.EStore.Core.Dtos;
using Bump.EStore.Core.Dtos.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bump.EStore.MVC.ViewModels.Products
{
	public class ProductCriteriaVM
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
	public static class ProductCriteriaVMExts
	{
		public static ProductCriteriaDto ToCriteriaDto(this ProductCriteriaVM vm)
		{
			return new ProductCriteriaDto
			{
				Name = vm.Name,
				Code = vm.Code,
				FirstCategoryId = vm.FirstCategoryId,
				SecondCategoryId = vm.SecondCategoryId,
				ThirdCategoryId = vm.ThirdCategoryId,
				BrandId = vm.BrandId,
				MinPrice = vm.MinPrice,
				MaxPrice = vm.MaxPrice,
			};
		}
	}
}