using Bump.EStore.Infrastructure.Data.EFModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Bump.EStore.Infrastructure.Repositories
{
	public abstract class RepositoryBase<T> where T : class
	{
		protected readonly AppDbContext _db;
		public RepositoryBase()
		{
			_db = new AppDbContext();
		}

		public virtual int Add(T entity)
		{
			_db.Set<T>().Add(entity);
			return _db.SaveChanges();
		}

		public virtual int Delete(int id)
		{
			var entity = _db.Set<T>().Find(id);

			if (entity != null)
			{
				_db.Set<T>().Remove(entity);
			}

			try
			{
				return _db.SaveChanges();
			}
			catch (Exception ex)
			{
                Console.WriteLine(ex.ToString());
				return 0;
			}
		}

		public virtual T GetById(int id)
		{
			return _db.Set<T>().Find(id);
		}

		public virtual IEnumerable<T> GetAll()
		{
			return _db.Set<T>().AsNoTracking().AsEnumerable();
		}
	}
}
