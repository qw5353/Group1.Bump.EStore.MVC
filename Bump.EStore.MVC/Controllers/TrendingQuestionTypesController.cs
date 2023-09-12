using Bump.EStore.Core.Services;
using Bump.EStore.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bump.EStore.MVC.Controllers
{
	[Authorize]
	public class TrendingQuestionTypesController : Controller
    {
        private readonly TrendingQuestionTypeService _service;
        public TrendingQuestionTypesController()
        {
            _service = new TrendingQuestionTypeService();
        }
        // GET: TrendingQuestionTypes
        public ActionResult Index()
        {
            var vms = _service
                .GetAll()
                .Select(dto => dto.ToVM());

            return View(vms);
        }

        // GET: TrendingQuestionTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TrendingQuestionTypes/Create
        [HttpPost]
        public ActionResult Create(TrendingQuestionTypeVM vm)
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

        // GET: TrendingQuestionTypes/Edit/5
        public ActionResult Edit(int id)
        {
			var vm = _service.GetById(id).ToVM();

			return View(vm);
		}

        // POST: TrendingQuestionTypes/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, TrendingQuestionTypeVM vm)
        {
			if (id != vm.Id)
			{
				ModelState.AddModelError("", "更新失敗!");
				return View(vm);
			}

			int affectedRows = _service.Update(vm.ToDto());

			if (affectedRows == 0)
			{
				ModelState.AddModelError("", "更新失敗!");
				return View(vm);
			}

			return RedirectToAction("Index");
		}

        // GET: TrendingQuestionTypes/Delete/5
        public ActionResult Delete(int id)
        {
            var vm = _service.GetById(id).ToVM();

            return View(vm);
        }

        // POST: TrendingQuestionTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeletePost(int id, TrendingQuestionTypeVM vm)
        {
            if (id != vm.Id)
            {
				ModelState.AddModelError("", "刪除失敗!");
                return View(vm);
			}

			int affectedRows = _service.Delete(id);

			if (affectedRows == 0)
			{
				ModelState.AddModelError("", "刪除失敗!");
				return View(vm);
			}

			return RedirectToAction("Index");
		}
    }
}
