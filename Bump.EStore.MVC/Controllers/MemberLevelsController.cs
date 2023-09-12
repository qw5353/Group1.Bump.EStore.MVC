using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Bump.EStore.Infrastructure.Data.EFModels;
using Bump.EStore.MVC.ViewModels.MemberLevels;

namespace Bump.EStore.MVC.Controllers
{
	[Authorize]
	public class MemberLevelsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: MemberLevels
        public ActionResult Index()
        {
            var memberLevel = db.MemberLevels.ToList().Select(m => m.ToMemberLevelIndexVM());
            return View(memberLevel);
        }

        // GET: MemberLevels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MemberLevel memberLevel = db.MemberLevels.Find(id);
            if (memberLevel == null)
            {
                return HttpNotFound();
            }
            return View(memberLevel);
        }

        // GET: MemberLevels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MemberLevels/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MemberLevelCreateVM vm)
        {
            //會員等級 & 等級名稱 不能選擇目前資料庫裏面有的
            // 升級金額&總訂單數預設帶入0

            if (ModelState.IsValid)
            {
                db.MemberLevels.Add(vm.ToMemberLevelCreateEntity());
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vm);
        }

        // GET: MemberLevels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MemberLevel memberLevel = db.MemberLevels.Find(id);
            if (memberLevel == null)
            {
                return HttpNotFound();
            }
            return View(memberLevel.ToMemberLevelEditVM());
        }

        // POST: MemberLevels/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MemberLevelEditVM vm)
        {
            //會員等級 & 等級名稱 不能選擇目前資料庫裏面有的

            if (ModelState.IsValid)
            {
                var memberLevelInDb = db.MemberLevels.FirstOrDefault(m=>m.Id == vm.Id);
                db.Entry(memberLevelInDb).CurrentValues.SetValues(vm);

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vm);
        }

        // GET: MemberLevels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MemberLevel memberLevel = db.MemberLevels.Find(id);
            if (memberLevel == null)
            {
                return HttpNotFound();
            }
            return View(memberLevel);
        }

        // POST: MemberLevels/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            MemberLevel memberLevel = db.MemberLevels.Find(id);
            db.MemberLevels.Remove(memberLevel);
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
