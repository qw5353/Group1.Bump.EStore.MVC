using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Bump.EStore.Infrastructure.Data.EFModels;
using Bump.EStore.MVC.ViewModels.Coupons;
using static Bump.EStore.MVC.Controllers.ActivitiesController;

namespace Bump.EStore.MVC.Controllers
{
	[Authorize]
	public class CouponsController : Controller
	{
		private AppDbContext db = new AppDbContext();

		// GET: Coupons
		public ActionResult Index()
		{
			var coupons = db.Coupons.Include(c => c.CouponSendＭembers).Include(c => c.CouponType)
				.Include(c => c.Freebie).Include(c => c.PromotionProductType).Include(c => c.TargetType)
				.Include(c => c.MemberLevels).Include(c => c.MemberTags).Include(c => c.ProductTags).Include(c => c.ThirdCategories);


			var vm = coupons.Select(entity => new CouponIndexVM
			{
				Id = entity.Id,
				Name = entity.Name,
				Code = entity.Code,
				PrevTime = entity.PrevTime,
				StartTime = entity.StartTime,
				EndTime = entity.EndTime,
				RepeatRule = entity.RepeatRule,
				RepeatNum = entity.RepeatNum,
				TargetTypeId = entity.TargetTypeId,
				PromotionProductTypeId = entity.PromotionProductTypeId,
				Status = entity.Status,
				PriceThreshold = entity.PriceThreshold,
				CouponTypeId = entity.CouponTypeId,
				DiscountQty = entity.DiscountQty,
				Amount = entity.Amount,
				FreebieId = entity.FreebieId,
				Quantity = entity.Quantity,
				ExtraSalesUsage = entity.ExtraSalesUsage,
				CreatedAt = entity.CreatedAt,
				LastModified = entity.LastModified,

				MemberTag = entity.MemberTags.Select(m => m.Name).FirstOrDefault(),
				MemberLevel = entity.MemberLevels.Select(m => m.Name).FirstOrDefault(),
				ProductTag = entity.ProductTags.Select(p => p.Name).FirstOrDefault(),
				Category = entity.ThirdCategories.Select(p => p.Name).FirstOrDefault(),
				TotalUsage = db.CouponSendＭembers
				.Where(csm => csm.CouponId == entity.Id)
				.Sum(csm => csm.Usage ? 1 : 0)
			}).ToList();



			return View(vm);
		}


		// GET: Coupons/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return HttpNotFound();
			}
			var entity = db.Coupons.Include(c => c.CouponSendＭembers).Include(c => c.CouponType)
				.Include(c => c.Freebie).Include(c => c.PromotionProductType).Include(c => c.TargetType)
				.Include(c => c.MemberLevels).Include(c => c.MemberTags).Include(c => c.ProductTags).Include(c => c.ThirdCategories).SingleOrDefault(c => c.Id == id);

			if (entity == null)
			{
				return HttpNotFound();
			}

			var vm = new CouponDetailVM
			{
				Id = entity.Id,
				Name = entity.Name,
				Code = entity.Code,
				PrevTime = entity.PrevTime,
				StartTime = entity.StartTime,
				EndTime = entity.EndTime,
				RepeatRule = entity.RepeatRule,
				RepeatNum = entity.RepeatNum,
				TargetTypeName = entity.TargetType.Name,
				PromotionProductTypeName = entity.PromotionProductType.Name,
				Status = entity.Status,
				PriceThreshold = entity.PriceThreshold,
				CouponTypeName = entity.CouponType.Name,
				DiscountQty = entity.DiscountQty,
				Amount = entity.Amount,
				FreebieName = entity.Freebie?.Name ?? string.Empty,
				Quantity = entity.Quantity,
				ExtraSalesUsage = entity.ExtraSalesUsage,
				CreatedAt = entity.CreatedAt,
				LastModified = entity.LastModified,

				MemberTag = entity.MemberTags.Select(m => m.Name).FirstOrDefault(),
				MemberLevel = entity.MemberLevels.Select(m => m.Name).FirstOrDefault(),
				ProductTag = entity.ProductTags.Select(p => p.Name).FirstOrDefault(),
				Category = entity.ThirdCategories.Select(p => p.Name).FirstOrDefault(),
				TotalUsage = db.CouponSendＭembers
	.Where(csm => csm.CouponId == entity.Id)
	.Sum(csm => (int?)(csm.Usage ? 1 : 0))
			};

