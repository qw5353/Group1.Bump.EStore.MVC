using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.EnterpriseServices;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Bump.EStore.Core.Services;
using Bump.EStore.Infrastructure.Data.EFModels;
using Bump.EStore.Infrastructure.Infra;
using Bump.EStore.Infrastructure.Repositories.EFRepositories;
using Bump.EStore.Infrastructure.Repositories.Interfaces;
using Bump.EStore.MVC.ViewModels.Activities;
using Microsoft.Ajax.Utilities;
using static Bump.EStore.MVC.Controllers.ActivitiesController;

namespace Bump.EStore.MVC.Controllers
{
	[Authorize]
	public class ActivityDetailsController : Controller
	{
		private AppDbContext db = new AppDbContext();

		// GET: ActivityDetails
		public ActionResult Index(int? id)
		{
			if (id == null)
			{
				return HttpNotFound();
			}
			int detailId = (int)id;
			IActivityRepository repo = new ActivityEFRepository();
			ActivityService service = new ActivityService(repo);

			if (service.Search(detailId).Count() == 0)
			{
				return HttpNotFound();
			}
			var activityName = service.Search(detailId).FirstOrDefault().Name;
			var activityStart = service.Search(detailId).FirstOrDefault().StartTime;
			var activityEnd = service.Search(detailId).FirstOrDefault().EndTime;

			ViewBag.Title = activityName;
			ViewBag.Start = activityStart;
			ViewBag.End = activityEnd;
			ViewBag.Id = detailId;
			//if (id == null)
			//{
			//	return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			//}
			var activityDetails = service.Search().Where(a => a.ActivityId == detailId);

			if (activityDetails == null)
			{
				return HttpNotFound();
			}


			return View(activityDetails.ToList().Select(ad => ad.ToVM()));
		}


		// GET: ActivityDetails/Create
		public ActionResult Create(int? id)
		{
			if (id == null)
			{
				return HttpNotFound();
			}

			ViewBag.ActivityId = id;//new SelectList(db.Activities, "Id", "Name");

			var activity = db.Activities.Find(id);
			if (activity == null) { return HttpNotFound(); }
			ViewBag.ActivityName = activity.Name;

			var activityStartTime = db.Activities.FirstOrDefault(a => a.Id == id).StartTime;
			var activityEndTime = db.Activities.FirstOrDefault(a => a.Id == id).EndTime;

			ViewBag.Start = activityStartTime;
			ViewBag.End = activityEndTime;

			var vm = new ActivityDetailCreateVM
			{
				ActivityId = (int)id,
				ActivityName = activity.Name,
				StartTime = DateTime.Now,
				EndTime = DateTime.Now
			};

			var discountTypeSelect = db.DiscountTypes.ToList().Prepend(new DiscountType { Id = 0, Name = "" });
			var freebie = db.Freebies.ToList().Prepend(new Freebie { Id = 0, Name = "" });
			var targetTypeSelect = db.TargetTypes.ToList().Prepend(new TargetType { Id = 0, Name = "" });
			var memberTagSelect = db.MemberTags.ToList().Prepend(new MemberTag { Id = 0, Name = "" });
			var memberLevelSelect = db.MemberLevels.ToList().Prepend(new MemberLevel { Id = 0, Name = "" });
			var promotionProductTypeSelect = db.PromotionProductTypes.ToList().Prepend(new PromotionProductType { Id = 0, Name = "" });
			var productTagSelect = db.ProductTags.ToList().Prepend(new ProductTag { Id = 0, Name = "" });
			var thirdCategorySelect = db.ThirdCategories.ToList().Prepend(new ThirdCategory { Id = 0, Name = "" });
			var CouponSelect = db.Coupons.ToList().Prepend(new Coupon { Id = 0, Name = "" });


			ViewBag.DiscountTypeId = new SelectList(discountTypeSelect, "Id", "Name");
			ViewBag.FreebieId = new SelectList(freebie, "Id", "Name");
			ViewBag.TargetTypeId = new SelectList(targetTypeSelect, "Id", "Name");
			ViewBag.MemberTagId = new SelectList(memberTagSelect, "Id", "Name");
			ViewBag.MemberLevelId = new SelectList(memberLevelSelect, "Id", "Name");
			ViewBag.PromotionProductTypeId = new SelectList(promotionProductTypeSelect, "Id", "Name");
			ViewBag.ProductTagId = new SelectList(productTagSelect, "Id", "Name");
			ViewBag.ThirdCategoryId = new SelectList(thirdCategorySelect, "Id", "Name");
			ViewBag.GiftCouponId = new SelectList(CouponSelect, "Id", "Name");

			return View(vm);
		}

