using Bump.EStore.Infrastructure.Data.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Bump.EStore.Core.Dtos
{
	public class TrendingQuestionEditDto
	{
			public int Id { get; set; }
			public int QuestionTypeId { get; set; }

			public string Title { get; set; }
			public string Description { get; set; }
	}
	
	public static class TrendingQuestionEditDtoExts
	{
		public static TrendingQuestion ToEntity(this TrendingQuestionEditDto dto)
		{
			return new TrendingQuestion
			{
				Id = dto.Id,
				QuestionTypeId = dto.QuestionTypeId,
				Title = dto.Title,
				Description = dto.Description,
			};
		}

		public static TrendingQuestionEditDto ToEditDto(this TrendingQuestion entity)
		{
			return new TrendingQuestionEditDto
			{
				Id = entity.Id,
				QuestionTypeId = entity.QuestionTypeId,
				Title = entity.Title,
				Description = entity.Description,
			};
		}
	}
}
