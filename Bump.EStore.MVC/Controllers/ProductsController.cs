using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Razor.Parser;
using System.Web.Services.Description;
using Bump.EStore.Core.Services;
using Bump.EStore.Infrastructure.Data.EFModels;
using Bump.EStore.Infrastructure.Infra;
using Bump.EStore.Infrastructure.Repositories.DapperRepositories;
using Bump.EStore.MVC.ViewModels.Products;

namespace Bump.EStore.MVC.Controllers
{
	[Authorize]
	public class ProductsController : Controller
	{
		private AppDbContext db = new AppDbContext();
		private ProductsService _prodcutService = new ProductsService();

		// GET: Products
		public ActionResult Index(ProductCriteriaVM vm, int pageNumber = 1, int rowsPerPage = 5)
		{
			var products = _prodcutService
				.Search(vm.ToCriteriaDto(), pageNumber, rowsPerPage)
				.Select(dto => dto.ToIndexVM())
			.ToList();

			var countOfProduct = _prodcutService.Count(vm.ToCriteriaDto());
			ViewBag.CountOfProduct = countOfProduct;

			//分頁邏輯
			int totalPages = countOfProduct % rowsPerPage == 0 ?
								countOfProduct / rowsPerPage :
								 countOfProduct / rowsPerPage + 1;
			ViewBag.TotalPages = totalPages;
			ViewBag.PageNumber = pageNumber;

			int firstPageNum = pageNumber > 3 ? pageNumber - 2 : 1;
			firstPageNum = firstPageNum + 4 > totalPages ? totalPages - 4 : firstPageNum;
			if (totalPages < 6) { firstPageNum = 1; }

			int endPageNum = firstPageNum < totalPages - 3 ? firstPageNum + 4 : totalPages;
			ViewBag.FirstPageNum = firstPageNum;
			ViewBag.EndPageNum = endPageNum;

			//篩選 選單資料
			PrepareBrandDataSource(null);
			PrepareFirstCategoryDataSource(null);
			PrepareSecondCategoryDataSource(null);
			PrepareThirdCategoryDataSource(null);

			ViewBag.Criteria = vm;
			return View(products);
		}

		[HttpPost]
		public ActionResult UpdateShelfStatus(int id, string shelfStatus)
		{

			Result result = _prodcutService
			   .UpdateShelfStatus(id, shelfStatus);

			if (result.IsSuccess) return RedirectToAction("Index");

			ModelState.AddModelError(string.Empty, result.ErrorMessage);
			return View();
		}

		// GET: Products/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Product product = db.Products.Find(id);
			if (product == null)
			{
				return HttpNotFound();
			}
			return View(product);
		}

		// GET: Products/Create
		public ActionResult Create()
		{
			PrepareBrandDataSource(null);
			PrepareDealerDataSource(null);
			PrepareFirstCategoryDataSource(null);
			PrepareSecondCategoryDataSource(null);
			PrepareThirdCategoryDataSource(null);

			return View(new ProductCreateVM());
		}
		private void PrepareFirstCategoryDataSource(int? firstcategoryId)
		{
			//var firstcategories = db.FirstCategories.ToList().Prepend(new FirstCategory());
			//ViewBag.FirstCategoryId = new SelectList(firstcategories, "Id", "Name", firstcategoryId);
			ViewBag.FirstCategoryId = new CategoriesRepository().FindFirstCategoryName();
		}
		private void PrepareSecondCategoryDataSource(int? sencondcategoryId)
		{

			ViewBag.SecondCategoryId = new CategoriesRepository().FindSecondCategoryName();
		}
		private void PrepareThirdCategoryDataSource(int? thirdcategoryId)
		{
			ViewBag.ThirdCategoryId = new CategoriesRepository().FindThirdCategoryName();
		}
		private void PrepareBrandDataSource(int? brandId)
		{
			var brands = db.Brands.ToList().Prepend(new Brand());
			ViewBag.BrandId = new SelectList(brands, "Id", "Name", brandId);
		}
		private void PrepareDealerDataSource(int? dealerId)
		{
			var dealers = db.Dealers.ToList().Prepend(new Dealer());
			ViewBag.DealerId = new SelectList(dealers, "Id", "Name", dealerId);

		}


