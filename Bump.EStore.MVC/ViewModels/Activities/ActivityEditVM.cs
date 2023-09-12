using Bump.EStore.Core.Dtos;
using Bump.EStore.Infrastructure.Data.EFModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Bump.EStore.MVC.ViewModels
{
	public class ActivityEditVM
	{
		[Display(Name = "狀態")]
		public string Status { get; set; }

		[Display(Name = "編號")]
		public int Id { get; set; }

		[Display(Name = "名稱")]
		[Required]
		public string Name { get; set; }

		[Display(Name = "開始時間")]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-ddTmm:ss}")]
		[Column(TypeName = "DateTime")]
		[Required]
		public DateTime StartTime { get; set; }

		[Display(Name = "結束時間")]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-ddTmm:ss}")]
		[Column(TypeName = "DateTime")]
		[Required]
		public DateTime EndTime { get; set; }

		[Display(Name = "活動敘述")]
		[Required]
		public string Description { get; set; }


		[Display(Name = "創建時間")]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-ddTmm:ss}")]
		public DateTime CreatedTime { get; set; }
	}
	public static class ActivityEditVMExts
	{

		public static Activity ToEntity(this ActivityEditVM vm) 
		{
			return new Activity
			{
				Id = vm.Id,
				Name = vm.Name,
				Status = vm.Status,
				StartTime = vm.StartTime,
				EndTime = vm.EndTime,
				Description = vm.Description,
				CreatedTime = vm.CreatedTime
			};
		}
	}
}