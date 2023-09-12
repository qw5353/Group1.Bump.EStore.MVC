using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Bump.EStore.Infrastructure.Data.EFModels;
using Bump.EStore.MVC.ViewModels;
using X.PagedList;

namespace Bump.EStore.MVC.Controllers
{
	[Authorize]
	public class FieldsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Fields
        public ActionResult Index(int page = 1, int pageSize = 3)
        {
            var field = db.Fields.AsQueryable()
                                 .ToList()
                                 .Select(c=>c.ToIndexVM())
								 .OrderBy(c => c.Id)
                                 .ToPagedList(page, pageSize);
            return View(field);
        }

        // GET: Fields/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Field field = db.Fields.Find(id);
            if (field == null)
            {
                return HttpNotFound();
            }
            return View(field.ToDetailsVM());
        }

        // GET: Fields/Create
        public ActionResult Create()
        {
            ViewBag.FieidId = new SelectList(db.Fields, "Id", "Name");
            return View();
        }

        // POST: Fields/Create
        // 若要免於大量指派 (overposting) 攻擊，請啟用您要繫結的特定屬性，
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
		public ActionResult Create(FieldCreateVM vm, HttpPostedFileBase file1)
		{
			if (ModelState.IsValid)
			{
				using (var transaction = db.Database.BeginTransaction())
				{
					try
					{
						string path = Server.MapPath("/Uploads/Field_imgs");
						string fileName = SaveUploadedFile(path, file1);
						vm.Thumbnail = fileName;
						Field field = vm.ToEntity();

						db.Fields.Add(field);
						db.SaveChanges();

						if (vm.Weekday != 0 && vm.BanStartDateTime != null && vm.BanEndDateTime != null)
						{
							// 處理 BanDates 資料
							DateTime today = DateTime.Today;

							// 建立一個 Dictionary 來映射星期幾到對應的 DayOfWeek 枚舉
							Dictionary<int, DayOfWeek> weekdayMapping = new Dictionary<int, DayOfWeek>()
					{						
						{ 1, DayOfWeek.Monday },
						{ 2, DayOfWeek.Tuesday },
						{ 3, DayOfWeek.Wednesday },
						{ 4, DayOfWeek.Thursday },
						{ 5, DayOfWeek.Friday },
						{ 6, DayOfWeek.Saturday },
						{ 7, DayOfWeek.Sunday }
					};

							// 處理每個選擇的星期的開始時間和結束時間
							if (weekdayMapping.ContainsKey(vm.Weekday))
							{
								// 取得選擇的星期的 DayOfWeek 枚舉值
								DayOfWeek selectedDayOfWeek = weekdayMapping[vm.Weekday];

								// 計算起始日期為下一個選擇的星期的日期
								int daysUntilNextWeekday = (7 + (int)selectedDayOfWeek - (int)today.DayOfWeek) % 7;
								DateTime selectedDate = today.AddDays(daysUntilNextWeekday);

								// 設定結束日期為當年底
								DateTime endDateTime = new DateTime(DateTime.Today.Year, 12, 31);

								// 確保選擇的日期在結束日期之前
								while (selectedDate <= endDateTime)
								{
									// 計算開始時間和結束時間
									DateTime startDateTime = selectedDate.Date + DateTime.Parse(vm.BanStartDateTime).TimeOfDay;
									DateTime endDateTimeRange = selectedDate.Date + DateTime.Parse(vm.BanEndDateTime).TimeOfDay;

									// 在這裡執行你要進行的操作，使用 startDateTime 和 endDateTimeRange 執行相應的處理

									// 將資料存入資料庫
									BanDate data = new BanDate
									{
										BanStartDateTime = startDateTime,
										BanEndDateTime = endDateTimeRange,
										FieldId = field.Id
									};
									db.BanDates.Add(data);
									db.SaveChanges();

									// 下一個選擇的星期
									selectedDate = selectedDate.AddDays(7);
								}
							}
						}

						// 返回視圖或其他適當的回應
						transaction.Commit();
						return RedirectToAction("Index");
					}
					catch
					{
						ViewBag.FieidId = new SelectList(db.Fields, "Id", "Name");
						return View(vm);
					}
				}
			}
			else
			{
				ViewBag.FieidId = new SelectList(db.Fields, "Id", "Name");
				return View(vm);
			}
		}
		private string SaveUploadedFile(string path, HttpPostedFileBase file1)
		{
			if (file1 == null || file1.ContentLength == 0) return string.Empty;

			string ext = System.IO.Path.GetExtension(file1.FileName);

			string[] allowedExts = new string[] { ".jpg", ".jpeg", ".png", ".tif", ".gif" , ".webp" };
			if (allowedExts.Contains(ext.ToLower()) == false) return string.Empty;

			string newFileName = Guid.NewGuid().ToString("N") + ext;
			string fullName = System.IO.Path.Combine(path, newFileName);

			file1.SaveAs(fullName);

			return newFileName;
		}

		// GET: Fields/Edit/5
		public ActionResult Edit(int? id)
        {
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Field field = db.Fields.Find(id);
			if (field == null)
			{
				return HttpNotFound();
			}
			return View(field.TOEditVM());
		}

        // POST: Fields/Edit/5
        // 若要免於大量指派 (overposting) 攻擊，請啟用您要繫結的特定屬性，
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FieldEditVM vm)
        {
			if (ModelState.IsValid)
			{
				var fieldInDb = db.Fields.Find(vm.Id);
				fieldInDb.Name = vm.Name;
				fieldInDb.PhoneNumber = vm.PhoneNumber;
				fieldInDb.Address = vm.Address;
                fieldInDb.Link = vm.Link;
                fieldInDb.Indoor= vm.Indoor;
                fieldInDb.ShortDescription = vm.ShortDescription;
                fieldInDb.BusinessWeekdayStartTime = vm.BusinessWeekdayStartTime;
                fieldInDb.BusinessWeekdayEndTime = vm.BusinessWeekdayEndTime;
                fieldInDb.BusinessWeekendStartTime = vm.BusinessWeekendStartTime;   
                fieldInDb.BusinessWeekendEndTime = vm.BusinessWeekendEndTime;

				db.SaveChanges();
				return RedirectToAction("Details", new { id = vm.Id });
			}
			return View(vm);
		}

		public ActionResult EditImg(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Field field = db.Fields.Find(id);
			if (field == null)
			{
				return HttpNotFound();
			}
			return View(field.TOEditImgVM());
		}

		[HttpPost]
		public ActionResult EditImg(FieldEditImgVM vm, HttpPostedFileBase file1)
		{
			if (vm.Id==null) { return new HttpStatusCodeResult(HttpStatusCode.BadRequest); }
			string path = Server.MapPath("/uploads/Field_imgs");
			var saveFileName = SaveUploadedFile(path, file1);
			vm.Thumbnail = saveFileName;

			if (saveFileName == null) ModelState.AddModelError("Img", "請選擇檔案");
			if (ModelState.IsValid)
			{
				var fieldInDb = db.Fields.Find(vm.Id);

				fieldInDb.Thumbnail = vm.Thumbnail;

				db.SaveChanges();
				return RedirectToAction("Details", new { id = vm.Id });
			}
			return View(vm);
		}

		// GET: Fields/Delete/5
		public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Field field = db.Fields.Find(id);
            if (field == null)
            {
                return HttpNotFound();
            }
            return View(field.ToDeleteVM());
        }

        // POST: Fields/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Field field = db.Fields.Find(id);
            db.Fields.Remove(field);
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
