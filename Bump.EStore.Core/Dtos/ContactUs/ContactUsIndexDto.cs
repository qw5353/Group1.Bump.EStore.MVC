using Bump.EStore.Infrastructure.Data.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bump.EStore.Core.Dtos.ContactUs
{
	public class ContactUsIndexDto
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string PhoneNumber { get; set; }

		public string Email { get; set; }

		public string Subject { get; set; }

		public string Inquiry { get; set; }

		public string Status { get; set; }
	}

	public static class ContactUsIndexDtoExts
	{
		public static ContactUsIndexDto ToDto(this ContactU entity)
		{
			return new ContactUsIndexDto
			{
				Id = entity.Id,
				Name = entity.Name,
				PhoneNumber = entity.PhoneNumber,
				Email = entity.Email,
				Subject = entity.Subject,
				Inquiry = entity.Inquiry,
				Status = entity.Status,
			};
		}
	}
}
