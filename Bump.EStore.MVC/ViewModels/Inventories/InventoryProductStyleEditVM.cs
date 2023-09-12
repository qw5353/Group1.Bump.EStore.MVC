using Bump.EStore.Core.Dtos.Inventories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bump.EStore.MVC.ViewModels.Inventories
{
	public class InventoryProductStyleEditVM
	{
		public int Id { get; set; }
		[Required]
		[Display(Name = "款式")]
		public string Style { get; set; }
		[Required]
		[Display(Name = "商品名稱")]
		public string Name { get; set; }
		[Required]
		[Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
		[Display(Name = "目前存貨量")]
		public int Inventory { get; set; }
		[Required]
		[Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
		[Display(Name = "安全存貨量")]
		public int MinimumStock { get; set; }
	}

	public static class InventoryProductStyleEditVMExts
	{
		public static InventoryProductStyleEditDto ToEditDto(this InventoryProductStyleEditVM vm)
		{
			return new InventoryProductStyleEditDto
			{
				Id = vm.Id,
				Inventory = vm.Inventory,
				MinimumStock = vm.MinimumStock,
			};
		}

		public static InventoryProductStyleEditVM ToEditVM(this InventoryProductStyleEditDto dto)
		{
			return new InventoryProductStyleEditVM
			{
				Id = dto.Id,
				Style = dto.Style,
				MinimumStock = dto.MinimumStock,
				Inventory = dto.Inventory,
				Name = dto.Name,
			};
		}
	}
}