using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bump.EStore.Infrastructure.Infra
{
	public class Result
	{
		public bool IsSuccess { get; private set; }
		public bool IsFail
		{
			get
			{
				return !IsSuccess;
			}
		}

		public string ErrorMessage { get; set; }

		public static Result Success() => new Result { IsSuccess = true, ErrorMessage = null };

		public static Result Fail(string errorMessage) => new Result { IsSuccess = false, ErrorMessage = errorMessage };

	}
}
