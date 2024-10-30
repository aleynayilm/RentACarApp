namespace RentACarApp.Api.Repositories.Contracts
{
    public interface IRepositoryManager
    {
        ICarRepository CarR { get; }
        void Save();
    }
}
