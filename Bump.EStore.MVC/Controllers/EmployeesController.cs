using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Bump.EStore.Core.Services;
using Bump.EStore.Infrastructure.Criteria;
using Bump.EStore.Infrastructure.Data.EFModels;
using Bump.EStore.Infrastructure.Infra;
using Bump.EStore.Infrastructure.Repositories.EFRepositories;
using Bump.EStore.Infrastructure.Repositories.Interfaces;
using Bump.EStore.MVC.ViewModels;
using Bump.EStore.MVC.ViewModels.Employees;
using X.PagedList;

namespace Bump.EStore.MVC.Controllers
{

	[Authorize]
	public class EmployeesController : Controller
	{
		private AppDbContext db = new AppDbContext();

		IEmployeeRepository repo = new EmployeeEFRepository();

		private EmployeeService _service;

		public EmployeesController()
		{
			_service = new EmployeeService(repo);
		}

		public string GetAvatar()
		{
			return db.Employees.FirstOrDefault(e => e.Account == User.Identity.Name).Img;
		}
		private List<SelectListItem> GetRoleSelectList()
		{
			return new List<SelectListItem>()
			{
				new SelectListItem { Text="員工",Value="員工" },
				new SelectListItem { Text="教練",Value="教練" },
				new SelectListItem { Text="管理員",Value="管理員" }
			};
		}


		// GET: Employees
		public ActionResult Index(EmployeeCriteria criteria, int page = 1, int pageSize = 6)
		{
			ViewBag.Criteria = criteria;
			ViewBag.Role = GetRoleSelectList().Prepend(new SelectListItem());

			var employeeQuery = db.Employees.AsQueryable();

			#region where
			if (string.IsNullOrEmpty(criteria.Search) == false)
			{
				employeeQuery = employeeQuery.Where(e => e.Name.Contains(criteria.Search) ||
													e.Account.Contains(criteria.Search));
			}
			if (criteria.Id != null && criteria.Id.HasValue)
			{
				employeeQuery = employeeQuery.Where(e => e.Id == criteria.Id);
			}
			if (string.IsNullOrEmpty(criteria.Role) == false)
			{
				employeeQuery = employeeQuery.Where(e => e.Role == criteria.Role);
			}
			#endregion

			var emp = employeeQuery.ToList().Select(p => p.ToEmployeeVM()).OrderBy(p => p.Id).ToPagedList(page, pageSize);

			return View(emp);

		}


		// GET: Employees/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Employee employee = db.Employees.Find(id);
			if (employee == null)
			{
				return HttpNotFound();
			}
			return View(employee);
		}

		// GET: Employees/Create
		public ActionResult Register()
		{
			var roleSelect = GetRoleSelectList();

			roleSelect.Where(q => q.Value == "員工").First().Selected = true;

			ViewBag.SelectList = roleSelect;
			return View();
		}

		// POST: Employees/Create
		// 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
		// 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Register(RegisterVM vm, HttpPostedFileBase imgFile)
		{
			if (ModelState.IsValid == false) return View(vm);

			//string basePath = AppDomain.CurrentDomain.BaseDirectory;
			//string path = Path.Combine(basePath, "../Bump.EStore.Infrastructure/UploadFiles/EmployeesImg");

			if (imgFile != null)
			{
				string path = Server.MapPath("/Uploads/EmployeeImg");
				string fileName = SaveUploadFile(path, imgFile);

				vm.Img = fileName;
			} 
			else
			{
				vm.Img = "7.png";
			}

			vm.Role = Request.Form["Role"];

			Result registed = _service.Register(vm.ToRegisterDto());

			if (!registed.IsSuccess)
			{
				ModelState.AddModelError(string.Empty, registed.ErrorMessage);
				ViewBag.SelectList = GetRoleSelectList();
				return View(vm);
			};

			return RedirectToAction("Index");

		}

