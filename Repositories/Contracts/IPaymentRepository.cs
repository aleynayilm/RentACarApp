using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IPaymentRepository:IRepositoryBase<Payment>
    {
        IQueryable<Payment> GetAllPayments(bool trackChanges);
        Payment GetOnePaymentById(int id, bool trackChanges);
        void CreateOnePayment(Payment payment);
        void UpdateOnePayment(Payment payment);
        void DeleteOnePayment(Payment payment);

    }
}
