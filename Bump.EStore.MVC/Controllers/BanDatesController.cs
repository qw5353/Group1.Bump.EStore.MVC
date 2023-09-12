using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Bump.EStore.Infrastructure.Data.EFModels;
using Bump.EStore.MVC.ViewModels.BanDates;

namespace Bump.EStore.MVC.Controllers
{
	[Authorize]
	public class BanDatesController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: BanDates
        public ActionResult Index()
        {
            var banDates = db.BanDates
                .ToList()
                .Select(b=>b.ToIndexVM());
                
            return View(banDates);
        }      

        public ActionResult Create()
		{
            var FieldList= db.Fields.ToList().Prepend(new Field());
			ViewBag.FieldId = new SelectList(FieldList, "Id", "Name");

			return View();
        }
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(BanDateCreateVM vm)
        {
            if (ModelState.IsValid)
            {
                if (vm.FieldId != 0)
                {
                    BanDate banDate = vm.ToCreateVM();

                    db.BanDates.Add(banDate);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                else { ModelState.AddModelError("FieldId","場館必填"); }
            }
			var FieldList = db.Fields.ToList().Prepend(new Field());
			ViewBag.FieldId = new SelectList(FieldList, "Id", "Name");

			return View(vm);
		}



		// GET: BanDates/Delete/5
		public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BanDate banDate = db.BanDates.Find(id);
            if (banDate == null)
            {
                return HttpNotFound();
            }
            return View(banDate.ToDeleteVM());
        }

        // POST: BanDates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BanDate banDate = db.BanDates.Find(id);
            db.BanDates.Remove(banDate);
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