		// POST: ActivityDetails/Create
		// 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
		// 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(ActivityDetailCreateVM vm)
		{
			var discountTypeSelect = db.DiscountTypes.ToList().Prepend(new DiscountType { Id = 0, Name = "" });
			var freebie = db.Freebies.ToList().Prepend(new Freebie { Id = 0, Name = "" });
			var targetTypeSelect = db.TargetTypes.ToList().Prepend(new TargetType { Id = 0, Name = "" });
			var memberTagSelect = db.MemberTags.ToList().Prepend(new MemberTag { Id = 0, Name = "" });
			var memberLevelSelect = db.MemberLevels.ToList().Prepend(new MemberLevel { Id = 0, Name = "" });
			var promotionProductTypeSelect = db.PromotionProductTypes.ToList().Prepend(new PromotionProductType { Id = 0, Name = "" });
			var productTagSelect = db.ProductTags.ToList().Prepend(new ProductTag { Id = 0, Name = "" });
			var thirdCategorySelect = db.ThirdCategories.ToList().Prepend(new ThirdCategory { Id = 0, Name = "" });
			var CouponSelect = db.Coupons.ToList().Prepend(new Coupon { Id = 0, Name = "" });


			ViewBag.DiscountTypeId = new SelectList(discountTypeSelect, "Id", "Name");
			ViewBag.FreebieId = new SelectList(freebie, "Id", "Name");
			ViewBag.TargetTypeId = new SelectList(targetTypeSelect, "Id", "Name");
			ViewBag.MemberTagId = new SelectList(memberTagSelect, "Id", "Name");
			ViewBag.MemberLevelId = new SelectList(memberLevelSelect, "Id", "Name");
			ViewBag.PromotionProductTypeId = new SelectList(promotionProductTypeSelect, "Id", "Name");
			ViewBag.ProductTagId = new SelectList(productTagSelect, "Id", "Name");
			ViewBag.ThirdCategoryId = new SelectList(thirdCategorySelect, "Id", "Name");
			ViewBag.GiftCouponId = new SelectList(CouponSelect, "Id", "Name");

			ViewBag.ActivityId = vm.ActivityId;
			ViewBag.ActivityName = db.Activities.FirstOrDefault(a => a.Id == vm.Id).Name;

			var activityStartTime = db.Activities.FirstOrDefault(a => a.Id == vm.Id).StartTime;
			var activityEndTime = db.Activities.FirstOrDefault(a => a.Id == vm.Id).EndTime;

			ViewBag.Start = activityStartTime;
			ViewBag.End = activityEndTime;


			if (!ModelState.IsValid)
			{
				return View(vm);
			}

			if (vm.StartTime <= DateTime.Now)
			{
				ModelState.AddModelError("StartTime", "開始時間要大於現在時間");
				return View(vm);
			}

			if (vm.StartTime >= vm.EndTime)
			{
				ModelState.AddModelError("StartTime", "開始時間大於或等於結束時間");
				return View(vm);
			}


			if (vm.StartTime < activityStartTime || vm.EndTime > activityEndTime)
			{
				ModelState.AddModelError("StartTime", "開始時間或結束時間不能在活動期間外");
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


			using (var transaction = db.Database.BeginTransaction())
			{
				try
				{
					var activityDetail = new ActivityDetail()
					{
						Name = vm.Name,
						ActivityId = vm.ActivityId,
						Description = vm.Description,
						StartTime = vm.StartTime,
						EndTime = vm.EndTime,
						Status = vm.Status,
						CreatedAt = DateTime.Now
					};

					db.ActivityDetails.Add(activityDetail);
					db.SaveChanges();

					int newActivityDetailId = activityDetail.Id;


					var activityDiscount = new ActivityDiscount()
					{
						AcitivityDetailId = newActivityDetailId,
						TargetTypeId = vm.TargetTypeId,
						PromotionProductTypeId = vm.PromotionProductTypeId,
						PriceThreshold = vm.PriceThreshold,
						DiscountTypeId = vm.DiscountTypeId,
						DiscountQty = vm.DiscountQty == 0 ? null : vm.DiscountQty,
						Amount = vm.Amount == 0 ? null : vm.Amount,
						FreebieId = vm.FreebieId == 0 ? null : vm.FreebieId,
						GiftCouponId = vm.GiftCouponId == 0 ? null : vm.GiftCouponId,
						ExtraSalesUsage = vm.ExtraSalesUsage
					};

					int? memberLevelId = vm.MemberLevelId == 0 ? null : (int?)vm.MemberLevelId;
					int? memberTagId = vm.MemberTagId == 0 ? null : (int?)vm.MemberTagId;
					int? productTagId = vm.ProductTagId == 0 ? null : (int?)vm.ProductTagId;
					int? thirdCategoryId = vm.ThirdCategoryId == 0 ? null : (int?)vm.ThirdCategoryId;

					activityDiscount.MemberLevels = db.MemberLevels.Where(m => m.Id == memberLevelId).ToList();
					activityDiscount.MemberTags = db.MemberTags.Where(m => m.Id == memberTagId).ToList();
					activityDiscount.ProductTags = db.ProductTags.Where(p => p.Id == productTagId).ToList();
					activityDiscount.ThirdCategories = db.ThirdCategories.Where(p => p.Id == thirdCategoryId).ToList();

					db.ActivityDiscounts.Add(activityDiscount);
					db.SaveChanges();

					// 提交事务
					transaction.Commit();

					return RedirectToAction("Index", "ActivityDetails", new { id = vm.ActivityId });
				}
				catch
				{
					transaction.Rollback();
					ModelState.AddModelError(string.Empty, "新增不成功");

					return View(vm);
				}
			}
		}

		// GET: ActivityDetails/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return HttpNotFound();
			}

