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

namespace Bump.EStore.MVC.Controllers
{
	[Authorize]
	public class SkillcurriculumsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Skillcurriculums
        public ActionResult Index()
        {
            var skillcurriculums = db.Skillcurriculums
                .Include(s => s.Coach)
                .Include(s => s.Field)
                .Include(s => s.SkillCours)
                .ToList()
                .Select(s=>s.ToIndexVM());
            return View(skillcurriculums);
        }


   

        // GET: Skillcurriculums/Create
        public ActionResult Create()
        {
            var coaceshList = db.Coaches.Where(c => c.Status).Prepend(new Coach());
			ViewBag.CoachId = new SelectList(coaceshList, "Id", "Name");
            var FieldList = db.Fields.ToList().Prepend(new Field());
            ViewBag.FieldId = new SelectList(FieldList, "Id", "Name");
            var SkillCourseList = db.SkillCourses.ToList().Prepend(new SkillCours());
			ViewBag.SkillCoursesId = new SelectList(SkillCourseList, "Id", "Name");
            return View();
        }

        // POST: Skillcurriculums/Create
        // 若要免於大量指派 (overposting) 攻擊，請啟用您要繫結的特定屬性，
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SkillcurriculumCreateVM vm)
        {
            if (ModelState.IsValid)
            {
                if (vm.CoachId != 0 && vm.FieldId != 0&& vm.SkillCoursesId != 0)
                {
                    string className = db.SkillCourses.FirstOrDefault(s => s.Id == vm.SkillCoursesId).Name;
                    DateTime startDate = vm.StartDate;
                    DateTime endDate = startDate.AddDays(7 * ((vm.Week) - 1));
                    string startDateText = startDate.ToString("MM/dd");
                    string EndDateText = endDate.ToString("MM/dd");
                    vm.Name = $"{className}({startDateText}~{EndDateText})";

                    Skillcurriculum skillcurriculum = vm.ToEntity();


                    db.Skillcurriculums.Add(skillcurriculum);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }else  {
                    if(vm.CoachId == 0) ModelState.AddModelError("CoachId", "教練必填");
					if (vm.FieldId == 0) ModelState.AddModelError("FieldId", "場館必填");
					if (vm.SkillCoursesId == 0) ModelState.AddModelError("SkillCoursesId", "課程必填");
				}
			}

			var coaceshList = db.Coaches.Where(c => c.Status).Prepend(new Coach());
			ViewBag.CoachId = new SelectList(coaceshList, "Id", "Name");
			var FieldList = db.Fields.ToList().Prepend(new Field());
			ViewBag.FieldId = new SelectList(FieldList, "Id", "Name");
			var SkillCourseList = db.SkillCourses.ToList().Prepend(new SkillCours());
			ViewBag.SkillCoursesId = new SelectList(SkillCourseList, "Id", "Name");
			return View(vm);
        }

        // GET: Skillcurriculums/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Skillcurriculum skillcurriculum = db.Skillcurriculums.Find(id);
            if (skillcurriculum == null)
            {
                return HttpNotFound();
            }
            ViewBag.CoachId = new SelectList(db.Coaches.Where(c => c.Status), "Id", "Name", skillcurriculum.CoachId);
            ViewBag.FieldId = new SelectList(db.Fields, "Id", "PhoneNumber", skillcurriculum.FieldId);
            ViewBag.SkillCoursesId = new SelectList(db.SkillCourses, "Id", "Name", skillcurriculum.SkillCoursesId);
            return View(skillcurriculum.ToEditVM());
        }

        // POST: Skillcurriculums/Edit/5
        // 若要免於大量指派 (overposting) 攻擊，請啟用您要繫結的特定屬性，
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SkillcurriculumEditVM vm)
        {
            if (ModelState.IsValid)
            {
                var skillcurriculumInDb = db.Skillcurriculums.Find(vm.Id);
				
				skillcurriculumInDb.CoachId = vm.CoachId; 

				
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CoachId = new SelectList(db.Coaches.Where(c => c.Status), "Id", "Name", vm.CoachId);
            ViewBag.FieldId = new SelectList(db.Fields, "Id", "Name", vm.Field);
            ViewBag.SkillCoursesId = new SelectList(db.SkillCourses, "Id", "Name", vm.SkillCoursesId);
            return View(vm);
        }

        // GET: Skillcurriculums/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Skillcurriculum skillcurriculum = db.Skillcurriculums.Find(id);
            if (skillcurriculum == null)
            {
                return HttpNotFound();
            }
            return View(skillcurriculum.ToDeleteVM());
        }

        // POST: Skillcurriculums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Skillcurriculum skillcurriculum = db.Skillcurriculums.Find(id);
            db.Skillcurriculums.Remove(skillcurriculum);
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
