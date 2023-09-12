using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Bump.EStore.Core;
using Bump.EStore.Core.Dtos;

namespace Bump.EStore.MVC.ViewModels
{
    public class TrendingQuestionIndexVM
    {
        private int _shortenDescriptionLength = 75;
        public int Id { get; set; }
        public string QuestionTypeName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ShortenDescription => Description.Length > _shortenDescriptionLength ?
            Description.Substring(0, _shortenDescriptionLength) + "..." :
            Description;
    }

    public static class TrendingQuestionIndexVMExts
    {
        public static TrendingQuestionIndexVM ToIndexVM(this TrendingQuestionIndexDto dto)
        {
            return new TrendingQuestionIndexVM
            {
                Id = dto.Id,
                QuestionTypeName = dto.QuestionTypeName,
                Title = dto.Title,
                Description = dto.Description
            };
        }
    }
}