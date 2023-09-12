using Bump.EStore.Core.Dtos;
using Bump.EStore.Infrastructure.Data.EFModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bump.EStore.MVC.ViewModels
{
	public class ActivityIndexVM
	{
		[Display(Name="狀態")]
		public string Status { get; set; }

		[Display(Name="編號")]
		public int Id { get; set; }

		[Display(Name = "名稱")]
		public string Name { get; set; }

		[Display(Name="開始時間")]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
		public DateTime StartTime { get; set; }

		[Display(Name = "結束時間")]
		//[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm}")]

		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			if (StartTime >= EndTime)
			{
				yield return new ValidationResult("開始時間必須小於結束時間", new[] { nameof(StartTime), nameof(EndTime) });
			}
		}

		public DateTime EndTime { get; set; }

		[Display(Name = "活動敘述")]
		public string Description { get; set; }

		//[Display(Name="宣傳圖片")]
		//public string Thumbnail { get; set; }

		[Display(Name = "創建時間")]
		public DateTime CreatedTime { get; set; }
	}
	public static class ActivityIndexVMExts
	{
		public static ActivityIndexVM ToVM(this ActivityIndexDto dto)
		{
			return new ActivityIndexVM
			{
				Id = dto.Id,
				Name = dto.Name,
				Status = dto.Status,
				StartTime = dto.StartTime,
				EndTime = dto.EndTime,
				Description = dto.Description,
				//Thumbnail = dto.Thumbnail,
				CreatedTime = dto.CreatedTime
			};
		}
	}
}