using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Bump.EStore.Infrastructure.Data.EFModels;
using Bump.EStore.Infrastructure.Repositories.DapperRepositories;
using Bump.EStore.MVC.ViewModels.MemberTags;
using X.PagedList;

namespace Bump.EStore.MVC.Controllers
{
	[Authorize]
	public class MemberTagsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: MemberTags
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var memberTag = new MemberTagDapperRepository()
                .TotalSearch()
                .Select(m => m.ToMemberTagIndexVM()).ToPagedList(page,pageSize);

            return View(memberTag);
        }

        // GET: MemberTags/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MemberTag memberTag = db.MemberTags.Find(id);
            if (memberTag == null)
            {
                return HttpNotFound();
            }
            return View(memberTag);
        }

        // GET: MemberTags/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MemberTags/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateTagVM[] conditions)
        {
            if(!ModelState.IsValid)
            {
                return View(conditions);
            }

            var create = new MemberTagDapperRepository();
            create.CreateMemberTags(conditions.Select(vm => vm.ToMemberTagCreateEntity()));
            var insertedId = create.CreatedMemberTagId();
            //MemberTag memberTagId = db.MemberTags.FirstOrDefault(d=>d.Id==insertedId);
            create.CreateMemberTagsCondition(conditions.Select(vm=>vm.ToMemberTagCreateEntity()), insertedId);

            return RedirectToAction("Index");
        }

        // GET: MemberTags/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MemberTag memberTag = db.MemberTags.Find(id);
            if (memberTag == null)
            {
                return HttpNotFound();
            }
            return View(memberTag);
        }

        // POST: MemberTags/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,CreateAt,Description")] MemberTag memberTag)
        {
            if (ModelState.IsValid)
            {
                db.Entry(memberTag).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(memberTag);
        }

        // GET: MemberTags/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MemberTag memberTag = db.MemberTags.Find(id);
            if (memberTag == null)
            {
                return HttpNotFound();
            }
            return View(memberTag);
        }

        // POST: MemberTags/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var delete = new MemberTagDapperRepository();
            delete.DeleteMemberTag(id);

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
