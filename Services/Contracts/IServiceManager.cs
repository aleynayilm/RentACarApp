namespace Services.Contracts
{
    public interface IServiceManager
    {
        ICarServices CarServices { get; }
        IReservationServices ReservationServices { get; }
        IDealershipServices DealershipServices { get; }
        IPaymentServices PaymentServices { get; }
        IUserServices UserServices { get; }
        IAdminServices AdminServices { get; }
        IDeletedServices DeletedServices { get; }
        IFuelTypeServices FuelTypeServices { get; }
    }
}
