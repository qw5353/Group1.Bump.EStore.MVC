using Bump.EStore.Infrastructure.Data.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Bump.EStore.Core.Dtos.Dealers
{
	public class DealerIndexDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string PhoneNumber { get; set; }
		public string Email { get; set; }
		public string Address { get; set; }
		public string Country { get; set; }
	}

	public static class DealerIndexDtoExts
	{
		public static DealerIndexDto ToDto(this Dealer entity)
		{
			return new DealerIndexDto
			{
				Id = entity.Id,
				Name = entity.Name,
				PhoneNumber = entity.PhoneNumber,
				Email = entity.Email,
				Address = entity.Address,
				Country = entity.Country,
			};
		}
	}
}
