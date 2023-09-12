using Bump.EStore.Infrastructure.Data.EFModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bump.EStore.MVC.ViewModels.Employees
{
	public class EmployeeIndexVM
	{
        [Display(Name = "員工編號")]
		public int Id { get; set; }

        [Display(Name = "照片")]
		public string Img { get; set; }
        
        [Display(Name = "姓名")]
		public string Name { get; set; }
        
        [Display(Name = "帳號")]
        public string Account { get; set; }

        [Display(Name = "職位")]
        public string Role { get; set; }
    }

    public static class EmployeeIndexExt
    {
        public static EmployeeIndexVM ToEmployeeVM(this Employee entity)
        {
            return new EmployeeIndexVM
            {
                Id = entity.Id,
                Img = entity.Img,
                Name = entity.Name,
                Account = entity.Account,
                Role = entity.Role,
            };
        }
    }
}