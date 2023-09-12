using Bump.EStore.Infrastructure.Data.EFModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bump.EStore.Core.Dtos
{
	public class TrendingQuestionTypeDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int QuestionsLength { get; set; }
	}

	public static class TrendingQuestionTypeDtoExts
	{
		public static TrendingQuestionTypeDto ToDto(this TrendingQuestionType entity)
		{
			return new TrendingQuestionTypeDto
			{
				Id = entity.Id,
				Name = entity.Name,
				QuestionsLength = entity.TrendingQuestions.Count(),
			};
		}

		public static TrendingQuestionType ToEntity(this TrendingQuestionTypeDto dto)
		{
			return new TrendingQuestionType
			{
				Id = dto.Id,
				Name = dto.Name
			};
		}
	}
}
