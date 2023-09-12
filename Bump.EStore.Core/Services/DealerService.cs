using Bump.EStore.Core.Dtos.Dealers;
using Bump.EStore.Infrastructure.Repositories.EFRepositories;
using Bump.EStore.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bump.EStore.Core.Services
{
	public class DealerService
	{
        private readonly IDealerRepository _repo;
        public DealerService()
        {
            _repo = new DealerRepository();
        }

        public DealerService(IDealerRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<DealerIndexDto> Search(DealerCriteriaDto dto)
        {
            return _repo
                .Search(dto.ToCriteria())
                .Select(d => d.ToDto());
        }

        public DealerIndexDto GetById(int id)
        {
            return _repo.GetById(id).ToDto();
        }

        public int Delete(int id)
        {
            return _repo.Delete(id);
        }

        public int Add(DealerCreateDto dto)
        {
            return _repo.Add(dto.ToEntity());
        }

        public int Update(DealerEditDto dto)
        {
            return _repo.Update(dto.ToEntity());
        }
    }
}
