using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitectureDomain.Entities;

namespace CleanArchitecture.Application.UseCases.GetAllUser
{
  public sealed class GetAllUserMapper : Profile
  {
    public GetAllUserMapper()
    {
      CreateMap<User, GetAllUserResponse>();
    }
  }
}
