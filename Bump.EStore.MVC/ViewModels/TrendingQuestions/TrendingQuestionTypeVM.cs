using Bump.EStore.Core.Dtos;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bump.EStore.MVC.ViewModels
{
	public class TrendingQuestionTypeVM
	{
		public int Id { get; set; }
		[Display(Name = "問題種類")]
		[Required]
		[StringLength(100)]
		public string Name { get; set; }
		public int QuestionsLength { get; set; }
	}

	public static class TrendingQuestionTypeVMExts
	{
		public static TrendingQuestionTypeVM ToVM(this TrendingQuestionTypeDto dto)
		{
			return new TrendingQuestionTypeVM
			{
				Id = dto.Id,
				Name = dto.Name,
				QuestionsLength = dto.QuestionsLength,
			};
		}

		public static TrendingQuestionTypeDto ToDto(this TrendingQuestionTypeVM vm)
		{
			return new TrendingQuestionTypeDto
			{
				Id = vm.Id,
				Name = vm.Name,
			};
		}
	}
}