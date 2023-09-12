using Bump.EStore.Infrastructure.Criteria;
using Bump.EStore.Infrastructure.Data.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bump.EStore.Infrastructure.Repositories.Interfaces
{
	public interface IDealerRepository
	{
		IEnumerable<Dealer> Search(DealerCriteria criteria);
		int Add(Dealer entity);
		int Delete(int id);
		IEnumerable<Dealer> GetAll();
		Dealer GetById(int id);
		int Update(Dealer dealer);
	}
}
