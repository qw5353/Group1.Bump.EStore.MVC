using Bump.EStore.Core.Dtos.Inventories;
using Bump.EStore.Infrastructure.Repositories.EFRepositories;
using Bump.EStore.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bump.EStore.Core.Services
{
	public class InventoryService
	{
        private readonly IInventoryRepository _repo;
        public InventoryService()
        {
            _repo = new InventoryRepository();
        }

        public InventoryService(IInventoryRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<InventoryProductIndexDto> Search()
        {
            return _repo.Search().Select(p => p.ToDto());
        }

        public InventoryProductStyleEditDto GetStyleById(int id)
        {
            return _repo.GetStyleById(id).ToInventoryEditDto();
        }

        public int Update(InventoryProductStyleEditDto dto)
        {
            return _repo.Update(dto.ToEntity());
        }
    }
}
