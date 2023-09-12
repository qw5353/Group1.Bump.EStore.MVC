using Bump.EStore.Core.Dtos.Activities;
using Bump.EStore.Infrastructure.Data.EFModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bump.EStore.MVC.ViewModels.Activities
{
	public class ActivityDetailIndexVM
	{
		public int Id { get; set; }

		[Display(Name = "名稱")]
		public string Name { get; set; }

		public string ActivityName { get; set; }

		public DateTime ActivityStartTime { get; set; }

		public DateTime ActivityEndTime { get; set; }

		[Display(Name = "活動敘述")]
		public string Description { get; set; }

		//public string Thumbnail { get; set; }

		[Display(Name = "開始時間")]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
		public DateTime StartTime { get; set; }

		[Display(Name = "結束時間")]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
		public DateTime EndTime { get; set; }

		//public int? CouponId { get; set; }

		[Display(Name = "優惠券")]
		public string CouponName { get; set; }

		[Display(Name = "優惠類型")]
		public string DiscountTypeName { get; set; }

		[Display(Name = "狀態")]
		public string Status { get; set; }

		[Display(Name = "建立時間")]
		public DateTime CreatedAt { get; set; }
		[JsonIgnore]
		public Activity Activity { get; set; }

		[Display(Name = "活動對象")]
		public string TargetType { get; set; }

		[Display(Name = "商品類型")]
		public string PromotionProductType { get; set; }

		[Display(Name = "消費門檻")]
		public int PriceThreshold { get; set; }

		[Display(Name = "買X送Y (Y)")]
		public int? DiscountQty { get; set; }

		[Display(Name = "數量")]
		public decimal? Amount { get; set; }

		[Display(Name = "贈品")]
		public string Freebie { get; set; }

		[Display(Name = "消費贈優惠券")]
		public int? GiftCouponId { get; set; }

		[Display(Name = "併用優惠")]
		public bool ExtraSalesUsage { get; set; }

		public List<string> ProductTag { get; set; }
		public List<string> Category { get; set; }
		public List<string> MemberLevel { get; set; }
		public List<string> MemberTag { get; set; }

	}

	public static class ActivityDetailIndexExts
	{
		public static ActivityDetailIndexVM ToVM(this ActivityDetailIndexDto dto)
		{

			return new ActivityDetailIndexVM()
			{
				Id = dto.Id,
				Name = dto.Name,
				ActivityName = dto.Activity.Name,
				ActivityStartTime = dto.Activity.StartTime,
				ActivityEndTime = dto.Activity.EndTime,
				Description = dto.Description,
				//Thumbnail = entity.Thumbnail,
				StartTime = dto.StartTime,
				EndTime = dto.EndTime,
				CouponName = dto.CouponName,
				DiscountTypeName = dto.DiscountTypeName == null ? "免消費贈優惠券" : dto.DiscountTypeName,
				Status = dto.Status,
				CreatedAt = dto.CreatedAt,
				Activity = dto.Activity,


				TargetType = dto.TargetType,
				PromotionProductType = dto.PromotionProductType,
				PriceThreshold = dto.PriceThreshold,
				DiscountQty = dto.DiscountQty,
				Amount = dto.Amount,
				Freebie = dto.Freebie,
				GiftCouponId = dto.GiftCouponId,
				ExtraSalesUsage = dto.ExtraSalesUsage,

				ProductTag = dto.ProductTag,
				Category = dto.Category,
				MemberTag = dto.MemberTag,
				MemberLevel = dto.MemberLevel
			};
		}

	}
}