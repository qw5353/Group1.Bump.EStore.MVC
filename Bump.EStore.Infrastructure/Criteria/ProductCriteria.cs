using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bump.EStore.Infrastructure.Criteria
{
	public class ProductCriteria
	{
		public string Name { get; set; }

		public string Code { get; set; }

		public int? FirstCategoryId { get; set; }

		public int? SecondCategoryId { get; set; }

		public int? ThirdCategoryId { get; set; }

		public int? BrandId { get; set; }

		public int? DlearId { get; set; }

		public int? MinPrice { get; set; }

		public int? MaxPrice { get; set; }
	}
}
