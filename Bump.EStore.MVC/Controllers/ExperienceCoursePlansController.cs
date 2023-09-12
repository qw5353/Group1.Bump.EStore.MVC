using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Bump.EStore.Infrastructure.Data.EFModels;
using Bump.EStore.MVC.ViewModels.ExperienceCoursePlans;

namespace Bump.EStore.MVC.Controllers
{
	[Authorize]
	public class ExperienceCoursePlansController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: ExperienceCoursePlans
        public ActionResult Index()
        {
            return View(db.ExperienceCoursePlans.ToList().Select(c=>c.ToIndexVM()));
        }

        // GET: ExperienceCoursePlans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExperienceCoursePlan experienceCoursePlan = db.ExperienceCoursePlans.Find(id);
            if (experienceCoursePlan == null)
            {
                return HttpNotFound();
            }
            return View(experienceCoursePlan);
        }

        // GET: ExperienceCoursePlans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExperienceCoursePlans/Create
        // 若要免於大量指派 (overposting) 攻擊，請啟用您要繫結的特定屬性，
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ExperienceCoursePlanCreateVM vm)
        {
            if (ModelState.IsValid)
            {
                db.ExperienceCoursePlans.Add(vm.ToEntity());
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vm);
        }

        // GET: ExperienceCoursePlans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExperienceCoursePlan experienceCoursePlan = db.ExperienceCoursePlans.Find(id);
            if (experienceCoursePlan == null)
            {
                return HttpNotFound();
            }
            return View(experienceCoursePlan.ToEditVM());
        }

        // POST: ExperienceCoursePlans/Edit/5
        // 若要免於大量指派 (overposting) 攻擊，請啟用您要繫結的特定屬性，
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ExperienceCoursePlanEditVM vm)
        {
            if (ModelState.IsValid)
            {
                var experienceCoursePlanInDb = db.ExperienceCoursePlans.Find(vm.Id);
				experienceCoursePlanInDb.Name = vm.Name;
				experienceCoursePlanInDb.Price = vm.Price;
				experienceCoursePlanInDb.PeopleMin = vm.PeopleMin;
				experienceCoursePlanInDb.PeopleMax = vm.PeopleMax;

				
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vm);
        }

        // GET: ExperienceCoursePlans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExperienceCoursePlan experienceCoursePlan = db.ExperienceCoursePlans.Find(id);
            if (experienceCoursePlan == null)
            {
                return HttpNotFound();
            }
            return View(experienceCoursePlan.ToDeleteVM());
        }

        // POST: ExperienceCoursePlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExperienceCoursePlan experienceCoursePlan = db.ExperienceCoursePlans.Find(id);
            db.ExperienceCoursePlans.Remove(experienceCoursePlan);
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
