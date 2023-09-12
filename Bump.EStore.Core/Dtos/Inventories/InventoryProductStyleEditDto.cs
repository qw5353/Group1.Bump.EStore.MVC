using Bump.EStore.Infrastructure.Data.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Bump.EStore.Core.Dtos.Inventories
{
	public class InventoryProductStyleEditDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Style { get; set; }
		public int Inventory { get; set; }
		public int MinimumStock { get; set; }
	}

	public static class InventoryProductStyleEditDtoExts
	{
		public static InventoryProductStyleEditDto ToInventoryEditDto(this ProductStyle entity)
		{
			return new InventoryProductStyleEditDto
			{
				Id = entity.Id,
				Style = entity.Style,
				MinimumStock = entity.MinimumStock,
				Inventory = entity.Inventory,
				Name = entity.Product.Name
			};
		}

		public static ProductStyle ToEntity(this InventoryProductStyleEditDto dto)
		{
			return new ProductStyle
			{
				Id = dto.Id,
				MinimumStock = dto.MinimumStock,
				Inventory = dto.Inventory
			};
		}
	}
}
