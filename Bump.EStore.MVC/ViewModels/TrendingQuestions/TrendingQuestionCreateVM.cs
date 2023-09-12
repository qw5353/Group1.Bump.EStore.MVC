using Bump.EStore.Core.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bump.EStore.MVC.ViewModels
{
	public class TrendingQuestionCreateVM
	{
		[Required]
		[Display(Name = "問題種類")]
		public int QuestionTypeId { get; set; }

		[Required]
		[StringLength(200)]
		[Display(Name = "問題標題")]
		public string Title { get; set; }

		[Required]
		[StringLength(2000)]
		[Display(Name = "問題描述")]
		public string Description { get; set; }
	}

	public static class TrendingQuestionCreateVMExts {
		public static TrendingQuestionCreateDto ToDto(this TrendingQuestionCreateVM vm) 
		{
			return new TrendingQuestionCreateDto
			{
				QuestionTypeId = vm.QuestionTypeId,
				Title = vm.Title,
				Description = vm.Description,
			};
		}
	}
}