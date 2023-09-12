using Bump.EStore.Infrastructure.Data.EFModels;
using Bump.EStore.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Bump.EStore.Infrastructure.Repositories.EFRepositories
{
	public class TrendingQuestionTypeRepository : RepositoryBase<TrendingQuestionType>, ITrendingQuestionTypeRepository
	{
        public TrendingQuestionTypeRepository() : base()
        {
            
        }

		public override IEnumerable<TrendingQuestionType> GetAll()
		{
			return _db.TrendingQuestionTypes
				.Include(ts => ts.TrendingQuestions)
				.AsNoTracking()
				.AsEnumerable();
		}

		public int Update(TrendingQuestionType entity)
		{
			var entityInDb = _db.Set<TrendingQuestionType>().Find(entity.Id);
			_db.Entry(entityInDb).CurrentValues.SetValues(entity);

			return _db.SaveChanges();
		}
	}
}
