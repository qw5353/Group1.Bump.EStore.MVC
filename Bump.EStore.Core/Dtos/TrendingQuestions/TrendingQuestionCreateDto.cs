using Bump.EStore.Infrastructure.Data.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Bump.EStore.Core.Dtos
{ 
	public class TrendingQuestionCreateDto
	{ 
		public int QuestionTypeId { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
	}

	public static class TrendingQuestionCreateDtoExts
	{
		public static TrendingQuestion ToEntity(this TrendingQuestionCreateDto dto)
		{
			return new TrendingQuestion
			{
				Id = 0,
				QuestionTypeId = dto.QuestionTypeId,
				Title = dto.Title,
				Description = dto.Description,
			};
		}
	}
}
