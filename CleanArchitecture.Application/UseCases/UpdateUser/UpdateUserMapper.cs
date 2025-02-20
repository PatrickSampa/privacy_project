
using AutoMapper;
using CleanArchitectureDomain.Entities;

namespace CleanArchitecture.Application.UseCases.UpdateUser
{
  public class UpdateUserMapper : Profile
  {
    public UpdateUserMapper()
    {
      CreateMap<User, UpdateUserResponse>();
      CreateMap<UpdateUserRequest, User>()
            .ForMember(dest => dest.Name, opt => opt.Condition(src => !string.IsNullOrWhiteSpace(src.Name)))
            .ForMember(dest => dest.Email, opt => opt.Condition(src => !string.IsNullOrWhiteSpace(src.Email)))
            .ForMember(dest => dest.Password, opt => opt.Condition(src => !string.IsNullOrWhiteSpace(src.Password)))
            .ForMember(dest => dest.Cpf, opt => opt.Condition(src => !string.IsNullOrWhiteSpace(src.Cpf)))
            .ForMember(dest => dest.Telephone, opt => opt.Condition(src => !string.IsNullOrWhiteSpace(src.Telephone)))
            .ForMember(dest => dest.AboutMe, opt => opt.Condition(src => !string.IsNullOrWhiteSpace(src.AboutMe)))
            .ForMember(dest => dest.AcountIsActive, opt => opt.Condition(src => src.AcountIsActive != null));
    }
  }
}
