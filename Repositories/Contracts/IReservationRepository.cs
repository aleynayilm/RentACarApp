using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IReservationRepository: IRepositoryBase<Reservation>
    {
        IQueryable<Reservation> GetAllReservations(bool trackChanges);
        Reservation GetOneReservationById(int id, bool trackChanges);
        void CreateOneReservation (Reservation reservation);
        void UpdateOneReservation (Reservation reservation);
        void DeleteOneReservation (Reservation reservation);

    }
}
