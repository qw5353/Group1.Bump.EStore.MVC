using Bump.EStore.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bump.EStore.MVC.ViewModels 
{ 
	public class TrendingQuestionCriteriaVM
	{
        public int? TypeId { get; set; }
		public string Title { get; set; }
    }

	public static class TrendingQuestionCriteriaVMExts
	{
		public static TrendingQuestionCriteriaDto ToDto(this TrendingQuestionCriteriaVM vm)
		{
			return new TrendingQuestionCriteriaDto
			{
				TypeId = vm.TypeId,
				Title = vm.Title,
			};
		}
	}
}