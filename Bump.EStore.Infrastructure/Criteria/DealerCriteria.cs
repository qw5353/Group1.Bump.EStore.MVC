using Bump.EStore.Infrastructure.Data.EFModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Bump.EStore.Infrastructure.Criteria
{
	public class DealerCriteria
	{
		[StringLength(200)]
		public string Name { get; set; }

		[StringLength(20)]
		public string PhoneNumber { get; set; }

		[StringLength(320)]
		public string Email { get; set; }

		[StringLength(320)]
		public string Address { get; set; }

		[StringLength(50)]
		public string Country { get; set; }
	}

	public static class DealerCriteriaExts
	{
		public static IQueryable<Dealer> WithCriteria(this IQueryable<Dealer> query, DealerCriteria criteria)
		{
			if (!string.IsNullOrEmpty(criteria.Name))
			{
				query = query.Where(d => d.Name.Contains(criteria.Name));
			}
			if (!string.IsNullOrEmpty(criteria.PhoneNumber))
			{
				query = query.Where(d => d.PhoneNumber.Contains(criteria.PhoneNumber));
			}
			if (!string.IsNullOrEmpty(criteria.Email))
			{
				query = query.Where(d => d.Email.Contains(criteria.Email));
			}
			if (!string.IsNullOrEmpty(criteria.Address))
			{
				query = query.Where(d => d.Address.Contains(criteria.Address));

			}
			if (!string.IsNullOrEmpty(criteria.Country))
			{
				query = query.Where(d => d.Country.Contains(criteria.Country));
			}

			return query;
		}
	}
}
