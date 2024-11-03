namespace Repositories.Contracts
{
    public interface IRepositoryManager
    {
        ICarRepository CarR { get; }
        void Save();
    }
}
