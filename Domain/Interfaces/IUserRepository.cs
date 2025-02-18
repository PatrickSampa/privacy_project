using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitectureDomain.Entities;

namespace CleanArchitectureDomain.Interfaces
{
  public interface IUserRepository : IBaseRepository<User>
  {
    Task<User> GetByEmail(string email, CancellationToken cancellationToken);

    Task<User> GetByCpf(string cpf, CancellationToken cancellationToken);
  }
}
