using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Bump.EStore.MVC.ViewModels
{
	public class SkillCoursDeleteVM
	{
		public int Id { get; set; }
		[Display(Name = "課程名稱")]
		[Required]
		public string Name { get; set; }
		[Display(Name = "課程價格")]
		[Required]
		[RegularExpression(@"^[0-9]*$", ErrorMessage = "請輸入數字")]
		public int Price { get; set; }
		[Display(Name = "課程簡介")]
		[Required]
		public string Description { get; set; }
		[Display(Name = "課程圖片")]

		public string Thumbnail { get; set; }
		[Display(Name = "課程最小人數")]
		[Required]
		[RegularExpression(@"^[0-9]*$", ErrorMessage = "請輸入數字")]
		public int PeopleMin { get; set; }
		[Display(Name = "課程最大人數")]
		[Required]
		[RegularExpression(@"^[0-9]*$", ErrorMessage = "請輸入數字")]
		public int PeopleMax { get; set; }
	}
}
