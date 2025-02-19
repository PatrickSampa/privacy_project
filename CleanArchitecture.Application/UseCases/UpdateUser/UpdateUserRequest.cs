
using MediatR;

namespace CleanArchitecture.Application.UseCases.UpdateUser
{
  public record UpdateUserRequest(Guid Id, string Email, string Name, string Password, string Cpf, string Telephone) : IRequest<UpdateUserResponse>;
}
