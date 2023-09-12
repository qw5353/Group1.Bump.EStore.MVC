using Bump.EStore.Core.Dtos.ContactUs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bump.EStore.MVC.ViewModels.ContactUs
{
	public class ContactUsIndexVM
	{
		public int Id { get; set; }

		[Required]
		[StringLength(50)]
		[Display(Name = "姓名")]
		public string Name { get; set; }

		[StringLength(20)]
		[Display(Name = "電話")]
		public string PhoneNumber { get; set; }

		[StringLength(320)]
		public string Email { get; set; }

		[Required]
		[StringLength(100)]
		[Display(Name = "主旨")]
		public string Subject { get; set; }

		[Required]
		[StringLength(2000)]
		[Display(Name = "內容")]
		public string Inquiry { get; set; }

		[Required]
		[StringLength(15)]
		[Display(Name = "狀態")]
		public string Status { get; set; }
	}

	public static class ContactUsIndexVMExts
	{
		public static ContactUsIndexVM ToIndexVM(this ContactUsIndexDto dto)
		{
			return new ContactUsIndexVM
			{
				Id = dto.Id,
				Name = dto.Name,
				PhoneNumber = dto.PhoneNumber,
				Email = dto.Email,
				Subject = dto.Subject,
				Inquiry = dto.Inquiry,
				Status = dto.Status,
			};
		}
	}
}