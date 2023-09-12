using Bump.EStore.Infrastructure.Data.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bump.EStore.MVC.ViewModels
{
	public static class FieldExtsVM
	{
		public static FieldIndexVM ToIndexVM(this Field entity)
		{
			return new FieldIndexVM
			{
				Id = entity.Id,
				Name = entity.Name,
				PhoneNumber = entity.PhoneNumber,
				Address = entity.Address,
				Indoor = entity.Indoor,
				BusinessWeekdayStartTime = entity.BusinessWeekdayStartTime,
				BusinessWeekdayEndTime = entity.BusinessWeekdayEndTime,
				BusinessWeekendStartTime = entity.BusinessWeekendStartTime,
				BusinessWeekendEndTime = entity.BusinessWeekendEndTime
			};
		}
		public static FieldDetailsVM ToDetailsVM(this Field entity)
		{
			return new FieldDetailsVM
			{
				Id = entity.Id,
				Name = entity.Name,
				PhoneNumber = entity.PhoneNumber,
				Address = entity.Address,
				Indoor = entity.Indoor,
				Thumbnail = entity.Thumbnail,
				ShortDescription = entity.ShortDescription,
				Link = entity.Link,
				BusinessWeekdayStartTime = entity.BusinessWeekdayStartTime,
				BusinessWeekdayEndTime = entity.BusinessWeekdayEndTime,
				BusinessWeekendStartTime = entity.BusinessWeekendStartTime,
				BusinessWeekendEndTime = entity.BusinessWeekendEndTime
			};
		}
		public static FieldCreateVM ToCreateVM(this Field entity)
		{
			return new FieldCreateVM
			{
				Id = entity.Id,
				Name = entity.Name,
				PhoneNumber = entity.PhoneNumber,
				Address = entity.Address,
				Indoor = entity.Indoor,
				Thumbnail = entity.Thumbnail,
				ShortDescription = entity.ShortDescription,
				Link = entity.Link,
				BusinessWeekdayStartTime = entity.BusinessWeekdayStartTime,
				BusinessWeekdayEndTime = entity.BusinessWeekdayEndTime,
				BusinessWeekendStartTime = entity.BusinessWeekendStartTime,
				BusinessWeekendEndTime = entity.BusinessWeekendEndTime
			};
		}
		public static Field ToEntity(this FieldCreateVM vm)
		{
			return new Field
			{
				Id = vm.Id,
				Name = vm.Name,
				PhoneNumber = vm.PhoneNumber,
				Address = vm.Address,
				Indoor = vm.Indoor,
				Thumbnail = vm.Thumbnail,
				ShortDescription = vm.ShortDescription,
				Link = vm.Link,
				BusinessWeekdayStartTime = vm.BusinessWeekdayStartTime,
				BusinessWeekdayEndTime = vm.BusinessWeekdayEndTime,
				BusinessWeekendStartTime = vm.BusinessWeekendStartTime,
				BusinessWeekendEndTime = vm.BusinessWeekendEndTime,
				
			};
		}
		public static FieldEditVM TOEditVM(this Field entity)
		{
			return new FieldEditVM
			{
				Id = entity.Id,
				Name = entity.Name,
				PhoneNumber = entity.PhoneNumber,
				Address = entity.Address,
				Indoor = entity.Indoor,
				ShortDescription = entity.ShortDescription,
				Link = entity.Link,
				BusinessWeekdayStartTime = entity.BusinessWeekdayStartTime,
				BusinessWeekdayEndTime = entity.BusinessWeekdayEndTime,
				BusinessWeekendStartTime = entity.BusinessWeekendStartTime,
				BusinessWeekendEndTime = entity.BusinessWeekendEndTime
			};
		}
		public static FieldEditImgVM TOEditImgVM(this Field entity)
		{
			return new FieldEditImgVM
			{
				Id = entity.Id,
				Thumbnail = entity.Thumbnail
			};
		}
		public static FieldDeleteVM ToDeleteVM(this Field entity)
		{
			return new FieldDeleteVM
			{
				Id = entity.Id,
				Name = entity.Name,
				PhoneNumber = entity.PhoneNumber,
				Address = entity.Address,
				Indoor = entity.Indoor,
				Thumbnail = entity.Thumbnail,
				ShortDescription = entity.ShortDescription,
				Link = entity.Link,
				BusinessWeekdayStartTime = entity.BusinessWeekdayStartTime,
				BusinessWeekdayEndTime = entity.BusinessWeekdayEndTime,
				BusinessWeekendStartTime = entity.BusinessWeekendStartTime,
				BusinessWeekendEndTime = entity.BusinessWeekendEndTime
			};
		}
	}
}
