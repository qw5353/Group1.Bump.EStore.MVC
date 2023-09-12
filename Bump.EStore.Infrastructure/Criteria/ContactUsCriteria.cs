using Bump.EStore.Infrastructure.Data.EFModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Bump.EStore.Infrastructure.Criteria
{
	public class ContactUsCriteria
	{
		[StringLength(50)]
		public string Name { get; set; }

		[StringLength(20)]
		public string PhoneNumber { get; set; }

		[StringLength(320)]
		public string Email { get; set; }
		[StringLength(15)]
		public string Status { get; set; }
	}

	public static class ContactUsCriteriaExts
	{
		public static IQueryable<ContactU> WithCriteria(this IQueryable<ContactU> query, ContactUsCriteria criteria)
		{
			if (!string.IsNullOrWhiteSpace(criteria.Name))
			{
				query = query.Where(x => x.Name.Contains(criteria.Name));
			}

			if (!string.IsNullOrWhiteSpace(criteria.Email))
			{
				query = query.Where(x => x.Email.Contains(criteria.Email));
			}

			if (!string.IsNullOrWhiteSpace(criteria.PhoneNumber))
			{
				query = query.Where(x => x.PhoneNumber.Contains(criteria.PhoneNumber));
			}

			if (!string.IsNullOrWhiteSpace(criteria.Status))
			{
				query = query.Where(x => x.Status.Equals(criteria.Status));
			}

			return query;
		}
	}
}
