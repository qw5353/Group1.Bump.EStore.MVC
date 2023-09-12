using Bump.EStore.Infrastructure.Data.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bump.EStore.Core.Dtos.Employees
{
	public class RegisterDto
	{
		public string Img { get; set; }

		public string Name { get; set; }

		public string Account { get; set; }

		public string Password { get; set; }
		public string Role { get; set; }
	}

	public static class RegisterExt
	{
		public static Employee ToRegisterEntity(this RegisterDto dto)
		{
			return new Employee
			{
				Img = dto.Img,
				Name = dto.Name,
				Account = dto.Account,
				Password = dto.Password,
				Role = dto.Role,
			};
		}
	}
}
