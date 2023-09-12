using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Bump.EStore.MVC.ViewModels
{
	public class CoachEditImgVM
	{
		[Display(Name = "教練編號")]
		public int? Id { get; set; }

		
		[Display(Name = "上傳新照片")]
		public string Img { get; set; }

	}
}