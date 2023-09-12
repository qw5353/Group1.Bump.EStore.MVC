using Bump.EStore.Infrastructure.Criteria;
using Bump.EStore.Infrastructure.Data.EFModels;
using Bump.EStore.Infrastructure.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bump.EStore.Infrastructure.Repositories.Interfaces
{
	public interface IActivityRepository
	{
		IEnumerable<Activity> Search(ActivityCriteria criteria);
		IEnumerable<Activity> Search(int id);

		IEnumerable<ActivityDetail> Search();
		void Create(Activity entity);
	}

}
