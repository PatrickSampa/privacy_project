using CleanArchitectureDomain.Entities;
using CleanArchitectureDomain.Interfaces;
using CleanArchtecture.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchtecture.Persistence.Repositories
{
  public class UseRepository : BaseRepository<User>, IUserRepository
  {
    public UseRepository(AppDbContext _Context) : base(_Context)
    {
    }

    public async Task<User> GetByCpf(string cpf, CancellationToken cancellationToken)
    {
      return await Context.Set<User>().FirstOrDefaultAsync(x => x.Cpf == cpf, cancellationToken);
    }

    public async Task<User> GetByEmail(string email, CancellationToken cancellationToken)
    {
      return await Context.Set<User>().FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
    }
  }
}
