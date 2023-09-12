using Bump.EStore.Infrastructure.Data.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bump.EStore.MVC.ViewModels
{
	public static class CoachExtsVM
	{
		public static CoachIndexVM TOindexVM(this Coach entity)
		{
			return new CoachIndexVM
			{
				Id = entity.Id,
				Name = entity.Name,
				Email = entity.Email,
				PhoneNumber = entity.PhoneNumber,
				Img = entity.Img,
				Status = entity.Status
			};
		}
		public static CoachCreateVM TOCreateVM(this Coach entity)
		{
			return new CoachCreateVM
			{
				Id = entity.Id,
				Name = entity.Name,
				Email = entity.Email,
				PhoneNumber = entity.PhoneNumber,
				Img = entity.Img,
				Status = entity.Status
			};
		}
		public static Coach TOEntity(this CoachCreateVM vm)
		{
			return new Coach
			{
				Id = vm.Id,
				Name = vm.Name,
				Email = vm.Email,
				PhoneNumber = vm.PhoneNumber,
				Img = vm.Img,
				Status = vm.Status
			};
		}

		public static CoachEditVM TOEditVM(this Coach entity)
		{
			return new CoachEditVM
			{
				Id = entity.Id,
				Name = entity.Name,
				Email = entity.Email,
				PhoneNumber = entity.PhoneNumber,
				Status = entity.Status
			};
		}
		public static CoachEditImgVM TOEditImgVM(this Coach entity)
		{
			return new CoachEditImgVM
			{
				Id = entity.Id,
				Img= entity.Img
			};
		}
	}
}