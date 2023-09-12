using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Bump.EStore.MVC.ViewModels
{
	public class CoachCriteria
	{
		[Display(Name = "教練編號")]
		public int? Id { get; set; }

		[Display(Name = "教練名字")]
		public string Name { get; set; }

		public bool Status { get; set; }
	}
}