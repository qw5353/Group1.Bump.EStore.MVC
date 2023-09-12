using Bump.EStore.Core.Dtos.Inventories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bump.EStore.MVC.ViewModels.Inventories
{
	public class InventoryProductStyleIndexVM
	{
		public int Id { get; set; }
		public string Style { get; set; }
		public int Inventory { get; set; }
		public int MinimumStock { get; set; }
		public string ParaTextClass => Inventory < MinimumStock ? "text-danger fw-bold" : string.Empty;
		public string CellClass => Inventory < MinimumStock ? "danger-cell" : string.Empty;
	}

	public static class InventoryProductStyleIndexVMExts { 
		public static InventoryProductStyleIndexVM ToVM(this InventoryProductStyleIndexDto dto)
		{
			return new InventoryProductStyleIndexVM
			{
				Id = dto.Id,
				Style = dto.Style,
				MinimumStock = dto.MinimumStock,
				Inventory = dto.Inventory,
			};
		}
	}

}