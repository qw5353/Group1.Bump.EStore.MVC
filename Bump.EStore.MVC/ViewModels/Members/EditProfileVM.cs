using Bump.EStore.Core.Dtos.Members;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Xml.Linq;

namespace Bump.EStore.MVC.ViewModels.Members
{
	public class EditProfileVM
	{
		public int Id { get; set; }

		[Display(Name = "帳號")]
		public string Account { get; set; }

		[Display(Name = "姓名")]
		public string Name { get; set; }

		[Display(Name = "暱稱")]
		public string Nickname { get; set; }

		[Display(Name = "會員等級")]
		public int MemberLevelOrder { get; set; }

		[Display(Name = "紅利點數")]
		public int Points { get; set; }

		[DataType(DataType.EmailAddress)]
		[Display(Name = "信箱")]
		public string Email { get; set; }

		[Display(Name = "性別")]
		public string Gender { get; set; }

		[Display(Name = "生日")]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
		[DataType(DataType.Date)]
		public DateTime Birthday { get; set; }

		[Display(Name = "手機號碼")]
		public string PhoneNumber { get; set; }

		[Display(Name = "電子報訂閱")]
		public bool DMSubscribe { get; set; }

		[Display(Name = "會員認證")]
		public bool IsConfirm { get; set; }

	}

	public static class MemberProfile
	{
		public static EditProfileVM ToEditProfileVM(this EditProfileDto dto)
		{
			return new EditProfileVM
			{
				Id = dto.Id,
				Account = dto.Account,
				Name = dto.Name,
				Nickname = dto.Nickname,
				MemberLevelOrder = dto.MemberLevelOrder,
				Points = dto.Points,
				Email = dto.Email,
				Gender = dto.Gender,
				Birthday = dto.Birthday,
				PhoneNumber = dto.PhoneNumber,
				DMSubscribe = dto.DMSubscribe,
				IsConfirm = dto.IsConfirm,
			};
		}

		public static EditProfileDto ToEditProfileDto(this EditProfileVM vm)
		{
			return new EditProfileDto
			{
				Id = vm.Id,
				Account = vm.Account,
				Name = vm.Name,
				Nickname = vm.Nickname,
				MemberLevelOrder = vm.MemberLevelOrder,
				Points = vm.Points,
				Email = vm.Email,
				Gender = vm.Gender,
				Birthday = vm.Birthday,
				PhoneNumber = vm.PhoneNumber,
				DMSubscribe = vm.DMSubscribe,
				IsConfirm = vm.IsConfirm,
			};
		}
	}
}