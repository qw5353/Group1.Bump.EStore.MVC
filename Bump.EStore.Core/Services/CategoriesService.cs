using Bump.EStore.Infrastructure.Repositories.DapperRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bump.EStore.Core.Services
{
	public class CategoriesService
	{
		private CategoriesRepository _repo;
		public CategoriesService(CategoriesRepository repo)
		{
			_repo = repo;
		}
	}
}
