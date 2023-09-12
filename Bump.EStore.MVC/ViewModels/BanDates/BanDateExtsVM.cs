using Bump.EStore.Infrastructure.Data.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bump.EStore.MVC.ViewModels.BanDates
{
	public static class BanDateExtsVM
	{
		public static BanDateIndexVM ToIndexVM(this BanDate entity)
		{
			return new BanDateIndexVM
			{
				Id = entity.Id,
				BanEndDateTime = entity.BanEndDateTime,
				BanStartDateTime = entity.BanStartDateTime,
				Field = entity.Field.Name
			};
		}
		public static BanDate ToCreateVM(this BanDateCreateVM vm)
		{
			return new BanDate
			{
				Id = vm.Id,
				BanEndDateTime = vm.BanEndDateTime,
				BanStartDateTime = vm.BanStartDateTime,
				FieldId = vm.FieldId
			};
		}
		public static BanDateDeleteVM ToDeleteVM(this BanDate entity)
		{
			return new BanDateDeleteVM
			{
				Id = entity.Id,
				BanEndDateTime = entity.BanEndDateTime,
				BanStartDateTime = entity.BanStartDateTime,
				Field = entity.Field.Name
			};
		}
	}

}