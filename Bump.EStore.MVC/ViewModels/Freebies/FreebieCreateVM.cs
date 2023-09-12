using Bump.EStore.Infrastructure.Data.EFModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bump.EStore.MVC.ViewModels.Freebies
{
	public class FreebieCreateVM
	{
		[Display(Name = "贈品名稱")]
		[Required]
		public string Name { get; set; }

		[Display(Name = "品牌")]
		public string Brand { get; set; }

		[Display(Name = "參考售價")]
		public int Price { get; set; }

		[Display(Name = "贈品敘述")]
		[Required]
		public string ShortDescription { get; set; }

		[Display(Name = "贈品圖片")]
		public string Thumbnail { get; set; }

		[Display(Name = "庫存量")]
		public int Inventory { get; set; }

		[Display(Name = "建立時間")]
		public DateTime CreatedAt { get; set; }

		[Display(Name = "更新時間")]
		public DateTime UpdatedTime { get; set; }
	}

	public static class FreebieCreateVMExts
	{
		public static Freebie ToEntity(this FreebieCreateVM vm)
		{
			return new Freebie
			{
				Name = vm.Name,
				Brand = vm.Brand,
				Price = vm.Price,
				ShortDescription = vm.ShortDescription,
				Thumbnail = vm.Thumbnail,
				Inventory = vm.Inventory,
				CreatedAt = vm.CreatedAt,
				UpdatedTime = vm.UpdatedTime,
			};
		}
	}
}