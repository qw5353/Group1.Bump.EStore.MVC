using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Bump.EStore.MVC.ViewModels
{
	public class FieldEditVM
	{
		[Display(Name = "場館編號")]
		public int Id { get; set; }

		[Display(Name = "連絡電話")]
		[RegularExpression(@"^0[0-9]*$", ErrorMessage = "請輸入以0開頭並只包含數字的電話號碼")]

		public string PhoneNumber { get; set; }
		[Display(Name = "場館地址")]

		public string Address { get; set; }
		[Display(Name = "場館類型是否為室內館")]

		public bool Indoor { get; set; }


		[Display(Name = "場館簡介")]
		public string ShortDescription { get; set; }


		[Display(Name = "場館網址")]
		public string Link { get; set; }

		[Display(Name = "場館名稱")]
		public string Name { get; set; }
		[Display(Name = "平日開始時間")]
		[DataType(DataType.Time)]
		[DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]

		public DateTime? BusinessWeekdayStartTime { get; set; }
		[Display(Name = "平日結束時間")]
		[DataType(DataType.Time)]
		[DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]

		public DateTime? BusinessWeekdayEndTime { get; set; }
		[Display(Name = "假日開始時間")]
		[DataType(DataType.Time)]
		[DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]

		public DateTime? BusinessWeekendStartTime { get; set; }
		[Display(Name = "假日結束時間")]
		[DataType(DataType.Time)]
		[DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]

		public DateTime? BusinessWeekendEndTime { get; set; }
	}
}