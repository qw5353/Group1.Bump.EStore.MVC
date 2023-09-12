using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bump.EStore.MVC.ViewModels
{
	public class CoachIndexVM
	{
		[Display(Name ="教練編號")]
		public int Id { get; set; }

		[Display(Name = "教練名字")]
		public string Name { get; set; }

		[Display(Name = "聯絡信箱")]
		public string Email { get; set; }

		[Display(Name = "手機號碼")]
		public string PhoneNumber { get; set; }
		[Display(Name = "大頭貼")]
		public string Img { get; set; }
		
		public bool Status { get; set; }
		[Display(Name = "在職狀態")]
		public string StatusText { get {
				return Status == true ? "在職中":"已離職" ;
			}
		}
    }
}