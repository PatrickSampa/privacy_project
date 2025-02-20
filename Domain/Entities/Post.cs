using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureDomain.Entities
{
  public class Post : BaseEntity
  {
    public string? Title { get; set; }

    public User? User { get; set; }
  }
}
