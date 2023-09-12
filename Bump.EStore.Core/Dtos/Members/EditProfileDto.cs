using Bump.EStore.Infrastructure.Data.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bump.EStore.Core.Dtos.Members
{
	public class EditProfileDto
	{
		public int Id { get; set; }

		public string Account { get; set; }

		public string Name { get; set; }
		public string Nickname { get; set; }

		public int MemberLevelOrder { get; set; }

		public int Points { get; set; }

		public string Email { get; set; }

		public string Gender { get; set; }

		public DateTime Birthday { get; set; }

		public string PhoneNumber { get; set; }

		public bool DMSubscribe { get; set; }

		public bool IsConfirm { get; set; }
	}

	public static class EditProfileDtoExt
	{
		public static EditProfileDto ToEditProfileDto(this Member entity)
		{
			return new EditProfileDto
			{
				Id = entity.Id,
				Account = entity.Account,
				Name = entity.Name,
				Nickname = entity.Nickname,
				Points = entity.Points,
				Email = entity.Email,
				Gender = entity.Gender,
				Birthday = entity.Birthday,
				PhoneNumber = entity.PhoneNumber,
				DMSubscribe = entity.DMSubscribe, 
				IsConfirm = entity.IsConfirm
			};
		}

		public static Member ToEditProfileEntity(this EditProfileDto dto)
		{
			return new Member
			{
				Id = dto.Id,
				Account = dto.Account,
				Name = dto.Name,
				Nickname = dto.Nickname,
				Points = dto.Points,
				Email = dto.Email,
				Gender = dto.Gender,
				Birthday = dto.Birthday,
				PhoneNumber = dto.PhoneNumber,
				DMSubscribe = dto.DMSubscribe,
				IsConfirm = dto.IsConfirm
			};
		}
	}
}
