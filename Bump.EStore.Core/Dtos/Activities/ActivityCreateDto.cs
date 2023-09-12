using Bump.EStore.Infrastructure.Data.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bump.EStore.Core.Dtos.Activities
{
	public class ActivityCreateDto
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public DateTime StartTime { get; set; }

		public DateTime EndTime { get; set; }

		public string Description { get; set; }

		public string Thumbnail { get; set; }

		public string Status { get; set; }

		public DateTime CreatedTime { get; set; }
	}

	public static class AcitivityCreateDtoExts
	{
		public static Activity ToEntity(this ActivityCreateDto dto)
		{
			return new Activity
			{
				Id = dto.Id,
				Name = dto.Name,
				StartTime = dto.StartTime,
				EndTime = dto.EndTime,
				Description = dto.Description,
				Thumbnail = dto.Thumbnail,
				Status = dto.Status,
				CreatedTime = dto.CreatedTime
			};
		}
	}
}
