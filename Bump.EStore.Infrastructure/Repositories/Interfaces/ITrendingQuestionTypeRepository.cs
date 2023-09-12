using Bump.EStore.Infrastructure.Data.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bump.EStore.Infrastructure.Repositories.Interfaces
{
	public interface ITrendingQuestionTypeRepository
	{
		int Add(TrendingQuestionType entity);
		int Delete(int id);
		IEnumerable<TrendingQuestionType> GetAll();
		TrendingQuestionType GetById(int id);
		int Update(TrendingQuestionType entity);
	}
}
