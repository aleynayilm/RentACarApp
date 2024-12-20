﻿using Entities.DataTransferObjects;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IReservationServices
    {
        IEnumerable<Reservation> GetAllReservations(bool trackChanges);
        Reservation GetOneReservationById(int id, bool trackChanges);
        Reservation CreateOneReservation(ReservationsDtoForCreate reservationDto);
        void UpdateOneReservation(int id,ReservationDtoForUpdate reservationDto, bool trackChanges);
        void DeleteOneReservation(int id, bool trackChanges);
    }
}
