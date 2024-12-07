namespace Repositories.Contracts
{
    public interface IRepositoryManager
    {
        ICarRepository CarR { get; }
        IReservationRepository ReservationR { get; }
        IDealershipRepository DealershipR { get; }
        IPaymentRepository PaymentR { get; }
        IUserRepository UserR { get; }
        IAdminRepository AdminR { get; }
        IDeletedRepository DeletedR { get; }
        IFuelTypeRepository FuelTypeR { get; }
        IGearTypeReppository GearTypeR { get; }
        void Save();
    }
}
