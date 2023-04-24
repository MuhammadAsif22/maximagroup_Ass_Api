using System.Linq.Expressions;

namespace eServicesApi.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IList<T>> GetAll();
        Task<T> Get(string Id);

        Task Insert(T entity);
        Task Update(T entity);
        Task Delete(Guid Id);
    }
}
