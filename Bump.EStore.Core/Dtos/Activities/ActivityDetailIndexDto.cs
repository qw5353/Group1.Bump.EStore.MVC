using Bump.EStore.Infrastructure.Data.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Bump.EStore.Core.Dtos.Activities
{
	public class ActivityDetailIndexDto
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public int ActivityId { get; set; }

		public string Description { get; set; }

		public string Thumbnail { get; set; }

		public DateTime StartTime { get; set; }

		public DateTime EndTime { get; set; }
		public string CouponName { get; set; }
		public string DiscountTypeName { get; set; }

		public string Status { get; set; }

		public string TargetType { get; set; }

		public string PromotionProductType { get; set; }
		public int PriceThreshold { get; set; }
		public int? DiscountQty { get; set; }
		public decimal? Amount { get; set; }
		public string Freebie { get; set; }
		public int? GiftCouponId { get; set; }
		public bool ExtraSalesUsage { get; set; }

		public DateTime CreatedAt { get; set; }
		public Activity Activity { get; set; }

		public List<string> ProductTag { get; set; }
		public List<string> Category { get; set; }
		public List<string> MemberLevel { get; set; }
		public List<string> MemberTag { get; set; }

	}

	public static class ActivityDetailIndexDtoExts
	{
		public static ActivityDetailIndexDto ToDto(this ActivityDetail entity)
		{
			return new ActivityDetailIndexDto()
			{
				Id = entity.Id,
				Name = entity.Name,
				ActivityId = entity.ActivityId,
				Description = entity.Description,
				Thumbnail = entity.Thumbnail,
				StartTime = entity.StartTime,
				EndTime = entity.EndTime,
				Status = entity.Status,
				CreatedAt = entity.CreatedAt,
				CouponName = entity.ActivityCoupons.Select(a => a.Coupon.Name).FirstOrDefault(),
				DiscountTypeName = entity.ActivityDiscounts.Select(a => a.DiscountType.Name).FirstOrDefault(),
				Activity = entity.Activity,


				TargetType = entity.ActivityDiscounts.Select(a => a.TargetType.Name).FirstOrDefault(),
				PromotionProductType = entity.ActivityDiscounts.Select(a => a.PromotionProductType.Name).FirstOrDefault(),
				PriceThreshold = entity.ActivityDiscounts.Select(a => a.PriceThreshold).FirstOrDefault(),
				DiscountQty = entity.ActivityDiscounts.Select(a => a.DiscountQty).FirstOrDefault(),
				Amount = entity.ActivityDiscounts.Select(a => a.Amount).FirstOrDefault(),
				Freebie = entity.ActivityDiscounts.FirstOrDefault()?.Freebie?.Name ?? string.Empty,
				GiftCouponId = entity.ActivityDiscounts.Select(a => a.GiftCouponId).FirstOrDefault(),
				ExtraSalesUsage = entity.ActivityDiscounts.Select(a => a.ExtraSalesUsage).FirstOrDefault(),


				ProductTag = entity.ActivityDiscounts.Select(a => a.ProductTags.Select(p => p.Name).ToList()).FirstOrDefault(),
				Category = entity.ActivityDiscounts.Select(a => a.ThirdCategories.Select(c => c.Name).ToList()).FirstOrDefault(),
				MemberTag = entity.ActivityDiscounts.Select(a=>a.MemberTags.Select(m=>m.Name).ToList()).FirstOrDefault(),
				MemberLevel=entity.ActivityDiscounts.Select(a=>a.MemberLevels.Select(m=>m.Name).ToList()).FirstOrDefault()
			};
		}
	}
}
