using Bump.EStore.Core.Services;
using Bump.EStore.MVC.ViewModels.Dealers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using X.PagedList;

namespace Bump.EStore.MVC.Controllers
{
	[Authorize]
	public class DealersController : Controller
    {
        private readonly DealerService _service;
        public DealersController()
        {
            _service = new DealerService();
        }
        // GET: Dealers
        public ActionResult Index(int? page, DealerCriteriaVM criteriaVM)
        {
            var vms = _service
                .Search(criteriaVM.ToDto())
                .Select(dto => dto.ToIndexVM());

			var pageNumber = page ?? 1;

			ViewBag.PagedList = vms.ToPagedList(pageNumber, 8);
            ViewBag.CriteriaVM = criteriaVM;

            return View();
        }

        // GET: Dealers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dealers/Create
        [HttpPost]
        public ActionResult Create(DealerCreateVM vm)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "新增失敗!");
				return View(vm);
			}

            int affectedRows = _service.Add(vm.ToDto());

            if (affectedRows == 0)
            {
				ModelState.AddModelError("", "新增失敗!");
				return View(vm);
			}

			return RedirectToAction("Index");
        }

        // GET: Dealers/Edit/5
        public ActionResult Edit(int id)
        {
            var vm = _service.GetById(id).ToVM();

            return View(vm);
        }

        // POST: Dealers/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, DealerEditVM vm)
        {
            if (!ModelState.IsValid || id != vm.Id)
            {
                ModelState.AddModelError("", "編輯錯誤!");
                return View(vm);
            }

            int affectedRows = _service.Update(vm.ToDto());

            if (affectedRows == 0)
            {
				ModelState.AddModelError("", "編輯錯誤!");
				return View(vm);
			}

            return RedirectToAction("Index");   
		}

        // GET: Dealers/Delete/5
        public ActionResult Delete(int id)
        {
            var vm = _service.GetById(id).ToIndexVM();

            return View(vm);
        }

        // POST: Dealers/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, DealerIndexVM vm)
        {
			if (id != vm.Id)
            {
                ModelState.AddModelError("", "刪除錯誤!");
				return View(vm);
			}

            int affectedRows = _service.Delete(id);

            if (affectedRows == 0)
            {
				ModelState.AddModelError("", "刪除錯誤!");
				return View(vm);
			}

			return RedirectToAction("Index");
        }
    }
}
