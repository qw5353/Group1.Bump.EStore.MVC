using Bump.EStore.Infrastructure.Data.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bump.EStore.Core.Dtos
{
	public class ActivityIndexDto
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

	public static class AcitivityIndexDtoExts
	{
		public static ActivityIndexDto ToDto(this Activity entity)
		{
			return new ActivityIndexDto
			{
				Id = entity.Id,
				Name = entity.Name,
				StartTime = entity.StartTime,
				EndTime = entity.EndTime,
				Description = entity.Description,
				Thumbnail = entity.Thumbnail,
				Status = entity.Status,
				CreatedTime = entity.CreatedTime
			};
		}
	}
}
