using Bump.EStore.Infrastructure.Criteria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bump.EStore.Core.Dtos
{
	public class TrendingQuestionCriteriaDto
	{
		public int? TypeId { get; set; }
		public string Title { get; set; }
	}

	public static class TrendingQuestionCriteriaDtoExts
	{
		public static TrendingQuestionCriteria ToCriteria(this TrendingQuestionCriteriaDto dto)
		{
			return new TrendingQuestionCriteria
			{
				TypeId = dto.TypeId,
				Title = dto.Title,
			};
		}
	}
}
