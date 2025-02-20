using CleanArchitectureDomain.Entities;
using CleanArchitectureDomain.Interfaces;
using CleanArchtecture.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchtecture.Persistence.Repositories
{
  public class PostRepository : BaseRepository<Post>, IPostRepository
  {
    public PostRepository(AppDbContext _Context) : base(_Context)
    {
    }

    public async Task<Post?> GetByIdUser(Guid Id, CancellationToken cancellationToken)
    {
      return await Context.Set<Post>().FirstOrDefaultAsync(x => x.User!.Id == Id, cancellationToken);
    }
  }
}
