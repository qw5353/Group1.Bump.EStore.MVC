using Bump.EStore.Core.Dtos;
using Bump.EStore.Core.Dtos.Members;
using Bump.EStore.Infrastructure.Data.EFModels;
using Bump.EStore.Infrastructure.Repositories.DapperRepositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bump.EStore.MVC.ViewModels
{
    public class MemberIndexVM
    {
        public int Id { get; set; }

        [Display(Name = "帳號")]
        public string Account { get; set; }

        [Display(Name = "姓名")]
		public string Name { get; set; }

        [Display(Name = "暱稱")]
		public string Nickname { get; set; }

		[Display(Name = "會員等級")]
		public string MemberLevel { get; set; }

        [Display(Name = "紅利點數")]
		public int Points { get; set; }

		[Display(Name = "大頭照")]
		public string Thumbnail { get; set; }

		[Display(Name = "信箱")]
		public string Email { get; set; }

		[Display(Name = "性別")]
		public string Gender { get; set; }

		[Display(Name = "生日")]
		[DataType(DataType.Date)]
		public DateTime Birthday { get; set; }

        [Display(Name = "手機號碼")]
        public string PhoneNumber { get; set; }

		[Display(Name = "電子報訂閱")]
		public bool DMSubscribe { get; set; }
		[Display(Name = "會員標籤")]
		public string MemberTag { get; set; }

		[Display(Name = "更新時間")]
		public DateTime LastModified { get; set; }

		[Display(Name = "會員認證")]
		public bool IsConfirm { get; set; }
	}


	public static class MemberIndexVMExts
	{
		public static MemberIndexVM ToMemberIndexVM(this MemberIndexEntity entity)
		{
			return new MemberIndexVM
			{
				Id = entity.Id,
				Account = entity.Account,
				Name = entity.MemberName,
				Nickname = entity.Nickname,
				MemberLevel = entity.MemberLevel,
				Points = entity.Points,
				Thumbnail = entity.Thumbnail,
				Email = entity.Email,
				Gender = entity.Gender,
				Birthday = entity.Birthday,
				PhoneNumber = entity.PhoneNumber,
				DMSubscribe = entity.DMSubscribe,
				MemberTag = entity.MemberTag,
				LastModified = entity.LastModified,
				IsConfirm = entity.IsConfirm
			};
		}

	}


}