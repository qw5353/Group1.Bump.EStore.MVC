using Bump.EStore.Infrastructure.Criteria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Bump.EStore.Core.Dtos.Dealers
{
	public class DealerCriteriaDto
	{
		public string Name { get; set; }
		public string PhoneNumber { get; set; }
		public string Email { get; set; }
		public string Address { get; set; }
		public string Country { get; set; }
	}

	public static class DealerCriteriaDtoExts
	{
		public static DealerCriteria ToCriteria(this DealerCriteriaDto dto)
		{
			return new DealerCriteria
			{
				Name = dto.Name,
				PhoneNumber = dto.PhoneNumber,
				Email = dto.Email,
				Address = dto.Address,
				Country = dto.Country,
			};
		}
	}
}
