using Bump.EStore.Infrastructure.Data.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bump.EStore.Core.Dtos
{
    public class TrendingQuestionIndexDto
    {
        public int Id { get; set; }
        public string QuestionTypeName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }

    public static class TrendingQuestionDtoExts
    {
        public static TrendingQuestionIndexDto ToDto(this TrendingQuestion entity)
        {
            return new TrendingQuestionIndexDto
            {
                Id = entity.Id,
                QuestionTypeName = entity.TrendingQuestionType.Name,
                Title = entity.Title,
                Description = entity.Description
            };
        }
    }
}
