using Bump.EStore.Infrastructure.Data.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Bump.EStore.MVC.ViewModels
{
	public static class SkillcurriculumExtsVM
	{
		public static SkillcurriculumIndexVM ToIndexVM(this Skillcurriculum entity)
		{
			return new SkillcurriculumIndexVM
			{
				Id = entity.Id,
				Name = entity.Name,
				Field = entity.Field.Name,
				StartTime = entity.StartTime,
				EndTime = entity.EndTime,
				Week = entity.Week,
				StartDate = entity.StartDate,
				Coach = entity.Coach.Name,
				Status = entity.Status
			};
		}
		
		public static Skillcurriculum ToEntity(this SkillcurriculumCreateVM vm)
		{
			return new Skillcurriculum
			{
				Id = vm.Id,
				Name = vm.Name,
				FieldId = vm.FieldId,
				SkillCoursesId = vm.SkillCoursesId,
				StartTime = vm.StartTime,
				EndTime = vm.EndTime,
				Week = vm.Week,
				StartDate = vm.StartDate,
				CoachId = vm.CoachId,
				Status = vm.Status
			};
		}
		public static SkillcurriculumEditVM ToEditVM(this Skillcurriculum entity)
		{
			return new SkillcurriculumEditVM
			{
				Id = entity.Id,
				Name = entity.Name,
				Field = entity.Field.Name,
				StartTime = entity.StartTime,
				EndTime = entity.EndTime,
				Week = entity.Week,
				StartDate = entity.StartDate,
				CoachId = entity.Coach.Id,
				Status = entity.Status
			};
		}

		public static SkillcurriculumDeleteVM ToDeleteVM(this Skillcurriculum entity)
		{
			return new SkillcurriculumDeleteVM
			{
				Id = entity.Id,
				Name = entity.Name,
				Field = entity.Field.Name,
				StartTime = entity.StartTime,
				EndTime = entity.EndTime,
				Week = entity.Week,
				StartDate = entity.StartDate,
				Coach = entity.Coach.Name,
			


			};
		}
	}
}