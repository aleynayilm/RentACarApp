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
    public class ReservationManager : IReservationServices
    {
        private readonly IRepositoryManager _manager;

        public ReservationManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public Reservation CreateOneReservation(Reservation reservation)
        {
            if (reservation == null) { throw new ArgumentNullException(nameof(reservation)); }
            _manager.ReservationR.CreateOneReservation(reservation);
            _manager.Save();
            return reservation;
        }

        public void DeleteOneReservation(int id, bool trackChanges)
        {
            var entity = _manager.ReservationR.GetOneReservationById(id, trackChanges);
            if (entity is null)
                throw new Exception($"Reservation with id:{id} could not found");
            _manager.ReservationR.DeleteOneReservation(entity);
            _manager.Save();
        }

        public IEnumerable<Reservation> GetAllReservations(bool trackChanges)
        {
           return _manager.ReservationR.GetAllReservations(trackChanges);
        }

        public Reservation GetOneReservationById(int id, bool trackChanges)
        {
            return _manager.ReservationR.GetOneReservationById(id, trackChanges);
        }

        public void UpdateOneReservation(int id, Reservation reservation, bool trackChanges)
        {
            var entity = _manager.ReservationR.GetOneReservationById(id, trackChanges);
            if (entity is null) throw new Exception($"Reservation with id:{id} could not found");
            if (reservation is null)
                throw new ArgumentNullException(nameof(reservation));
            entity.UserId = reservation.UserId;
            entity.CarId = reservation.CarId;
            entity.StartDate = reservation.StartDate;
            entity.EndDate = reservation.EndDate;
            entity.TotalPrice = reservation.TotalPrice;
            entity.Status = reservation.Status;
            entity.CreatedDate = reservation.CreatedDate;
            entity.UpdatedDate = reservation.UpdatedDate;
            _manager.ReservationR.UpdateOneReservation(entity);
            _manager.Save();
        }
    }
}
