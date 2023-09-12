using Bump.EStore.Core.Services;
using Bump.EStore.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace Bump.EStore.MVC.Controllers
{
	[Authorize]
	public class TrendingQuestionsController : Controller
    {
        private TrendingQuestionService _service;
        public TrendingQuestionsController()
        {
            _service = new TrendingQuestionService();
        }
        // GET: TrendingQuestions
        public ActionResult Index(TrendingQuestionCriteriaVM criteriaVM, int pageNumber = 1, int rowsPerPage = 5)
        {
            var vms = _service
                .Search(criteriaVM.ToDto(), pageNumber, rowsPerPage)
                .Select(dto => dto.ToIndexVM())
                .ToList();

            var countOfQuestions = _service.Count(criteriaVM.ToDto());

			ViewBag.TotalPages = countOfQuestions % rowsPerPage == 0 ?
                countOfQuestions / rowsPerPage :
                countOfQuestions / rowsPerPage + 1;
            ViewBag.PageNumber = pageNumber;

            SetTypeSelectList();


			return View(vms);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            int affectedRows = _service.Delete(id);

            if (affectedRows == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        public ActionResult Create()
        {
			SetTypeSelectList();

			return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TrendingQuestionCreateVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            int affectedRows = _service.Create(vm.ToDto());

            if (affectedRows == 0)
            {
                ModelState.AddModelError("", "新增失敗");
                return View(vm);
            }

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            var vm = _service.GetById(id).ToVM();
            SetTypeSelectList();

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(TrendingQuestionEditVM vm)
        {
            if (!ModelState.IsValid) 
            {
                ModelState.AddModelError("", "更新失敗");
                return View(vm);
            }

            int affectedRows = _service.Update(vm.ToDto());

            if (affectedRows == 0)
            {
				ModelState.AddModelError("", "更新失敗");
				return View(vm);
			}

            return RedirectToAction("Index");
		}

        private void SetTypeSelectList()
        {
			var questionTypes = _service.GetQuestionTypes();

			ViewBag.TypeSelect = new SelectList(questionTypes, "Id", "Name");
		}
	}
}