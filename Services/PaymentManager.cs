﻿using AutoMapper;
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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Services
{
    public class PaymentManager : IPaymentServices
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;
        private readonly ILoggerServices _logger;
        public PaymentManager(IRepositoryManager manager, IMapper mapper, ILoggerServices logger)
        {
            _manager = manager;
            _mapper = mapper;
            _logger = logger;
        }

        public Payment CreateOnePayment(PaymentDtoForCreate paymentDto)
        {
            try
            {
                _logger.LogInfo("CreateOnePayment process started.");
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
            catch (Exception ex)
            {
                _logger.LogError($"CreateOnePayment failed: {ex.Message}");
                throw;
            }
        }

        public void DeleteOnePayment(int id, bool trackChanges)
        {
            try
            {
                _logger.LogInfo($"DeleteOnePayment process started for Payment ID: {id}");
                var entity = _manager.PaymentR.GetOnePaymentById(id, trackChanges);
                if (entity is null)
                    throw new Exception($"Payment with id:{id} could not found");
                _manager.PaymentR.DeleteOnePayment(entity);
                _manager.Save();
                _logger.LogInfo($"Payment with ID: {id} deleted successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"DeleteOnePayment failed for Payment ID: {id}. Error: {ex.Message}");
                throw;
            }
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
            try
            {
                _logger.LogInfo($"UpdateOnePayment process started for Payment ID: {id}");
                var entity = _manager.PaymentR.GetOnePaymentById(id, trackChanges: true);
            if (entity is null)
            {
                string message = $"The payment with id:{id} could not found";
                    _logger.LogError(message);
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
                _logger.LogInfo($"Payment with ID: {id} updated successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"UpdateOnePayment failed for Payment ID: {id}. Error: {ex.Message}");
                throw;
            }
        }
    }
}