		// POST: Products/Create
		// 若要免於大量指派 (overposting) 攻擊，請啟用您要繫結的特定屬性，
		// 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(ProductCreateVM vm, HttpPostedFileBase file1)
		{
			// 儲存檔案
			var savedFileName = UploadImage(file1);
			string imageErrorMes = "";
			if (savedFileName == null)
			{
				imageErrorMes = "尚未上傳圖片，";
				ModelState.AddModelError("Thumbnail", "請選擇檔案");
			}

			vm.Thumbnail = savedFileName;
			Guid guid = Guid.NewGuid();
			vm.Code = guid.ToString("N").Substring(0, 6) + "-" + guid.ToString("N").Substring(6, 3);

			if (ModelState.IsValid)
			{
				bool result = new ProductRepository().Create(vm.ToEntity());

				return RedirectToAction("Index");
			}

			PrepareBrandDataSource(null);
			PrepareDealerDataSource(null);
			PrepareFirstCategoryDataSource(null);
			PrepareSecondCategoryDataSource(null);
			PrepareThirdCategoryDataSource(null);
			ViewBag.ErrorMessage = "新增失敗，"+imageErrorMes+"請在執行一次。";

			return View(vm);
		}

		// GET: Products/Edit/5
		public ActionResult Edit(int? id, int? pageNumber, ProductCriteriaVM vm)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var products = _prodcutService
							.GetProductEdits(id)
							.ToEditVM();

			if (products == null)
			{
				return HttpNotFound();
			}
			PrepareBrandDataSource(null);
			PrepareDealerDataSource(null);
			PrepareFirstCategoryDataSource(null);
			PrepareSecondCategoryDataSource(null);
			PrepareThirdCategoryDataSource(null);

			ViewBag.PageNumber = pageNumber;
			ViewBag.Criteria = vm;
			return View(products);
		}

		// POST: Products/Edit/5
		// 若要免於大量指派 (overposting) 攻擊，請啟用您要繫結的特定屬性，
		// 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
		[HttpPost]
		[ValidateAntiForgeryToken]
		[ValidateInput(false)]
		public ActionResult Edit(ProductEditVM vm, int? pageNumber, ProductCriteriaVM c_vm, HttpPostedFileBase file1)
		{
			if (ModelState.IsValid)
			{
				if (!string.IsNullOrEmpty(vm.ShortDescription) && !string.IsNullOrEmpty(vm.Description))
				{

					var savedFileName = UploadImage(file1);
					vm.Thumbnail = savedFileName;
					bool affectedRows = _prodcutService.Edit(vm.ToEditDto());

					if (affectedRows)
					{
						return RedirectToAction("Index");
					}
					else
					{
						ViewBag.ErrorMessage = "更新失敗，請在執行一次。";
					}
				}
				else
				{
					if (string.IsNullOrEmpty(vm.ShortDescription)) { ModelState.AddModelError("ShortDescription", "尚未輸入商品簡介"); }
					if (string.IsNullOrEmpty(vm.Description)) { ModelState.AddModelError("Description", "尚未輸入商品描述"); }
				}

			}
			PrepareBrandDataSource(null);
			PrepareDealerDataSource(null);
			PrepareFirstCategoryDataSource(null);
			PrepareSecondCategoryDataSource(null);
			PrepareThirdCategoryDataSource(null);
			ViewBag.PageNumber = pageNumber;
			ViewBag.Criteria = c_vm;
			//ModelState.AddModelError("", "更新失敗");
			return View(vm);
		}

		// GET: Products/Delete/5
		[HttpPost]
		public ActionResult DeleteProduct(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			int result = new ProductRepository().Delete(id);
			if (result > 0)
			{
				return RedirectToAction("Index");
			}
			//Product product = db.Products.Find(id);

			//ModelState.AddModelError(string.Empty, "刪除失敗，請檢查是否有相依其他資料表，或者重新整理後再嘗試..");
			return View();
		}

		// POST: Products/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			Product product = db.Products.Find(id);
			db.Products.Remove(product);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		[HttpPost]
		public string UploadImage(HttpPostedFileBase file1)
		{
			if (file1 == null || file1.ContentLength == 0)
			{
				//return Json(new { success = false, message = "圖片上傳失敗" });
				return null;
			}

			// var fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(file1.FileName);
			var extension = System.IO.Path.GetExtension(file1.FileName);

			if (IsImageFile(extension) == false) return null;

			var fileName = $"{Guid.NewGuid().ToString("N")}{extension}";


			var fullPath = System.IO.Path.Combine(Server.MapPath("~/Uploads/product/images/"), fileName);
			file1.SaveAs(fullPath);

			//return Json(new { success = true, message = "圖片上傳成功" , fileName = fileName });
			return fileName;
		}
		private bool IsImageFile(string extension)
		{
			var exts = new string[] { ".jpg", ".jpeg", ".png", ".gif", ".tif" };
			return exts.Contains(extension.ToLower());
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
