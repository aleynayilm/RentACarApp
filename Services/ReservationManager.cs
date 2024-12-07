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
    public class ReservationManager : IReservationServices
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public ReservationManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
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

        public void UpdateOneReservation(int id, ReservationDtoForUpdate reservationDto, bool trackChanges)
        {
            var entity = _manager.ReservationR.GetOneReservationById(id, trackChanges: true);
            if (entity is null)
            {
                string message = $"The reservation with id:{id} could not found";
                //_logger.LogInfo(message);
                throw new Exception(message);

            }
            if (reservationDto is null)
                throw new ArgumentNullException(nameof(reservationDto));
            var existingCreatedDate = entity.CreatedDate;

            _mapper.Map(reservationDto, entity);
            //entity = _mapper.Map<Reservation>(reservationDto);
            entity.CreatedDate = existingCreatedDate;
            _manager.ReservationR.UpdateOneReservation(entity);
            _manager.Save();
        }
    }
}
