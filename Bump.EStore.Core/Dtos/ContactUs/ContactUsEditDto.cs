using Bump.EStore.Infrastructure.Data.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Bump.EStore.Core.Dtos.ContactUs
{
	public class ContactUsEditDto
	{
		public int Id { get; set; }
		public string Status { get; set; }
	}

	public static class ContactUsEditDtoExts
	{
		public static ContactU ToEntity(this ContactUsEditDto dto)
		{
			return new ContactU
			{
				Id = dto.Id,
				Status = dto.Status
			};
		}

		public static ContactUsEditDto ToEditDto(this ContactU entity)
		{
			return new ContactUsEditDto
			{
				Id = entity.Id,
				Status = entity.Status
			};
		}
	}
}
