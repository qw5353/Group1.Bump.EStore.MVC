using Bump.EStore.Core.Dtos.Dealers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bump.EStore.MVC.ViewModels.Dealers
{
	public class DealerEditVM
	{
		public int Id { get; set; }

		[Required]
		[StringLength(200)]
		public string Name { get; set; }

		[Required]
		[StringLength(20)]
		public string PhoneNumber { get; set; }

		[Required]
		[StringLength(320)]
		public string Email { get; set; }

		[Required]
		[StringLength(320)]
		public string Address { get; set; }

		[Required]
		[StringLength(50)]
		public string Country { get; set; }
	}

	public static class DealerEditVMExts
	{
		public static DealerEditVM ToVM(this DealerIndexDto dto)
		{
			return new DealerEditVM
			{
				Id = dto.Id,
				Name = dto.Name,
				PhoneNumber = dto.PhoneNumber,
				Email = dto.Email,
				Address = dto.Address,
				Country = dto.Country,
			};
		}

		public static DealerEditDto ToDto(this DealerEditVM vm)
		{
			return new DealerEditDto
			{
				Id = vm.Id,
				Name = vm.Name,
				PhoneNumber = vm.PhoneNumber,
				Email = vm.Email,
				Address = vm.Address,
				Country = vm.Country,
			};
		}
	}
}