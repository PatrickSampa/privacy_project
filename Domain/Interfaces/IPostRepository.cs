using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitectureDomain.Entities;

namespace CleanArchitectureDomain.Interfaces
{
  public interface IPostRepository : IBaseRepository<Post>
  {
    Task<Post?> GetByIdUser(Guid Id, CancellationToken cancellationToken);
  }
}
