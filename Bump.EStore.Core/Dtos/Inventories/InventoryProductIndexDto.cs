using Bump.EStore.Infrastructure.Data.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bump.EStore.Core.Dtos.Inventories
{
	public class InventoryProductIndexDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Thumbnail { get; set; }
		public string Code { get; set; }
		public IEnumerable<InventoryProductStyleIndexDto> ProductStyles { get; set; }
	}

	public static class InventoryProductIndexDtoExts
	{
		public static InventoryProductIndexDto ToDto(this Product entity)
		{
			return new InventoryProductIndexDto
			{
				Id = entity.Id,
				Name = entity.Name,
				Thumbnail = entity.Thumbnail,
				Code = entity.Code,
				ProductStyles = entity.ProductStyles.Select(st => {
					return new InventoryProductStyleIndexDto
					{
						Id = st.Id,
						Style = st.Style,
						MinimumStock = st.MinimumStock,
						Inventory = st.Inventory
					};
				})
			};
		}
	}
}
