using Bump.EStore.Infrastructure.Data.EFModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bump.EStore.MVC.ViewModels
{
	public static class SkillCoursExtVM
	{
		public static SkillCoursIndexVM ToIndexVM(this SkillCours entity) 
		{
			return new SkillCoursIndexVM
			{
				Id = entity.Id,
				Name = entity.Name,
				Price = entity.Price,
				Description = entity.Description,
				Thumbnail = entity.Thumbnail,
				PeopleMax = entity.PeopleMax,
				PeopleMin = entity.PeopleMin
			};
		}
		public static SkillCours ToEntity(this SkillCoursCreateVM vm)
		{
			return new SkillCours
			{
				Id = vm.Id,
				Name = vm.Name,
				Price = vm.Price,
				Description = vm.Description,
				Thumbnail = vm.Thumbnail,
				PeopleMax = vm.PeopleMax,
				PeopleMin = vm.PeopleMin
			};
		}
		public static SkillCoursEditVM ToEditVM(this SkillCours entity)
		{
			return new SkillCoursEditVM
			{
				Id = entity.Id,
				Name = entity.Name,
				Price = entity.Price,
				Description = entity.Description,
				PeopleMax = entity.PeopleMax,
				PeopleMin = entity.PeopleMin
			};
		}
		public static SkillCoursEditImgVM ToEditImgVM(this SkillCours entity)
		{
			return new SkillCoursEditImgVM
			{
				Id = entity.Id,
				Thumbnail=entity.Thumbnail,
				Name=entity.Name
			};
		}
		public static SkillCoursDeleteVM ToDeleteVM(this SkillCours entity)
		{
			return new SkillCoursDeleteVM
			{
				Id = entity.Id,
				Name = entity.Name,
				Price = entity.Price,
				Description = entity.Description,
				Thumbnail = entity.Thumbnail,
				PeopleMax = entity.PeopleMax,
				PeopleMin = entity.PeopleMin
			};
		}
	}
}