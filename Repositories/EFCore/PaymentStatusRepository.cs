using Entities.Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class PaymentStatusRepository : RepositoryBase<PaymentStatus>, IPaymentStatusRepository
    {
        public PaymentStatusRepository(RepositoryContext context) : base(context)
        {
        }

        public IQueryable<PaymentStatus> GetAllPaymentStatus(bool trackChanges) => FindAll(trackChanges).OrderBy(c => c.Id);

        public PaymentStatus GetOnePaymentStatusById(int id, bool trackChanges) => FindByCondiition(c => c.Id.Equals(id), trackChanges).SingleOrDefault();

        public PaymentStatus GetPaymentStatus(int id)
        {
            return _context.PaymentStatuses.FirstOrDefault(ft => ft.Id == id);
        }
    }
}
