using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Bump.EStore.Infrastructure.Data.EFModels;

namespace Bump.EStore.MVC.Controllers
{
	[Authorize]
	public class CouponSendＭembersController : Controller
	{
		private AppDbContext db = new AppDbContext();

		// GET: CouponSendＭembers
		public ActionResult Index(int? id)
		{
			if (id == null)
			{
				return HttpNotFound();
			}
			ViewBag.Id = id;
			var couponSendＭembers = db.CouponSendＭembers.Where(c => c.CouponId == id).Include(c => c.Coupon);

			return View(couponSendＭembers.ToList());
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
