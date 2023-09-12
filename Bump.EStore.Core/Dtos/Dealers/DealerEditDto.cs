using Bump.EStore.Infrastructure.Data.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bump.EStore.Core.Dtos.Dealers
{
	public class DealerEditDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string PhoneNumber { get; set; }
		public string Email { get; set; }
		public string Address { get; set; }
		public string Country { get; set; }
	}

	public static class DealerEditDtoExts
	{
		public static Dealer ToEntity(this DealerEditDto dto)
		{
			return new Dealer
			{
				Id = dto.Id,
				Name = dto.Name,
				PhoneNumber = dto.PhoneNumber,
				Email = dto.Email,
				Address = dto.Address,
				Country = dto.Country,
			};
		}
	}
}
