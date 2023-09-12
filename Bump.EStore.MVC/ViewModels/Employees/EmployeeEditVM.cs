using Bump.EStore.Infrastructure.Data.EFModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bump.EStore.MVC.ViewModels.Employees
{
	public class EmployeeEditVM
	{
		[Display(Name="姓名")]
		public string Name { get; set; }

		[Required]
		[Display(Name="帳號")]
		public string Account { get; set; }

		[Required]
		[Display(Name = "角色")]
		public string Role { get; set; }

	}

	public static class EmployeeExt
	{
		public static Employee ToEditEntity(this EmployeeEditVM vm)
		{
			return new Employee
			{
				Name = vm.Name,
				Account = vm.Account,
				Role = vm.Role
			};
		}

		public static EmployeeEditVM ToEditVM(this Employee entity)
		{
			return new EmployeeEditVM
			{
				Name = entity.Name,
				Account = entity.Account,
				Role = entity.Role
			};
		}
	}
}