using Bump.EStore.Infrastructure.Data.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Bump.EStore.Infrastructure.Repositories.DapperRepositories;

namespace Bump.EStore.MVC.Controllers
{
	[Authorize]
	public class CourseEnrollmentsController : BaseController  
    {
        private readonly CourseEnrollmentRepository _repo;
        public CourseEnrollmentsController() : base()
        {
            _repo = new CourseEnrollmentRepository();
        }
        // GET: CourseEnrollments
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Data(int fieldId = 1)
        {
            var db = new AppDbContext();

            var data = new
            {
                skill = _repo.GetAllSkills(fieldId),
                experience = _repo.GetAllExperience(fieldId),
            };

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Fields() => Json(_repo.GetFields(), JsonRequestBehavior.AllowGet);
    }
}