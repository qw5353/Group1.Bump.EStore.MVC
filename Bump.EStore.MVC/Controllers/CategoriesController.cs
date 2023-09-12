using Bump.EStore.Core.Services;
using Bump.EStore.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Bump.EStore.Infrastructure.Repositories.DapperRepositories;
using Bump.EStore.Infrastructure.Data.EFModels;

namespace Bump.EStore.MVC.Controllers
{
	[Authorize]
	public class CategoriesController : Controller
	{
		// GET: Categories
		public ActionResult Index()
		{
			var categoryItems = new CategoriesRepository().Search();

			return View(categoryItems);
			//return View();
		}

		public ActionResult Create() 
		{
			ViewBag.FirstCategoryName = new CategoriesRepository().FindFirstCategoryName();
			ViewBag.SecondCategoryName = new CategoriesRepository().FindSecondCategoryName();


			return View();
		}

		[HttpPost]
		public ActionResult Create( string createCategoeyName, int categoryLevel ,int categoryName = 0)
		{
			var create = new CategoriesRepository();
			if (categoryLevel ==2 )
			{
				create.CreateSecondCategories(createCategoeyName, categoryName);
			}else if (categoryLevel ==3 )
			{
				create.CreateThirdCategories(createCategoeyName, categoryName);
			}
			else if (categoryLevel == 1)
			{
				create.CreateFirstCategories(createCategoeyName);
			}

			return RedirectToAction("Index");
		}

		public ActionResult Edit()
		{
			ViewBag.FirstCategoryName = new CategoriesRepository().FindFirstCategoryName();
			ViewBag.SecondCategoryName = new CategoriesRepository().FindSecondCategoryName();
			ViewBag.ThirdCategoryName = new CategoriesRepository().FindThirdCategoryName();

			return View();
		}

		[HttpPost]
		public ActionResult Edit(string editCategoeyName, int categoryLevel, int categoryName1 = 0, int categoryName2 = 0, int categoryName3 = 0)
		{
			var edit = new CategoriesRepository();

			if (categoryLevel == 1)
			{
				edit.EditFirstCategories(editCategoeyName, categoryName1);
			}
			else if (categoryLevel == 2)
			{
				edit.EditSecondCategories(editCategoeyName, categoryName2);
			}
			else if (categoryLevel == 3)
			{
				edit.EditThirdCategories(editCategoeyName, categoryName3);
			}

			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult Delete()
		{
			ViewBag.FirstCategoryName = new CategoriesRepository().FindFirstCategoryName();
			ViewBag.SecondCategoryName = new CategoriesRepository().FindSecondCategoryName();
			ViewBag.ThirdCategoryName = new CategoriesRepository().FindThirdCategoryName();

			return View();
		}

		[HttpPost]
		public ActionResult Delete(int categoryLevel, int categoryName1 = 0, int categoryName2 = 0, int categoryName3 = 0)
		{
			var delete = new CategoriesRepository();

			if (categoryLevel == 1)
			{
				delete.DeleteFirstCategories( categoryName1);
			}
			else if (categoryLevel == 2)
			{
				delete.DeleteSecondCategories( categoryName2);
			}
			else if (categoryLevel == 3)
			{
				delete.DeleteThirdCategories( categoryName3);
			}

			return RedirectToAction("Index");
		}

	}
}
