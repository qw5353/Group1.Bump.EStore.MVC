using Bump.EStore.Core.Dtos.Members;
using Bump.EStore.Infrastructure.Infra;
using Bump.EStore.Infrastructure.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Bump.EStore.Core.Services
{
	public class MembersService
	{
		private IMemberRepository _repo;
		public MembersService(IMemberRepository repo)
		{
			_repo = repo;
		}
		public IEnumerable<MemberIndexDto> Search()
		{
			return _repo.Search()
				.ToList()
				.Select(p => p.ToMemberIndexDto());
				
		}

		
		//public int Delete(int id)
		//{
		//	return _repo.Delete(id);
		//}

		public EditProfileDto GetMember(int id)
		{
			return _repo.GetMember(id).ToEditProfileDto();
		}

		public Result Update(EditProfileDto dto)
		{
			int editProfile = _repo.Update(dto.ToEditProfileEntity());
			return editProfile == 0 ? Result.Fail("沒有更新成功") : Result.Success();
		}
	}
}
