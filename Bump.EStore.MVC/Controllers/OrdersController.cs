using Bump.EStore.Infrastructure.Repositories.DapperRepositories;
using Bump.EStore.Infrastructure.Criteria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bump.EStore.MVC.Controllers
{
	[Authorize]
	public class OrdersController : Controller
    {
        // GET: Orders
        public ActionResult Index(OrderCriteria criteria)
        {
            ViewBag.Criteria = criteria;
			var orderItems = new OrderRepository().TotalSearch(criteria);

			return View(orderItems);
        }

        public ActionResult Details(int id)
        {
            var detail = new OrderRepository().TotalDetailSearch(id).FirstOrDefault();

			return Json(detail, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Chart()
        {
            int year = 2023;
            int month = 6;
			ViewBag.Now = new OrderRepository().MonthOfChart(year, month);

            return View();
        }

		public ActionResult WhichMonth(int year, int month)
		{
			var date = new OrderRepository().MonthOfChart(year, month);

			return Json(date, JsonRequestBehavior.AllowGet);
		}

	}
}