using Bump.EStore.Infrastructure.Data.EFModels;
using Bump.EStore.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bump.EStore.Infrastructure.Repositories.EFRepositories
{
	public class MemberRepositories : IMemberRepository
	{
		private AppDbContext _db;
		public MemberRepositories()
		{
			_db = new AppDbContext();
		}

		//public int Delete(int id)
		//{
		//	var memberInDb = _db.Members.Find(id);
		//	_db.Members.Remove(memberInDb);
		//	return _db.SaveChanges();
		//}

		public Member GetMember(int id)
		{
			return _db.Members.Find(id);
		}

		public IEnumerable<Member> Search()
		{
			return _db.Members
				.AsNoTracking()
				.OrderBy(p => p.Id);
		}

		public int Update(Member entity)
		{
			var memberInDb = _db.Members.Find(entity.Id);


			_db.Entry(memberInDb).State = System.Data.Entity.EntityState.Modified;

			memberInDb.Points = entity.Points;
			memberInDb.DMSubscribe = entity.DMSubscribe;
			memberInDb.Birthday = entity.Birthday;
			memberInDb.IsConfirm = entity.IsConfirm;


			return _db.SaveChanges();
		}
	}
}
