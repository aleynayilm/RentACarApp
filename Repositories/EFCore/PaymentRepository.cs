using Entities.Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class PaymentRepository : RepositoryBase<Payment>, IPaymentRepository
    {
        public PaymentRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOnePayment(Payment payment) => CreateOnePayment(payment);

        public void DeleteOnePayment(Payment payment)=> DeleteOnePayment(payment);

        public IQueryable<Payment> GetAllPayments(bool trackChanges) => FindAll(trackChanges).OrderBy(c=>c.Id);

        public Payment GetOnePaymentById(int id, bool trackChanges) => FindByCondiition(c => c.Id.Equals(id), trackChanges).SingleOrDefault();

        public void UpdateOnePayment(Payment payment)=> UpdateOnePayment(payment);
    }
}
