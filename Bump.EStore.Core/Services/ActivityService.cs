using Bump.EStore.Core.Dtos;
using Bump.EStore.Core.Dtos.Activities;
using Bump.EStore.Infrastructure.Criteria;
using Bump.EStore.Infrastructure.Infra;
using Bump.EStore.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bump.EStore.Core.Services
{
	public class ActivityService
	{
		private IActivityRepository _repo;
        public ActivityService(IActivityRepository repo)
        {
            _repo = repo;
        }
		public IEnumerable<ActivityIndexDto> Search(ActivityCriteria criteria)
		{
			return _repo.Search(criteria)
				.ToList()
				.Select(a => a.ToDto());
		}

		public IEnumerable<ActivityIndexDto> Search(int id)
		{
			return _repo.Search(id)
				.ToList()
				.Select(a => a.ToDto());
		}

		public IEnumerable<ActivityDetailIndexDto> Search()
		{
			return _repo.Search()
				.ToList()
				.Select(ad => ad.ToDto());
		}

		public void Create(ActivityCreateDto dto)
		{
			_repo.Create(dto.ToEntity());
		}
	}
}
