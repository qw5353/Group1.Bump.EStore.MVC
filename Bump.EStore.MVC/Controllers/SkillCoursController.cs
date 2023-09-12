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
using X.PagedList;

namespace Bump.EStore.MVC.Controllers
{
	[Authorize]
	public class SkillCoursController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: SkillCours
        public ActionResult Index(int page = 1, int pageSize = 3)
        {
            var skillCours = db.SkillCourses.AsQueryable()
                .ToList()
                .Select(s => s.ToIndexVM())
				.OrderBy(c => c.Id).ToPagedList(page, pageSize); ;
            return View(skillCours);
        }

        // GET: SkillCours/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SkillCours skillCours = db.SkillCourses.Find(id);
            if (skillCours == null)
            {
                return HttpNotFound();
            }
            return View(skillCours);
        }

        // GET: SkillCours/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SkillCours/Create
        // 若要免於大量指派 (overposting) 攻擊，請啟用您要繫結的特定屬性，
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SkillCoursCreateVM vm,HttpPostedFileBase file1)
        {
            if (ModelState.IsValid)
            {
				string path = Server.MapPath("/Uploads/SkillCours_imgs");
				string fileName = SaveUploadedFile(path, file1);
				vm.Thumbnail = fileName;

				SkillCours skillCours = vm.ToEntity();

				db.SkillCourses.Add(skillCours);
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

		// GET: SkillCours/Edit/5
		public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SkillCours skillCours = db.SkillCourses.Find(id);
            if (skillCours == null)
            {
                return HttpNotFound();
            }
            return View(skillCours.ToEditVM());
        }

        // POST: SkillCours/Edit/5
        // 若要免於大量指派 (overposting) 攻擊，請啟用您要繫結的特定屬性，
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SkillCoursEditVM vm)
        {
            if (ModelState.IsValid)
            {
               var skillCoursInDb = db.SkillCourses.Find(vm.Id);
				skillCoursInDb.Name = vm.Name;
                skillCoursInDb.Description = vm.Description;
				skillCoursInDb.Price = vm.Price;
				skillCoursInDb.PeopleMin = vm.PeopleMin;
                skillCoursInDb.PeopleMax = vm.PeopleMax;

				db.SaveChanges();
                return RedirectToAction("Index");
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
			SkillCours skillCours = db.SkillCourses.Find(id);
			if (skillCours == null)
			{
				return HttpNotFound();
			}
			return View(skillCours.ToEditImgVM());
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult EditImg(SkillCoursEditImgVM vm, HttpPostedFileBase file1)
		{
			if (vm.Id == null) { return new HttpStatusCodeResult(HttpStatusCode.BadRequest); }
			string path = Server.MapPath("/Uploads/SkillCours_imgs");
			var saveFileName = SaveUploadedFile(path, file1);
			vm.Thumbnail = saveFileName;

			if (saveFileName == null) ModelState.AddModelError("Img", "請選擇檔案");
			if (ModelState.IsValid)
			{
				var skillCoursInDb = db.SkillCourses.Find(vm.Id);

				skillCoursInDb.Thumbnail = vm.Thumbnail;

				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(vm);
		}
		// GET: SkillCours/Delete/5
		public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SkillCours skillCours = db.SkillCourses.Find(id);
            if (skillCours == null)
            {
                return HttpNotFound();
            }
            return View(skillCours.ToDeleteVM());
        }

        // POST: SkillCours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SkillCours skillCours = db.SkillCourses.Find(id);
            db.SkillCourses.Remove(skillCours);
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