			var activityDetail = db.ActivityDetails.Find(id);
			if (activityDetail == null)
			{
				return HttpNotFound();
			}

			ViewBag.ActivityId = activityDetail.ActivityId;
			ViewBag.ActivityDetailId = activityDetail.Id;
			ViewBag.ActivityDetailName = activityDetail.Name;

			var activityDiscount = db.ActivityDiscounts.FirstOrDefault(a => a.AcitivityDetailId == activityDetail.Id);
			if (activityDiscount == null)
			{
				return HttpNotFound();
			}

			var vm = new ActivityDetailEditVM
			{
				Id = activityDetail.Id,
				ActivityId = activityDetail.ActivityId,
				ActivityDiscountId = activityDiscount.Id,
				Name = activityDetail.Name,
				Description = activityDetail.Description,
				StartTime = activityDetail.StartTime,
				EndTime = activityDetail.EndTime,
				Status = activityDetail.Status,
				DiscountTypeId = activityDiscount.DiscountTypeId,
				TargetTypeId = activityDiscount.TargetTypeId,
				MemberTagId = activityDiscount.MemberTags.Select(m => m.Id).FirstOrDefault(),
				MemberLevelId = activityDiscount.MemberLevels.Select(m => m.Id).FirstOrDefault(),
				PromotionProductTypeId = activityDiscount.PromotionProductTypeId,
				ProductTagId = activityDiscount.ProductTags.Select(p => p.Id).FirstOrDefault(),
				ThirdCategoryId = activityDiscount.ThirdCategories.Select(t => t.Id).FirstOrDefault(),
				PriceThreshold = activityDiscount.PriceThreshold,
				DiscountQty = activityDiscount.DiscountQty,
				Amount = activityDiscount.Amount,
				FreebieId = activityDiscount.FreebieId,
				GiftCouponId = activityDiscount.GiftCouponId,
				ExtraSalesUsage = activityDiscount.ExtraSalesUsage,
				CreatedAt = activityDetail.CreatedAt
			};


			var discountTypeSelect = db.DiscountTypes.ToList().Prepend(new DiscountType { Id = 0, Name = "" });
			var freebie = db.Freebies.ToList().Prepend(new Freebie { Id = 0, Name = "" });
			var targetTypeSelect = db.TargetTypes.ToList().Prepend(new TargetType { Id = 0, Name = "" });
			var memberTagSelect = db.MemberTags.ToList().Prepend(new MemberTag { Id = 0, Name = "" });
			var memberLevelSelect = db.MemberLevels.ToList().Prepend(new MemberLevel { Id = 0, Name = "" });
			var promotionProductTypeSelect = db.PromotionProductTypes.ToList().Prepend(new PromotionProductType { Id = 0, Name = "" });
			var productTagSelect = db.ProductTags.ToList().Prepend(new ProductTag { Id = 0, Name = "" });
			var thirdCategorySelect = db.ThirdCategories.ToList().Prepend(new ThirdCategory { Id = 0, Name = "" });
			var CouponSelect = db.Coupons.ToList().Prepend(new Coupon { Id = 0, Name = "" });

