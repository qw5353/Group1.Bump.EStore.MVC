using Bump.EStore.Infrastructure.Data.EFModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Bump.EStore.MVC.ViewModels.Coupons
{
	public class CouponDetailVM
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
		[Required]
		public string RepeatRule { get; set; }

		[Display(Name = "發送規則 (次數)")]
		public byte? RepeatNum { get; set; }

		[Display(Name = "活動對象")]
		[Required]
		public string TargetTypeName { get; set; }

		[Display(Name = "商品類型")]
		[Required]
		public string PromotionProductTypeName { get; set; }

		[Display(Name = "狀態")]
		[Required]
		public string Status { get; set; }

		[Display(Name = "消費門檻")]
		[Required]
		public int PriceThreshold { get; set; }

		[Display(Name = "優惠類型")]
		[Required]
		public string CouponTypeName { get; set; }

		[Display(Name = "買X送Y (Y)")]
		[Required]
		public int? DiscountQty { get; set; }

		[Display(Name = "數量")]
		public decimal? Amount { get; set; }

		[Display(Name = "贈品")]
		public string FreebieName { get; set; }

		[Display(Name = "使用/發送")]
		public int? Quantity { get; set; }

		[Display(Name = "併用優惠")]
		[Required]
		public bool ExtraSalesUsage { get; set; }

		[Display(Name = "建立時間")]
		[Required]
		public DateTime CreatedAt { get; set; }

		[Display(Name = "最後修改時間")]
		[Required]
		public DateTime LastModified { get; set; }

		public string MemberTag { get; set; }
		public string MemberLevel { get; set; }
		public string ProductTag { get; set; }
		public string Category { get; set; }

		public IEnumerable<CouponSendＭembers> Usages { get; set; }

		[Display(Name = "使用數量")]
		public int? TotalUsage { get; set; }

		public float? UseRate
		{
			get
			{
				if (TotalUsage.HasValue && Quantity.HasValue && Quantity.Value > 0)
				{
					return (float)TotalUsage.Value / Quantity.Value * 100;
				}
				else
				{
					return null;
				}
			}
		}
	}
}