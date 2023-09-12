using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Bump.EStore.MVC.ViewModels
{
	public class SkillCoursEditImgVM
	{
		public int? Id { get; set; }
		
		[Display(Name = "課程圖片")]

		public string Thumbnail { get; set; }
        public string Name { get; set; }

    }
}