using Bump.EStore.Core.Dtos.Dealers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Bump.EStore.MVC.ViewModels.Dealers
{
	public class DealerCriteriaVM
	{
		[StringLength(200)]
		[Display(Name = "名稱")]
		public string Name { get; set; }

		[StringLength(20)]
		[Display(Name = "電話")]
		public string PhoneNumber { get; set; }

		[StringLength(320)]
		public string Email { get; set; }

		[StringLength(320)]
		[Display(Name = "地址")]
		public string Address { get; set; }

		[StringLength(50)]
		[Display(Name = "國籍")]
		public string Country { get; set; }
	}

	public static class DealerCriteriaVMExts
	{
		public static DealerCriteriaDto ToDto(this DealerCriteriaVM vm)
		{
			return new DealerCriteriaDto
			{
				Name = vm.Name,
				PhoneNumber = vm.PhoneNumber,
				Email = vm.Email,
				Address = vm.Address,
				Country = vm.Country,
			};
		}
	}
}