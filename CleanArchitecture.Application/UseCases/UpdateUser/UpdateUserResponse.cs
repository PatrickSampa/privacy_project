using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UseCases.UpdateUser
{
  public class UpdateUserResponse
  {
    public string? Email { get; set; }

    public string? Name { get; set; }

    public string? Cpf { get; set; }

    public string? Telephone { get; set; }
  }
}
