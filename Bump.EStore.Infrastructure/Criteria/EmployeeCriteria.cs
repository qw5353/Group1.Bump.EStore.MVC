using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bump.EStore.Infrastructure.Criteria
{
	public class EmployeeCriteria
	{
		public int? Id { get; set; }
		public string Search { get; set; }
        public string Role { get; set; }
    }
}
