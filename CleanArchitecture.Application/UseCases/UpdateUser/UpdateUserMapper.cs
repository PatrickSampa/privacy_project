
using AutoMapper;
using CleanArchitectureDomain.Entities;

namespace CleanArchitecture.Application.UseCases.UpdateUser
{
  public class UpdateUserMapper : Profile
  {
    public UpdateUserMapper()
    {
      CreateMap<User, UpdateUserResponse>();
      CreateMap<UpdateUserRequest, User>();
    }
  }
}