			ViewBag.DiscountTypeId = new SelectList(discountTypeSelect, "Id", "Name", activityDiscount.DiscountTypeId);
			ViewBag.FreebieId = new SelectList(freebie, "Id", "Name", activityDiscount.FreebieId);
			ViewBag.TargetTypeId = new SelectList(targetTypeSelect, "Id", "Name", activityDiscount.TargetTypeId);
			ViewBag.MemberTagId = new SelectList(memberTagSelect, "Id", "Name", vm.MemberTagId);
			ViewBag.MemberLevelId = new SelectList(memberLevelSelect, "Id", "Name", vm.MemberLevelId);
			ViewBag.PromotionProductTypeId = new SelectList(promotionProductTypeSelect, "Id", "Name", activityDiscount.PromotionProductTypeId);
			ViewBag.ProductTagId = new SelectList(productTagSelect, "Id", "Name", vm.ProductTagId);
			ViewBag.ThirdCategoryId = new SelectList(thirdCategorySelect, "Id", "Name", vm.ThirdCategoryId);
			ViewBag.GiftCouponId = new SelectList(CouponSelect, "Id", "Name", activityDiscount.GiftCouponId);

			return View(vm);
		}

		// POST: ActivityDetails/Edit/5
		// 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
		// 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(ActivityDetailEditVM vm)
		{
			if (vm.StartTime >= vm.EndTime)
			{
				ModelState.AddModelError("StartTime", "開始時間大於或等於結束時間");
				return View(vm);
			}

			var activityStartTime = db.Activities.FirstOrDefault(a => a.Id == vm.ActivityId).StartTime;
			var activityEndTime = db.Activities.FirstOrDefault(a => a.Id == vm.ActivityId).EndTime;

			if (vm.StartTime < activityStartTime || vm.EndTime > activityEndTime)
			{
				ModelState.AddModelError("StartTime", "開始時間或結束時間不能在活動期間外");
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

			ViewBag.ActivityId = vm.ActivityId;

			var activityDetail = new ActivityDetail
			{
				Id = vm.Id,
				Name = vm.Name,
				ActivityId = vm.ActivityId,
				Description = vm.Description,
				StartTime = vm.StartTime,
				EndTime = vm.EndTime,
				Status = vm.Status,
				CreatedAt = vm.CreatedAt,
			};

			ViewBag.ActivityDetailId = activityDetail.Id;
			ViewBag.ActivityDetailName = activityDetail.Name;


			var activityDiscount = new ActivityDiscount
			{
				Id = vm.ActivityDiscountId,
				AcitivityDetailId = vm.Id,
				DiscountTypeId = vm.DiscountTypeId,
				TargetTypeId = vm.TargetTypeId,
				PromotionProductTypeId = vm.PromotionProductTypeId,
				PriceThreshold = vm.PriceThreshold,
				DiscountQty = vm.DiscountQty == 0 ? null : vm.DiscountQty,
				Amount = vm.Amount == 0 ? null : vm.Amount,
				FreebieId = vm.FreebieId == 0 ? null : vm.FreebieId,
				GiftCouponId = vm.GiftCouponId == 0 ? null : vm.GiftCouponId,
				ExtraSalesUsage = vm.ExtraSalesUsage
			};

			int? memberLevelId = vm.MemberLevelId == 0 ? null : (int?)vm.MemberLevelId;
			int? memberTagId = vm.MemberTagId == 0 ? null : (int?)vm.MemberTagId;
			int? productTagId = vm.ProductTagId == 0 ? null : (int?)vm.ProductTagId;

			activityDiscount.MemberLevels = db.MemberLevels.Where(m => m.Id == vm.MemberLevelId).ToList();
			activityDiscount.MemberTags = db.MemberTags.Where(m => m.Id == vm.MemberTagId).ToList();
			activityDiscount.ProductTags = db.ProductTags.Where(p => p.Id == vm.ProductTagId).ToList();

			//var activityDetailInDb = db.ActivityDetails.FirstOrDefault(a => a.Id == vm.Id);

			//var activityDiscountInDb = db.ActivityDiscounts.FirstOrDefault(a => a.AcitivityDetailId == vm.Id);
			//if (activityDetailInDb == null || activityDiscountInDb == null)
			//{
			//	ModelState.AddModelError(string.Empty, "找不到資料");
			//	return View(vm);
			//}

			using (var transaction = db.Database.BeginTransaction())
			{
				try
				{
					//db.Entry(activityDetail).CurrentValues.SetValues(vm);
					//db.Entry(activityDiscount).CurrentValues.SetValues(vm);

					db.Entry(activityDetail).State = EntityState.Modified;
					db.Entry(activityDiscount).State = EntityState.Modified;
					////db.SaveChanges();
					db.SaveChanges();

					// 提交事务
					transaction.Commit();

					return RedirectToAction("Index", "ActivityDetails", new { id = vm.ActivityId });
				}
				catch
				{
					var discountTypeSelect = db.DiscountTypes.ToList().Prepend(new DiscountType { Id = 0, Name = "" });
					var freebie = db.Freebies.ToList().Prepend(new Freebie { Id = 0, Name = "" });
					var targetTypeSelect = db.TargetTypes.ToList().Prepend(new TargetType { Id = 0, Name = "" });
					var memberTagSelect = db.MemberTags.ToList().Prepend(new MemberTag { Id = 0, Name = "" });
					var memberLevelSelect = db.MemberLevels.ToList().Prepend(new MemberLevel { Id = 0, Name = "" });
					var promotionProductTypeSelect = db.PromotionProductTypes.ToList().Prepend(new PromotionProductType { Id = 0, Name = "" });
					var productTagSelect = db.ProductTags.ToList().Prepend(new ProductTag { Id = 0, Name = "" });
					var thirdCategorySelect = db.ThirdCategories.ToList().Prepend(new ThirdCategory { Id = 0, Name = "" });
					var CouponSelect = db.Coupons.ToList().Prepend(new Coupon { Id = 0, Name = "" });

					ViewBag.DiscountTypeId = new SelectList(discountTypeSelect, "Id", "Name", vm.DiscountTypeId);
					ViewBag.FreebieId = new SelectList(freebie, "Id", "Name", vm.FreebieId);
					ViewBag.TargetTypeId = new SelectList(targetTypeSelect, "Id", "Name", vm.TargetTypeId);
					ViewBag.MemberTagId = new SelectList(memberTagSelect, "Id", "Name", vm.MemberTagId);
					ViewBag.MemberLevelId = new SelectList(memberLevelSelect, "Id", "Name", vm.MemberLevelId);
					ViewBag.PromotionProductTypeId = new SelectList(promotionProductTypeSelect, "Id", "Name", vm.PromotionProductTypeId);
					ViewBag.ProductTagId = new SelectList(productTagSelect, "Id", "Name", vm.ProductTagId);
					ViewBag.ThirdCategoryId = new SelectList(thirdCategorySelect, "Id", "Name", vm.ThirdCategoryId);
					ViewBag.GiftCouponId = new SelectList(CouponSelect, "Id", "Name", vm.GiftCouponId);

					ModelState.AddModelError(string.Empty, "編輯失敗");
					return View(vm);
				}
			}
		}

		// POST: ActivityDetails/Delete/5
		[HttpPost, ActionName("Delete")]
		public ActionResult DeleteConfirmed(int? id)
		{
			if (id == null)
			{
				return HttpNotFound();
			}

			ActivityDetail activityDetail = db.ActivityDetails.Find(id);
			int activityId = activityDetail.ActivityId;
			ActivityDiscount activityDiscount = db.ActivityDiscounts.FirstOrDefault(a => a.AcitivityDetailId == id);

			if (activityDiscount == null && activityDetail == null)
			{
				ModelState.AddModelError(string.Empty, "資料庫找不到檔案");
				return RedirectToAction("Index", "ActivityDetails", new { id = activityId });
			}
			if (activityDiscount == null && activityDetail != null)
			{
				db.ActivityDetails.Remove(activityDetail);
				db.SaveChanges();
				return RedirectToAction("Index", "ActivityDetails", new { id = activityId });
			}

			db.ActivityDiscounts.Remove(activityDiscount);
			db.ActivityDetails.Remove(activityDetail);

			db.SaveChanges();
			return RedirectToAction("Index", "ActivityDetails", new { id = activityId });
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				db.Dispose();
			}
			base.Dispose(disposing);
		}

	}
}
