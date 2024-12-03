using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IPaymentServices
    {
        IEnumerable<Payment> GetAllPayments(bool trackChanges);
        Payment GetOnePaymentById(int id, bool trackChanges);
        Payment CreateOnePayment(Payment payment);
        void UpdateOnePayment(int id, Payment payment, bool tracjChanges);
        void DeleteOnePayment(int id, bool trackChanges);
    }
}
