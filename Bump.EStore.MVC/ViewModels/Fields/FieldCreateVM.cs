using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Bump.EStore.MVC.ViewModels
{
	public class FieldCreateVM
	{
		[Display(Name = "場館編號")]
		[Required]
		public int Id { get; set; }

		[Display(Name = "連絡電話")]
		//Required]
		[RegularExpression(@"^[0-9]{2}-[0-9]*$", ErrorMessage = "請輸入以0開頭並只包含數字的電話號碼")]

		public string PhoneNumber { get; set; }

		[Display(Name = "場館地址")]
		[Required]

		public string Address { get; set; }
		[Display(Name = "場館類型是否為室內館")]
		[Required]

		public bool Indoor { get; set; }
		
		
		[Display(Name = "場館圖片")]
	

		public string Thumbnail { get; set; }

		[Display(Name = "場館簡介")]
		[Required]
		public string ShortDescription { get; set; }


		[Display(Name = "場館網址")]
		[Required]
		public string Link { get; set; }

		[Display(Name = "場館名稱")]
		[Required]
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



		[Display(Name = "禁用日起始時間")]
		[DataType(DataType.Time)]
		[RegularExpression(@"^$|^([0-1]?[0-9]|2[0-3]):[0-5][0-9]$", ErrorMessage = "時間格式不正確")]
		public string BanStartDateTime { get; set; }

		[Display(Name = "禁用日結束時間")]
		[DataType(DataType.Time)]
		[RegularExpression(@"^$|^([0-1]?[0-9]|2[0-3]):[0-5][0-9]$", ErrorMessage = "時間格式不正確")]
		public string BanEndDateTime { get; set; }
		[Required]
		[Display(Name = "每週幾不可使用")]
		public int Weekday { get; set; }
    }
}