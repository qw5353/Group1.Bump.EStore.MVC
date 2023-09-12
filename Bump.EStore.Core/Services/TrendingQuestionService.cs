using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bump.EStore.Core.Dtos;
using Bump.EStore.Core.Specifications;
using Bump.EStore.Infrastructure;
using Bump.EStore.Infrastructure.Data.EFModels;
using Bump.EStore.Infrastructure.Repositories.DapperRepositories;
using Bump.EStore.Infrastructure.Repositories.Interfaces;

namespace Bump.EStore.Core.Services
{
	public class TrendingQuestionService
	{
		private ITrendingQuestionRepository _repo;
		public TrendingQuestionService()
		{
			_repo = new TrendingQuestionRepository();
		}
		// 測試時可抽換
		public TrendingQuestionService(ITrendingQuestionRepository repo)
		{
			_repo = repo;
		}

		public IEnumerable<TrendingQuestionIndexDto> Search(TrendingQuestionCriteriaDto dto, int pageNumber, int rowsPerPage)
		{
			var rows = _repo
						.Search(pageNumber, rowsPerPage, dto.ToCriteria())
						.Select(q => q.ToDto())
						.ToList();

			return rows;
		}

		public int Count(TrendingQuestionCriteriaDto dto) => _repo.Count(dto.ToCriteria());
		public int Delete(int id) => _repo.Delete(id);
		public IEnumerable<TrendingQuestionTypeDto> GetQuestionTypes() =>
			_repo
			.GetQuestionTypes()
			.Select(entity => entity.ToDto());

		public int Create(TrendingQuestionCreateDto dto)
		{
			return _repo.Create(dto.ToEntity());
		}

		public TrendingQuestionEditDto GetById(int id)
		{
			return _repo.GetById(id).ToEditDto();
		}

		public int Update(TrendingQuestionEditDto dto)
		{
			return _repo.Update(dto.ToEntity());
		}
	}
}
