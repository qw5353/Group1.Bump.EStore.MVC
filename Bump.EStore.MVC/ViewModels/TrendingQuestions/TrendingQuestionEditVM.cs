using Bump.EStore.Core.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bump.EStore.MVC.ViewModels
{
	public class TrendingQuestionEditVM
	{
		[Required]
		public int Id { get; set; }

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

	public static class TrendingQuestionEditVMExts
	{
		public static TrendingQuestionEditDto ToDto(this TrendingQuestionEditVM vm)
		{
			return new TrendingQuestionEditDto
			{
				Id = vm.Id,
				QuestionTypeId = vm.QuestionTypeId,
				Title = vm.Title,
				Description = vm.Description,
			};
		}

		public static TrendingQuestionEditVM ToVM(this TrendingQuestionEditDto dto)
		{
			return new TrendingQuestionEditVM
			{
				Id = dto.Id,
				QuestionTypeId = dto.QuestionTypeId,
				Title = dto.Title,
				Description = dto.Description,
			};
		}
	}
}