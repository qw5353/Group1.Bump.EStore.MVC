using Bump.EStore.Core.Dtos.Employees;
using Bump.EStore.Core.Infra;
using Bump.EStore.Infrastructure.Infra;
using Bump.EStore.Infrastructure.Repositories.EFRepositories;
using Bump.EStore.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bump.EStore.Core.Services
{
	public class EmployeeService

	{
		IEmployeeRepository _repo;
		public EmployeeService(IEmployeeRepository repo) 
		{ 
			_repo = repo;
		}

		public Result Register(RegisterDto dto)
		{
			if (_repo.ExistAccount(dto.Account)) return Result.Fail($"帳號{dto.Account}已存在, 請更換再試一次!");

			var salt = HashUtility.GetSalt();
			var hashPassword = HashUtility.ToSHA256(dto.Password, salt);

			dto.Password = hashPassword;

			_repo.Register(dto.ToRegisterEntity());

			return Result.Success();
		}

	}
}
