using Entities.Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class ReservationRepository : RepositoryBase<Reservation>, IReservationRepository
    {
        public ReservationRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneReservation(Reservation reservation) => Create(reservation);

        public void DeleteOneReservation(Reservation reservation) => Delete(reservation);

        public IQueryable<Reservation> GetAllReservations(bool trackChanges) => FindAll(trackChanges).OrderBy(c => c.Id);

        public Reservation GetOneReservation(int id)
        {
            return _context.Reservations.FirstOrDefault(ft => ft.Id == id);
        }

        public Reservation GetOneReservationById(int id, bool trackChanges) => FindByCondiition(c=>c.Id.Equals(id), trackChanges).SingleOrDefault();

        public void UpdateOneReservation(Reservation reservation) => Update(reservation);
    }
}
