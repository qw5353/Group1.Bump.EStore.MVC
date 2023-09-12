using Bump.EStore.Core.Dtos;
using Bump.EStore.Infrastructure.Repositories.EFRepositories;
using Bump.EStore.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bump.EStore.Core.Services
{
	public class TrendingQuestionTypeService
	{
        private readonly ITrendingQuestionTypeRepository _repo;
        public TrendingQuestionTypeService()
        {
            _repo = new TrendingQuestionTypeRepository();
        }

		public TrendingQuestionTypeService(ITrendingQuestionTypeRepository repo)
		{
			_repo = repo;
		}

		public IEnumerable<TrendingQuestionTypeDto> GetAll()
		{
			return _repo.GetAll().Select(t => t.ToDto());
		}

		public int Add(TrendingQuestionTypeDto dto)
		{
			return _repo.Add(dto.ToEntity());
		}

		public int Delete(int id)
		{
			return _repo.Delete(id);
		}

		public TrendingQuestionTypeDto GetById(int id)
		{
			return _repo.GetById(id).ToDto();
		}

		public int Update(TrendingQuestionTypeDto dto)
		{
			return _repo.Update(dto.ToEntity());
		}
	}
}
