
using CleanArchitectureDomain.Entities;
using CleanArchitectureDomain.Interfaces;
using CleanArchtecture.Persistence.Context;
using Microsoft.EntityFrameworkCore;


namespace CleanArchtecture.Persistence.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {

        protected readonly AppDbContext Context;

        public BaseRepository(AppDbContext _Context)
        {
            Context = _Context;
        }

        public void Create(T entity)
        {
            entity.DateCreated = DateTimeOffset.UtcNow;
            Context.Add(entity);
        }

        public void Delete(T entity)
        {
           entity.DateDeleted = DateTimeOffset.UtcNow;
            Context.Remove(entity);
        }

        public async Task<T?> Get(Guid id, CancellationToken cancellationToken)
        {
            return await Context.Set<T>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            
        }

        public async Task<List<T>> GetAll(CancellationToken cancellationToken)
        {
            return await Context.Set<T>().ToListAsync(cancellationToken);
        }

        public void Update(T entity)
        {
           entity.DateUpdated = DateTimeOffset.UtcNow;
            Context.Update(entity);
        }
    }
}
