using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bump.EStore.MVC.ViewModels.BanDates
{
	public class BanDateIndexVM
	{
		[Display(Name ="流水號")]
		public int Id { get; set; }
		[Display(Name = "禁用日起始時間")]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]

		public DateTime BanStartDateTime { get; set; }
		[Display(Name = "場館")]
		public string Field { get; set; }
		[Display(Name = "禁用日結束時間")]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]

		public DateTime BanEndDateTime { get; set; }

	}
}