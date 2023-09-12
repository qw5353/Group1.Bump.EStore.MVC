using Bump.EStore.Infrastructure.Data.EFModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Bump.EStore.MVC.ViewModels.Activities
{
	public class ActivityDetailEditVM
	{
		public int Id { get; set; }
		public int ActivityId { get; set; }
		public int ActivityDiscountId { get; set; }

		[Display(Name = "名稱")]
		[Required]
		public string Name { get; set; }


		[Display(Name = "活動敘述")]
		[Required]
		public string Description { get; set; }

		//public string Thumbnail { get; set; }

		[Display(Name = "開始時間")]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
		[Required]
		public DateTime StartTime { get; set; }

		[Display(Name = "結束時間")]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
		[Required]
		public DateTime EndTime { get; set; }


		[Display(Name = "狀態")]
		public string Status { get; set; }

		[Display(Name = "建立時間")]
		[Required]
		public DateTime CreatedAt { get; set; }


		//public int? CouponId { get; set; }

		[Display(Name = "優惠類型")]
		[Required]
		public int DiscountTypeId { get; set; }

		[Display(Name = "活動對象")]
		[Required]
		public int TargetTypeId { get; set; }
		public int? MemberTagId { get; set; }
		public int? MemberLevelId { get; set; }


		[Display(Name = "商品類型")]
		[Required]
		public int PromotionProductTypeId { get; set; }
		public int? ProductTagId { get; set; }
		public int? ThirdCategoryId { get; set; }


		[Display(Name = "消費門檻")]
		[Required]
		public int PriceThreshold { get; set; }

		[Display(Name = "買X送Y (Y)")]
		public int? DiscountQty { get; set; }

		[Display(Name = "數量")]
		public decimal? Amount { get; set; }

		[Display(Name = "贈品")]
		public int? FreebieId { get; set; }

		public int? GiftCouponId { get; set; }

		[Display(Name = "併用優惠")]
		public bool ExtraSalesUsage { get; set; }
	}
}