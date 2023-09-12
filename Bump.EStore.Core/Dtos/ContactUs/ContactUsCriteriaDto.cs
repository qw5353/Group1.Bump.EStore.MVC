using Bump.EStore.Infrastructure.Criteria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bump.EStore.Core.Dtos.ContactUs
{
	public class ContactUsCriteriaDto
	{
		public string Name { get; set; }

		public string PhoneNumber { get; set; }

		public string Email { get; set; }
		public string Status { get; set; }
	}

	public static class ContactUsCriteriaExts
	{
		public static ContactUsCriteria ToCriteria(this ContactUsCriteriaDto dto)
		{
			return new ContactUsCriteria
			{
				Name = dto.Name,
				PhoneNumber = dto.PhoneNumber,
				Email = dto.Email,
				Status = dto.Status,
			};
		}
	}
}
