using Bump.EStore.Infrastructure.Data.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bump.EStore.MVC.ViewModels.ExperienceCoursePlans
{
	public static class ExperienceCoursePlanExtsVM
	{
		public static ExperienceCoursePlanIndexVM ToIndexVM(this ExperienceCoursePlan Entity)
		{
			return new ExperienceCoursePlanIndexVM
			{
				Id = Entity.Id,
				Name = Entity.Name,
				Price = Entity.Price,
				PeopleMax = Entity.PeopleMax,
				PeopleMin = Entity.PeopleMin
			};
		}
		public static ExperienceCoursePlan ToEntity(this ExperienceCoursePlanCreateVM vm)
		{
			return new ExperienceCoursePlan
			{
				Id = vm.Id,
				Name = vm.Name,
				Price = vm.Price,
				PeopleMax = vm.PeopleMax,
				PeopleMin = vm.PeopleMin
			};
		}
		public static ExperienceCoursePlanEditVM ToEditVM(this ExperienceCoursePlan Entity)
		{
			return new ExperienceCoursePlanEditVM
			{
				Id = Entity.Id,
				Name = Entity.Name,
				Price = Entity.Price,
				PeopleMax = Entity.PeopleMax,
				PeopleMin = Entity.PeopleMin
			};
		}

		public static ExperienceCoursePlan ToEntity(this ExperienceCoursePlanEditVM vm)
		{
			return new ExperienceCoursePlan
			{
				Id = vm.Id,
				Name = vm.Name,
				Price = vm.Price,
				PeopleMax = vm.PeopleMax,
				PeopleMin = vm.PeopleMin
			};
		}
		public static ExperienceCoursePlanDeleteVM ToDeleteVM(this ExperienceCoursePlan Entity)
		{
			return new ExperienceCoursePlanDeleteVM
			{
				Id = Entity.Id,
				Name = Entity.Name,
				Price = Entity.Price,
				PeopleMax = Entity.PeopleMax,
				PeopleMin = Entity.PeopleMin
			};
		}
	}
}