using Bump.EStore.Infrastructure.Data.EFModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bump.EStore.MVC.ViewModels
{
	public class FieldIndexVM
	{
		[Display(Name = "場館編號")]
		public int Id { get; set; }

		[Display(Name = "連絡電話")]

		public string PhoneNumber { get; set; }

		[Display(Name = "場館地址")]

		public string Address { get; set; }
		
		public bool Indoor { get; set; }
		[Display(Name = "場館類型")]

		public string IndoorText { get
			{
				return this.Indoor == true ? "室內館" : "室外場";
			} }

		[Display(Name = "場館名稱")]
		public string Name { get; set; }
		[Display(Name = "平日開始時間")]
		[DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]

		public DateTime? BusinessWeekdayStartTime { get; set; }
		[Display(Name = "平日結束時間")]
		[DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]

		public DateTime? BusinessWeekdayEndTime { get; set; }
		[Display(Name = "假日開始時間")]
		[DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]

		public DateTime? BusinessWeekendStartTime { get; set; }
		[Display(Name = "平日結束時間")]
		[DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]

		public DateTime? BusinessWeekendEndTime { get; set; }

		public virtual ICollection<BanDate> BanDates { get; set; }
	}
}