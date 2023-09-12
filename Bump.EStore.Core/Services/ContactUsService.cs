using Bump.EStore.Core.Dtos.ContactUs;
using Bump.EStore.Infrastructure.Repositories.EFRepositories;
using Bump.EStore.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bump.EStore.Core.Services
{
	public class ContactUsService
	{
		private readonly IContactUsRepository _repo;
        public ContactUsService()
        {
            _repo = new ContactUsRepository();
        }

        public ContactUsService(IContactUsRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<ContactUsIndexDto> GetAll(ContactUsCriteriaDto CriteriaDto)
        {
            return _repo.GetAll(CriteriaDto.ToCriteria()).Select(e => e.ToDto());
        }

		public ContactUsEditDto GetEdit(int id)
		{
            return _repo.GetById(id).ToEditDto();
		}

        public int Update(ContactUsEditDto dto)
        {
            return _repo.Update(dto.ToEntity());
        }
	}
}
