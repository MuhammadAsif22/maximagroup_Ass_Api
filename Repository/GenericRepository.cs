using eServicesApi.Data;
using eServicesApi.IRepository;
using Microsoft.EntityFrameworkCore;

namespace eServicesApi.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ServiceDbContext context;
        private DbSet<T> entities;
        public GenericRepository(ServiceDbContext _context)
        {
            context = _context;
            entities = context.Set<T>();
        }

       

        public async Task<T> Get(string Id)
        {
            return await entities.FindAsync(Id);
        }


        //Other all pending for future work
        public Task<IList<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(T entity)
        {
            throw new NotImplementedException();
        }
        public Task Delete(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
