using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IPaymentMethodRepository:IRepositoryBase<PaymentMethod>
    {
        IQueryable<PaymentMethod> GetAllPaymentMethod(bool trackChanges);
        PaymentMethod GetOnePaymentMethodById(int id, bool trackChanges);
        PaymentMethod GetPaymentMethod(int id);
    }
}
