using Bump.EStore.Core.Services;
using Bump.EStore.Infrastructure.Repositories.Interfaces;
using Bump.EStore.Infrastructure.Repositories.EFRepositories;
using Bump.EStore.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Bump.EStore.Infrastructure.Infra;
using System.Net;
using Bump.EStore.Infrastructure.Data.EFModels;
using Member = Bump.EStore.Infrastructure.Data.EFModels.Member;
using Bump.EStore.MVC.ViewModels.Members;
using Antlr.Runtime.Misc;
using System.Data.Entity;
using Bump.EStore.Infrastructure.Repositories.DapperRepositories;
using Bump.EStore.Infrastructure.Criteria;
using X.PagedList;

namespace Bump.EStore.MVC.Controllers
{
	[Authorize]
	public class MembersController : Controller
    {
        private AppDbContext _db = new AppDbContext();
		IMemberRepository repo = new MemberRepositories();
        
        private MembersService _service;
        public MembersController()
        {
            _service = new MembersService(repo);
        }


        // GET: Members
        public ActionResult Index(MemberCriteria criteria, int page = 1, int pageSize = 6)
        {

            ViewBag.Criteria = criteria;
			PrepareMemberLevelOrderDataSource(criteria.MemberLevel); //ViewBag.MemberLevel = _db.MemberLevels
			PrepareMemberTagDataSource(criteria.MemberTag);  //ViewBag.MemberTag = _db.MemberTags

			var memberWithPage = new MemberDapperRepository()
				.TotalSearch(criteria)
				.Select(m => m.ToMemberIndexVM()).ToPagedList(page, pageSize);

			var memberCount = new MemberDapperRepository()
				.TotalSearch(criteria)
				.Select(m => m.ToMemberIndexVM()).Count();

			ViewBag.MemberCount = memberCount;

			return View(memberWithPage);
			

			//var MemberQuery = _db.Members.AsQueryable();
			//var MemberLevelQuery = _db.MemberLevels.AsQueryable();
			//var MemberTagQuery = _db.MemberTags.AsQueryable();

			//#region Where
			//if (string.IsNullOrEmpty(criteria.Search) == false)
			//{
			//	MemberQuery = MemberQuery.Where(p => p.Name.Contains(criteria.Search) ||
			//										 p.Nickname.Contains(criteria.Search) ||
			//										 p.Account.Contains(criteria.Search) ||
			//										 p.Email.Contains(criteria.Search) ||
			//										 DbFunctions.TruncateTime(p.Birthday).ToString().Contains(criteria.Search));
			//}
			//if (criteria.MemberLevelId != null && criteria.MemberLevelId.Value > 0)
			//{
			//	//MemberLevelQuery = MemberLevelQuery.Where(p=>p.LevelOrder==criteria.MemberLevelId);

			//	MemberQuery = MemberQuery.Join(
			//			MemberLevelQuery,
			//			member => member.MemberLevelId,
			//			memberLevel => memberLevel.Id,
			//			(member, memberLevel) => new { Member = member, MemberLevel = memberLevel }
			//			 ).Where(joined => joined.MemberLevel.LevelOrder == criteria.MemberLevelId)
			//			.Select(joined => joined.Member);
			//}
			////         if(criteria.MemberTagId !=null && criteria.MemberTagId.Value > 0)
			////         {
			////	//MemberTagQuery= MemberTagQuery.Where(p=>p.Id==criteria.MemberTagId);

			////	MemberQuery = MemberQuery.Join(
			////	 MemberTagQuery,
			////	member => member.MemberTagId,
			////	 memberTag => memberTag.Id,
			////	 (member, memberTag) => new { Member = member, MemberTag = memberTag }
			////	 ).Where(joined => joined.MemberTag.Id == criteria.MemberTagId)
			////	 .Select(joined => joined.Member);

			////}
			//#endregion

			//var totalCount = MemberQuery.Count();  // 總紀錄數
			//var totalPages = (int)Math.Ceiling((double)totalCount / rowPerPage);  // 總頁數

			//var vms = MemberQuery
			//	.OrderBy(m => m.Id)
			//	.Skip((pageNumber - 1) * rowPerPage)
			//	.Take(rowPerPage)
			//	.AsEnumerable()
			//	.Select(m =>
			//	{
			//		var vm = m.ToMemberIndexVM();
			//		vm.MemberLevel = _db.MemberLevels.SingleOrDefault(lv => lv.LevelOrder == vm.MemberLevelOrder)?.Name;
			//		return vm;
			//	})
			//	.ToList();

			//ViewBag.TotalCount = totalCount;
			//ViewBag.TotalPages = totalPages;
			//ViewBag.CurrentPage = pageNumber;

			//return View(vms);

			//IEnumerable<MemberIndexVM> member = GetMembers();
			//var vms1 = MemberQuery
			//			 .AsEnumerable()
			//			 .Select(m => m.ToMemberIndexVM())
			//			 .ToList();

			//return View(vms);
		}

		private void PrepareMemberLevelOrderDataSource(int? MemberLevelName)
		{
			var memberLevel = _db.MemberLevels.ToList();
			ViewBag.MemberLevel = new SelectList(memberLevel, "LevelOrder", "Name", MemberLevelName);

		}

		private void PrepareMemberTagDataSource(int? MemberTagName)
		{
            var memberTag = _db.MemberTags.ToList();
            ViewBag.MemberTag = new SelectList(memberTag,"Id","Name", MemberTagName);
		}

		//private IEnumerable<MemberIndexVM> GetMembers()
		//{
  //          return _service.Search().Select(dto=>dto.ToMemberIndexVM());
		//}

        public ActionResult Edit(int? id)
        {

            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

			
			EditProfileVM memberInDb = _service.GetMember(id.Value).ToEditProfileVM();


			if (memberInDb == null) return HttpNotFound();
            
            return View(memberInDb);
        }

        [HttpPost]
		public ActionResult Edit(EditProfileVM vm)
        {
            if (ModelState.IsValid == false) return View(vm);
            Result updateResult = _service.Update(vm.ToEditProfileDto());
            if (updateResult.IsSuccess) return RedirectToAction("Index");

            ModelState.AddModelError(string.Empty, updateResult.ErrorMessage);
            return View(vm);
        }


	}
}