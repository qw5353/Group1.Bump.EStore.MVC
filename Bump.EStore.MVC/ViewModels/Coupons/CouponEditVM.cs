using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Bump.EStore.MVC.ViewModels.Coupons
{
	public class CouponEditVM
	{
		public int Id { get; set; }

		[Display(Name = "名稱")]
		[Required]
		public string Name { get; set; }

		[Display(Name = "代碼")]
		[Required]
		public string Code { get; set; }

		public DateTime? PrevTime { get; set; }

		[Display(Name = "開始時間")]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
		[Required]
		public DateTime StartTime { get; set; }

		[Display(Name = "結束時間")]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
		[Required]
		public DateTime EndTime { get; set; }

		[Display(Name = "發送規則 (時間)")]
		public string RepeatRule { get; set; }

		[Display(Name = "發送規則 (次數)")]
		public byte? RepeatNum { get; set; }

		[Display(Name = "活動對象")]
		[Required]
		public int TargetTypeId { get; set; }

		[Display(Name = "商品類型")]
		[Required]
		public int PromotionProductTypeId { get; set; }

		[Display(Name = "狀態")]
		public string Status { get; set; }

		[Display(Name = "消費門檻")]
		[Required]
		public int PriceThreshold { get; set; }

		[Display(Name = "優惠類型")]
		[Required]
		public int CouponTypeId { get; set; }

		[Display(Name = "買X送Y (Y)")]
		public int? DiscountQty { get; set; }

		[Display(Name = "數量")]
		public decimal? Amount { get; set; }

		[Display(Name = "贈品")]
		public int? FreebieId { get; set; }

		[Display(Name = "使用上限")]
		public int? Quantity { get; set; }

		[Display(Name = "併用優惠")]
		[Required]
		public bool ExtraSalesUsage { get; set; }

		[Display(Name = "建立時間")]
		public DateTime CreatedAt { get; set; }

		[Display(Name = "最後修改時間")]
		public DateTime LastModified { get; set; }

		public int? MemberTagId { get; set; }
		public int? MemberLevelId { get; set; }
		public int? ProductTagId { get; set; }
		public int? ThirdCategoryId { get; set; }
	}
}