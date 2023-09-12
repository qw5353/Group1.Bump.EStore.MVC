using Bump.EStore.Core.Dtos;
using Bump.EStore.Core.Dtos.Activities;
using Bump.EStore.Infrastructure.Data.EFModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Bump.EStore.MVC.ViewModels.Activities
{
	public class ActivityCreateVM
	{
		public string Status { get; set; }

		[Display(Name = "名稱")]
		[Required]
		public string Name { get; set; }

		[Display(Name = "開始時間")]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
		[Column(TypeName = "DateTime")]
		[Required]
		public DateTime StartTime { get; set; }

		[Display(Name = "結束時間")]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
		[Column(TypeName = "DateTime")]
		[Required]
		public DateTime EndTime { get; set; }

		[Display(Name = "活動敘述")]
		[Required]
		public string Description { get; set; }

		[Display(Name = "宣傳圖片")]
		public string Thumbnail { get; set; }

		[Display(Name = "創建時間")]
		public DateTime CreatedTime { get; set; }
	}

	public static class ActivityCreateVMExts
	{
		public static ActivityCreateDto ToDto(this ActivityCreateVM vm)
		{
			return new ActivityCreateDto
			{
				Name = vm.Name,
				Status = vm.Status,
				StartTime = vm.StartTime,
				EndTime = vm.EndTime,
				Description = vm.Description,
				Thumbnail = vm.Thumbnail,
				CreatedTime = vm.CreatedTime
			};
		}
	}
}