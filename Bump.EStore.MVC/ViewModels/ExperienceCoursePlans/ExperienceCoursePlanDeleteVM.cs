using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Bump.EStore.MVC.ViewModels.ExperienceCoursePlans
{
	public class ExperienceCoursePlanDeleteVM
	{
		[Display(Name = "方案編號")]
		public int Id { get; set; }
		[Display(Name = "方案名稱")]

		public string Name { get; set; }
		[Display(Name = "方案一人價格")]

		public int Price { get; set; }
		[Display(Name = "最少人數")]

		public int PeopleMin { get; set; }
		[Display(Name = "最多人數")]

		public int PeopleMax { get; set; }
	}
}