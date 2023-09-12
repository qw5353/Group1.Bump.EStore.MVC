using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Bump.EStore.MVC.ViewModels
{
	public class CoachCreateVM
	{
		[Display(Name = "教練編號")]
		public int Id { get; set; }


		[Display(Name = "教練名字")]
		[Required]
		[StringLength(50)]
		public string Name { get; set; }


		[Display(Name = "聯絡信箱")]
		[Required]
		[StringLength(400)]
		[RegularExpression(@"^[\w\.-]+@[\w\.-]+\.\w+$", ErrorMessage = "請輸入有效的電子郵件地址")]
		public string Email { get; set; }


		[Display(Name = "手機號碼")]
		[Required]
		[StringLength(10)]
		[RegularExpression(@"^09\d{8}", ErrorMessage = "手機號碼必須是09開頭且數字十碼")]
		public string PhoneNumber { get; set; }

		[Display(Name = "大頭貼")]
		//[Required]
		[StringLength(2550)]
		public string Img { get; set; }

		[Display(Name = "在職狀態")]
		public bool Status { get; set; }

		
	
	}
}