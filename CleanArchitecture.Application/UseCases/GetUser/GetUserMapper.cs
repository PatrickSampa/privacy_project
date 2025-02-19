
using AutoMapper;
using CleanArchitectureDomain.Entities;

namespace CleanArchitecture.Application.UseCases.GetUser
{
  public class GetUserMapper : Profile
  {
    public GetUserMapper()
    {
      CreateMap<User, GetUserResponse>();
    }
  }
}
