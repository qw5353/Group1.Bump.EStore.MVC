using Bump.EStore.Infrastructure.Criteria;
using Bump.EStore.Infrastructure.Data.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bump.EStore.Infrastructure.Repositories.Interfaces
{
    public interface ITrendingQuestionRepository
    {
        int Count(TrendingQuestionCriteria criteria);
		int Create(TrendingQuestion entity);
		int Delete(int id);
		TrendingQuestion GetById(int id);
		IEnumerable<TrendingQuestionType> GetQuestionTypes();
		IEnumerable<TrendingQuestion> Search(int pageNumber, int rowsPerPage, TrendingQuestionCriteria criteria);
		int Update(TrendingQuestion trendingQuestion);
	}
}
