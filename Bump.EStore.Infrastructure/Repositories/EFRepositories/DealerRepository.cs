using Bump.EStore.Infrastructure.Criteria;
using Bump.EStore.Infrastructure.Data.EFModels;
using Bump.EStore.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bump.EStore.Infrastructure.Repositories.EFRepositories
{
	public class DealerRepository : RepositoryBase<Dealer>, IDealerRepository
	{
		public DealerRepository() : base()
		{

		}

		public IEnumerable<Dealer> Search(DealerCriteria criteria)
		{
			return _db.Dealers
				.WithCriteria(criteria)
				.AsNoTracking()
				.AsEnumerable();
		}

		public int Update(Dealer dealer)
		{
			Dealer dealerInDb = _db.Dealers.Find(dealer.Id);
			
			if (dealerInDb == null)
			{
				return 0;
			}

			_db.Entry(dealerInDb).CurrentValues.SetValues(dealer);

			return _db.SaveChanges();
		}
	}
}
