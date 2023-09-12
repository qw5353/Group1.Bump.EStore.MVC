using Bump.EStore.Infrastructure.Data.EFModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Bump.EStore.MVC.ViewModels.Freebies
{
	public class FreebieEditVM
	{
		public int Id { get; set; }

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

		[Display(Name = "庫存量")]
		public int Inventory { get; set; }

		[Display(Name = "建立時間")]
		public DateTime CreatedAt { get; set; }

		[Display(Name = "更新時間")]
		public DateTime UpdatedTime { get; set; }

	}

	public static class FreebieEditVMExts
	{
		public static FreebieEditVM ToVM(this Freebie entity)
		{
			return new FreebieEditVM
			{
				Id = entity.Id,
				Name = entity.Name,
				Brand = entity.Brand,
				Price = entity.Price,
				ShortDescription = entity.ShortDescription,
				Inventory = entity.Inventory,
				CreatedAt = entity.CreatedAt,
				UpdatedTime = entity.UpdatedTime
			};
		}

		public static Freebie ToEntity(this FreebieEditVM vm)
		{
			return new Freebie
			{
				Id = vm.Id,
				Name = vm.Name,
				Brand = vm.Brand,
				Price = vm.Price,
				ShortDescription = vm.ShortDescription,
				Inventory = vm.Inventory,
				CreatedAt = vm.CreatedAt,
				UpdatedTime = vm.UpdatedTime
			};
		}
	}
}