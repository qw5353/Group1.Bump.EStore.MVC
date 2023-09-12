using Bump.EStore.Core.Services;
using Bump.EStore.Infrastructure.Data.EFModels;
using Bump.EStore.MVC.ViewModels.ContactUs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using X.PagedList;

namespace Bump.EStore.MVC.Controllers
{
	[Authorize]
	public class ContactUsController : Controller
    {
        private readonly ContactUsService _service;
        public ContactUsController()
        {
            _service = new ContactUsService();
        }
        // GET: ContactUs
        public ActionResult Index(int? page, ContactUsCriteriaVM vm)
        {
            var vms = _service.GetAll(vm.ToDto()).Select(dto => dto.ToIndexVM());
			var pageNumber = page ?? 1;
			var onePageOfContactUs = vms.ToPagedList(pageNumber, 10);

			ViewBag.OnePageOfContactUs = onePageOfContactUs;
            ViewBag.CriteriaVM = vm;

			return View(vms);
        }

        public ActionResult Edit(int id)
        {
			var vm = _service.GetEdit(id).ToEditVM();

			return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ContactUsEditVM vm)
        {
			if (!ModelState.IsValid)
			{
				return View(vm);
			}

			int affectedRows = _service.Update(vm.ToEditDto());

            if (affectedRows == 0) 
            {
                ModelState.AddModelError("", "編輯失敗!");
                return View(vm);
            }

			return RedirectToAction("Index");
		}
    }
}