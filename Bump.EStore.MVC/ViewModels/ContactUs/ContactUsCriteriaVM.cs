using Bump.EStore.Core.Dtos.ContactUs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Bump.EStore.MVC.ViewModels.ContactUs
{
	public class ContactUsCriteriaVM
	{
		[StringLength(50)]
		public string Name { get; set; }  

		[StringLength(20)]
		public string PhoneNumber { get; set; }

		[StringLength(320)]
		public string Email { get; set; }
		[StringLength(15)]
		public string Status { get; set; } = "處理中";
	}

	public static class ContactUsCriteriaVMExts
	{
		public static ContactUsCriteriaDto ToDto(this ContactUsCriteriaVM vm)
		{
			return new ContactUsCriteriaDto
			{
				Name = vm.Name,
				PhoneNumber = vm.PhoneNumber,
				Email = vm.Email,
				Status = vm.Status,
			};
		}
	}
}