using Bump.EStore.Infrastructure.Criteria;
using Bump.EStore.Infrastructure.Data.EFModels;
using Bump.EStore.Infrastructure.Infra;
using Bump.EStore.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bump.EStore.Infrastructure.Repositories.EFRepositories
{
	public class ActivityEFRepository : IActivityRepository
	{
		private AppDbContext _db;
		public ActivityEFRepository()
		{
			_db = new AppDbContext();
		}

		public IEnumerable<Activity> Search(int id)
		{
			var query = _db.Activities.AsNoTracking().AsQueryable();

			#region where
			query = query.Where(p => p.Id == id);
			#endregion

			return query
				.OrderBy(a => a.StartTime);
		}


		public IEnumerable<Activity> Search(ActivityCriteria criteria)
		{
			var query = _db.Activities.AsNoTracking().AsQueryable();

			#region where
			if (string.IsNullOrEmpty(criteria.Name) == false)
			{
				query = query.Where(p => p.Name.Contains(criteria.Name));
			}
			if (string.IsNullOrEmpty(criteria.Status) == false)
			{
				query = query.Where(p => p.Status == criteria.Status);
			}
			if (criteria.StartTime != new DateTime(0001, 1, 1, 0, 0, 0))
			{
				query = query.Where(p => p.StartTime > criteria.StartTime);
			}
			if (criteria.EndTime != new DateTime(0001, 1, 1, 0, 0, 0))
			{
				query = query.Where(p => p.EndTime < criteria.EndTime);
			}
			#endregion

			return query
				.OrderBy(a => a.StartTime);
		}

		public IEnumerable<ActivityDetail> Search()
		{
			return _db.ActivityDetails
				.AsNoTracking()
				.OrderBy(a => a.StartTime);
		}


		public void Create(Activity entity)
		{
			_db.Activities.Add(entity);
			_db.SaveChanges();
		}

	}
}
