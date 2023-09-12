using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Bump.EStore.Infrastructure.Data.EFModels;
using Bump.EStore.MVC.ViewModels;
using Newtonsoft.Json.Linq;
using static System.Net.Mime.MediaTypeNames;
using X.PagedList;

namespace Bump.EStore.MVC.Controllers
{
	[Authorize(Roles = "教練,管理員")]
	public class CoachesController : Controller
	{
		private AppDbContext db = new AppDbContext();

		// GET: Coaches
		public ActionResult Index(CoachCriteria criteria, int page = 1, int pageSize = 3)
		{

			ViewBag.Criteria = criteria;

			

			var query = db.Coaches.AsQueryable();
			if (string.IsNullOrEmpty(criteria.Name) == false)
			{
				query = query.Where(c => c.Name.Contains(criteria.Name));
			}
			if (criteria.Id != null && criteria.Id > 0)
			{
				query = query.Where(c => c.Id == criteria.Id);
			}
			//if (criteria.Status == true)
			//{
			//	query = query.Where(c => c.Status == criteria.Status);
			//}
			//if (criteria.Status == false)
			//{
			//	query = query.Where(c => c.Status == criteria.Status);
			//}
			var coaches = query.ToList().Select(c => c.TOindexVM()).OrderBy(c => c.Id).ToPagedList(page, pageSize);
			return View(coaches);
		}


		// GET: Coaches/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Coaches/Create
		// 若要免於大量指派 (overposting) 攻擊，請啟用您要繫結的特定屬性，
		// 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(CoachCreateVM vm, HttpPostedFileBase file1)
		{
			if (ModelState.IsValid)
			{
				string path = Server.MapPath("/Uploads/Coach_imgs");
				string fileName = SaveUploadedFile(path, file1);
				vm.Img = fileName;

				vm.Status = true;
				Coach coach = vm.TOEntity();

				db.Coaches.Add(coach);
				db.SaveChanges();

				return RedirectToAction("Index");
			}

			return View(vm);
		}

		private string SaveUploadedFile(string path, HttpPostedFileBase file1)
		{
			if (file1 == null || file1.ContentLength == 0) return string.Empty;

			string ext = System.IO.Path.GetExtension(file1.FileName);

			string[] allowedExts = new string[] { ".jpg", ".jpeg", ".png", ".tif", ".gif" };
			if (allowedExts.Contains(ext.ToLower()) == false) return string.Empty;

			string newFileName = Guid.NewGuid().ToString("N") + ext;
			string fullName = System.IO.Path.Combine(path, newFileName);

			file1.SaveAs(fullName);

			return newFileName;
		}

		// GET: Coaches/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Coach coach = db.Coaches.Find(id);
			if (coach == null)
			{
				return HttpNotFound();
			}
			return View(coach.TOEditVM());
		}

		// POST: Coaches/Edit/5
		// 若要免於大量指派 (overposting) 攻擊，請啟用您要繫結的特定屬性，
		// 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(CoachEditVM vm)
		{
			if (ModelState.IsValid)
			{
				var coachInDb = db.Coaches.Find(vm.Id);
				coachInDb.Name = vm.Name;
				coachInDb.PhoneNumber = vm.PhoneNumber;
				coachInDb.Email = vm.Email;

				var Skillcurriculums = db.Skillcurriculums
	.Where(s => s.CoachId == vm.Id)
	 .OrderByDescending(s => s.StartDate)
	.FirstOrDefault();
				if (Skillcurriculums == null)
				{
					coachInDb.Status = vm.Status;
					db.SaveChanges();
					return RedirectToAction("Index");
				}

				var startDate = Skillcurriculums.StartDate;
				var week = Skillcurriculums.Week;
				DateTime endDate = startDate.AddDays(7 * ((week) - 1));
				if (endDate < DateTime.Now.Date)
				{
					coachInDb.Status = vm.Status;

					db.SaveChanges();
					return RedirectToAction("Index");
				}
				else
				{
					ModelState.AddModelError("", "該教練還有課表沒上完，無法更改狀態");
				}
			}
			return View(vm);
		}

		// GET: Coaches/EditImg/
		public ActionResult EditImg(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Coach coach = db.Coaches.Find(id);
			if (coach == null)
			{
				return HttpNotFound();
			}
			return View(coach.TOEditImgVM());
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult EditImg(CoachEditImgVM vm, HttpPostedFileBase file1)
		{
			if (vm.Id == null) { return new HttpStatusCodeResult(HttpStatusCode.BadRequest); }
			string path = Server.MapPath("/uploads/Coach_imgs");
			var saveFileName = SaveUploadedFile(path, file1);
			vm.Img = saveFileName;

			if (saveFileName == null) ModelState.AddModelError("Img", "請選擇檔案");
			if (ModelState.IsValid)
			{
				var coachInDb = db.Coaches.Find(vm.Id);

				coachInDb.Img = vm.Img;

				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(vm);
		}

		// GET: Coaches/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Coach coach = db.Coaches.Find(id);
			if (coach == null)
			{
				return HttpNotFound();
			}
			return View(coach);
		}

		// POST: Coaches/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			Coach coach = db.Coaches.Find(id);
			db.Coaches.Remove(coach);
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
	}
}
