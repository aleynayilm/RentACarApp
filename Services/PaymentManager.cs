using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PaymentManager : IPaymentServices
    {
        private readonly IRepositoryManager _manager;
        public PaymentManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public Payment CreateOnePayment(Payment payment)
        {
            if (payment == null)
            {
                throw new ArgumentNullException(nameof(payment));
            }
            _manager.PaymentR.CreateOnePayment(payment);
            _manager.Save();
            return payment;
        }

        public void DeleteOnePayment(int id, bool trackChanges)
        {
            var entity = _manager.PaymentR.GetOnePaymentById(id, trackChanges);
            if (entity is null)
                throw new Exception($"Payment with id:{id} could not found");
            _manager.PaymentR.DeleteOnePayment(entity);
            _manager.Save();
        }

        public IEnumerable<Payment> GetAllPayments(bool trackChanges)
        {
            return _manager.PaymentR.GetAllPayments(trackChanges);
        }

        public Payment GetOnePaymentById(int id, bool trackChanges)
        {
            return _manager.PaymentR.GetOnePaymentById(id, trackChanges);
        }

        public void UpdateOnePayment(int id, Payment payment, bool trackChanges)
        {
            var entity = _manager.PaymentR.GetOnePaymentById(id, trackChanges);
            if (entity is null)
                throw new Exception($"Payment with id:{id} could not found");
            if (payment is null)
                throw new ArgumentNullException(nameof(id));
            entity.ReservationId=payment.ReservationId;
            entity.Amount=payment.Amount;
            entity.PaymentMethod=payment.PaymentMethod;
            entity.PaymentDate=payment.PaymentDate;
            entity.PaymentStatus=payment.PaymentStatus;
            _manager.PaymentR.UpdateOnePayment(entity);
            _manager.Save();
        }
    }
}
