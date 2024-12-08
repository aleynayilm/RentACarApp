using AutoMapper;
using Entities.DataTransferObjects;
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
        private readonly IMapper _mapper;
        public PaymentManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public Payment CreateOnePayment(PaymentDtoForCreate paymentDto)
        {
            var paymentStatus = _manager.PaymentStatusR.GetPaymentStatus(paymentDto.PaymentStatus);
            if (paymentStatus == null)
            {
                throw new Exception($"PaymentStatus '{paymentDto.PaymentStatus}' not found!");
            }
            var paymentMethod = _manager.PaymentMethodR.GetPaymentMethod(paymentDto.PaymentMethod);
            if (paymentMethod == null)
            {
                throw new Exception($"PaymentMethod '{paymentDto.PaymentMethod}' not found!");
            }
            var reservation = _manager.ReservationR.GetOneReservation(paymentDto.ReservationId);
            if (reservation == null)
            {
                throw new Exception($"Reservation '{paymentDto.ReservationId}' not found!");
            }

            var payment = _mapper.Map<Payment>(paymentDto);

            payment.PaymentStatus = paymentStatus.Id;
            payment.PaymentMethod = paymentMethod.Id;
            payment.ReservationId = reservation.Id;
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

        public void UpdateOnePayment(int id, PaymentDtoForUpdate paymentDto, bool trackChanges)
        {
            var entity = _manager.PaymentR.GetOnePaymentById(id, trackChanges: true);
            if (entity is null)
            {
                string message = $"The payment with id:{id} could not found";
                //_logger.LogInfo(message);
                throw new Exception(message);

            }
            if (paymentDto is null)
                throw new ArgumentNullException(nameof(id));
            var existingCreatedAt = entity.CreatedAt;

            _mapper.Map(paymentDto, entity);
            //entity = _mapper.Map<Payment>(paymentDto);
            entity.CreatedAt = existingCreatedAt;
            _manager.PaymentR.UpdateOnePayment(entity);
            _manager.Save();
        }
    }
}
