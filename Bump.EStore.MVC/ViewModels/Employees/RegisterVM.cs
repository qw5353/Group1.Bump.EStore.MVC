using Bump.EStore.Core.Dtos.Employees;
using Bump.EStore.Infrastructure.Data.EFModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace Bump.EStore.MVC.ViewModels.Employees
{
	public class RegisterVM
	{

		[Display(Name="大頭貼")]
		public string Img { get; set; }

		[Required]
		[Display(Name="姓名")]
		public string Name { get; set; }

		[Required]
		[Display(Name="帳號")]
		public string Account { get; set; }

		[Required]
		[Display(Name="密碼")]
        [DataType(DataType.Password)]
		public string Password { get; set; }

		[Required]
		[Display(Name="確認密碼")]
        [DataType(DataType.Password)]
		public string ConfirmPassword { get; set; }

		[Required]
		[Display(Name="職位")]
		public string Role { get; set; }
	}

	public static class RegisterExt
	{
		public static RegisterDto ToRegisterDto(this RegisterVM vm)
		{
			return new RegisterDto
			{
				Img = vm.Img,
				Name = vm.Name,
				Account = vm.Account,
				Password = vm.Password,
				Role = vm.Role
			};
		}
	}
}