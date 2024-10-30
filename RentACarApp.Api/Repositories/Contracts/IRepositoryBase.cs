using System.Linq.Expressions;

namespace RentACarApp.Api.Repositories.Contracts
{
    public interface IRepositoryBase<T>
    {
        //CRUD
        IQueryable<T> FindAll(bool trackChanges);
        IQueryable<T> FindByCondiition(Expression<Func<T, bool>> expression, bool trackChanges);
        void Create(T entity);
        void Update(T entity); 
        void Delete(T entity);
    }
}
