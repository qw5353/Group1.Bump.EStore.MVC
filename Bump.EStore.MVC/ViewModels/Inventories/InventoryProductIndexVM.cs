using Bump.EStore.Core.Dtos.Inventories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bump.EStore.MVC.ViewModels.Inventories
{
	public class InventoryProductIndexVM
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Thumbnail { get; set; }
		public string Code { get; set; }
		public IEnumerable<InventoryProductStyleIndexVM> ProductStyles { get; set; }
	}

	public static class InventoryProductVMExts
	{
		public static InventoryProductIndexVM ToVM(this InventoryProductIndexDto dto)
		{
			return new InventoryProductIndexVM
			{
				Id = dto.Id,
				Name = dto.Name,
				Thumbnail = dto.Thumbnail,
				Code = dto.Code,
				ProductStyles = dto.ProductStyles.Select(ps => ps.ToVM()),
			};
		}
	}
}