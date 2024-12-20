﻿using Entities.DataTransferObjects;
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
        Payment CreateOnePayment(PaymentDtoForCreate paymentDto);
        void UpdateOnePayment(int id, PaymentDtoForUpdate paymentDto, bool trackChanges);
        void DeleteOnePayment(int id, bool trackChanges);
    }
}
