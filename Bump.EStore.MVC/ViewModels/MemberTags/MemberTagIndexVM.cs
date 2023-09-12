using Bump.EStore.Infrastructure.Repositories.DapperRepositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bump.EStore.MVC.ViewModels.MemberTags
{
	public class MemberTagIndexVM
	{
		[Display(Name="標籤編號")]
		public int Id { get; set; }

		[Required]
		[Display(Name="標籤名稱")]
		public string TagName { get; set; }

		[Display(Name="標籤註記")]
		public string Description { get; set; }

		[Required]
		[Display(Name="條件名稱")]
		public string ConditionName { get; set; }

		[Display(Name="運算式")]
		public string Operator { get; set; }

		[Display(Name="條件值")]
		public decimal Value { get; set; }

		[Required]
		[Display(Name="單位")]
		public string Unit { get; set; }
	}

	public static class MemberTagIndexExt
	{
        public static MemberTagIndexVM ToMemberTagIndexVM(this MemberTagEntity entity)
        {
            return new MemberTagIndexVM
            {
                Id = entity.Id,
                TagName = entity.TagName,
                Description = entity.Description,
                ConditionName = entity.ConditionName,
                Operator = entity.Operator,
                Value = entity.Value,
                Unit = entity.Unit
            };
        }
    }
}