		private string SaveUploadFile(string path, HttpPostedFileBase imgFile)
		{
			if (imgFile == null || imgFile.ContentLength == 0) return string.Empty;
			string ext = System.IO.Path.GetExtension(imgFile.FileName);

			string[] allowExt = new string[] { ".jpg", ".jpeg", ".png", ".tif", ".gif", ".svg" };
			if (allowExt.Contains(ext.ToLower()) == false) return string.Empty;

			string newFileName = Guid.NewGuid().ToString("N") + ext;
			string fullPath = System.IO.Path.Combine(path, newFileName);

			imgFile.SaveAs(fullPath);

			return newFileName;
		}

		// GET: Employees/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Employee employee = db.Employees.Find(id);

			if (employee == null)
			{
				return HttpNotFound();
			}

			ViewBag.SelectList = GetRoleSelectList();

			return View(employee.ToEditVM());
		}

		// POST: Employees/Edit/5
		// 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
		// 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
		[HttpPost, ActionName("EditEmployee")]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(EmployeeEditVM vm)
		{
			if (ModelState.IsValid)
			{
				var entityIndb = db.Employees.FirstOrDefault(e => e.Account == vm.Account);
				db.Entry(entityIndb).CurrentValues.SetValues(vm);

				db.SaveChanges();
				return RedirectToAction("Index");
			}

			ViewBag.SelectList = GetRoleSelectList();

			return View(vm);
		}

		// GET: Coaches/EditImg/
		public ActionResult EditImg(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Employee emp = db.Employees.Find(id);
			if (emp == null)
			{
				return HttpNotFound();
			}
			return View(emp.ToEmpImgVM());
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult EditImg(EmployeeEditImgVM vm, HttpPostedFileBase file1)
		{
			if (vm.Id == null) { return new HttpStatusCodeResult(HttpStatusCode.BadRequest); }
			string path = Server.MapPath("/Uploads/EmployeeImg");
			var saveFileName = SaveUploadFile(path, file1);
			vm.Img = saveFileName;

			if (saveFileName == null) ModelState.AddModelError("Img", "請選擇檔案");
			if (ModelState.IsValid)
			{
				var empInDb = db.Employees.Find(vm.Id);

				empInDb.Img = vm.Img;

				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(vm);
		}


		// GET: Employees/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}

			Employee employee = db.Employees.Find(id);
			if (employee == null)
			{
				return HttpNotFound();
			}
			return View(employee);
		}

		// POST: Employees/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			Employee employee = db.Employees.Find(id);
			db.Employees.Remove(employee);
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

		[AllowAnonymous]
		public ActionResult Login()
		{
			return View();
		}
		[HttpPost]
		[AllowAnonymous]
		public ActionResult Login(ViewModels.Employees.LoginVM vm)
		{
			if (ModelState.IsValid == false) return View();

			Result result = ValidLogin(vm);

			if (result.IsSuccess != true)
			{
				ModelState.AddModelError("", result.ErrorMessage);
				return View(vm);
			}
			const bool rememberME = false;
			(string returnUrl, HttpCookie cookie) processResult = ProcessLogin(vm.Account, rememberME);
			Response.Cookies.Add(processResult.cookie);

			return Redirect(processResult.returnUrl);

		}

		private (string returnUrl, HttpCookie cookie) ProcessLogin(string account, bool rememberME)
		{
			string role = db.Employees.FirstOrDefault(e => e.Account == account).Role;
			//string role = db.Employees.Where(e => string.Compare(e.Account,account,true)==0).FirstOrDefault().Role;

			var ticket = new FormsAuthenticationTicket(
				1,
				account,
				DateTime.Now,
				DateTime.Now.AddDays(5),
				rememberME,
				role,
				"/"
				);

			var value = FormsAuthentication.Encrypt(ticket);

			var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, value);

			string url = FormsAuthentication.GetRedirectUrl(account, true);

			return (url, cookie);
		}

		private Result ValidLogin(LoginVM vm)
		{
			var employeeAccount = db.Employees.FirstOrDefault(e => e.Account == vm.Account);
			if (employeeAccount == null) return Result.Fail("帳密有誤");

			var employeePassword = db.Employees.FirstOrDefault(e => e.Password == vm.Password);
			if (employeePassword == null) return Result.Fail("帳密有誤");

			return Result.Success();

		}

		public ActionResult Logout()
		{
			Session.Abandon();
			FormsAuthentication.SignOut();

			return RedirectToAction("Login");
		}
	}
}
