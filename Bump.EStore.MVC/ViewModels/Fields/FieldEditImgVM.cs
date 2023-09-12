using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Bump.EStore.MVC.ViewModels
{
	public class FieldEditImgVM
	{
		[Display(Name = "教練編號")]
		public int? Id { get; set; }


		[Display(Name = "上傳取代場館圖片")]

		public string Thumbnail { get; set; }
	}
}