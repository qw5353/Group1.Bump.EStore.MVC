using Bump.EStore.Infrastructure.Data.EFModels;
using Bump.EStore.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace Bump.EStore.Infrastructure.Repositories.EFRepositories
{
	public class EmployeeEFRepository : IEmployeeRepository
	{
		private AppDbContext _db = new AppDbContext();

		public bool ExistAccount(string account)
		{
			//return _db.Employees.FirstOrDefault(e => e.Account == account);
			return _db.Employees.Any(e => e.Account == account);
		}

		public void Register(Employee entity)
		{
			_db.Employees.Add(entity);
			_db.SaveChanges();
		}
	}
}
