using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IPaymentStatusRepository:IRepositoryBase<PaymentStatus>
    {
        IQueryable<PaymentStatus> GetAllPaymentStatus(bool trackChanges);
        PaymentStatus GetOnePaymentStatusById(int id, bool trackChanges);
        PaymentStatus GetPaymentStatus(int id);
    }
}
