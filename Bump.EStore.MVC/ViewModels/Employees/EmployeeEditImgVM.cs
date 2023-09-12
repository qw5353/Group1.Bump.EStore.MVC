using Bump.EStore.Infrastructure.Data.EFModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Bump.EStore.MVC.ViewModels.Employees
{
	public class EmployeeEditImgVM
	{
		[Display(Name = "會員編號")]
		public int? Id { get; set; }


		[Display(Name = "上傳新照片")]
		public string Img { get; set; }
	}


	public static class EmpExt
	{
		public static EmployeeEditImgVM ToEmpImgVM(this Employee entity)
		{
			return new EmployeeEditImgVM
			{
				Id = entity.Id,
				Img = entity.Img
			};
		}
	}
}