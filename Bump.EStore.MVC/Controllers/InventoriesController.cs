using Bump.EStore.Core.Services;
using Bump.EStore.MVC.ViewModels.Inventories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bump.EStore.MVC.Controllers
{
	[Authorize]
	public class InventoriesController : Controller
    {
        private readonly InventoryService _service;
        public InventoriesController()
        {
            _service = new InventoryService();
        }
        // GET: Inventories
        public ActionResult Index()
        {
            var vms = _service
                .Search()
                .Select(p => p.ToVM());

            return View(vms);
        }

        public ActionResult Edit(int id)
        {
            var vm = _service
                .GetStyleById(id)
                .ToEditVM();

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, InventoryProductStyleEditVM vm)
        {
            if (!ModelState.IsValid || vm.Id != id) 
            {
                ModelState.AddModelError("", "更新錯誤!");
                return View(vm);
            }

            int affectedRows = _service.Update(vm.ToEditDto());

            if (affectedRows == 0)
            {
				ModelState.AddModelError("", "更新錯誤!");
				return View(vm);
			}

            return RedirectToAction("Index");
		}
    }
}