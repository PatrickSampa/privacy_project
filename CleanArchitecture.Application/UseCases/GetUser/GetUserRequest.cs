
using MediatR;

namespace CleanArchitecture.Application.UseCases.GetUser
{
  public sealed record GetUserRequest(Guid guid) : IRequest<GetUserResponse>;

}
