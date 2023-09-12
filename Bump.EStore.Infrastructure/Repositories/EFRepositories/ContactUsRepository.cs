using Bump.EStore.Infrastructure.Criteria;
using Bump.EStore.Infrastructure.Data.EFModels;
using Bump.EStore.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bump.EStore.Infrastructure.Repositories.EFRepositories
{
	public class ContactUsRepository : RepositoryBase<ContactU>, IContactUsRepository
	{
        public ContactUsRepository() : base()
        {
            
        }

		public IEnumerable<ContactU> GetAll(ContactUsCriteria criteria)
		{
			return _db.ContactUs
				.AsNoTracking()
				.OrderByDescending(x => x.CreatedAt)
				.WithCriteria(criteria)
				.AsEnumerable();
		}

		public int Update(ContactU contact)
		{
			var entity = _db.ContactUs.Find(contact.Id);

			entity.Status = contact.Status;

			return _db.SaveChanges();
		}
	}
}
