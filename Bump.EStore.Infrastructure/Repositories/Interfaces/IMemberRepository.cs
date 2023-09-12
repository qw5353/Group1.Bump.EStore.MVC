using Bump.EStore.Infrastructure.Data.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bump.EStore.Infrastructure.Repositories.Interfaces
{
	public interface IMemberRepository
	{
		IEnumerable<Member> Search();
		//IEnumerable<Member> Search(MemberCriteria criteria);
		Member GetMember(int id);
		int Update(Member entity);
		
	}
}
