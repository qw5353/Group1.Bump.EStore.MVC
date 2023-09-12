using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Bump.EStore.Infrastructure.Data.EFModels;
using Bump.EStore.MVC.ViewModels.Freebies;

namespace Bump.EStore.MVC.Controllers
{
	[Authorize]
	public class FreebiesController : Controller
	{
		private AppDbContext db = new AppDbContext();

		// GET: Freebies
		public ActionResult Index()
		{
			return View(db.Freebies.ToList());
		}

		// GET: Freebies/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Freebie freebie = db.Freebies.Find(id);
			if (freebie == null)
			{
				return HttpNotFound();
			}
			return View(freebie);
		}

		// GET: Freebies/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Freebies/Create
		// 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
		// 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(FreebieCreateVM vm, HttpPostedFileBase imgFile)
		{
			vm.CreatedAt = DateTime.Now;
			vm.UpdatedTime = DateTime.Now;

			if (!ModelState.IsValid) return View(vm);

			string path = Server.MapPath("/Uploads/Freebie_imgs");
			string fileName = SaveUploadFile(path, imgFile);
			vm.Thumbnail = fileName;

			db.Freebies.Add(vm.ToEntity());
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		// GET: Freebies/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return HttpNotFound();
			}
			Freebie freebie = db.Freebies.Find(id);
			if (freebie == null)
			{
				return HttpNotFound();
			}
			return View(freebie.ToVM());
		}

		// POST: Freebies/Edit/5
		// 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
		// 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(FreebieEditVM vm)
		{
			vm.UpdatedTime = DateTime.Now;
			if (ModelState.IsValid)
			{
				var entityIndb = db.Freebies.Find(vm.Id);
				db.Entry(entityIndb).CurrentValues.SetValues(vm);

				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(vm);
		}

		// GET: Freebies/Edit/5
		public ActionResult EditImg(int? id)
		{
			if (id == null)
			{
				return HttpNotFound();
			}
			Freebie freebie = db.Freebies.Find(id);
			if (freebie == null)
			{
				return HttpNotFound();
			}
			return View(freebie.ToImgVM());
		}

		// POST: Freebies/Edit/5
		// 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
		// 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult EditImg(FreebieEditImgVM vm, HttpPostedFileBase imgFile)
		{
			string path = Server.MapPath("/Uploads/Freebie_imgs");
			string fileName = SaveUploadFile(path, imgFile);
			vm.Thumbnail = fileName;

			if (ModelState.IsValid)
			{
				var entityIndb = db.Freebies.Find(vm.Id);
				entityIndb.Thumbnail = vm.Thumbnail;

				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(vm);
		}


		// GET: Freebies/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return HttpNotFound();
			}
			Freebie freebie = db.Freebies.Find(id);
			if (freebie == null)
			{
				return HttpNotFound();
			}
			return View(freebie);
		}

		// POST: Freebies/Delete/5
		[HttpPost, ActionName("Delete")]
		public ActionResult DeleteConfirmed(int id)
		{
			Freebie freebie = db.Freebies.Find(id);
			db.Freebies.Remove(freebie);
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

		private string SaveUploadFile(string path, HttpPostedFileBase imgFile)
		{
			if (imgFile == null || imgFile.ContentLength == 0) return string.Empty;
			string ext = System.IO.Path.GetExtension(imgFile.FileName);

			string[] allowExt = new string[] { ".jpg", ".jpeg", ".png", ".tif", ".gif", ".svg" };
			if (allowExt.Contains(ext.ToLower()) == false) return string.Empty;

			string newFileName = Guid.NewGuid().ToString("N") + ext;
			string fullPath = System.IO.Path.Combine(path, newFileName);

			imgFile.SaveAs(fullPath);

			return newFileName;
		}
	}
}
