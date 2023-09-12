using Bump.EStore.Infrastructure.Criteria;
using Bump.EStore.Infrastructure.Data.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bump.EStore.Infrastructure.Repositories.Interfaces
{
	public interface IContactUsRepository
	{
		int Add(ContactU entity);
		int Delete(int id);
		IEnumerable<ContactU> GetAll(ContactUsCriteria criteria);
		ContactU GetById(int id);
		int Update(ContactU contact);
	}
}
