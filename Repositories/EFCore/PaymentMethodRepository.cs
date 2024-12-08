using Entities.Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    internal class PaymentMethodRepository : RepositoryBase<PaymentMethod>, IPaymentMethodRepository
    {
        public PaymentMethodRepository(RepositoryContext context) : base(context)
        {
        }

        public IQueryable<PaymentMethod> GetAllPaymentMethod(bool trackChanges) => FindAll(trackChanges).OrderBy(c => c.Id);

        public PaymentMethod GetOnePaymentMethodById(int id, bool trackChanges) => FindByCondiition(c => c.Id.Equals(id), trackChanges).SingleOrDefault();

        public PaymentMethod GetPaymentMethod(int id)
        {
            return _context.PaymentMethods.FirstOrDefault(ft => ft.Id == id);
        }
    }
}
