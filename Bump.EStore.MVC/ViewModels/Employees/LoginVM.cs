using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bump.EStore.MVC.ViewModels.Employees
{
	public class LoginVM
	{
        [Required]
        [Display(Name ="帳號")]
        public string Account { get; set; }
        [Required]
        [Display(Name ="密碼")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}