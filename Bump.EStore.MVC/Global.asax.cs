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

			//���oFormIdentity
			//var id1 = (FormsIdentity)HttpContext.Current.User.Identity;
			var id = (FormsIdentity)User.Identity;

			//�A���X�{�Ҳ�
			FormsAuthenticationTicket ticket = id.Ticket;

			//�N�s�b�{�Ҳ���userData(roles)���X
			string role = ticket.UserData;
			//string[] arrRoles1 = role.Split(',');
			string[] arrRoles = role.Split(new char[] { ',' },StringSplitOptions.RemoveEmptyEntries);

			IPrincipal currentUser = new GenericPrincipal(User.Identity, arrRoles);

			//HttpContext.Current.User = currentUser;
			Context.User = currentUser;

		}

	}
}
