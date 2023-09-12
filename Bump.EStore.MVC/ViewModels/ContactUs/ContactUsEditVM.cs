using Bump.EStore.Core.Dtos.ContactUs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Bump.EStore.MVC.ViewModels.ContactUs
{
	public class ContactUsEditVM
	{
		public int Id { get; set; }
		[Required]
		[StringLength(15)]
		[Display(Name = "狀態")]
		public string Status { get; set; }
	}

	public static class ContactUsEditVMExts
	{
		public static ContactUsEditVM ToEditVM(this ContactUsEditDto dto)
		{
			return new ContactUsEditVM
			{
				Id = dto.Id,
				Status = dto.Status,
			};
		}

		public static ContactUsEditDto ToEditDto(this ContactUsEditVM vm)
		{
			return new ContactUsEditDto
			{
				Id = vm.Id,
				Status = vm.Status,
			};
		}
	}
}