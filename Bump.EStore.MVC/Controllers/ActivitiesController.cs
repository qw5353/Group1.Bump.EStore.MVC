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
using Bump.EStore.Infrastructure.Criteria;
using Bump.EStore.Infrastructure.Data.EFModels;
using Bump.EStore.Infrastructure.Infra;
using Bump.EStore.Infrastructure.Repositories.EFRepositories;
using Bump.EStore.Infrastructure.Repositories.Interfaces;
using Bump.EStore.MVC.ViewModels;
using Bump.EStore.MVC.ViewModels.Activities;
using Activity = Bump.EStore.Infrastructure.Data.EFModels.Activity;

namespace Bump.EStore.MVC.Controllers
{
	[Authorize]
	public class ActivitiesController : Controller
	{
		private AppDbContext db = new AppDbContext();

		// GET: Activities
		public ActionResult Index(ActivityCriteria criteria)
		{
			ViewBag.Criteria = criteria;
			var statusList = new Status[] {
				new Status {},
				new Status {Name= "未開始", Id=1},
				new Status {Name= "進行中", Id=2},
				new Status {Name= "已過期", Id=3}
			};
			ViewBag.Status = new SelectList(statusList, "Id", "Name");

			IActivityRepository repo = new ActivityEFRepository();
			ActivityService service = new ActivityService(repo);

			var activity = service.Search(criteria).Select(a => a.ToVM());

			return View(activity);
		}


		// GET: Activities/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Activities/Create
		// 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
		// 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(ActivityCreateVM vm)
		{
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

			vm.CreatedTime = DateTime.Now;

			if (vm.StartTime > vm.EndTime)
			{
				ModelState.AddModelError(string.Empty, "SystemErrorMessage");
			}

			IActivityRepository repo = new ActivityEFRepository();
			ActivityService service = new ActivityService(repo);

			if (ModelState.IsValid == false) return View(vm);

			service.Create(vm.ToDto());

			return RedirectToAction("Index");
		}

		// GET: Activities/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return HttpNotFound();
			}
			Activity activity = db.Activities.Find(id);
			if (activity == null)
			{
				return HttpNotFound();
			}
			var vm = new ActivityEditVM
			{
				Id = activity.Id,
				Name = activity.Name,
				Status = activity.Status,
				StartTime = activity.StartTime,
				EndTime = activity.EndTime,
				Description = activity.Description,
				//Thumbnail = entity.Thumbnail,
				CreatedTime = activity.CreatedTime
			};

			return View(vm);
		}

		// POST: Activities/Edit/5
		// 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
		// 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(ActivityEditVM vm)
		{
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


			if (ModelState.IsValid)
			{
				db.Entry(vm.ToEntity()).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View();
		}

		// GET: Activities/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return HttpNotFound();
			}
			Activity activity = db.Activities.Find(id);
			if (activity == null)
			{
				return HttpNotFound();
			}
			return View(activity);
		}

		// POST: Activities/Delete/5
		[HttpPost, ActionName("Delete")]
		public ActionResult DeleteConfirmed(int id)
		{
			Activity activity = db.Activities.Find(id);
			db.Activities.Remove(activity);
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

		public class Status
		{
			public int Id { get; set; }
			public string Name { get; set; }
		}
	}
}