			return View(vm);
		}

		// GET: Coupons/Create
		public ActionResult Create()
		{
			var couponTypeSelect = db.CouponTypes.ToList().Prepend(new CouponType { Id = 0, Name = "" });
			var freebie = db.Freebies.ToList().Prepend(new Freebie { Id = 0, Name = "" });
			var targetTypeSelect = db.TargetTypes.ToList().Prepend(new TargetType { Id = 0, Name = "" });
			var memberTagSelect = db.MemberTags.ToList().Prepend(new MemberTag { Id = 0, Name = "" });
			var memberLevelSelect = db.MemberLevels.ToList().Prepend(new MemberLevel { Id = 0, Name = "" });
			var promotionProductTypeSelect = db.PromotionProductTypes.ToList().Prepend(new PromotionProductType { Id = 0, Name = "" });
			var productTagSelect = db.ProductTags.ToList().Prepend(new ProductTag { Id = 0, Name = "" });
			var thirdCategorySelect = db.ThirdCategories.ToList().Prepend(new ThirdCategory { Id = 0, Name = "" });

			var repeatRuleList = new RepeatRule[] {
				new RepeatRule {},
				new RepeatRule {Name= "每年", Id="每年"},
				new RepeatRule {Name= "每月", Id="每月"},
				new RepeatRule {Name= "每週", Id="每週"},
				new RepeatRule {Name= "每日", Id="每日"}
			};

			ViewBag.RepeatRule = new SelectList(repeatRuleList, "Id", "Name");
			ViewBag.CouponTypeId = new SelectList(couponTypeSelect, "Id", "Name");
			ViewBag.FreebieId = new SelectList(freebie, "Id", "Name");
			ViewBag.TargetTypeId = new SelectList(targetTypeSelect, "Id", "Name");
			ViewBag.MemberTagId = new SelectList(memberTagSelect, "Id", "Name");
			ViewBag.MemberLevelId = new SelectList(memberLevelSelect, "Id", "Name");
			ViewBag.PromotionProductTypeId = new SelectList(promotionProductTypeSelect, "Id", "Name");
			ViewBag.ProductTagId = new SelectList(productTagSelect, "Id", "Name");
			ViewBag.ThirdCategoryId = new SelectList(thirdCategorySelect, "Id", "Name");

			return View();
		}

		// POST: Coupons/Create
		// 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
		// 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(CouponCreateVM vm)
		{
			var couponTypeSelect = db.CouponTypes.ToList().Prepend(new CouponType { Id = 0, Name = "" });
			var freebie = db.Freebies.ToList().Prepend(new Freebie { Id = 0, Name = "" });
			var targetTypeSelect = db.TargetTypes.ToList().Prepend(new TargetType { Id = 0, Name = "" });
			var memberTagSelect = db.MemberTags.ToList().Prepend(new MemberTag { Id = 0, Name = "" });
			var memberLevelSelect = db.MemberLevels.ToList().Prepend(new MemberLevel { Id = 0, Name = "" });
			var promotionProductTypeSelect = db.PromotionProductTypes.ToList().Prepend(new PromotionProductType { Id = 0, Name = "" });
			var productTagSelect = db.ProductTags.ToList().Prepend(new ProductTag { Id = 0, Name = "" });
			var thirdCategorySelect = db.ThirdCategories.ToList().Prepend(new ThirdCategory { Id = 0, Name = "" });
			var CouponSelect = db.Coupons.ToList().Prepend(new Coupon { Id = 0, Name = "" });

			var repeatRuleList = new RepeatRule[] {
				new RepeatRule {},
				new RepeatRule {Name= "每年", Id="每年"},
				new RepeatRule {Name= "每月", Id="每月"},
				new RepeatRule {Name= "每週", Id="每週"},
				new RepeatRule {Name= "每日", Id="每日"}
			};

			ViewBag.RepeatRule = new SelectList(repeatRuleList, "Name", "Name");
			ViewBag.CouponTypeId = new SelectList(couponTypeSelect, "Id", "Name");
			ViewBag.FreebieId = new SelectList(freebie, "Id", "Name");
			ViewBag.TargetTypeId = new SelectList(targetTypeSelect, "Id", "Name");
			ViewBag.MemberTagId = new SelectList(memberTagSelect, "Id", "Name");
			ViewBag.MemberLevelId = new SelectList(memberLevelSelect, "Id", "Name");
			ViewBag.PromotionProductTypeId = new SelectList(promotionProductTypeSelect, "Id", "Name");
			ViewBag.ProductTagId = new SelectList(productTagSelect, "Id", "Name");
			ViewBag.ThirdCategoryId = new SelectList(thirdCategorySelect, "Id", "Name");


			var codeInDb = db.Coupons.FirstOrDefault(c => c.Code == vm.Code);
			if (codeInDb != null)
			{
				ModelState.AddModelError("Code", "優惠碼重複");
				return View(vm);
			}

			if (vm.StartTime >= vm.EndTime)
			{
				ModelState.AddModelError("StartTime", "開始時間大於或等於結束時間");
				return View(vm);
			}

			if (vm.StartTime > DateTime.Now)
			{
				vm.Status = "未開始";
			}
			else if (vm.EndTime < DateTime.Now)
			{
				vm.Status = "已過期";
			}
			else
			{
				vm.Status = "進行中";
			}

			vm.CreatedAt = DateTime.Now;
			vm.LastModified = DateTime.Now;

			var entity = new Coupon
			{
				Name = vm.Name,
				Code = vm.Code,
				PrevTime = vm.PrevTime,
				StartTime = vm.StartTime,
				EndTime = vm.EndTime,
				RepeatRule = vm.RepeatRule,
				RepeatNum = vm.RepeatNum,
				TargetTypeId = vm.TargetTypeId,
				PromotionProductTypeId = vm.PromotionProductTypeId,
				Status = vm.Status,
				PriceThreshold = vm.PriceThreshold,
				CouponTypeId = vm.CouponTypeId,
				DiscountQty = vm.DiscountQty == 0 ? null : vm.DiscountQty,
				Amount = vm.Amount == 0 ? null : vm.Amount,
				FreebieId = vm.FreebieId == 0 ? null : vm.FreebieId,
				Quantity = vm.Quantity == 0 ? null : vm.Quantity,
				ExtraSalesUsage = vm.ExtraSalesUsage,
				CreatedAt = vm.CreatedAt,
				LastModified = vm.LastModified,
			};

			int? memberLevelId = vm.MemberLevelId == 0 ? null : (int?)vm.MemberLevelId;
			int? memberTagId = vm.MemberTagId == 0 ? null : (int?)vm.MemberTagId;
			int? productTagId = vm.ProductTagId == 0 ? null : (int?)vm.ProductTagId;
			int? thirdCategoryId = vm.ThirdCategoryId == 0 ? null : (int?)vm.ThirdCategoryId;

			entity.MemberLevels = db.MemberLevels.Where(m => m.Id == memberLevelId).ToList();
			entity.MemberTags = db.MemberTags.Where(m => m.Id == memberTagId).ToList();
			entity.ProductTags = db.ProductTags.Where(p => p.Id == productTagId).ToList();
			entity.ThirdCategories = db.ThirdCategories.Where(p => p.Id == thirdCategoryId).ToList();

			if (ModelState.IsValid)
			{
				db.Coupons.Add(entity);
				db.SaveChanges();

				return RedirectToAction("Index");
			}

			var msg = string.Empty;
			foreach (var value in ModelState.Values)
			{
				if (value.Errors.Count > 0)
				{
					foreach (var error in value.Errors)
					{
						msg = msg + error.ErrorMessage;
					}
				}
			}

			ModelState.AddModelError(string.Empty, msg);

			return View(vm);
		}

		public string GenerateCode()
		{
			int codeLength = 8;
			string codeResult = "";

			for (int i = 0; i < codeLength; i++)
			{
				var codeChar = CharGenerate();
				codeResult += codeChar;
			}

			return codeResult;
		}


		private char CharGenerate()
		{
			char[] uppercase = { 'Q', 'W', 'E', 'R', 'T', 'Y', 'U', 'I', 'O', 'P', 'A', 'S', 'D', 'F', 'G', 'H', 'J', 'K', 'L', 'Z', 'X', 'C', 'V', 'B', 'N', 'M' };
			char[] lowercase = { 'q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p', 'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'z', 'x', 'c', 'v', 'b', 'n', 'm' };
			char[] numbers = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

			char[] symbols = { '`', '~', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '_', '=', '+', '\\', '|', '/', '[', ']', '{', '}', ';', ':', '<', '>', ',', '.', '?' };

			char[] combineCase = uppercase.Concat(lowercase).ToArray();
			combineCase = combineCase.Concat(numbers).ToArray();

			Random random = new Random(Guid.NewGuid().GetHashCode());
			int rdn = random.Next(0, combineCase.Length);

			return combineCase[rdn];
		}

		// GET: Coupons/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return HttpNotFound();
			}
			var coupon = db.Coupons.Find(id);
			if (coupon == null)
			{
				return HttpNotFound();
			}

			var vm = new CouponEditVM
			{
				Id = coupon.Id,
				Name = coupon.Name,
				Code = coupon.Code,
				StartTime = coupon.StartTime,
				EndTime = coupon.EndTime,
				RepeatRule = coupon.RepeatRule,
				RepeatNum = coupon.RepeatNum,
				TargetTypeId = coupon.TargetTypeId,
				PromotionProductTypeId = coupon.PromotionProductTypeId,
				Status = coupon.Status,
				PriceThreshold = coupon.PriceThreshold,
				CouponTypeId = coupon.CouponTypeId,
				DiscountQty = coupon.DiscountQty,
				Amount = coupon.Amount,
				FreebieId = coupon.FreebieId,
				Quantity = coupon.Quantity,
				ExtraSalesUsage = coupon.ExtraSalesUsage,
				CreatedAt = coupon.CreatedAt,
				LastModified = coupon.LastModified,
				MemberLevelId = coupon.MemberLevels.Select(m => m.Id).FirstOrDefault(),
				MemberTagId = coupon.MemberTags.Select(m => m.Id).FirstOrDefault(),
				ProductTagId = coupon.ProductTags.Select(m => m.Id).FirstOrDefault(),
				ThirdCategoryId = coupon.ThirdCategories.Select(m => m.Id).FirstOrDefault()
			};



			ViewBag.Id = new SelectList(db.CouponSendＭembers, "Id", "Id", coupon.Id);
			var couponTypeSelect = db.CouponTypes.ToList().Prepend(new CouponType { Id = 0, Name = "" });
			var freebie = db.Freebies.ToList().Prepend(new Freebie { Id = 0, Name = "" });
			var targetTypeSelect = db.TargetTypes.ToList().Prepend(new TargetType { Id = 0, Name = "" });
			var memberTagSelect = db.MemberTags.ToList().Prepend(new MemberTag { Id = 0, Name = "" });
			var memberLevelSelect = db.MemberLevels.ToList().Prepend(new MemberLevel { Id = 0, Name = "" });
			var promotionProductTypeSelect = db.PromotionProductTypes.ToList().Prepend(new PromotionProductType { Id = 0, Name = "" });
			var productTagSelect = db.ProductTags.ToList().Prepend(new ProductTag { Id = 0, Name = "" });
			var thirdCategorySelect = db.ThirdCategories.ToList().Prepend(new ThirdCategory { Id = 0, Name = "" });
			var CouponSelect = db.Coupons.ToList().Prepend(new Coupon { Id = 0, Name = "" });

			var repeatRuleList = new RepeatRule[] {
				new RepeatRule {},
				new RepeatRule {Name= "每年", Id="每年"},
				new RepeatRule {Name= "每月", Id="每月"},
				new RepeatRule {Name= "每週", Id="每週"},
				new RepeatRule {Name= "每日", Id="每日"}
			};
			ViewBag.RepeatRule = new SelectList(repeatRuleList, "Id", "Name");
			ViewBag.CouponTypeId = new SelectList(couponTypeSelect, "Id", "Name", coupon.CouponTypeId);
			ViewBag.FreebieId = new SelectList(freebie, "Id", "Name", coupon.FreebieId);
			ViewBag.TargetTypeId = new SelectList(targetTypeSelect, "Id", "Name", coupon.TargetTypeId);
			ViewBag.MemberTagId = new SelectList(memberTagSelect, "Id", "Name", vm.MemberTagId);
			ViewBag.MemberLevelId = new SelectList(memberLevelSelect, "Id", "Name", vm.MemberLevelId);
			ViewBag.PromotionProductTypeId = new SelectList(promotionProductTypeSelect, "Id", "Name", coupon.PromotionProductTypeId);
			ViewBag.ProductTagId = new SelectList(productTagSelect, "Id", "Name", vm.ProductTagId);
			ViewBag.ThirdCategoryId = new SelectList(thirdCategorySelect, "Id", "Name", vm.ThirdCategoryId);

			return View(vm);
		}

		// POST: Coupons/Edit/5
		// 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
		// 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(CouponEditVM vm)
		{
			if (vm.StartTime > DateTime.Now)
			{
				vm.Status = "未開始";
			}
			else if (vm.EndTime < DateTime.Now)
			{
				vm.Status = "已過期";
			}
			else
			{
				vm.Status = "進行中";
			}
			var entity = new Coupon
			{
				Id = vm.Id,
				Name = vm.Name,
				Code = vm.Code,
				PrevTime = vm.PrevTime,
				StartTime = vm.StartTime,
				EndTime = vm.EndTime,
				RepeatRule = vm.RepeatRule,
				RepeatNum = vm.RepeatNum,
				TargetTypeId = vm.TargetTypeId,
				PromotionProductTypeId = vm.PromotionProductTypeId,
				Status = vm.Status,
				PriceThreshold = vm.PriceThreshold,
				CouponTypeId = vm.CouponTypeId,
				DiscountQty = vm.DiscountQty == 0 ? null : vm.DiscountQty,
				Amount = vm.Amount == 0 ? null : vm.Amount,
				FreebieId = vm.FreebieId == 0 ? null : vm.FreebieId,
				Quantity = vm.Quantity == 0 ? null : vm.Quantity,
				ExtraSalesUsage = vm.ExtraSalesUsage,
				CreatedAt = vm.CreatedAt,
				LastModified = vm.LastModified,
			};

			int? memberLevelId = vm.MemberLevelId == 0 ? null : (int?)vm.MemberLevelId;
			int? memberTagId = vm.MemberTagId == 0 ? null : (int?)vm.MemberTagId;
			int? productTagId = vm.ProductTagId == 0 ? null : (int?)vm.ProductTagId;
			int? thirdCategoryId = vm.ThirdCategoryId == 0 ? null : (int?)vm.ThirdCategoryId;

			entity.MemberLevels = db.MemberLevels.Where(m => m.Id == memberLevelId).ToList();
			entity.MemberTags = db.MemberTags.Where(m => m.Id == memberTagId).ToList();
			entity.ProductTags = db.ProductTags.Where(p => p.Id == productTagId).ToList();
			entity.ThirdCategories = db.ThirdCategories.Where(p => p.Id == thirdCategoryId).ToList();

			if (ModelState.IsValid)
			{
				db.Entry(entity).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}


			var couponTypeSelect = db.CouponTypes.ToList().Prepend(new CouponType { Id = 0, Name = "" });
			var freebie = db.Freebies.ToList().Prepend(new Freebie { Id = 0, Name = "" });
			var targetTypeSelect = db.TargetTypes.ToList().Prepend(new TargetType { Id = 0, Name = "" });
			var memberTagSelect = db.MemberTags.ToList().Prepend(new MemberTag { Id = 0, Name = "" });
			var memberLevelSelect = db.MemberLevels.ToList().Prepend(new MemberLevel { Id = 0, Name = "" });
			var promotionProductTypeSelect = db.PromotionProductTypes.ToList().Prepend(new PromotionProductType { Id = 0, Name = "" });
			var productTagSelect = db.ProductTags.ToList().Prepend(new ProductTag { Id = 0, Name = "" });
			var thirdCategorySelect = db.ThirdCategories.ToList().Prepend(new ThirdCategory { Id = 0, Name = "" });
			var CouponSelect = db.Coupons.ToList().Prepend(new Coupon { Id = 0, Name = "" });

			var repeatRuleList = new RepeatRule[] {
				new RepeatRule {},
				new RepeatRule {Name= "每年", Id="每年"},
				new RepeatRule {Name= "每月", Id="每月"},
				new RepeatRule {Name= "每週", Id="每週"},
				new RepeatRule {Name= "每日", Id="每日"}
			};

			ViewBag.RepeatRule = new SelectList(repeatRuleList, "Id", "Name");
			ViewBag.CouponTypeId = new SelectList(couponTypeSelect, "Id", "Name", vm.CouponTypeId);
			ViewBag.FreebieId = new SelectList(freebie, "Id", "Name", vm.FreebieId);
			ViewBag.TargetTypeId = new SelectList(targetTypeSelect, "Id", "Name", vm.TargetTypeId);
			ViewBag.MemberTagId = new SelectList(memberTagSelect, "Id", "Name", vm.MemberTagId);
			ViewBag.MemberLevelId = new SelectList(memberLevelSelect, "Id", "Name", vm.MemberLevelId);
			ViewBag.PromotionProductTypeId = new SelectList(promotionProductTypeSelect, "Id", "Name", vm.PromotionProductTypeId);
			ViewBag.ProductTagId = new SelectList(productTagSelect, "Id", "Name", vm.ProductTagId);
			ViewBag.ThirdCategoryId = new SelectList(thirdCategorySelect, "Id", "Name", vm.ThirdCategoryId);

			var msg = string.Empty;
			foreach (var value in ModelState.Values)
			{
				if (value.Errors.Count > 0)
				{
					foreach (var error in value.Errors)
					{
						msg = msg + error.ErrorMessage;
					}
				}
			}

			ModelState.AddModelError(string.Empty, msg);

			return View(vm);
		}


		// POST: Coupons/Delete/5
		[HttpPost, ActionName("Delete")]
		public ActionResult DeleteConfirmed(int? id)
		{
			if (id == null)
			{
				return HttpNotFound();
			}

			Coupon coupon = db.Coupons.Find(id);
			db.Coupons.Remove(coupon);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				db.Dispose();
			}
			base.Dispose(disposing);
		}


		[HttpPost]
		public ActionResult SendCoupon(int id)
		{
			List<int> memberIds = db.Members.Select(m => m.Id).ToList();

			var coupon = db.Coupons.Find(id);

			if (coupon == null)
			{
				return HttpNotFound();
			}

			foreach (var memberId in memberIds)
			{
				var couponSendMember = new CouponSendＭembers
				{
					CouponId = id,
					MemberId = memberId,
					Usage = false,
					SendingTime = DateTime.Now
				};

				db.CouponSendＭembers.Add(couponSendMember);
			}

			db.SaveChanges();

			return RedirectToAction("Index");
		}

		[HttpPost]
		public ActionResult CheckSendStatus(int id)
		{
			var sendRecord = db.CouponSendＭembers.FirstOrDefault(c => c.CouponId == id);
			bool isSent = sendRecord != null;

			return Json(new { isSent });
		}

		private class RepeatRule
		{
			public string Id { get; set; }
			public string Name { get; set; }
		}
	}
}
