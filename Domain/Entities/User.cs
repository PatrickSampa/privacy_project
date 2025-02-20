using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureDomain.Entities
{
  public sealed class User : BaseEntity
  {

    public string? Email { get; set; }

    public string? Name { get; set; }

    public string? Password { get; set; }

    public string? Cpf { get; set; }

    public string? Telephone { get; set; }

    public bool? AcountIsActive { get; set; }

    public string? AboutMe { get; set; }

    public Post? Post { get; set; }
  }
}
