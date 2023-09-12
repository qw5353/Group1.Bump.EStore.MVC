using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace Bump.EStore.MVC
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
		}
		
		protected void Application_AuthenticateRequest()
		{
			//if(HttpContext.Current.Request.IsAuthenticated)
			if(!Request.IsAuthenticated)
			{
				return;
			}

			//取得FormIdentity
			//var id1 = (FormsIdentity)HttpContext.Current.User.Identity;
			var id = (FormsIdentity)User.Identity;

			//再取出認證票
			FormsAuthenticationTicket ticket = id.Ticket;

			//將存在認證票的userData(roles)取出
			string role = ticket.UserData;
			//string[] arrRoles1 = role.Split(',');
			string[] arrRoles = role.Split(new char[] { ',' },StringSplitOptions.RemoveEmptyEntries);

			IPrincipal currentUser = new GenericPrincipal(User.Identity, arrRoles);

			//HttpContext.Current.User = currentUser;
			Context.User = currentUser;

		}

	}
}
