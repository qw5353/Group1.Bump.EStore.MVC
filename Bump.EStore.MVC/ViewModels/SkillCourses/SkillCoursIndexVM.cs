using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bump.EStore.MVC.ViewModels
{
	public class SkillCoursIndexVM
	{
		[Display(Name ="課程編號")]
		public int Id { get; set; }

		[Display(Name = "課程名稱")]
		public string Name { get; set; }
		[Display(Name = "課程價格(人/元)")]
		[DisplayFormat(DataFormatString = "{0:N0}")]
		public int Price { get; set; }

		[Display(Name = "課程縮圖")]
		public string Thumbnail { get; set; }

		[Display(Name = "課程簡介")]
		public string Description { get; set; }
		
		public string DescriptionText
		{
			get
			{
				return this.Description.Length > 20 ? this.Description.Substring(0, 20) + "..." : this.Description;
			}
		}
		[Display(Name = "最少人數")]
		public int PeopleMin { get; set; }
		[Display(Name = "最多人數")]
		public int PeopleMax { get; set; }
	}
}