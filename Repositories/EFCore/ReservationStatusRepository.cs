using Entities.Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class ReservationStatusRepository : RepositoryBase<ReservationStatus>, IResrvationStatusRepository
    {
        public ReservationStatusRepository(RepositoryContext context) : base(context)
        {
        }

        public IQueryable<ReservationStatus> GetAllReservationsStatus(bool trackChanges) => FindAll(trackChanges).OrderBy(c => c.Id);

        public ReservationStatus GetOneReservationStatusById(int id, bool trackChanges) => FindByCondiition(c => c.Id.Equals(id), trackChanges).SingleOrDefault();

        public ReservationStatus GetReservationStatus(int id)
        {
            return _context.ReservationStatuses.FirstOrDefault(ft => ft.Id == id);
        }
    }
}
