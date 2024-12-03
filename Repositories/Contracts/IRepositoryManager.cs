namespace Repositories.Contracts
{
    public interface IRepositoryManager
    {
        ICarRepository CarR { get; }
        IReservationRepository ReservationR { get; }
        IDealershipRepository DealershipR { get; }
        IPaymentRepository PaymentR { get; }
        IUserRepository UserR { get; }
        void Save();
    }
}
