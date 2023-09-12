using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bump.EStore.Infrastructure.Criteria
{
	public class MemberCriteria
	{
		public string Search { get; set; }
		public int? MemberLevel { get; set; }
		public int? MemberTag { get; set; }
	}

}
