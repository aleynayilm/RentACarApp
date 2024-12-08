using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IResrvationStatusRepository:IRepositoryBase<ReservationStatus>
    {
        IQueryable<ReservationStatus> GetAllReservationsStatus(bool trackChanges);
        ReservationStatus GetOneReservationStatusById(int id, bool trackChanges);
        ReservationStatus GetReservationStatus(int id);
    }
}
