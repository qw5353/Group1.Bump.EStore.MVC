using Bump.EStore.Infrastructure.Data.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bump.EStore.Core.Dtos.Members
{
	public class MemberIndexDto
	{
		public int Id { get; set; }

		public string Account { get; set; }

		public string Name { get; set; }
		public string Nickname { get; set; }

		public int MemberLevelOrder { get; set; }

		public int Points { get; set; }

		public string Thumbnail { get; set; }

		public string Email { get; set; }

		public string Gender { get; set; }

		public DateTime Birthday { get; set; }

		public string PhoneNumber { get; set; }

		public bool DMSubscribe { get; set; }

		public DateTime CreatedAt { get; set; }

		public DateTime LastModified { get; set; }

		public bool IsConfirm { get; set; }
	}

	public static class MemberIndexDtoExts
	{
		public static MemberIndexDto ToMemberIndexDto(this Member entity)
		{
			return new MemberIndexDto
			{
				Id = entity.Id,
				Account = entity.Account,
				Name = entity.Name,
				Nickname = entity.Nickname,
				MemberLevelOrder = entity.MemberLevelId,
				Points = entity.Points,
				Thumbnail = entity.Thumbnail,
				Email = entity.Email,
				Gender = entity.Gender,
				Birthday = entity.Birthday,
				PhoneNumber = entity.PhoneNumber,
				DMSubscribe = entity.DMSubscribe,
				CreatedAt = entity.CreatedAt,
				LastModified = entity.LastModified,
				IsConfirm = entity.IsConfirm
			};
		}
	}

}
