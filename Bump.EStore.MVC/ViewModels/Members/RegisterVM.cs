using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Bump.EStore.MVC.ViewModels.Members
{
	public class RegisterVM
	{
		[Required]
		[Display(Name = "帳號")]
		[StringLength(50)]
		public string Account { get; set; }

		[Required]
		[Display(Name = "密碼")]
		[StringLength(64)]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Required]
		[Display(Name = "確認密碼")]
		[StringLength(64)]
		[DataType(DataType.Password)]
		public string ConfirmPassword { get; set; }

		[Required]
		[Display(Name = "名稱")]
		[StringLength(50)]
		public string Name { get; set; }

		[Display(Name = "暱稱")]
		[StringLength(100)]
		public string Nickname { get; set; }

		[Required]
		[StringLength(320)]
		[EmailAddress]
		public string Email { get; set; }


		[StringLength(50)]
		public string Gender { get; set; }

		[Display(Name = "生日")]
		public DateTime Birthday { get; set; }

		[Display(Name = "手機")]
		public string PhoneNumber { get; set; }

		public bool DMSubscribe { get; set; }


	}
}